using HarmonyLib;
using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Deities;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.JsonSystem;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content {
    class ContentAdder {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch {
            private static bool Initialized;

            [HarmonyPriority(Priority.First)]
            public static void Postfix() {
                if (Initialized) return;
                Initialized = true;
                Main.LogDebug("first init call");

                Features.ExtraWings.Add();
                Main.LogDebug("first init call wings patched");
                Features.ExoticWeaponProficiency.Add();
                Main.LogDebug("first init call start if block");

                if (IsekaiContext.AddedContent.Feats.IsEnabled("Exceptional Feats")) AddExceptionalFeats();
                if (IsekaiContext.AddedContent.Backgrounds.IsEnabled("Isekai Backgrounds")) AddIsekaiBackgrounds();
                if (IsekaiContext.AddedContent.Deities.IsEnabled("Isekai Deities")) AddIsekaiDeities();
                if (IsekaiContext.AddedContent.Heritages.IsEnabled("Isekai Heritages")) AddIsekaiHeritages();
                if (IsekaiContext.AddedContent.Classes.IsEnabled("Isekai Protagonist")) AddIsekaiProtagonistClass();
            }

            public static void AddIsekaiProtagonistClass() {
                Main.LogDebug("Class: Start");
                LegacySelection.ConfigureStep1();
                VillainLegacySelection.Configure();
                EdgeLordLegacySelection.Configure();
                HeroLegacySelection.Configure();
                // Isekai Protagonist Class
                IsekaiProtagonistSpellList.Add();
                IsekaiProtagonistSpellsPerDay.Add();
                IsekaiProtagonistSpellsKnown.Add();
                IsekaiProtagonistSpellbook.Add();
                IsekaiProtagonistClass.Add();
                Main.LogDebug("Class: Configured");

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
                Main.LogDebug("Class: Features");

                // Beach Episode Selection
                Features.IsekaiProtagonist.BeachEpisode.BeachEpisodeSelection.Add();
                Features.IsekaiProtagonist.BeachEpisode.HealthyBody.Add();
                Features.IsekaiProtagonist.BeachEpisode.InnerPower.Add();
                Features.IsekaiProtagonist.BeachEpisode.MasterSelf.Add();
                Features.IsekaiProtagonist.BeachEpisode.Tenacious.Add();
                Main.LogDebug("Class: BeachEpisode");

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
                Main.LogDebug("Class: SpecialPower");

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
                
                Main.LogDebug("Class: OP");

                // God Emperor Archetype
                GodEmperorProficiencies.Add();
                NascentApotheosis.Add();
                DivineArray.Add();
                GodEmperorEnergySelection.Add();
                AuraOfGoldenProtection.Add();
                DarkAuraFeature.Add();
                AuraOfMajesty.Add();
                GodlyVessel.Add();
                SiphoningAuraFeature.Add();
                CelestialRealm.Add();
                Godhood.Add();
                Classes.IsekaiProtagonist.Archetypes.GodEmperor.Add();
                Main.LogDebug("Class: Emperor");

                // Edge Lord Archetype
                EdgeLordProficiencies.Add();
                SupersonicCombat.Add();
                EdgeLordFastMovement.Add();
                ExtraStrike.Add();
                Classes.IsekaiProtagonist.Archetypes.EdgeLord.Add();
                Main.LogDebug("Class: EdgeLord");

                // Hero Archetype
                HeroProficiencies.Add();
                GracefulCombat.Add();
                TrueSmite.Add();
                TrueMark.Add();
                HerosPresence.Add();
                Classes.IsekaiProtagonist.Archetypes.Hero.Add();
                Main.LogDebug("Class: Hero");

                // Villain Archetype
                VillainProficiencies.Add();
                CorruptAuraFeature.Add();
                VillainQuickFooted.Add();
                SecondFormFeature.Add();
                VillainSpellbook.Add();
                Classes.IsekaiProtagonist.Archetypes.Villain.Add();
                Main.LogDebug("Class: Villain");

                // Add Progression & Prebuild after Class and class-dependent features are added
                PrebuildIsekaiProtagonistFeatureList.Add();
                IsekaiProtagonistProgression.Add();

                // Patch Prestige Class Spellbooks
                PrestigeClassReplaceSpellbook.Patch();
                Main.LogDebug("Class: Prestige");

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
                Main.LogDebug("Class: Deathsnatcher");

                // Add extra dialogue (Depends on IsekaiProtagonistClass)
                Dialogue.IsekaiHulrun.Add();
                Dialogue.IsekaiRadiance.Add();
                Dialogue.IsekaiKaylessaDrowLeader.Add();
                Main.LogDebug("Class: Dialogue");

                LegacySelection.ConfigureStep2();
                Main.LogDebug("Class: Done");

            }
            public static void AddIsekaiHeritages() {
                // Add Heritages
                Heritages.IsekaiSuccubusHeritage.Add();
                Heritages.IsekaiAngelHeritage.Add();
                Heritages.IsekaiVampireHeritage.Add();
                Heritages.IsekaiSprigganHeritage.Add();
                Heritages.IsekaiDarkElfHeritage.Add();
                Heritages.IsekaiHighElfHeritage.Add();
                Heritages.IsekaiWoodElfHeritage.Add();
                Heritages.IsekaiFurryHeritage.Add();

                // Patch Heritages
                Heritages.ElfHeritagePatcher.Patch();
            }
            public static void AddIsekaiBackgrounds() {
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
            public static void AddIsekaiDeities() {
                // Add the Selection First
                IsekaiDeitySelection.Add();

                // Add Deities to the Isekai Deity Selection
                TruckKun.Add();
                Aqua.Add();
                Ristarte.Add();
                AdministratorD.Add();
            }
            public static void AddExceptionalFeats() {
                // Add Exceptional Feats
                Features.ExceptionalFeats.ExceptionalFeatSelection.Add();
                Features.ExceptionalFeats.EffectImmunitySelection.Add();
                Features.ExceptionalFeats.ExceptionalSummoningSelection.Add();
                Features.ExceptionalFeats.ExceptionalWeaponSelection.Add();
            }
        }
    }

    [HarmonyPriority(-100)]    
    [HarmonyPatch(typeof(StartGameLoader), "LoadAllJson")]
    static class StartGameLoader_LoadAllJson {
        private static bool Run = false;

        static void Postfix() {
            if (Run) return; 
            Run = true;
            Main.LogDebug("Postfix Patching: Start");
            IsekaiDeitySelection.PatchDeitySelection();
            Main.LogDebug("Postfix Patching: Deities fixed");

            if (IsekaiContext.AddedContent.Classes.IsDisabled("Isekai Protagonist")) return;

            KineticLegacy.PatchKineticistProgression();
            Main.LogDebug("Postfix Patching: Kineticist Patched");
            OracleLegacy.PatchClassOracleSelection();
            Main.LogDebug("Postfix Patching: Oracle Patched");
            SorcererLegacy.PatchSorcererBloodlines();
            Main.LogDebug("Postfix Patching: Sorcerer Patched");
            ShamanLegacy.PatchShamanProgressions();
            Main.LogDebug("Postfix Patching: Shaman Patched");
            KineticKnightLegacy.configure();
            KineticKnightLegacy.PatchKineticistProgression();
            Main.LogDebug("Postfix Patching: Kinetic Knight Patched");

            //done here because it should be done after all spells have been initialized and were added to the canon books
            if (IsekaiContext.AddedContent.Classes.IsEnabled("Merge Isekai Spelllist")) IsekaiProtagonistSpellList.MergeSpellLists();

            if (ModSupport.IsTableTopTweakBaseEnabled()) {
                PatchTableTopTweakCore();
            }
            if (ModSupport.IsExpandedContentEnabled()) { 
                DreadKnightLegacy.Configure();
            }
        }

        private static void PatchTableTopTweakCore() {
            var barbariancapstone = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("c9a1d2ace58a403c994a0df1b72f5614");
            var bardcapstone = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("112097ea789246c9840af6b08faeaba1");
            var paladincapstone = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("a92b9d62930247759b2796a6c2103c0e");
            var kineticistcapstone = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("9683375ecaf446358daaadd4a445fb00");
            var oraclecapstone = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("c898b6e4918c41c3a351c9a882c65cea");
            var roguecapstone = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("fe5077bae2094c9189697fd3c46f400e");
            var shamancapstone = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("6e32488a2cec4ba586508db4f78b062d");
            var sorcerercapstone = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("40f13b4925c24e50bc8f3d5fe4d42a05");
            
            if (barbariancapstone != null) {
                BarbarianLegacy.Get().LevelEntries = BarbarianLegacy.Get().LevelEntries.AddToArray(Helpers.CreateLevelEntry(20, barbariancapstone));
            }
            if (bardcapstone!= null) {
                BardLegacy.Get().LevelEntries = BardLegacy.Get().LevelEntries.AddToArray(Helpers.CreateLevelEntry(20,bardcapstone));
            }
            if (paladincapstone != null) {
                HeroicLegacy.Get().LevelEntries = HeroicLegacy.Get().LevelEntries.AddToArray(Helpers.CreateLevelEntry(20, paladincapstone));
            }
            if (kineticistcapstone != null) {
                KineticLegacy.Get().LevelEntries = KineticLegacy.Get().LevelEntries.AddToArray(Helpers.CreateLevelEntry(20, kineticistcapstone));
            }
            if (oraclecapstone != null) {
                OracleLegacy.Get().LevelEntries = OracleLegacy.Get().LevelEntries.AddToArray(Helpers.CreateLevelEntry(20, oraclecapstone));
            }
            if (roguecapstone != null) {
                RogueLegacy.Get().LevelEntries = RogueLegacy.Get().LevelEntries.AddToArray(Helpers.CreateLevelEntry(20, roguecapstone));
            }
            if (shamancapstone != null) {
                ShamanLegacy.Get().LevelEntries.AddToArray(Helpers.CreateLevelEntry(20, shamancapstone));
            }
            if (sorcerercapstone != null) {
                SorcererLegacy.Get().LevelEntries = SorcererLegacy.Get().LevelEntries.AddToArray(Helpers.CreateLevelEntry(20, sorcerercapstone));
            }
            MagusLegacy.PatchForBroadStudy();
        }

    }
}
