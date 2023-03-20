using HarmonyLib;
using IsekaiMod.Config;
using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Deities;
using IsekaiMod.Content.Features.ExceptionalFeats;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Content.Features.IsekaiProtagonist.BeachEpisode;
using IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature;
using IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility;
using IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.JsonSystem;
using TabletopTweaks.Core.Config;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content {
    class ContentAdder {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch {
            private static bool Initialized;
            private static readonly AddedContent AddedContent = IsekaiContext.AddedContent;
            private static readonly SettingGroup Other = IsekaiContext.AddedContent.Other;
            private static readonly SettingGroup Isekai = IsekaiContext.AddedContent.Isekai;

            [HarmonyPriority(Priority.First)]
            public static void Postfix() {
                if (Initialized) return;
                Initialized = true;
                Main.LogDebug("first init call");

                Features.ExtraWings.Add();
                Main.LogDebug("first init call wings patched");
                Features.ExoticWeaponProficiency.Add();
                Main.LogDebug("first init call start if block");

                if (Other.IsEnabled("Exceptional Feats")) AddExceptionalFeats();
                if (Isekai.IsEnabled("Isekai Backgrounds")) AddIsekaiBackgrounds();
                if (Isekai.IsEnabled("Isekai Deities")) AddIsekaiDeities();
                if (Isekai.IsEnabled("Isekai Heritages")) AddIsekaiHeritages();
                if (Isekai.IsEnabled("Isekai Protagonist")) AddIsekaiProtagonistClass();
                if (Other.IsEnabled("Exceptional Feats") && Isekai.IsEnabled("Isekai Protagonist") && AddedContent.RestrictExceptionalFeats) RestrictExceptionalFeats();
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
                BeachEpisodeSelection.Add();
                HealthyBody.Add();
                InnerPower.Add();
                MasterSelf.Add();
                Tenacious.Add();
                Main.LogDebug("Class: BeachEpisode");

                // Special Power
                SpecialPowerSelection.Add();
                MundaneAura.Add();
                AlphaStrike.Add();
                BetaStrike.Add();
                GammaStrike.Add();
                OmegaStrike.Add();
                Regeneration.Add();
                EnergyImmunitySelection.Add();
                TrainingMontage.Add();
                BodyStrengthening.Add();
                SpellNegation.Add();
                ExtremeSpeed.Add();
                IsekaiChannelPositiveEnergy.Add();
                IsekaiChannelNegativeEnergy.Add();
                KineticPower.Add();
                SneakyMagic.Add();
                SpellMaster.Add();
                ArmorSaint.Add();
                ArmorOfStrength.Add();
                SummonBeast.Add();
                AuraOfDivineFury.Add();
                KillingIntent.Add();
                MagicalAmplification.Add();
                Reflect.Add();
                Main.LogDebug("Class: SpecialPower");

                // OP Ability
                OverpoweredAbilitySelection.Add();
                AutoBolster.Add();
                AutoEmpower.Add();
                AutoExtend.Add();
                AutoMaximize.Add();
                AutoQuicken.Add();
                AutoReach.Add();
                AutoSelective.Add();
                Instakill.Add();
                DupeGold.Add();
                PerfectRoll.Add();
                SuperBuff.Add();
                UnlimitedPower.Add();
                MindControl.Add();
                SummonCalamity.Add();
                InfiniteSpace.Add();
                TrueResurrection.Add();
                SupremeBeing.Add();
                AuraOfRighteousWrath.Add();
                if (IsekaiContext.AddedContent.Other.IsEnabled("Mythic Class Feature")) Features.IsekaiProtagonist.OverpoweredAbility.BlessingOfTheMythic.Configure();
                
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
                ExceptionalFeatSelection.Add();
                EffectImmunitySelection.Add();
                ExceptionalSummoningSelection.Add();
                ExceptionalWeaponSelection.Add();
            }
            public static void RestrictExceptionalFeats() {
                ExceptionalFeatSelection.Get().AddPrerequisite<PrerequisiteClassLevel>(c => {
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                    c.Level = 1;
                });
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

            if (IsekaiContext.AddedContent.Isekai.IsDisabled("Isekai Protagonist")) return;

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
            if (IsekaiContext.AddedContent.MergeIsekaiSpellList) IsekaiProtagonistSpellList.MergeSpellLists();

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
