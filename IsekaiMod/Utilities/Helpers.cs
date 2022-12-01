using JetBrains.Annotations;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.Localization.Shared;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using IsekaiMod.Config;
using Kingmaker.Blueprints.Root;
using IsekaiMod.Extensions;
using IsekaiMod.Localization;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.DialogSystem;
using Kingmaker.UnitLogic.Alignments;

namespace IsekaiMod.Utilities
{
    public static class Helpers
    {
        public static void RegisterClass(BlueprintCharacterClass ClassToRegister)
        {
            ProgressionRoot progression = ResourcesLibrary.GetRoot().Progression;
            List<BlueprintCharacterClassReference> list = ((IEnumerable<BlueprintCharacterClassReference>)progression.m_CharacterClasses).ToList();
            list.Add(ClassToRegister.ToReference<BlueprintCharacterClassReference>());
            list.Sort((x, y) =>
            {
                BlueprintCharacterClass blueprint1 = ResourcesLibrary.TryGetBlueprint<BlueprintCharacterClass>(x.guid);
                BlueprintCharacterClass blueprint2 = ResourcesLibrary.TryGetBlueprint<BlueprintCharacterClass>(y.guid);
                return blueprint1 == null || blueprint2 == null ? 1 : (blueprint1.PrestigeClass == blueprint2.PrestigeClass ? blueprint1.NameSafe().CompareTo(blueprint2.NameSafe()) : (blueprint1.PrestigeClass ? 1 : -1));
            });
            progression.m_CharacterClasses = list.ToArray();
            if (!ClassToRegister.IsArcaneCaster && !ClassToRegister.IsDivineCaster)
                return;
            BlueprintProgression.ClassWithLevel classWithLevel = ClassToClassWithLevel(ClassToRegister);
            BlueprintProgression blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintProgression>("fe9220cdc16e5f444a84d85d5fa8e3d5");
            blueprint.m_Classes = blueprint.m_Classes.AppendToArray(new BlueprintProgression.ClassWithLevel[1]
            {
                   classWithLevel
            });
        }
        public static BlueprintProgression.ClassWithLevel ClassToClassWithLevel(BlueprintCharacterClass orig, int addLevel = 0)
        {
            return new BlueprintProgression.ClassWithLevel()
            {
                m_Class = orig.ToReference<BlueprintCharacterClassReference>(),
                AdditionalLevel = addLevel
            };
        }
        public static T Create<T>(Action<T> init = null) where T : new()
        {
            var result = new T();
            init?.Invoke(result);
            return result;
        }
        public static T CreateBlueprint<T>(Action<T> init = null) where T : new()
        {
            var result = new T();
            init?.Invoke(result);
            return result;
        }

        public static T CreateBlueprint<T>([NotNull] string name, Action<T> init = null) where T : SimpleBlueprint, new()
        {
            var result = new T
            {
                name = name,
                AssetGuid = ModSettings.Blueprints.GetGUID(name)
            };
            Resources.AddBlueprint(result);
            init?.Invoke(result);
            return result;
        }

