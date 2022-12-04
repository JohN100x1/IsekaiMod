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

                Features.ExtraWings.Add();
                Features.ExoticWeaponProficiency.Add();

                if (ModSettings.AddedContent.Feats.IsEnabled("Exceptional Feats")) AddExceptionalFeats();
                if (ModSettings.AddedContent.Backgrounds.IsEnabled("Isekai Backgrounds")) AddIsekaiBackgrounds();
                if (ModSettings.AddedContent.Deities.IsEnabled("Isekai Deities")) AddIsekaiDeities();
                if (ModSettings.AddedContent.Heritages.IsEnabled("Isekai Heritages")) AddIsekaiHeritages();
                if (ModSettings.AddedContent.Classes.IsEnabled("Isekai Protagonist")) AddIsekaiProtagonistClass();
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
                Features.IsekaiProtagonist.IsekaiProtagonistCantrips.Add();
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

                // Beach Episode Selection
                Features.IsekaiProtagonist.BeachEpisode.BeachEpisodeSelection.Add();
                Features.IsekaiProtagonist.BeachEpisode.HealthyBody.Add();
                Features.IsekaiProtagonist.BeachEpisode.InnerPower.Add();
                Features.IsekaiProtagonist.BeachEpisode.MasterSelf.Add();
                Features.IsekaiProtagonist.BeachEpisode.Tenacious.Add();

                // Character Development
                Features.IsekaiProtagonist.CharacterDevelopment.CharacterDevelopmentSelection.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.MundaneAura.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.AlphaStrike.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.BetaStrike.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.GammaStrike.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.Regeneration.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.EnergyImmunitySelection.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.TrainingMontage.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.BodyStrengthening.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.SpellNegation.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.ExtremeSpeed.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.IsekaiChannelPositiveEnergy.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.IsekaiChannelNegativeEnergy.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.KineticPower.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.SneakyMagic.Add();
                Features.IsekaiProtagonist.CharacterDevelopment.SpellMaster.Add();

                // OP Ability
                Features.IsekaiProtagonist.OverpoweredAbility.OverpoweredAbilitySelection.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoBolster.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoEmpower.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoExtend.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoMaximize.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoQuicken.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoReach.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoSelective.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.GraspHeart.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.DupeGold.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.PerfectRoll.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.SuperBuff.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.UnlimitedPower.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.MindControl.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.SummonCalamity.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.InterdimensionalBag.Add();

                // God Emperor Archetype
                Features.IsekaiProtagonist.Archetypes.GodEmperor.GodEmperorProficiencies.Add();
                Features.IsekaiProtagonist.Archetypes.GodEmperor.NascentApotheosis.Add();
                Features.IsekaiProtagonist.Archetypes.GodEmperor.ProtectiveAuraFeature.Add();
                Features.IsekaiProtagonist.Archetypes.GodEmperor.DarkAuraFeature.Add();
                Features.IsekaiProtagonist.Archetypes.GodEmperor.GloriousAuraFeature.Add();
                Features.IsekaiProtagonist.Archetypes.GodEmperor.GodlyVessel.Add();
                Features.IsekaiProtagonist.Archetypes.GodEmperor.SiphoningAuraFeature.Add();
                Features.IsekaiProtagonist.Archetypes.GodEmperor.Godhood.Add();
                Classes.IsekaiProtagonist.Archetypes.GodEmperor.Add();

                // Edge Lord Archetype
                Features.IsekaiProtagonist.Archetypes.EdgeLord.EdgeLordProficiencies.Add();
                Features.IsekaiProtagonist.Archetypes.EdgeLord.SupersonicCombat.Add();
                Features.IsekaiProtagonist.Archetypes.EdgeLord.EdgeLordFastMovement.Add();
                Features.IsekaiProtagonist.Archetypes.EdgeLord.ExtraStrike.Add();
                Classes.IsekaiProtagonist.Archetypes.EdgeLord.Add();

                // Hero Archetype
                Features.IsekaiProtagonist.Archetypes.Hero.HeroProficiencies.Add();
                Features.IsekaiProtagonist.Archetypes.Hero.GracefulCombat.Add();
                Features.IsekaiProtagonist.Archetypes.Hero.TrueSmite.Add();
                Features.IsekaiProtagonist.Archetypes.Hero.HerosPresence.Add();
                Classes.IsekaiProtagonist.Archetypes.Hero.Add();

                // Villain Archetype
                Features.IsekaiProtagonist.Archetypes.Villain.VillainProficiencies.Add();
                Features.IsekaiProtagonist.Archetypes.Villain.CorruptAuraFeature.Add();
                Features.IsekaiProtagonist.Archetypes.Villain.VillainQuickFooted.Add();
                Features.IsekaiProtagonist.Archetypes.Villain.SecondFormFeature.Add();
                Classes.IsekaiProtagonist.VillainSpellbook.Add();
                Classes.IsekaiProtagonist.Archetypes.Villain.Add();

                // Add Progression & Prebuild after Class and class-dependent features are added
                Classes.IsekaiProtagonist.PrebuildIsekaiProtagonistFeatureList.Add();
                Classes.IsekaiProtagonist.IsekaiProtagonistProgression.Add();

                // Patch Loremaster & Hellknight Signifier Spellbooks
                Classes.IsekaiProtagonist.LoremasterReplaceSpellbook.Patch();
                Classes.IsekaiProtagonist.HellknightSignifierReplaceSpellbook.Patch();

                // Deathsnatcher animal Companion (Depends on IsekaiProtagonistClass)
                Classes.Deathsnatcher.DeathsnatcherClass.Add();
                Features.Deathsnatcher.DeathsnatcherSizeBaby.Add();
                Features.Deathsnatcher.DeathsnatcherResistances.Add();
                Features.Deathsnatcher.DeathsnatcherCommandUndead.Add();
                Features.Deathsnatcher.DeathsnatcherAnimateDead.Add();
                Features.Deathsnatcher.DeathsnatcherCreateUndead.Add();
                Features.Deathsnatcher.DeathsnatcherFingerOfDeath.Add();
                Features.Deathsnatcher.DeathsnatcherFastHealing.Add();
                Features.Deathsnatcher.DeathsnatcherPoisonSting.Add();
                Features.Deathsnatcher.DeathsnatcherUndeadMaster.Add();
                Classes.Deathsnatcher.DeathsnatcherProgression.Add();
                Classes.Deathsnatcher.DeathsnatcherUnit.Add();

                // Add extra dialogue (Depends on IsekaiProtagonistClass)
                Dialogue.IsekaiHulrun.Add();
                Dialogue.IsekaiRadiance.Add();
            }
            public static void AddIsekaiHeritages()
            {
                // Add Heritages
                Heritages.IsekaiSuccubus.SuccubusCharmAbility.Add();
                Heritages.IsekaiSuccubus.IsekaiSuccubusHeritage.Add();
                Heritages.IsekaiAngel.AngelicBoltAbility.Add();
                Heritages.IsekaiAngel.IsekaiAngelHeritage.Add();
                Heritages.IsekaiVampire.IsekaiVampireHeritage.Add();
                Heritages.IsekaiSpriggan.SizeAlterationAbility.Add();
                Heritages.IsekaiSpriggan.IsekaiSprigganHeritage.Add();
                Heritages.IsekaiDarkElf.DrowPoisonAbility.Add();
                Heritages.IsekaiDarkElf.IsekaiDarkElfHeritage.Add();
                Heritages.IsekaiHighElf.IsekaiHighElfHeritage.Add();
                Heritages.IsekaiWoodElf.IsekaiWoodElfHeritage.Add();

                // Patch Heritages
                Heritages.ElfHeritagePatcher.Patch();
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
                Backgrounds.RebornDemonLord.Add();
                Backgrounds.Otaku.Add();
                Backgrounds.Gamer.Add();
                Backgrounds.BetaTester.Add();
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
            public static void AddExceptionalFeats()
            {
                // Add Exceptional Feats
                Features.ExceptionalFeats.ExceptionalFeatSelection.Add();
                Features.ExceptionalFeats.EffectImmunitySelection.Add();
                Features.ExceptionalFeats.ExceptionalSummoningSelection.Add();
                Features.ExceptionalFeats.ExceptionalWeaponSelection.Add();

            }
        }
    }
}
