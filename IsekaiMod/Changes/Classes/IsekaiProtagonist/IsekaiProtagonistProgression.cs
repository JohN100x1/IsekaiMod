using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Changes.Classes.IsekaiProtagonist
{
    class IsekaiProtagonistProgression
    {
        public static void Add()
        {
            //// Class Features
            var IsekaiProtagonistProficiencies = Resources.GetModBlueprint<BlueprintFeature>("IsekaiProtagonistProficiencies");
            var GodEmporerProficiencies = Resources.GetModBlueprint<BlueprintFeature>("GodEmporerProficiencies");
            var IsekaiProtagonistCantripsFeature = Resources.GetModBlueprint<BlueprintFeature>("IsekaiProtagonistCantripsFeature");
            var IsekaiProtagonistBonusFeatSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("IsekaiProtagonistBonusFeatSelection");
            var SneakAttack = Resources.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");
            var PlotArmor = Resources.GetModBlueprint<BlueprintFeature>("PlotArmor");
            var GodEmporerPlotArmor = Resources.GetModBlueprint<BlueprintFeature>("GodEmporerPlotArmor");
            var EdgeLordPlotArmor = Resources.GetModBlueprint<BlueprintFeature>("EdgeLordPlotArmor");
            var UncannyDodge = Resources.GetBlueprint<BlueprintFeature>("3c08d842e802c3e4eb19d15496145709");
            var ImprovedUncannyDodge = Resources.GetBlueprint<BlueprintFeature>("485a18c05792521459c7d06c63128c79");
            var Evasion = Resources.GetBlueprint<BlueprintFeature>("576933720c440aa4d8d42b0c54b77e80");
            var ImprovedEvasion = Resources.GetBlueprint<BlueprintFeature>("ce96af454a6137d47b9c6a1e02e66803");
            var HaremMagnetFeature = Resources.GetModBlueprint<BlueprintFeature>("HaremMagnetFeature");
            var OtherworldlyStamina = Resources.GetModBlueprint<BlueprintFeature>("OtherworldlyStamina");
            var SignatureAttack = Resources.GetModBlueprint<BlueprintFeature>("SignatureAttack");
            var GodEmporerSignatureAttack = Resources.GetModBlueprint<BlueprintFeature>("GodEmporerSignatureAttack");
            var IsekaiFighterTraining = Resources.GetModBlueprint<BlueprintFeature>("IsekaiFighterTraining");
            var GodEmporerTraining = Resources.GetModBlueprint<BlueprintFeature>("GodEmporerTraining");
            var IsekaiFastMovement = Resources.GetModBlueprint<BlueprintFeature>("IsekaiFastMovement");
            var IsekaiQuickFooted = Resources.GetModBlueprint<BlueprintFeature>("IsekaiQuickFooted");
            var FriendlyAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("FriendlyAuraFeature");
            var DarkAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("DarkAuraFeature");
            var TrueMainCharacter = Resources.GetModBlueprint<BlueprintFeature>("TrueMainCharacter");
            var Godhood = Resources.GetModBlueprint<BlueprintFeature>("Godhood");
            var GodlyVessel = Resources.GetModBlueprint<BlueprintFeature>("GodlyVessel");
            var NascentApotheosis = Resources.GetModBlueprint<BlueprintFeature>("NascentApotheosis");
            var ProtectiveAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("ProtectiveAuraFeature");
            var GloriousAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("GloriousAuraFeature");
            var SiphoningAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("SiphoningAuraFeature");
            var SupersonicCombat = Resources.GetModBlueprint<BlueprintFeature>("SupersonicCombat");
            var EdgeLordProficiencies = Resources.GetModBlueprint<BlueprintFeature>("EdgeLordProficiencies");
            var EdgeLordFastMovement = Resources.GetModBlueprint<BlueprintFeature>("EdgeLordFastMovement");

            var BackstorySelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("BackstorySelection");
            var TrainingArcSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("TrainingArcSelection");
            var BeachEpisodeSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("BeachEpisodeSelection");
            var CharacterDevelopmentSelection1 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection1");
            var CharacterDevelopmentSelection2 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection2");
            var CharacterDevelopmentSelection3 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection3");
            var CharacterDevelopmentSelection4 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection4");

            var IsekaiProtagonistClass = Resources.GetModBlueprint<BlueprintCharacterClass>("IsekaiProtagonistClass");
            var IsekaiProtagonistProgression = Helpers.CreateBlueprint<BlueprintProgression>("IsekaiProtagonistProgression", bp => {
                bp.SetName("");
                bp.SetDescription(
                    "Isekai protagonists are otherworldly entities who have been reincarnated into the world of Golarion with extraordinary abilities. " +
                    "As their story progresses, they gain more unexplained and overpowered abilities to overcome every challenge they face.");
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = true;
                bp.m_FeaturesRankIncrease = null;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>(),
                        AdditionalLevel = 0
                    }
                };
            });
            IsekaiProtagonistProgression.LevelEntries = new LevelEntry[20] {
                Helpers.LevelEntry(1, IsekaiProtagonistProficiencies, IsekaiProtagonistCantripsFeature, IsekaiProtagonistBonusFeatSelection, SneakAttack, BackstorySelection, PlotArmor),
                Helpers.LevelEntry(2, IsekaiProtagonistBonusFeatSelection, UncannyDodge),
                Helpers.LevelEntry(3, SneakAttack, IsekaiFighterTraining, Evasion, CharacterDevelopmentSelection1),
                Helpers.LevelEntry(4, IsekaiProtagonistBonusFeatSelection),
                Helpers.LevelEntry(5, SneakAttack, TrainingArcSelection, ImprovedUncannyDodge),
                Helpers.LevelEntry(6, IsekaiProtagonistBonusFeatSelection, SignatureAttack),
                Helpers.LevelEntry(7, SneakAttack, CharacterDevelopmentSelection2),
                Helpers.LevelEntry(8, IsekaiProtagonistBonusFeatSelection, IsekaiFastMovement),
                Helpers.LevelEntry(9, SneakAttack, FriendlyAuraFeature),
                Helpers.LevelEntry(10, IsekaiProtagonistBonusFeatSelection, TrainingArcSelection, ImprovedEvasion),
                Helpers.LevelEntry(11, SneakAttack),
                Helpers.LevelEntry(12, IsekaiProtagonistBonusFeatSelection, BeachEpisodeSelection),
                Helpers.LevelEntry(13, SneakAttack, CharacterDevelopmentSelection3),
                Helpers.LevelEntry(14, IsekaiProtagonistBonusFeatSelection),
                Helpers.LevelEntry(15, SneakAttack, TrainingArcSelection, OtherworldlyStamina, IsekaiQuickFooted),
                Helpers.LevelEntry(16, IsekaiProtagonistBonusFeatSelection),
                Helpers.LevelEntry(17, SneakAttack, HaremMagnetFeature),
                Helpers.LevelEntry(18, IsekaiProtagonistBonusFeatSelection),
                Helpers.LevelEntry(19, SneakAttack, CharacterDevelopmentSelection4),
                Helpers.LevelEntry(20, IsekaiProtagonistBonusFeatSelection, TrueMainCharacter)
            };
            IsekaiProtagonistProgression.UIGroups = new UIGroup[] {
                Helpers.CreateUIGroup(BackstorySelection, TrainingArcSelection, NascentApotheosis, GodlyVessel, CharacterDevelopmentSelection1, ProtectiveAuraFeature, CharacterDevelopmentSelection2, GloriousAuraFeature, SiphoningAuraFeature, CharacterDevelopmentSelection3, CharacterDevelopmentSelection4, Godhood),
                Helpers.CreateUIGroup(PlotArmor, EdgeLordPlotArmor, GodEmporerPlotArmor, IsekaiFighterTraining, GodEmporerTraining, SignatureAttack, GodEmporerSignatureAttack, FriendlyAuraFeature, DarkAuraFeature, BeachEpisodeSelection, OtherworldlyStamina, HaremMagnetFeature, TrueMainCharacter),
                Helpers.CreateUIGroup(SupersonicCombat, UncannyDodge, ImprovedUncannyDodge, Evasion, ImprovedEvasion, IsekaiFastMovement, EdgeLordFastMovement, IsekaiQuickFooted),
            };
            IsekaiProtagonistProgression.m_UIDeterminatorsGroup = new BlueprintFeatureBaseReference[] {
                EdgeLordProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                GodEmporerProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                IsekaiProtagonistProficiencies.ToReference<BlueprintFeatureBaseReference>(),
                IsekaiProtagonistCantripsFeature.ToReference<BlueprintFeatureBaseReference>()
            };
            IsekaiProtagonistClass.m_Progression = IsekaiProtagonistProgression.ToReference<BlueprintProgressionReference>();
        }
    }
}
