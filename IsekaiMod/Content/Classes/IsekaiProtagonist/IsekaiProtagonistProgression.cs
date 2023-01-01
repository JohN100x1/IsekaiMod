using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist
{
    class IsekaiProtagonistProgression
    {
        public static void Add()
        {
            // Isekai Protagonist Features
            var IsekaiProtagonistProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistProficiencies");
            var EdgeLordProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "EdgeLordProficiencies");
            var GodEmperorProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GodEmperorProficiencies");
            var VillainProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "VillainProficiencies");
            var HeroProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "HeroProficiencies");

            var IsekaiProtagonistCantripsFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistCantripsFeature");
            var IsekaiProtagonistBonusFeatSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiProtagonistBonusFeatSelection");
            var SneakAttack = BlueprintTools.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");
            var PlotArmor = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "PlotArmor");
            var StartingWeaponSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "StartingWeaponSelection");
            var SummonHaremFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SummonHaremFeature");
            var UncannyDodge = BlueprintTools.GetBlueprint<BlueprintFeature>("3c08d842e802c3e4eb19d15496145709");
            var ImprovedUncannyDodge = BlueprintTools.GetBlueprint<BlueprintFeature>("485a18c05792521459c7d06c63128c79");
            var Evasion = BlueprintTools.GetBlueprint<BlueprintFeature>("576933720c440aa4d8d42b0c54b77e80");
            var ImprovedEvasion = BlueprintTools.GetBlueprint<BlueprintFeature>("ce96af454a6137d47b9c6a1e02e66803");
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
            var CripplingStrike = BlueprintTools.GetBlueprint<BlueprintFeature>("b696bd7cb38da194fa3404032483d1db");
            var DispellingAttack = BlueprintTools.GetBlueprint<BlueprintFeature>("1b92146b8a9830d4bb97ab694335fa7c");
            var CorruptAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "CorruptAuraFeature");
            var SecondFormFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondFormFeature");
            var GracefulCombat = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GracefulCombat");
            var TrueSmiteFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "TrueSmiteFeature");
            var TrueSmiteAdditionalUse = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "TrueSmiteAdditionalUse");
            var TrueMarkFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "TrueMarkFeature");
            var HerosPresenceFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "HerosPresenceFeature");
            var IsekaiChannelPositiveEnergyFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiChannelPositiveEnergyFeature");
            var IsekaiChannelNegativeEnergyFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiChannelNegativeEnergyFeature");

            var IsekaiPetSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiPetSelection");
            var OverpoweredAbilitySelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection");
            var OverpoweredAbilitySelection2 = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection2");
            var OverpoweredAbilitySelectionVillain = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelectionVillain");
            var BeachEpisodeSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BeachEpisodeSelection");
            var SpecialPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerSelection");

            var IsekaiProtagonistProgression = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "IsekaiProtagonistProgression", bp => {
                bp.SetName(IsekaiContext, "");
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
                Helpers.CreateLevelEntry(1, IsekaiProtagonistProficiencies, IsekaiProtagonistCantripsFeature, IsekaiProtagonistBonusFeatSelection, SneakAttack, OverpoweredAbilitySelection, PlotArmor, StartingWeaponSelection, IsekaiPetSelection),
                Helpers.CreateLevelEntry(2, IsekaiProtagonistBonusFeatSelection, UncannyDodge),
                Helpers.CreateLevelEntry(3, SneakAttack, IsekaiFighterTraining, Evasion, SpecialPowerSelection),
                Helpers.CreateLevelEntry(4, IsekaiProtagonistBonusFeatSelection),
                Helpers.CreateLevelEntry(5, SneakAttack, OverpoweredAbilitySelection2, ImprovedUncannyDodge),
                Helpers.CreateLevelEntry(6, IsekaiProtagonistBonusFeatSelection, SignatureMoveSelection),
                Helpers.CreateLevelEntry(7, SneakAttack, SpecialPowerSelection),
                Helpers.CreateLevelEntry(8, IsekaiProtagonistBonusFeatSelection, IsekaiFastMovement),
                Helpers.CreateLevelEntry(9, SneakAttack, SpecialPowerSelection, FriendlyAuraFeature),
                Helpers.CreateLevelEntry(10, IsekaiProtagonistBonusFeatSelection, OverpoweredAbilitySelection2, ImprovedEvasion),
                Helpers.CreateLevelEntry(11, SneakAttack, SpecialPowerSelection),
                Helpers.CreateLevelEntry(12, IsekaiProtagonistBonusFeatSelection, BeachEpisodeSelection),
                Helpers.CreateLevelEntry(13, SneakAttack, SpecialPowerSelection),
                Helpers.CreateLevelEntry(14, IsekaiProtagonistBonusFeatSelection),
                Helpers.CreateLevelEntry(15, SneakAttack, OverpoweredAbilitySelection2, OtherworldlyStamina, IsekaiQuickFooted),
                Helpers.CreateLevelEntry(16, IsekaiProtagonistBonusFeatSelection),
                Helpers.CreateLevelEntry(17, SneakAttack, SpecialPowerSelection, SummonHaremFeature),
                Helpers.CreateLevelEntry(18, IsekaiProtagonistBonusFeatSelection),
                Helpers.CreateLevelEntry(19, SneakAttack, SpecialPowerSelection),
                Helpers.CreateLevelEntry(20, IsekaiProtagonistBonusFeatSelection, OverpoweredAbilitySelection2, SecondReincarnation)
            };
            IsekaiProtagonistProgression.UIGroups = new UIGroup[] {
                Helpers.CreateUIGroup(SneakAttack, OverpoweredAbilitySelectionVillain),
                Helpers.CreateUIGroup(SupersonicCombat, ExtraStrike),
                Helpers.CreateUIGroup(SlayerStudyTargetFeature, SlayerSwiftStudyTargetFeature),
                Helpers.CreateUIGroup(GracefulCombat, TrueSmiteFeature, TrueSmiteAdditionalUse, TrueMarkFeature),
                Helpers.CreateUIGroup(NascentApotheosis, DivineArray, GodEmperorEnergySelection, AuraOfGoldenProtectionFeature, AuraOfMajestyFeature, SiphoningAuraFeature, GodlyVessel, CelestialRealmFeature, Godhood),
                Helpers.CreateUIGroup(OverpoweredAbilitySelection, OverpoweredAbilitySelection2, CorruptAuraFeature, SpecialPowerSelection, IsekaiChannelPositiveEnergyFeature, IsekaiChannelNegativeEnergyFeature, ArmorSaint, AuraOfDivineFuryFeature),
                Helpers.CreateUIGroup(PlotArmor, CripplingStrike, DispellingAttack, IsekaiFighterTraining, SignatureMoveSelection, SummonHaremFeature, FriendlyAuraFeature, DarkAuraFeature, BeachEpisodeSelection, OtherworldlyStamina, SecondReincarnation, SecondFormFeature, HerosPresenceFeature),
                Helpers.CreateUIGroup(IsekaiPetSelection, UncannyDodge, ImprovedUncannyDodge, Evasion, ImprovedEvasion, IsekaiFastMovement, EdgeLordFastMovement, IsekaiQuickFooted, VillainQuickFooted),
            };
            IsekaiProtagonistProgression.m_UIDeterminatorsGroup = new BlueprintFeatureBaseReference[] {
                HeroProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                EdgeLordProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                GodEmperorProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                VillainProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                IsekaiProtagonistProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                IsekaiProtagonistCantripsFeature.ToReference<BlueprintFeatureBaseReference>(),
                StartingWeaponSelection.ToReference<BlueprintFeatureBaseReference>(),
            };
            IsekaiProtagonistClass.SetProgression(IsekaiProtagonistProgression);
        }
    }
}
