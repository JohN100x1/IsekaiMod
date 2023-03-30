﻿using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord;
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
            var HeroProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "HeroProficiencies");
            var MastermindProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "MastermindProficiencies");
            var OverlordProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "OverlordProficiencies");

            var IsekaiProtagonistCantripsFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistCantripsFeature");
            var IsekaiProtagonistBonusFeatSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiProtagonistBonusFeatSelection");
            var PlotArmor = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "PlotArmor");
            var StartingWeaponSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "StartingWeaponSelection");
            var SummonHaremFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SummonHaremFeature");
            var OtherworldlyStamina = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "OtherworldlyStamina");
            var SignatureMoveSelection = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SignatureMoveSelection");
            var SignatureAbility = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SignatureAbility");
            var SignatureMove = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SignatureMove");
            var IsekaiFighterTraining = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiFighterTraining");
            var IsekaiFastMovement = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiFastMovement");
            var IsekaiQuickFooted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiQuickFooted");
            var MastermindQuickFooted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "MastermindQuickFooted");
            var OverlordQuickFooted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "OverlordQuickFooted");
            var IsekaiAuraSelection = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiAuraSelection");
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
            var ExtraStrike = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ExtraStrike");
            var CorruptAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "CorruptAuraFeature");
            var SecondFormFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondFormFeature");
            var GracefulCombat = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GracefulCombat");
            var HerosPresenceFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "HerosPresenceFeature");
            var IsekaiChannelPositiveEnergyFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiChannelPositiveEnergyFeature");
            var IsekaiChannelNegativeEnergyFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiChannelNegativeEnergyFeature");

            var IsekaiPetSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiPetSelection");
            var OverpoweredAbilitySelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection");
            var OverpoweredAbilitySelectionMastermind = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelectionMastermind");
            var OverpoweredAbilitySelectionOverlord = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelectionOverlord");
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
                Helpers.CreateLevelEntry(10, IsekaiProtagonistBonusFeatSelection, OverpoweredAbilitySelection, IsekaiAuraSelection),
                Helpers.CreateLevelEntry(11, SpecialPowerSelection),
                Helpers.CreateLevelEntry(12, IsekaiProtagonistBonusFeatSelection, BeachEpisodeSelection),
                Helpers.CreateLevelEntry(13, SpecialPowerSelection, OtherworldlyStamina),
                Helpers.CreateLevelEntry(14, IsekaiProtagonistBonusFeatSelection),
                Helpers.CreateLevelEntry(15, OverpoweredAbilitySelection, IsekaiQuickFooted),
                Helpers.CreateLevelEntry(16, IsekaiProtagonistBonusFeatSelection),
                Helpers.CreateLevelEntry(17, SpecialPowerSelection, SummonHaremFeature),
                Helpers.CreateLevelEntry(18, IsekaiProtagonistBonusFeatSelection),
                Helpers.CreateLevelEntry(19, SpecialPowerSelection),
                Helpers.CreateLevelEntry(20, IsekaiProtagonistBonusFeatSelection, OverpoweredAbilitySelection, SecondReincarnation)
            };
            IsekaiProtagonistProgression.UIGroups = new UIGroup[] {
                
                // Isekai UI group
                Helpers.CreateUIGroup(PlotArmor, IsekaiFighterTraining, SignatureAbility, SignatureMove, SignatureMoveSelection, SummonHaremFeature, IsekaiAuraSelection, DarkAuraFeature,
                IsekaiFastMovement, EdgeLordFastMovement, IsekaiQuickFooted, MastermindQuickFooted, OverlordQuickFooted, BeachEpisodeSelection, OtherworldlyStamina, SecondReincarnation),
                
                // Edge Lord UI group
                Helpers.CreateUIGroup(SupersonicCombat, ExtraStrike),
                
                // God Emperor UI group
                Helpers.CreateUIGroup(NascentApotheosis, DivineArray, GodEmperorEnergySelection, AuraOfGoldenProtectionFeature, AuraOfMajestyFeature, SiphoningAuraFeature, GodlyVessel, Godhood,
                
                // Hero UI group
                GracefulCombat, IsekaiChannelPositiveEnergyFeature, AuraOfDivineFuryFeature, CelestialRealmFeature, HerosPresenceFeature, ArmorSaint),
                
                // Mastermind UI group
                Helpers.CreateUIGroup(OverpoweredAbilitySelectionMastermind),

                // Overlord UI group
                Helpers.CreateUIGroup(OverpoweredAbilitySelectionOverlord),
                Helpers.CreateUIGroup(IsekaiChannelNegativeEnergyFeature, CorruptAuraFeature, SecondFormFeature),
                
                // OP ability and Special Power UI group
                Helpers.CreateUIGroup(OverpoweredAbilitySelection, SpecialPowerSelection),

                // Legacy UI groups
                Helpers.CreateUIGroup(LegacySelection.GetClassFeature()),
                Helpers.CreateUIGroup(HeroLegacySelection.getClassFeature()),
                Helpers.CreateUIGroup(MastermindLegacySelection.getClassFeature()),
                Helpers.CreateUIGroup(OverlordLegacySelection.getClassFeature()),
                Helpers.CreateUIGroup(EdgeLordLegacySelection.getClassFeature()),
            };
            IsekaiProtagonistProgression.m_UIDeterminatorsGroup = new BlueprintFeatureBaseReference[] {
                IsekaiProtagonistCantripsFeature.ToReference<BlueprintFeatureBaseReference>(),
                StartingWeaponSelection.ToReference<BlueprintFeatureBaseReference>(),
                IsekaiPetSelection.ToReference<BlueprintFeatureBaseReference>(),
                IsekaiProtagonistProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                EdgeLordProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                GodEmperorProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                HeroProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                MastermindProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                OverlordProficiencies.ToReference<BlueprintFeatureBaseReference>(),
            };
            IsekaiProtagonistClass.SetProgression(IsekaiProtagonistProgression);
        }
    }
}