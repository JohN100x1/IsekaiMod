using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;

namespace IsekaiMod.Changes
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
                Features.IsekaiProtagonist.PlotArmor.Add();
                Features.IsekaiProtagonist.IsekaiFighterTraining.Add();
                Features.IsekaiProtagonist.SignatureAttack.Add();
                Features.IsekaiProtagonist.IsekaiFastMovement.Add();
                Features.IsekaiProtagonist.OtherworldlyStamina.Add();
                Features.IsekaiProtagonist.IsekaiQuickFooted.Add();
                Features.IsekaiProtagonist.FriendlyAuraFeature.Add();
                Features.IsekaiProtagonist.HaremMagnetFeature.Add();
                Features.IsekaiProtagonist.TrueMainCharacter.Add();
                Features.IsekaiProtagonist.TrainingArc.StudyMontage.Add();
                Features.IsekaiProtagonist.TrainingArc.TrainingMontage.Add();
                Features.IsekaiProtagonist.TrainingArc.BodyStrengthening.Add();
                Features.IsekaiProtagonist.TrainingArc.SpellNegation.Add();
                Features.IsekaiProtagonist.TrainingArc.TrainingArcSelection.Add();
                Features.IsekaiProtagonist.BeachEpisode.HealthyBody.Add();
                Features.IsekaiProtagonist.BeachEpisode.InnerPower.Add();
                Features.IsekaiProtagonist.BeachEpisode.MasterSelf.Add();
                Features.IsekaiProtagonist.BeachEpisode.Unstoppable.Add();
                Features.IsekaiProtagonist.BeachEpisode.BeachEpisodeSelection.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.MundaneAura.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.VigorousWard.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.AlphaStrike.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.GammaStrike.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.CharacterDevelopmentSelection1.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.CharacterDevelopmentSelection2.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.CharacterDevelopmentSelection3.Add();
                Features.IsekaiProtagonist.Backstory.HopelessBackstory.Add();
                Features.IsekaiProtagonist.Backstory.TragicBackstory.Add();
                Features.IsekaiProtagonist.Backstory.PainfulBackstory.Add();
                Features.IsekaiProtagonist.Backstory.VengefulBackstory.Add();
                Features.IsekaiProtagonist.Backstory.ForsakenBackstory.Add();
                Features.IsekaiProtagonist.Backstory.BackstorySelection.Add();

                Features.IsekaiProtagonist.GodEmporerProficiencies.Add();
                Features.IsekaiProtagonist.GodEmporerPlotArmor.Add();
                Features.IsekaiProtagonist.NascentApotheosis.Add();
                Features.IsekaiProtagonist.GodEmporerTraining.Add();
                Features.IsekaiProtagonist.ProtectiveAuraFeature.Add();
                Features.IsekaiProtagonist.GodEmporerSignatureAttack.Add();
                Features.IsekaiProtagonist.DarkAuraFeature.Add();
                Features.IsekaiProtagonist.GloriousAuraFeature.Add();
                Features.IsekaiProtagonist.GodlyBody.Add();
                Features.IsekaiProtagonist.Invincible.Add();
                Classes.IsekaiProtagonist.Archetypes.GodEmporer.Add();

                // Add Progression & Prebuild after Class and class-dependent features are added
                Classes.IsekaiProtagonist.PrebuildIsekaiProtagonistFeatureList.Add();
                Classes.IsekaiProtagonist.IsekaiProtagonistProgression.Add();

                Heritages.TieflingHeritageSuccubus.Add();

                Backgrounds.BlackRoseMatriarch.Add();
                Backgrounds.BlackRoseSelection.Add();
            }
        }
    }
}
