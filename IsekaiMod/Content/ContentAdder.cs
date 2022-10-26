using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;

namespace IsekaiMod.Content
{
    class ContentAdder {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch {
            static bool Initialized;

            [HarmonyPriority(Priority.First)]
            public static void Postfix() {
                if (Initialized) return;
                Initialized = true;
                // Isekai Protagonist Class
                Classes.IsekaiProtagonist.IsekaiProtagonistSpellList.Add();
                Classes.IsekaiProtagonist.IsekaiProtagonistSpellsPerDay.Add();
                Classes.IsekaiProtagonist.IsekaiProtagonistSpellsKnown.Add();
                Classes.IsekaiProtagonist.IsekaiProtagonistSpellbook.Add();
                Classes.IsekaiProtagonist.IsekaiProtagonistClass.Add();
                // Isekai Protagonist Features
                Features.IsekaiProtagonist.IsekaiProtagonistProficiencies.Add();
                Features.IsekaiProtagonist.IsekaiProtagonistCantripsFeature.Add();
                Features.IsekaiProtagonist.IsekaiProtagonistBonusFeatSelection.Add();
                Features.IsekaiProtagonist.IsekaiProtagonistTalentSelection.Add();
                Features.IsekaiProtagonist.PlotArmor.Add();
                Features.IsekaiProtagonist.IsekaiFighterTraining.Add();
                Features.IsekaiProtagonist.SignatureAttack.Add();
                Features.IsekaiProtagonist.IsekaiFastMovement.Add();
                Features.IsekaiProtagonist.OtherworldlyStamina.Add();
                Features.IsekaiProtagonist.IsekaiQuickFooted.Add();
                Features.IsekaiProtagonist.FriendlyAuraFeature.Add();
                Features.IsekaiProtagonist.HaremMagnetFeature.Add();
                Features.IsekaiProtagonist.TrueMainCharacter.Add();
                Features.IsekaiProtagonist.TrainingArc.TrainingMontage.Add();
                Features.IsekaiProtagonist.TrainingArc.BodyStrengthening.Add();
                Features.IsekaiProtagonist.TrainingArc.SpellNegation.Add();
                Features.IsekaiProtagonist.TrainingArc.ExtremeSpeed.Add();
                Features.IsekaiProtagonist.TrainingArc.TrainingArcSelection.Add();
                Features.IsekaiProtagonist.BeachEpisode.HealthyBody.Add();
                Features.IsekaiProtagonist.BeachEpisode.InnerPower.Add();
                Features.IsekaiProtagonist.BeachEpisode.MasterSelf.Add();
                Features.IsekaiProtagonist.BeachEpisode.Tenacious.Add();
                Features.IsekaiProtagonist.BeachEpisode.BeachEpisodeSelection.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.MundaneAura.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.AlphaStrike.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.BetaStrike.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.GammaStrike.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.AcidImmunity.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.ColdImmunity.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.ElectricityImmunity.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.FireImmunity.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.SonicImmunity.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.CharacterDevelopmentSelection.Add();
                Features.IsekaiProtagonist.CheatSkill.AutoEmpowerFeature.Add();
                Features.IsekaiProtagonist.CheatSkill.AutoExtendFeature.Add();
                Features.IsekaiProtagonist.CheatSkill.AutoMaximizeFeature.Add();
                Features.IsekaiProtagonist.CheatSkill.AutoQuickenFeature.Add();
                Features.IsekaiProtagonist.CheatSkill.AutoReachFeatureFeature.Add();
                Features.IsekaiProtagonist.CheatSkill.GraspHeartFeature.Add();
                Features.IsekaiProtagonist.CheatSkill.DupeGoldFeature.Add();
                Features.IsekaiProtagonist.CheatSkill.Winner.Add();
                Features.IsekaiProtagonist.CheatSkill.CheatSkillSelection.Add();
                Features.IsekaiProtagonist.CheatSkill.CheatSkillMythicSelection.Add();
                // God Emporer Archetype
                Features.IsekaiProtagonist.GodEmporer.GodEmporerProficiencies.Add();
                Features.IsekaiProtagonist.GodEmporer.GodEmporerPlotArmor.Add();
                Features.IsekaiProtagonist.GodEmporer.NascentApotheosis.Add();
                Features.IsekaiProtagonist.GodEmporer.GodEmporerTraining.Add();
                Features.IsekaiProtagonist.GodEmporer.ProtectiveAuraFeature.Add();
                Features.IsekaiProtagonist.GodEmporer.GodEmporerSignatureAttack.Add();
                Features.IsekaiProtagonist.GodEmporer.DarkAuraFeature.Add();
                Features.IsekaiProtagonist.GodEmporer.GloriousAuraFeature.Add();
                Features.IsekaiProtagonist.GodEmporer.GodlyVessel.Add();
                Features.IsekaiProtagonist.GodEmporer.SiphoningAuraFeature.Add();
                Features.IsekaiProtagonist.GodEmporer.Godhood.Add();
                Classes.IsekaiProtagonist.Archetypes.GodEmporer.Add();
                // Edge Lord Archetype
                Features.IsekaiProtagonist.EdgeLord.EdgeLordProficiencies.Add();
                Features.IsekaiProtagonist.EdgeLord.EdgeLordPlotArmor.Add();
                Features.IsekaiProtagonist.EdgeLord.SupersonicCombat.Add();
                Features.IsekaiProtagonist.EdgeLord.EdgeLordTraining.Add();
                Features.IsekaiProtagonist.EdgeLord.EdgeLordSignatureAttack.Add();
                Features.IsekaiProtagonist.EdgeLord.EdgeLordFastMovement.Add();
                Features.IsekaiProtagonist.EdgeLord.ExtraStrike.Add();
                Classes.IsekaiProtagonist.Archetypes.EdgeLord.Add();

                // Add Progression & Prebuild after Class and class-dependent features are added
                Classes.IsekaiProtagonist.PrebuildIsekaiProtagonistFeatureList.Add();
                Classes.IsekaiProtagonist.IsekaiProtagonistProgression.Add();

                Heritages.TieflingHeritageSuccubus.Add();

                Backgrounds.TabletopRPGPlayer.Add();
                Backgrounds.IsekaiBackgroundSelection.Add();
            }
        }
    }
}