        public static BlueprintBuff CreateBuff(string name, Action<BlueprintBuff> init = null)
        {
            var result = CreateBlueprint<BlueprintBuff>(name, bp => {
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            init?.Invoke(result);
            return result;
        }

        public static BlueprintFeature CreateFeature(string name, Action<BlueprintFeature> init = null)
        {
            var result = CreateBlueprint<BlueprintFeature>(name, bp => {
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            init?.Invoke(result);
            return result;
        }

        public static BlueprintAnswer CreateAnswer(string name, Action<BlueprintAnswer> init = null)
        {
            var result = CreateBlueprint<BlueprintAnswer>(name, bp => {
                bp.NextCue = new CueSelection()
                {
                    Cues = new List<BlueprintCueBaseReference>(),
                    Strategy = Strategy.First
                };
                bp.ShowOnce = false;
                bp.ShowOnceCurrentDialog = false;
                bp.ShowCheck = new ShowCheck() { Type = StatType.Unknown, DC = 0 };
                bp.Experience = DialogExperience.NoExperience;
                bp.DebugMode = false;
                bp.CharacterSelection = new CharacterSelection() { SelectionType = CharacterSelection.Type.Clear, ComparisonStats = new StatType[0] };
                bp.ShowConditions = ActionFlow.EmptyCondition();
                bp.SelectConditions = ActionFlow.EmptyCondition();
                bp.RequireValidCue = false;
                bp.AddToHistory = true;
                bp.OnSelect = ActionFlow.DoNothing();
                bp.FakeChecks = new CheckData[0];
                bp.AlignmentShift = new AlignmentShift() { Direction = AlignmentShiftDirection.TrueNeutral, Value = 0, Description = new LocalizedString() };
            });
            init?.Invoke(result);
            return result;
        }

        public static LevelEntry LevelEntry(int level, BlueprintFeatureBase feature)
        {
            LevelEntry levelEntry = new()
            {
                Level = level
            };
            levelEntry.Features.Add(feature);
            return levelEntry;
        }

        public static LevelEntry LevelEntry(int level, params BlueprintFeatureBase[] features)
        {
            return CreateLevelEntry(level, features);
        }

        public static LevelEntry CreateLevelEntry(int level, IEnumerable<BlueprintFeatureBase> features)
        {
            LevelEntry levelEntry = new()
            {
                Level = level
            };
            features.ForEach(f => levelEntry.Features.Add(f));
            return levelEntry;
        }

        public static UIGroup CreateUIGroup(params BlueprintFeatureBase[] features) => CreateUIGroup((IEnumerable<BlueprintFeatureBase>)features);

        public static UIGroup CreateUIGroup(IEnumerable<BlueprintFeatureBase> features)
        {
            UIGroup uiGroup = new();
            BlueprintFeatureBaseReference[] featureBaseReferenceArray = new BlueprintFeatureBaseReference[features.Count()];
            for (int index = 0; index < ((IEnumerable<BlueprintFeatureBaseReference>)featureBaseReferenceArray).Count(); ++index)
                featureBaseReferenceArray[index] = features.ElementAt(index).ToReference<BlueprintFeatureBaseReference>();
            uiGroup.m_Features.AddRange(featureBaseReferenceArray);
            return uiGroup;
        }

        public static UIGroup[] CreateUIGroups(params BlueprintFeatureBase[] features) => CreateUIGroups((IEnumerable<BlueprintFeatureBase>)features);

        public static UIGroup[] CreateUIGroups(IEnumerable<BlueprintFeatureBase> features)
        {
            UIGroup uiGroup = new();
            BlueprintFeatureBaseReference[] featureBaseReferenceArray = new BlueprintFeatureBaseReference[features.Count()];
            for (int index = 0; index < ((IEnumerable<BlueprintFeatureBaseReference>)featureBaseReferenceArray).Count(); ++index)
                featureBaseReferenceArray[index] = features.ElementAt(index).ToReference<BlueprintFeatureBaseReference>();
            uiGroup.m_Features.AddRange(featureBaseReferenceArray);
            return new UIGroup[1] { uiGroup };
        }

        public static ContextValue CreateContextValueRank(AbilityRankType value = AbilityRankType.Default) => value.CreateContextValue();
        public static ContextValue CreateContextValue(this AbilityRankType value)
        {
            return new ContextValue() { ValueType = ContextValueType.Rank, ValueRank = value };
        }
        public static ContextValue CreateContextValue(this AbilitySharedValue value)
        {
            return new ContextValue() { ValueType = ContextValueType.Shared, ValueShared = value };
        }
        public static ActionList CreateActionList(params GameAction[] actions)
        {
            if (actions == null || actions.Length == 1 && actions[0] == null) actions = Array.Empty<GameAction>();
            return new ActionList() { Actions = actions };
        }
        public static LocalizedString CreateString(string simpleName, string text, Locale locale = Locale.enGB, bool shouldProcess = true)
        {
            // See if we used the text previously.
            // (It's common for many features to use the same localized text.
            // In that case, we reuse the old entry instead of making a new one.)
            string strippedText = text.StripHTML().StripEncyclopediaTags();
            if (ModSettings.ModLocalizationPack.TryGetText(strippedText, out MultiLocalizationPack.MultiLocaleString multiLocalized))
            {
                return multiLocalized.LocalizedString;
            }
            multiLocalized = new MultiLocalizationPack.MultiLocaleString(simpleName, strippedText, shouldProcess, locale);
            Main.LogDebug($"WARNING: Generated New Localizaed String: {multiLocalized.Key}:{multiLocalized.SimpleName}");
            ModSettings.ModLocalizationPack.AddString(multiLocalized);
            return multiLocalized.LocalizedString;
        }
        public static LocalizedString CreateString(string simpleName, string text,  bool shouldProcess)
        {
            return CreateString(simpleName, text, Locale.enGB, shouldProcess);
        }
        public static FastRef<T, S> CreateFieldSetter<T, S>(string name)
        {
            return new FastRef<T, S>(HarmonyLib.AccessTools.FieldRefAccess<T, S>(HarmonyLib.AccessTools.Field(typeof(T), name)));
            //return new FastSetter<T, S>(HarmonyLib.FastAccess.CreateSetterHandler<T, S>(HarmonyLib.AccessTools.Field(typeof(T), name)));
        }
        public static FastRef<T, S> CreateFieldGetter<T, S>(string name)
        {
            return new FastRef<T, S>(HarmonyLib.AccessTools.FieldRefAccess<T, S>(HarmonyLib.AccessTools.Field(typeof(T), name)));
            //return new FastGetter<T, S>(HarmonyLib.FastAccess.CreateGetterHandler<T, S>(HarmonyLib.AccessTools.Field(typeof(T), name)));
        }
        public static void SetField(object obj, string name, object value)
        {
            HarmonyLib.AccessTools.Field(obj.GetType(), name).SetValue(obj, value);
        }
        public static object GetField(object obj, string name)
        {
            return HarmonyLib.AccessTools.Field(obj.GetType(), name).GetValue(obj);
        }
        // Parses the lowest 64 bits of the Guid (which corresponds to the last 16 characters).
        static ulong ParseGuidLow(string id) => ulong.Parse(id.Substring(id.Length - 16), NumberStyles.HexNumber);
        // Parses the high 64 bits of the Guid (which corresponds to the first 16 characters).
        static ulong ParseGuidHigh(string id) => ulong.Parse(id.Substring(0, id.Length - 16), NumberStyles.HexNumber);
        public static string MergeIds(string guid1, string guid2, string guid3 = null)
        {
            // Parse into low/high 64-bit numbers, and then xor the two halves.
            ulong low = ParseGuidLow(guid1);
            ulong high = ParseGuidHigh(guid1);

            low ^= ParseGuidLow(guid2);
            high ^= ParseGuidHigh(guid2);

            if (guid3 != null)
            {
                low ^= ParseGuidLow(guid3);
                high ^= ParseGuidHigh(guid3);
            }
            return high.ToString("x16") + low.ToString("x16");
        }
        public static ContextRankConfig CreateContextRankConfig(
            ContextRankBaseValueType baseValueType = ContextRankBaseValueType.CasterLevel,
            ContextRankProgression progression = ContextRankProgression.AsIs,
            AbilityRankType type = AbilityRankType.Default,
            int? min = null, int? max = null, int startLevel = 0, int stepLevel = 0,
            bool exceptClasses = false, StatType stat = StatType.Unknown,
            BlueprintUnitProperty customProperty = null,
            BlueprintCharacterClass[] classes = null, BlueprintArchetype[] archetypes = null, BlueprintArchetype archetype = null,
            BlueprintFeature feature = null, BlueprintFeature[] featureList = null,
            (int, int)[] customProgression = null)
        {
            var config = new ContextRankConfig()
            {
                m_Type = type,
                m_BaseValueType = baseValueType,
                m_Progression = progression,
                m_UseMin = min.HasValue,
                m_Min = min.GetValueOrDefault(),
                m_UseMax = max.HasValue,
                m_Max = max.GetValueOrDefault(),
                m_StartLevel = startLevel,
                m_StepLevel = stepLevel,
                m_Feature = feature.ToReference<BlueprintFeatureReference>(),
                m_ExceptClasses = exceptClasses,
                m_CustomProperty = customProperty.ToReference<BlueprintUnitPropertyReference>(),
                m_Stat = stat,
                m_Class = classes == null ? Array.Empty<BlueprintCharacterClassReference>() : classes.Select(c => c.ToReference<BlueprintCharacterClassReference>()).ToArray(),
                Archetype = archetype.ToReference<BlueprintArchetypeReference>(),
                m_AdditionalArchetypes = archetypes == null ? Array.Empty<BlueprintArchetypeReference>() : archetypes.Select(c => c.ToReference<BlueprintArchetypeReference>()).ToArray(),
                m_FeatureList = featureList == null ? Array.Empty<BlueprintFeatureReference>() : featureList.Select(c => c.ToReference<BlueprintFeatureReference>()).ToArray()
            };
            return config;
        }
        public static ContextRankConfig CreateContextRankConfig(Action<ContextRankConfig> init)
        {
            var config = CreateContextRankConfig();
            init?.Invoke(config);
            return config;
        }

        private class ObjectDeepCopier
        {
            private class ArrayTraverse
            {
                public int[] Position;
                private int[] maxLengths;

                public ArrayTraverse(Array array)
                {
                    maxLengths = new int[array.Rank];
                    for (int i = 0; i < array.Rank; ++i)
                    {
                        maxLengths[i] = array.GetLength(i) - 1;
                    }
                    Position = new int[array.Rank];
                }

                public bool Step()
                {
                    for (int i = 0; i < Position.Length; ++i)
                    {
                        if (Position[i] < maxLengths[i])
                        {
                            Position[i]++;
                            for (int j = 0; j < i; j++)
                            {
                                Position[j] = 0;
                            }
                            return true;
                        }
                    }
                    return false;
                }
            }
            private class ReferenceEqualityComparer : EqualityComparer<object>
            {
                public override bool Equals(object x, object y)
                {
                    return ReferenceEquals(x, y);
                }
                public override int GetHashCode(object obj)
                {
                    if (obj == null) return 0;
                    if (obj is WeakResourceLink wrl)
                    {
                        if (wrl.AssetId == null)
                        {
                            return "WeakResourceLink".GetHashCode();
                        }
                        else
                        {
                            return wrl.GetHashCode();
                        }
                    }
                    return obj.GetHashCode();
                }
            }
            private static readonly MethodInfo CloneMethod = typeof(object).GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);

            public static bool IsPrimitive(Type type)
            {
                if (type == typeof(string)) return true;
                return type.IsValueType & type.IsPrimitive;
            }
            public static object Clone(object originalObject)
            {
                return InternalCopy(originalObject, new Dictionary<object, object>(new ReferenceEqualityComparer()));
            }
            private static object InternalCopy(object originalObject, IDictionary<object, object> visited)
            {
                if (originalObject == null) return null;
                var typeToReflect = originalObject.GetType();
                if (IsPrimitive(typeToReflect)) return originalObject;
                if (originalObject is BlueprintReferenceBase) return originalObject;
                if (visited.ContainsKey(originalObject)) return visited[originalObject];
                if (typeof(Delegate).IsAssignableFrom(typeToReflect)) return null;
                var cloneObject = CloneMethod.Invoke(originalObject, null);
                if (typeToReflect.IsArray)
                {
                    var arrayType = typeToReflect.GetElementType();
                    if (IsPrimitive(arrayType) == false)
                    {
                        var clonedArray = (Array)cloneObject;
                        ForEach(clonedArray, (array, indices) => array.SetValue(InternalCopy(clonedArray.GetValue(indices), visited), indices));
                    }

                }
                visited.Add(originalObject, cloneObject);
                CopyFields(originalObject, visited, cloneObject, typeToReflect);
                RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect);
                return cloneObject;

                void ForEach(Array array, Action<Array, int[]> action)
                {
                    if (array.LongLength == 0) return;
                    var walker = new ArrayTraverse(array);
                    do action(array, walker.Position);
                    while (walker.Step());
                }
            }
            private static void RecursiveCopyBaseTypePrivateFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect)
            {
                if (typeToReflect.BaseType != null)
                {
                    RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect.BaseType);
                    CopyFields(originalObject, visited, cloneObject, typeToReflect.BaseType, BindingFlags.Instance | BindingFlags.NonPublic, info => info.IsPrivate);
                }
            }
            private static void CopyFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy, Func<FieldInfo, bool> filter = null)
            {
                foreach (FieldInfo fieldInfo in typeToReflect.GetFields(bindingFlags))
                {
                    if (filter != null && filter(fieldInfo) == false) continue;
                    if (IsPrimitive(fieldInfo.FieldType)) continue;
                    var originalFieldValue = fieldInfo.GetValue(originalObject);
                    var clonedFieldValue = InternalCopy(originalFieldValue, visited);
                    fieldInfo.SetValue(cloneObject, clonedFieldValue);
                }
            }
        }
        public delegate ref S FastRef<T, S>(T source = default);
        public delegate void FastSetter<T, S>(T source, S value);
        public delegate S FastGetter<T, S>(T source);
        public delegate object FastInvoke(object target, params object[] paramters);
    }
}
