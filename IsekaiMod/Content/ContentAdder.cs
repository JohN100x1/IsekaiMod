using HarmonyLib;
using IsekaiMod.Config;
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

                Features.ExoticWeaponProficiency.Add();

                if (ModSettings.AddedContent.Classes.IsEnabled("Isekai Protagonist")) AddIsekaiProtagonistClass();
                if (ModSettings.AddedContent.Heritages.IsEnabled("Isekai Heritages")) AddIsekaiHeritages();
                if (ModSettings.AddedContent.Backgrounds.IsEnabled("Isekai Backgrounds")) AddIsekaiBackgrounds();
                if (ModSettings.AddedContent.Deities.IsEnabled("Isekai Deities")) AddIsekaiDeities();
            }

            public static void AddIsekaiProtagonistClass()
            {
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
                Features.IsekaiProtagonist.IsekaiPetSelection.Add();
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
                Features.IsekaiProtagonist.TrainingArc.SpellNegationFeature.Add();
                Features.IsekaiProtagonist.TrainingArc.ExtremeSpeedFeature.Add();
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
                Features.IsekaiProtagonist.CharacterDevelopment.ExceptionalSummoningFeature.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.CharacterDevelopmentSelection.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoEmpowerFeature.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoExtendFeature.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoMaximizeFeature.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoQuickenFeature.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoReachFeatureFeature.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.GraspHeartFeature.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.DupeGoldFeature.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.PerfectRollFeature.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.SuperBuffFeature.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.InterdimensionalBagFeature.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.WinnerFeature.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.OverpoweredAbilitySelection.Add();
                // God Emperor Archetype
                Features.IsekaiProtagonist.GodEmperor.GodEmperorProficiencies.Add();
                Features.IsekaiProtagonist.GodEmperor.NascentApotheosis.Add();
                Features.IsekaiProtagonist.GodEmperor.ProtectiveAuraFeature.Add();
                Features.IsekaiProtagonist.GodEmperor.DarkAuraFeature.Add();
                Features.IsekaiProtagonist.GodEmperor.GloriousAuraFeature.Add();
                Features.IsekaiProtagonist.GodEmperor.GodlyVessel.Add();
                Features.IsekaiProtagonist.GodEmperor.SiphoningAuraFeature.Add();
                Features.IsekaiProtagonist.GodEmperor.Godhood.Add();
                Classes.IsekaiProtagonist.Archetypes.GodEmperor.Add();
                // Edge Lord Archetype
                Features.IsekaiProtagonist.EdgeLord.EdgeLordProficiencies.Add();
                Features.IsekaiProtagonist.EdgeLord.SupersonicCombat.Add();
                Features.IsekaiProtagonist.EdgeLord.EdgeLordFastMovement.Add();
                Features.IsekaiProtagonist.EdgeLord.ExtraStrike.Add();
                Classes.IsekaiProtagonist.Archetypes.EdgeLord.Add();
                // Villain Archetype
                Features.IsekaiProtagonist.Villain.VillainProficiencies.Add();
                Features.IsekaiProtagonist.Villain.VillainQuickFooted.Add();
                Features.IsekaiProtagonist.Villain.SecondFormFeature.Add();
                Classes.IsekaiProtagonist.VillainSpellbook.Add();
                Classes.IsekaiProtagonist.Archetypes.Villain.Add();
                // Add Progression & Prebuild after Class and class-dependent features are added
                Classes.IsekaiProtagonist.PrebuildIsekaiProtagonistFeatureList.Add();
                Classes.IsekaiProtagonist.IsekaiProtagonistProgression.Add();

                // Patch Loremaster & Hellknight Signifier Spellbooks
                Classes.IsekaiProtagonist.LoremasterSpellbookSelection.Patch();
                Classes.IsekaiProtagonist.HellknightSignifierSpellbookSelection.Patch();

                // Deathsnatcher animal Companion
                Classes.Deathsnatcher.DeathsnatcherClass.Add();
                Features.Deathsnatcher.DeathsnatcherResistances.Add();
                Features.Deathsnatcher.DeathsnatcherAnimateDeadResource.Add();
                Features.Deathsnatcher.DeathsnatcherAnimateDead.Add();
                Features.Deathsnatcher.DeathsnatcherFastHealing.Add();
                Classes.Deathsnatcher.DeathsnatcherClassProgression.Add();
                Classes.Deathsnatcher.DeathsnatcherUnit.Add();
                // Add extra dialogue
                Dialogue.IsekaiWelcomeDialogue.Add();
            }
            public static void AddIsekaiHeritages()
            {
                // Add Heritages
                Features.IsekaiSuccubus.SuccubusCharmAbility.Add();
                Features.IsekaiSuccubus.SuccubusWingsAbility.Add();
                Heritages.IsekaiSuccubusHeritage.Add();
                Features.IsekaiAngel.AngelicBoltAbility.Add();
                Heritages.IsekaiAngelHeritage.Add();
                Heritages.IsekaiVampireHeritage.Add();
            }
            public static void AddIsekaiBackgrounds()
            {
                // Add the Selection First
                Backgrounds.IsekaiBackgroundSelection.Add();

                // Add Backgrounds to Isekai Background Selection
                Backgrounds.TabletopRPGPlayer.Add();
                Backgrounds.MartialArtist.Add();
                Backgrounds.Salaryman.Add();
                Backgrounds.HighschoolStudent.Add();
                Backgrounds.Otaku.Add();
                Backgrounds.RebornDemonLord.Add();
                Backgrounds.Gamer.Add();
            }
            public static void AddIsekaiDeities()
            {
                // Add the Selection First
                Deities.IsekaiDeitySelection.Add();

                // Add Deities to the Isekai Deity Selection
                Deities.TruckKun.Add();
                Deities.Aqua.Add();
                Deities.Ristarte.Add();
                Deities.AdministratorD.Add();
            }
        }
    }
}
