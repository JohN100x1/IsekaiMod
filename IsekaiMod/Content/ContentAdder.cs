using HarmonyLib;
using IsekaiMod.Config;
using IsekaiMod.Content.Classes.Deathsnatcher;
using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes;
using IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes.Overlord;
using IsekaiMod.Content.Features.Deathsnatcher;
using IsekaiMod.Content.Features.ExceptionalFeats;
using IsekaiMod.Content.Features.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord;
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
            [HarmonyPostfix]
            public static void CreateNewBlueprints() {
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
                // Isekai Protagonist Class
                IsekaiProtagonistSpellList.Add();
                IsekaiProtagonistSpellsPerDay.Add();
                IsekaiProtagonistSpellsKnown.Add();
                IsekaiProtagonistSpellbook.Add();
                IsekaiProtagonistClass.Add();
                Main.LogDebug("Class: Configured");

                // Isekai Protagonist Features
                IsekaiProtagonistProficiencies.Add();
                IsekaiProtagonistCantrips.Add();
                IsekaiProtagonistBonusFeatSelection.Add();
                IsekaiProtagonistTalentSelection.Add();
                IsekaiPetSelection.Add();
                PlotArmor.Add();
                StartingWeaponSelection.Add();
                IsekaiFighterTraining.Add();
                SignatureMoveSelection.Add();
                IsekaiFastMovement.Add();
                OtherworldlyStamina.Add();
                IsekaiQuickFooted.Add();
                IsekaiAuraSelection.Add();
                SummonHarem.Add();
                SecondReincarnation.Add();
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
                MetaLuck.Add();
                AuraOfRighteousWrath.Add();
                if (Other.IsEnabled("Mythic Class Feature")) BlessingOfTheMythic.Configure();
                
                Main.LogDebug("Class: OP");

                // God Emperor Archetype
                GodEmperorProficiencies.Add();
                NascentApotheosis.Add();
                DivineArray.Add();
                GodEmperorEnergySelection.Add();
                AuraOfGoldenProtection.Add();
                AuraOfMajesty.Add();
                GodlyVessel.Add();
                SiphoningAuraFeature.Add();
                CelestialRealm.Add();
                Godhood.Add();
                GodEmperorArchetype.Add();
                Main.LogDebug("Class: Emperor");

                // Edge Lord Archetype
                EdgeLordProficiencies.Add();
                SupersonicCombat.Add();
                EdgeLordFastMovement.Add();
                ExtraStrike.Add();
                EdgeLordArchetype.Add();
                Main.LogDebug("Class: EdgeLord");

                // Hero Archetype
                HeroProficiencies.Add();
                GracefulCombat.Add();
                TrueSmite.Add();
                TrueMark.Add();
                HerosPresence.Add();
                HeroArchetype.Add();
                Main.LogDebug("Class: Hero");

                // Mastermind Archetype
                MastermindSpellbook.Add();
                MastermindProficiencies.Add();
                MastermindQuickFooted.Add();
                MastermindArchetype.Add();
                Main.LogDebug("Class: Mastermind");

                // Overlord Archetype
                OverlordSpellbook.Add();
                OverlordProficiencies.Add();
                CorruptAuraFeature.Add();
                OverlordQuickFooted.Add();
                SecondFormFeature.Add();
                OverlordArchetype.Add();
                Main.LogDebug("Class: Overlord");

                // Add Progression & Prebuild after Class and class-dependent features are added
                PrebuildIsekaiProtagonistFeatureList.Add();
                IsekaiProtagonistProgression.Add();

                // Patch Prestige Class Spellbooks
                PrestigeClassReplaceSpellbook.Patch();
                Main.LogDebug("Class: Prestige");

                // Deathsnatcher animal Companion (Depends on IsekaiProtagonistClass)
                DeathsnatcherClass.Add();
                DeathsnatcherSizeBaby.Add();
                DeathsnatcherResistances.Add();
                DeathsnatcherCommandUndead.Add();
                DeathsnatcherAnimateDead.Add();
                DeathsnatcherCreateUndead.Add();
                DeathsnatcherFingerOfDeath.Add();
                DeathsnatcherFastHealing.Add();
                DeathsnatcherPoisonSting.Add();
                DeathsnatcherUndeadMaster.Add();
                DeathsnatcherProgression.Add();
                DeathsnatcherUnit.Add();
                Main.LogDebug("Class: Deathsnatcher");

                // Add extra dialogue (Depends on IsekaiProtagonistClass)
                if (Isekai.IsEnabled("Isekai Dialogue")) AddIsekaiDialogue();
                Main.LogDebug("Class: Dialogue");

                LegacySelection.ConfigureStep2();
                Main.LogDebug("Class: Done");

            }
            public static void AddIsekaiDialogue() {
                Dialogue.IsekaiHulrun.Add();
                Dialogue.IsekaiRadiance.Add();
                Dialogue.IsekaiKaylessaDrowLeader.Add();
                Dialogue.IsekaiHorgus.Add();
                Dialogue.IsekaiMinagho.Add();
                Dialogue.IsekaiAnevia.Add();
            }
            public static void AddIsekaiHeritages() {
                // Add Heritages
                Heritages.HumanHeritageSelection.CreateDummy();
                Heritages.IsekaiSuccubusHeritage.Add();
                Heritages.IsekaiAngelHeritage.Add();
                Heritages.IsekaiVampireHeritage.Add();
                Heritages.IsekaiSprigganHeritage.Add();
                Heritages.IsekaiDarkElfHeritage.Add();
                Heritages.IsekaiHighElfHeritage.Add();
                Heritages.IsekaiWoodElfHeritage.Add();
                Heritages.IsekaiFurryHeritage.Add();

                Heritages.IsekaiHighHumanHeritage.Add();

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
                Deities.IsekaiDeitySelection.Add();

                // Add Deities to the Isekai Deity Selection
                Deities.TruckKun.Add();
                Deities.Aqua.Add();
                Deities.Ristarte.Add();
                Deities.AdministratorD.Add();
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
            Deities.IsekaiDeitySelection.PatchDeitySelection();
            Main.LogDebug("Postfix Patching: Deities fixed");

            if (IsekaiContext.AddedContent.Isekai.IsEnabled("Isekai Heritages")) Heritages.HumanHeritageSelection.Patch();

            if (IsekaiContext.AddedContent.Isekai.IsDisabled("Isekai Protagonist")) return;

            LegacySelection.ConfigureStep3();



            //done here because it should be done after all spells have been initialized and were added to the canon books
            if (IsekaiContext.AddedContent.MergeIsekaiSpellList) IsekaiProtagonistSpellList.MergeSpellLists();

            if (ModSupport.IsTableTopTweakBaseEnabled()) {
                PatchTableTopTweakCore();
            }
            if (ModSupport.IsExpandedContentEnabled()) { 
                DreadKnightLegacy.PatchProgression();
            }
        }

        private static void PatchTableTopTweakCore() {
            var paladincapstone = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("a92b9d62930247759b2796a6c2103c0e");
            var oraclecapstone = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("c898b6e4918c41c3a351c9a882c65cea");
            var shamancapstone = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("6e32488a2cec4ba586508db4f78b062d");
            var sorcerercapstone = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("40f13b4925c24e50bc8f3d5fe4d42a05");
            
            
            if (paladincapstone != null) {
                HeroicLegacy.Get().LevelEntries = HeroicLegacy.Get().LevelEntries.AddToArray(Helpers.CreateLevelEntry(20, paladincapstone));
            }
            if (oraclecapstone != null) {
                OracleLegacy.Get().LevelEntries = OracleLegacy.Get().LevelEntries.AddToArray(Helpers.CreateLevelEntry(20, oraclecapstone));
            }
            if (shamancapstone != null) {
                ShamanLegacy.Get().LevelEntries = ShamanLegacy.Get().LevelEntries.AddToArray(Helpers.CreateLevelEntry(20, shamancapstone));
            }
            if (sorcerercapstone != null) {
                SorcererLegacy.Get().LevelEntries = SorcererLegacy.Get().LevelEntries.AddToArray(Helpers.CreateLevelEntry(20, sorcerercapstone));
            }
            MagusLegacy.PatchForBroadStudy();
        }

    }
}
