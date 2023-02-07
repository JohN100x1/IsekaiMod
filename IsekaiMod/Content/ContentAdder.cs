using HarmonyLib;
using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature;
using Kingmaker.Blueprints.JsonSystem;

using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

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

                if (IsekaiContext.AddedContent.Feats.IsEnabled("Exceptional Feats")) AddExceptionalFeats();
                if (IsekaiContext.AddedContent.Backgrounds.IsEnabled("Isekai Backgrounds")) AddIsekaiBackgrounds();
                if (IsekaiContext.AddedContent.Deities.IsEnabled("Isekai Deities")) AddIsekaiDeities();
                if (IsekaiContext.AddedContent.Heritages.IsEnabled("Isekai Heritages")) AddIsekaiHeritages();
                if (IsekaiContext.AddedContent.Classes.IsEnabled("Isekai Protagonist")) AddIsekaiProtagonistClass();

               

            }

            public static void AddIsekaiProtagonistClass()
            {

                LegacySelection.configureStep1();
                VillainLegacySelection.Configure();
                EdgeLordLegacySelection.Configure();
                HeroLegacySelection.Configure();
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
                Features.IsekaiProtagonist.StartingWeaponSelection.Add();
                Features.IsekaiProtagonist.IsekaiFighterTraining.Add();
                Features.IsekaiProtagonist.SignatureMoveSelection.Add();
                Features.IsekaiProtagonist.IsekaiFastMovement.Add();
                Features.IsekaiProtagonist.OtherworldlyStamina.Add();
                Features.IsekaiProtagonist.IsekaiQuickFooted.Add();
                Features.IsekaiProtagonist.FriendlyAuraFeature.Add();
                Features.IsekaiProtagonist.SummonHarem.Add();
                Features.IsekaiProtagonist.SecondReincarnation.Add();

                // Beach Episode Selection
                Features.IsekaiProtagonist.BeachEpisode.BeachEpisodeSelection.Add();
                Features.IsekaiProtagonist.BeachEpisode.HealthyBody.Add();
                Features.IsekaiProtagonist.BeachEpisode.InnerPower.Add();
                Features.IsekaiProtagonist.BeachEpisode.MasterSelf.Add();
                Features.IsekaiProtagonist.BeachEpisode.Tenacious.Add();

                // Special Power
                Features.IsekaiProtagonist.SpecialPower.SpecialPowerSelection.Add();
                Features.IsekaiProtagonist.SpecialPower.MundaneAura.Add();
                Features.IsekaiProtagonist.SpecialPower.AlphaStrike.Add();
                Features.IsekaiProtagonist.SpecialPower.BetaStrike.Add();
                Features.IsekaiProtagonist.SpecialPower.GammaStrike.Add();
                Features.IsekaiProtagonist.SpecialPower.OmegaStrike.Add();
                Features.IsekaiProtagonist.SpecialPower.Regeneration.Add();
                Features.IsekaiProtagonist.SpecialPower.EnergyImmunitySelection.Add();
                Features.IsekaiProtagonist.SpecialPower.TrainingMontage.Add();
                Features.IsekaiProtagonist.SpecialPower.BodyStrengthening.Add();
                Features.IsekaiProtagonist.SpecialPower.SpellNegation.Add();
                Features.IsekaiProtagonist.SpecialPower.ExtremeSpeed.Add();
                Features.IsekaiProtagonist.SpecialPower.IsekaiChannelPositiveEnergy.Add();
                Features.IsekaiProtagonist.SpecialPower.IsekaiChannelNegativeEnergy.Add();
                Features.IsekaiProtagonist.SpecialPower.KineticPower.Add();
                Features.IsekaiProtagonist.SpecialPower.SneakyMagic.Add();
                Features.IsekaiProtagonist.SpecialPower.SpellMaster.Add();
                Features.IsekaiProtagonist.SpecialPower.ArmorSaint.Add();
                Features.IsekaiProtagonist.SpecialPower.ArmorOfStrength.Add();
                Features.IsekaiProtagonist.SpecialPower.SummonBeast.Add();
                Features.IsekaiProtagonist.SpecialPower.AuraOfDivineFury.Add();
                Features.IsekaiProtagonist.SpecialPower.KillingIntent.Add();
                Features.IsekaiProtagonist.SpecialPower.MagicalAmplification.Add();
                Features.IsekaiProtagonist.SpecialPower.Reflect.Add();

                // OP Ability
                Features.IsekaiProtagonist.OverpoweredAbility.OverpoweredAbilitySelection.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoBolster.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoEmpower.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoExtend.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoMaximize.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoQuicken.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoReach.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AutoSelective.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.Instakill.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.DupeGold.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.PerfectRoll.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.SuperBuff.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.UnlimitedPower.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.MindControl.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.SummonCalamity.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.InfiniteSpace.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.TrueResurrection.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.SupremeBeing.Add();
                Features.IsekaiProtagonist.OverpoweredAbility.AuraOfRighteousWrath.Add();
                if (IsekaiContext.AddedContent.Feats.IsEnabled("Overpowered - Mythic Blessing")) Features.IsekaiProtagonist.OverpoweredAbility.BlessingOfTheMythic.Configure();

                // God Emperor Archetype
                Features.IsekaiProtagonist.Archetypes.GodEmperor.GodEmperorProficiencies.Add();
                Features.IsekaiProtagonist.Archetypes.GodEmperor.NascentApotheosis.Add();
                Features.IsekaiProtagonist.Archetypes.GodEmperor.DivineArray.Add();
                Features.IsekaiProtagonist.Archetypes.GodEmperor.GodEmperorEnergySelection.Add();
                Features.IsekaiProtagonist.Archetypes.GodEmperor.AuraOfGoldenProtection.Add();
                Features.IsekaiProtagonist.Archetypes.GodEmperor.DarkAuraFeature.Add();
                Features.IsekaiProtagonist.Archetypes.GodEmperor.AuraOfMajesty.Add();
                Features.IsekaiProtagonist.Archetypes.GodEmperor.GodlyVessel.Add();
                Features.IsekaiProtagonist.Archetypes.GodEmperor.SiphoningAuraFeature.Add();
                Features.IsekaiProtagonist.Archetypes.GodEmperor.CelestialRealm.Add();
                Features.IsekaiProtagonist.Archetypes.GodEmperor.Godhood.Add();
                Classes.IsekaiProtagonist.Archetypes.GodEmperor.Add();

                // Edge Lord Archetype
                EdgeLordProficiencies.Add();
                SupersonicCombat.Add();
                EdgeLordFastMovement.Add();
                ExtraStrike.Add();
                Classes.IsekaiProtagonist.Archetypes.EdgeLord.Add();

                // Hero Archetype
                HeroProficiencies.Add();
                GracefulCombat.Add();
                TrueSmite.Add();
                TrueMark.Add();
                HerosPresence.Add();
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

                // Patch Prestige Class Spellbooks
                Classes.IsekaiProtagonist.PrestigeClassReplaceSpellbook.Patch();

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

                LegacySelection.configureStep2();

            }
            public static void AddIsekaiHeritages()
            {
                // Add Heritages
                Heritages.IsekaiSuccubusHeritage.Add();
                Heritages.IsekaiAngelHeritage.Add();
                Heritages.IsekaiVampireHeritage.Add();
                Heritages.IsekaiSprigganHeritage.Add();
                Heritages.IsekaiDarkElfHeritage.Add();
                Heritages.IsekaiHighElfHeritage.Add();
                Heritages.IsekaiWoodElfHeritage.Add();

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

    [HarmonyPriority(Priority.Last)]    
    [HarmonyPatch(typeof(StartGameLoader), "LoadAllJson")]
    static class StartGameLoader_LoadAllJson {
        private static bool Run = false;

        static void Postfix() {
            if (Run) return; 
            Run = true;
            if (IsekaiContext.AddedContent.Classes.IsDisabled("Isekai Protagonist")) return;
            KineticLegacy.PatchKineticistProgression();
            OracleLegacy.PatchClassOracleSelection();
            SorcererLegacy.PatchSorcererBloodlines();
            ShamanLegacy.PatchShamanProgressions();
            //done here because it should be done after all spells have been initialized and were added to the canon books
            if (IsekaiContext.AddedContent.Classes.IsEnabled("Merge Isekai Spelllist")) IsekaiProtagonistSpellList.MergeSpellLists();


        }

    }
}
