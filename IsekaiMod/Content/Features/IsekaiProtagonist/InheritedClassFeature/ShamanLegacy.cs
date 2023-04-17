using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {

    internal class ShamanLegacy {
        public static BlueprintFeatureSelection shamanSpirit = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("00c8c566d1825dd4a871250f35285982");
        public static BlueprintFeatureSelection shamanHex = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("4223fe18c75d4d14787af196a04e14e7");

        private static BlueprintProgression prog;

        public static void Configure() {
            ShamanSelection.Configure();
            var shamanFeat = ShamanSelection.Get();
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "ShamanLegacy", bp => {
                bp.SetName(IsekaiContext, "Shaman Legacy - Spirit Beacons");
                bp.SetDescription(IsekaiContext, "As persons who originated from the other worlds, Spirit Beacons have an unique aura. \n" +
                    "This aura is particularly attractive to spirits, and they have learned to harness the power of these spirits by forming contracts with them. \n" +
                    "Despite their reliance on spirits, Spirit Beacons are not bound by the will of these supernatural beings. \n" +
                    "They are able to maintain their independence and make their own decisions, using the power of the spirits as a tool rather than being controlled by them.");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }
                };
                bp.LevelEntries = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, shamanFeat),
                    Helpers.CreateLevelEntry(2, shamanFeat),
                    Helpers.CreateLevelEntry(4, shamanFeat),
                    Helpers.CreateLevelEntry(8, shamanFeat),
                    Helpers.CreateLevelEntry(10, shamanFeat),
                    Helpers.CreateLevelEntry(12, shamanFeat),
                    Helpers.CreateLevelEntry(16, shamanFeat),
                    Helpers.CreateLevelEntry(18, shamanFeat),
            };
                bp.UIGroups = new UIGroup[] {
                    Helpers.CreateUIGroup(shamanFeat)
                };
            });
            LegacySelection.RegisterForFeat(prog);
            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Prohibit(prog);
            GodEmperorLegacySelection.Register(prog);
            HeroLegacySelection.Register(prog);
            MastermindLegacySelection.Register(prog);
            OverlordLegacySelection.Prohibit(prog);
        }

        public static void PatchProgression() {
            ShamanSelection.GetHex().m_AllFeatures = shamanHex.m_AllFeatures;

            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            BlueprintCharacterClassReference refClass = ClassTools.Classes.ShamanClass.ToReference<BlueprintCharacterClassReference>();
            PatchTools.PatchClassIntoFeatureOfReferenceClass(shamanSpirit, myClass, refClass);
            PatchTools.PatchClassIntoFeatureOfReferenceClass(shamanHex, myClass, refClass);
            ShamanSelection.GetSpirit().m_AllFeatures = shamanSpirit.m_AllFeatures;
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = WitchBaseLegacy.Get().ToReference<BlueprintFeatureReference>(); });
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "ShamanLegacy");
        }
    }

    internal class ShamanSelection {
        private static BlueprintFeatureSelection myfeat;
        private static BlueprintFeatureSelection isekaiHex;
        private static BlueprintFeatureSelection isekaiSpirit;

        public static void Configure() {
            isekaiHex = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiHexSelection", bp => {
                bp.SetName(IsekaiContext, "Hex");
                bp.SetDescription(IsekaiContext, "Gain an additional Hex.");
                bp.m_Icon = ShamanLegacy.shamanHex.m_Icon;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = ShamanLegacy.shamanHex.m_AllFeatures;
            });
            isekaiSpirit = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiSpiritSelection", bp => {
                bp.m_DisplayName = ShamanLegacy.shamanSpirit.m_DisplayName;
                bp.m_Description = ShamanLegacy.shamanSpirit.m_Description;
                bp.IgnorePrerequisites = true;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = ShamanLegacy.shamanSpirit.m_AllFeatures;
            });

            myfeat = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiShamanSelection", bp => {
                bp.SetName(IsekaiContext, "Spirit Blessing");
                bp.SetDescription(IsekaiContext, "As you grow so does your connection to the spirits and the power you derive from them. \nAllowing you to connect with more spirits or gain more powers from them.");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    isekaiHex.ToReference<BlueprintFeatureReference>(),
                    isekaiSpirit.ToReference<BlueprintFeatureReference>()
                };
            });
        }

        public static BlueprintFeatureSelection Get() {
            if (myfeat != null) return myfeat;
            return BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiShamanSelection");
        }

        public static BlueprintFeatureSelection GetHex() {
            if (isekaiHex != null) return isekaiHex;
            return BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiHexSelection");
        }

        public static BlueprintFeatureSelection GetSpirit() {
            if (isekaiSpirit != null) return isekaiSpirit;
            return BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiSpiritSelection");
        }
    }
}