using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
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

            // TODO: add feature/ability that uses ICON_EXCALIBUR.png

            // Isekai Protagonist
            var IsekaiProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProficiencies");
            var IsekaiCantrips = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiCantrips");
            BlueprintFeatureSelection IsekaiBonusFeatSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiBonusFeatSelection");
            BlueprintFeatureSelection IsekaiPetSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiPetSelection");
            BlueprintFeatureSelection StartingWeaponSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "StartingWeaponSelection");
            BlueprintFeatureSelection SecretPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SecretPowerSelection");
            BlueprintFeatureSelection BeachEpisodeSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BeachEpisodeSelection");
            BlueprintFeatureSelection HaxSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "HaxSelection");
            BlueprintFeatureSelection SignatureMoveSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SignatureMoveSelection");
            BlueprintFeatureSelection SignatureMoveBonusSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SignatureMoveBonusSelection");
            BlueprintFeatureSelection IsekaiAuraSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiAuraSelection");
            var PlotArmor = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "PlotArmor");
            var SummonHaremFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SummonHaremFeature");
            var OtherworldlyStamina = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "OtherworldlyStamina");
            var SignatureAbility = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SignatureAbility");
            var IsekaiFighterTraining = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiFighterTraining");
            var Afterimage = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "Afterimage");
            var IsekaiQuickFooted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiQuickFooted");
            var ReleaseEnergy = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ReleaseEnergy");
            var Gifted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "Gifted");
            var DarkAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DarkAuraFeature");
            var DivineAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DivineAuraFeature");
            var SecondReincarnation = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondReincarnation");

            // Edge Lord
            var EdgeLordProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "EdgeLordProficiencies");
            var SupersonicCombat = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SupersonicCombat");
            var ExtraStrike = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ExtraStrike");
            var ChuunibyouActualisationFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ChuunibyouActualisationFeature");

            // God Emperor
            BlueprintFeatureSelection GodEmperorEnergySelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "GodEmperorEnergySelection");
            BlueprintFeatureSelection GodEmperorAuraSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "GodEmperorAuraSelection");
            BlueprintFeatureSelection EnergyCondensationSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "EnergyCondensationSelection");
            BlueprintFeatureSelection BarrierSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BarrierSelection");
            BlueprintFeatureSelection BodyMindAlterSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BodyMindAlterSelection");
            BlueprintFeatureSelection PathSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "PathSelection");
            BlueprintFeatureSelection RealmSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "RealmSelection");
            var GodEmperorProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GodEmperorProficiencies");
            var GodEmperorQuickFooted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GodEmperorQuickFooted");
            var NascentApotheosis = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "NascentApotheosis");
            var LightEnergyCondensation = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "LightEnergyCondensation");
            var GodlyVessel = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GodlyVessel");
            var Godhood = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "Godhood");

            // Hero
            BlueprintFeatureSelection HeroAuraSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "HeroAuraSelection");
            var HeroProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "HeroProficiencies");
            var GracefulCombat = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GracefulCombat");
            var HandsOfSalvation = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "HandsOfSalvation");
            var GoldBarrierFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GoldBarrierFeature");
            var GoldBarrierHeroism = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GoldBarrierHeroism");
            var GoldBarrierFastHealing = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GoldBarrierFastHealing");
            var DeusExMachinaFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DeusExMachinaFeature");
            var GoldBarrierResistance = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "GoldBarrierResistance");

            // Mastermind
            var MastermindProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "MastermindProficiencies");
            var MastermindQuickFooted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "MastermindQuickFooted");
            var MasterplanFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "MasterplanFeature");

            BlueprintFeatureSelection ArcanistExploitSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("b8bf3d5023f2d8c428fdf6438cecaea7");
            var ArcanistArcaneReservoirFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("55db1859bd72fd04f9bd3fe1f10e4cbb");
            var ArcanistConsumeSpells = BlueprintTools.GetBlueprint<BlueprintFeature>("69cfb4ab0d9812249b924b8f23d6d19f");
            var EldritchFontEldritchSurge = BlueprintTools.GetBlueprint<BlueprintFeature>("644c0e9618e417947bd0a1252a5e6ecf");
            var EldritchFontImprovedSurge = BlueprintTools.GetBlueprint<BlueprintFeature>("718fe8e143d38cc4899ae798dd098b6e");
            var EldritchFontGreaterSurge = BlueprintTools.GetBlueprint<BlueprintFeature>("685ee64e43fcb6546b65436a3deb98bd");

            // Overlord
            var OverlordProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "OverlordProficiencies");
            var CorruptAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "CorruptAuraFeature");
            var SiphoningAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SiphoningAuraFeature");
            var SecondFormFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondFormFeature");

            // Special Powers
            BlueprintFeatureSelection SpecialPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerSelection");
            var ArmorSaint = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ArmorSaint");
            var IsekaiChannelPositiveEnergyFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiChannelPositiveEnergyFeature");
            var IsekaiChannelNegativeEnergyFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiChannelNegativeEnergyFeature");

            // Overpowered Ability
            BlueprintFeatureSelection OverpoweredAbilitySelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection");
            BlueprintFeatureSelection OverpoweredAbilitySelectionMastermind = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelectionMastermind");
            BlueprintFeatureSelection OverpoweredAbilitySelectionOverlord = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelectionOverlord");

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
                Helpers.CreateLevelEntry(1, IsekaiProficiencies, IsekaiCantrips, IsekaiBonusFeatSelection,
                    OverpoweredAbilitySelection, PlotArmor, StartingWeaponSelection, IsekaiPetSelection, Gifted, LegacySelection.GetClassFeature()),
                Helpers.CreateLevelEntry(2, IsekaiBonusFeatSelection),
                Helpers.CreateLevelEntry(3, IsekaiFighterTraining, SpecialPowerSelection, ReleaseEnergy),
                Helpers.CreateLevelEntry(4, IsekaiBonusFeatSelection),
                Helpers.CreateLevelEntry(5, OverpoweredAbilitySelection),
                Helpers.CreateLevelEntry(6, IsekaiBonusFeatSelection, SignatureMoveSelection, SignatureMoveBonusSelection),
                Helpers.CreateLevelEntry(7, SpecialPowerSelection),
                Helpers.CreateLevelEntry(8, IsekaiBonusFeatSelection, Afterimage),
                Helpers.CreateLevelEntry(9, SpecialPowerSelection),
                Helpers.CreateLevelEntry(10, IsekaiBonusFeatSelection, OverpoweredAbilitySelection, IsekaiAuraSelection, SecretPowerSelection),
                Helpers.CreateLevelEntry(11, SpecialPowerSelection),
                Helpers.CreateLevelEntry(12, IsekaiBonusFeatSelection, BeachEpisodeSelection),
                Helpers.CreateLevelEntry(13, SpecialPowerSelection, OtherworldlyStamina),
                Helpers.CreateLevelEntry(14, IsekaiBonusFeatSelection),
                Helpers.CreateLevelEntry(15, OverpoweredAbilitySelection, IsekaiQuickFooted, SecondReincarnation),
                Helpers.CreateLevelEntry(16, IsekaiBonusFeatSelection),
                Helpers.CreateLevelEntry(17, SpecialPowerSelection, SummonHaremFeature),
                Helpers.CreateLevelEntry(18, IsekaiBonusFeatSelection),
                Helpers.CreateLevelEntry(19, SpecialPowerSelection),
                Helpers.CreateLevelEntry(20, IsekaiBonusFeatSelection, OverpoweredAbilitySelection, HaxSelection)
            };
            IsekaiProtagonistProgression.UIGroups = new UIGroup[] {
                
                // Isekai UI group
                Helpers.CreateUIGroup(PlotArmor, IsekaiFighterTraining, SignatureAbility, SignatureMoveSelection,
                    SummonHaremFeature, IsekaiAuraSelection, GodEmperorAuraSelection, DarkAuraFeature, HeroAuraSelection, Afterimage,
                    IsekaiQuickFooted, GodEmperorQuickFooted, MastermindQuickFooted, BeachEpisodeSelection, OtherworldlyStamina, HaxSelection,
                    ChuunibyouActualisationFeature, DeusExMachinaFeature, MasterplanFeature),
                Helpers.CreateUIGroup(ReleaseEnergy, Gifted, SignatureMoveBonusSelection, SecretPowerSelection, SecondReincarnation),
                
                // Edge Lord UI group
                Helpers.CreateUIGroup(SupersonicCombat, ExtraStrike),
                
                // God Emperor UI group
                Helpers.CreateUIGroup(NascentApotheosis, LightEnergyCondensation, GodEmperorEnergySelection, BodyMindAlterSelection,
                    EnergyCondensationSelection, BarrierSelection, PathSelection, RealmSelection, GodlyVessel, Godhood),
                
                // Hero UI group
                Helpers.CreateUIGroup(GracefulCombat, IsekaiChannelPositiveEnergyFeature, HandsOfSalvation, GoldBarrierFeature,
                    GoldBarrierHeroism, GoldBarrierFastHealing, GoldBarrierResistance),
                
                // Mastermind UI group
                Helpers.CreateUIGroup(OverpoweredAbilitySelectionMastermind, ArcanistExploitSelection),
                Helpers.CreateUIGroup(ArcanistConsumeSpells, EldritchFontEldritchSurge, EldritchFontImprovedSurge, EldritchFontGreaterSurge),

                // Overlord UI group
                Helpers.CreateUIGroup(OverpoweredAbilitySelectionOverlord),
                Helpers.CreateUIGroup(IsekaiChannelNegativeEnergyFeature, CorruptAuraFeature, SecondFormFeature, SiphoningAuraFeature),
                
                // OP ability and Special Power UI group
                Helpers.CreateUIGroup(OverpoweredAbilitySelection, SpecialPowerSelection, ArmorSaint),

                // Legacy UI groups
                Helpers.CreateUIGroup(LegacySelection.GetClassFeature()),
                Helpers.CreateUIGroup(HeroLegacySelection.getClassFeature()),
                Helpers.CreateUIGroup(MastermindLegacySelection.getClassFeature()),
                Helpers.CreateUIGroup(OverlordLegacySelection.getClassFeature()),
                Helpers.CreateUIGroup(EdgeLordLegacySelection.getClassFeature()),
            };
            IsekaiProtagonistProgression.m_UIDeterminatorsGroup = new BlueprintFeatureBaseReference[] {
                IsekaiCantrips.ToReference<BlueprintFeatureBaseReference>(),
                StartingWeaponSelection.ToReference<BlueprintFeatureBaseReference>(),
                IsekaiPetSelection.ToReference<BlueprintFeatureBaseReference>(),
                IsekaiProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                EdgeLordProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                GodEmperorProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                HeroProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                MastermindProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                OverlordProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                ArcanistArcaneReservoirFeature.ToReference<BlueprintFeatureBaseReference>(),
            };
            IsekaiProtagonistClass.SetProgression(IsekaiProtagonistProgression);
        }
    }
}