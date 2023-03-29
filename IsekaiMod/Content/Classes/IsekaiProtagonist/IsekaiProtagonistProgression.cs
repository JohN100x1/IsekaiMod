using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist {

    internal class IsekaiProtagonistProgression {

        public static void Add() {
            // Isekai Protagonist Features
            var IsekaiProtagonistProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistProficiencies");
            var EdgeLordProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "EdgeLordProficiencies");
            var GodEmperorProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GodEmperorProficiencies");
            var VillainProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "VillainProficiencies");
            var HeroProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "HeroProficiencies");

            var IsekaiProtagonistCantripsFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistCantripsFeature");
            var IsekaiProtagonistBonusFeatSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiProtagonistBonusFeatSelection");
            var PlotArmor = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "PlotArmor");
            var StartingWeaponSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "StartingWeaponSelection");
            var SummonHaremFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SummonHaremFeature");
            var OtherworldlyStamina = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "OtherworldlyStamina");
            var SignatureMoveSelection = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SignatureMoveSelection");
            var IsekaiFighterTraining = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiFighterTraining");
            var IsekaiFastMovement = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiFastMovement");
            var IsekaiQuickFooted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiQuickFooted");
            var VillainQuickFooted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "VillainQuickFooted");
            var FriendlyAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "FriendlyAuraFeature");
            var DarkAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DarkAuraFeature");
            var SecondReincarnation = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondReincarnation");
            var CelestialRealmFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "CelestialRealmFeature");
            var Godhood = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "Godhood");
            var GodlyVessel = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GodlyVessel");
            var NascentApotheosis = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "NascentApotheosis");
            var DivineArray = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DivineArray");
            var GodEmperorEnergySelection = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GodEmperorEnergySelection");
            var AuraOfGoldenProtectionFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "AuraOfGoldenProtectionFeature");
            var AuraOfMajestyFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "AuraOfMajestyFeature");
            var SiphoningAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SiphoningAuraFeature");
            var ArmorSaint = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ArmorSaint");
            var AuraOfDivineFuryFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "AuraOfDivineFuryFeature");
            var SupersonicCombat = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SupersonicCombat");
            var EdgeLordFastMovement = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "EdgeLordFastMovement");
            var SlayerStudyTargetFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("09bdd9445ac38044389476689ae8d5a1");
            var SlayerSwiftStudyTargetFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("40d4f55a5ac0e4f469d67d36c0dfc40b");
            var ExtraStrike = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ExtraStrike");
            var CorruptAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "CorruptAuraFeature");
            var SecondFormFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondFormFeature");
            var GracefulCombat = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GracefulCombat");
            var HerosPresenceFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "HerosPresenceFeature");
            var IsekaiChannelPositiveEnergyFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiChannelPositiveEnergyFeature");
            var IsekaiChannelNegativeEnergyFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiChannelNegativeEnergyFeature");

            var IsekaiPetSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiPetSelection");
            var OverpoweredAbilitySelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection");
            var OverpoweredAbilitySelectionVillain = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelectionVillain");
            var BeachEpisodeSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BeachEpisodeSelection");
            var SpecialPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerSelection");

            var IsekaiProtagonistProgression = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "IsekaiProtagonistProgression", bp => {
                bp.SetName(StaticReferences.Strings.Null);
                bp.SetDescription(IsekaiContext, "Isekai protagonists are otherworldly entities who have been reincarnated into the world of Golarion with extraordinary abilities. "
                    + "As their story progresses, they gain more unexplained and overpowered abilities to overcome every challenge they face.");
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = true;
                bp.m_FeaturesRankIncrease = null;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }
                };
            });
            IsekaiProtagonistProgression.LevelEntries = new LevelEntry[20] {
                Helpers.CreateLevelEntry(1, IsekaiProtagonistProficiencies, IsekaiProtagonistCantripsFeature, IsekaiProtagonistBonusFeatSelection, OverpoweredAbilitySelection, PlotArmor, StartingWeaponSelection, IsekaiPetSelection, LegacySelection.GetClassFeature()),
                Helpers.CreateLevelEntry(2, IsekaiProtagonistBonusFeatSelection),
                Helpers.CreateLevelEntry(3, IsekaiFighterTraining, SpecialPowerSelection),
                Helpers.CreateLevelEntry(4, IsekaiProtagonistBonusFeatSelection),
                Helpers.CreateLevelEntry(5, OverpoweredAbilitySelection),
                Helpers.CreateLevelEntry(6, IsekaiProtagonistBonusFeatSelection, SignatureMoveSelection),
                Helpers.CreateLevelEntry(7, SpecialPowerSelection),
                Helpers.CreateLevelEntry(8, IsekaiProtagonistBonusFeatSelection, IsekaiFastMovement),
                Helpers.CreateLevelEntry(9, SpecialPowerSelection),
                Helpers.CreateLevelEntry(10, IsekaiProtagonistBonusFeatSelection, OverpoweredAbilitySelection, FriendlyAuraFeature),
                Helpers.CreateLevelEntry(11, SpecialPowerSelection),
                Helpers.CreateLevelEntry(12, IsekaiProtagonistBonusFeatSelection, BeachEpisodeSelection),
                Helpers.CreateLevelEntry(13, SpecialPowerSelection),
                Helpers.CreateLevelEntry(14, IsekaiProtagonistBonusFeatSelection),
                Helpers.CreateLevelEntry(15, OverpoweredAbilitySelection, OtherworldlyStamina),
                Helpers.CreateLevelEntry(16, IsekaiProtagonistBonusFeatSelection, IsekaiQuickFooted),
                Helpers.CreateLevelEntry(17, SpecialPowerSelection, SummonHaremFeature),
                Helpers.CreateLevelEntry(18, IsekaiProtagonistBonusFeatSelection),
                Helpers.CreateLevelEntry(19, SpecialPowerSelection),
                Helpers.CreateLevelEntry(20, IsekaiProtagonistBonusFeatSelection, OverpoweredAbilitySelection, SecondReincarnation)
            };
            IsekaiProtagonistProgression.UIGroups = new UIGroup[] {
                
                // Isekai UI group
                Helpers.CreateUIGroup(PlotArmor, IsekaiFighterTraining, SignatureMoveSelection, SummonHaremFeature, FriendlyAuraFeature, DarkAuraFeature,
                IsekaiFastMovement, EdgeLordFastMovement, IsekaiQuickFooted, VillainQuickFooted, BeachEpisodeSelection, OtherworldlyStamina, SecondReincarnation),
                
                // Edge Lord UI group
                Helpers.CreateUIGroup(SupersonicCombat, ExtraStrike),
                
                // God Emperor UI group
                Helpers.CreateUIGroup(NascentApotheosis, DivineArray, GodEmperorEnergySelection, AuraOfGoldenProtectionFeature, AuraOfMajestyFeature, SiphoningAuraFeature, GodlyVessel, Godhood,
                
                // Hero UI group
                GracefulCombat, IsekaiChannelPositiveEnergyFeature, AuraOfDivineFuryFeature, CelestialRealmFeature, HerosPresenceFeature, ArmorSaint),
                
                // Villain UI group
                Helpers.CreateUIGroup(OverpoweredAbilitySelectionVillain,  IsekaiChannelNegativeEnergyFeature, CorruptAuraFeature, SecondFormFeature),
                Helpers.CreateUIGroup(SlayerStudyTargetFeature, SlayerSwiftStudyTargetFeature),
                
                // OP ability and Special Power UI group
                Helpers.CreateUIGroup(OverpoweredAbilitySelection, SpecialPowerSelection),

                // Legacy UI groups
                Helpers.CreateUIGroup(LegacySelection.GetClassFeature()),
                Helpers.CreateUIGroup(HeroLegacySelection.getClassFeature()),
                Helpers.CreateUIGroup(VillainLegacySelection.getClassFeature()),
                Helpers.CreateUIGroup(EdgeLordLegacySelection.getClassFeature())
            };
            IsekaiProtagonistProgression.m_UIDeterminatorsGroup = new BlueprintFeatureBaseReference[] {
                HeroProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                EdgeLordProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                GodEmperorProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                VillainProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                IsekaiProtagonistProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                IsekaiProtagonistCantripsFeature.ToReference<BlueprintFeatureBaseReference>(),
                StartingWeaponSelection.ToReference<BlueprintFeatureBaseReference>(),
                IsekaiPetSelection.ToReference<BlueprintFeatureBaseReference>()
            };
            IsekaiProtagonistClass.SetProgression(IsekaiProtagonistProgression);
        }
    }
}