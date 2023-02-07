using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class SorcererLegacy {
        public static void configure() {
            ExtraBloodlineSelection.Configure();
            var ExtraSelection = ExtraBloodlineSelection.Get();
            var prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "SorcererLegacyProgression", bp => {
                bp.SetName(IsekaiContext, "Sorcerer Legacy - Chimera");
                bp.SetDescription(IsekaiContext, "Their otherworldly knowledge and point of view allows Chimeras to imbue themselves with different bloodlines in order to gain power and strength. \nThe Chimera is constantly seeking out new sources of power, and their ability to absorb and incorporate these different bloodlines allows them to become truly formidable foes. \nHowever, their constant experimentation with bloodlines can also lead to confusion and uncertainty about their own heritage and identity, as their original ancestry becomes harder to discern over time.");
                bp.GiveFeaturesForPreviousLevels = false;
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }

                };
                //do not place the bloodline at level 1, when inside a progression it does not like that and makes all options invalid, strangely for oracle it works and that is a progression too...
                bp.LevelEntries = new LevelEntry[] {
                    Helpers.CreateLevelEntry (1, ExtraSelection ),
                    Helpers.CreateLevelEntry(3, ExtraSelection),
                    Helpers.CreateLevelEntry(6, ExtraSelection),
                    Helpers.CreateLevelEntry(9, ExtraSelection),
                    Helpers.CreateLevelEntry(12, ExtraSelection),
                    Helpers.CreateLevelEntry(15, ExtraSelection),
                    Helpers.CreateLevelEntry(18, ExtraSelection),

                };
                bp.UIGroups = new UIGroup[] {
                    Helpers.CreateUIGroup( ExtraSelection),
                };
            });
            LegacySelection.getClassFeature().AddFeatures(prog);
            LegacySelection.getOverwhelmingFeature().AddFeatures(prog);
            VillainLegacySelection.getClassFeature().AddFeatures(prog);

        }
        public static void PatchSorcererBloodlines() {
            IsekaiContext.Logger.Log("trying to patch bloodlines:");
            BlueprintCharacterClass myClass = IsekaiProtagonistClass.Get();
            foreach (BlueprintProgression prog in StaticReferences.SorcererBloodlineSelection.m_AllFeatures) {
                prog.GiveFeaturesForPreviousLevels = true;
                prog.AddClass(myClass);
                //check all levelentries of the progression and their features
                foreach (var levelItem in prog.LevelEntries) {
                    foreach (var potentialFeature in levelItem.m_Features) {
                        if (potentialFeature.Get() is BlueprintFeature feature) {
                            var mySet = new HashSet<SpellReference>();
                            foreach (var component in feature.Components) {
                                //if so are any of its components adding known spells
                                if (component is AddKnownSpell asSpell) {
                                    //don't re add spells already added for my class
                                    if (asSpell.m_CharacterClass != myClass.ToReference<BlueprintCharacterClassReference>()) {
                                        mySet.Add(new SpellReference(asSpell.SpellLevel, asSpell.m_Spell));
                                    }
                                }
                            }
                            foreach (var spellReference in mySet) {
                                feature.AddComponent<AddKnownSpell>(c => {
                                    c.m_Spell = spellReference.value;
                                    c.SpellLevel = spellReference.level;
                                    c.m_CharacterClass = myClass.ToReference<BlueprintCharacterClassReference>();

                                });
                            }
                        }

                    }
                }
            }
        }
    }

    internal class ExtraBloodlineSelection {
        private static BlueprintFeatureSelection IsekaiSorcererSelection;
        public static void Configure() {
            var IsekaiBloodlineSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiBloodlineSelection", bp => {
                bp.SetName(IsekaiContext, "Bloodline");
                bp.SetDescription(IsekaiContext, "You can pick additional bloodlines as your chimera blood becomes stronger.");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.IgnorePrerequisites = true;
                //bp.Group = FeatureGroup.BloodLine;
                bp.m_AllFeatures = StaticReferences.SorcererBloodlineSelection.m_AllFeatures;
            });
            IsekaiSorcererSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiSorcererSelection", bp => {
                bp.SetName(IsekaiContext, "Bloodline Evolution");
                bp.SetDescription(IsekaiContext, "As your chimera blood evolves you can pick a new bloodline feat or a new bloodline.");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                //bp.Group = FeatureGroup.BloodLine;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    IsekaiBloodlineSelection.ToReference<BlueprintFeatureReference>(),
                    StaticReferences.SorcererFeatSelection.ToReference<BlueprintFeatureReference>(),
                };
            });

        }
        public static BlueprintFeatureSelection Get() {
            if (IsekaiSorcererSelection != null) return IsekaiSorcererSelection;
            return BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiSorcererSelection");
        }
        public static BlueprintFeatureReference GetReference() {
            return Get().ToReference<BlueprintFeatureReference>();
        }
    }
}
