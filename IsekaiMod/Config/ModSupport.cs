using HarmonyLib;
using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility.TabletopTweaksBase;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;
using static Kingmaker.Blueprints.Classes.BlueprintProgression;
using static UnityModManagerNet.UnityModManager;

namespace IsekaiMod.Utilities {
    class ModSupport {
        public static bool IsExpandedContentEnabled() { 
            return IsModEnabled("ExpandedContent"); 
        }
        public static bool IsMysticalMayhemEnabled() { 
            return IsModEnabled("MysticalMayhem"); 
        }
        public static bool IsSpellbookMergeEnabled() { 
            return IsModEnabled("SpellbookMerge"); 
        }
        public static bool IsExpandedElementEnabled() { 
            return IsModEnabled("KineticistElementsExpanded"); 
        }
        public static bool IsTableTopTweakBaseEnabled() { 
            return IsModEnabled("TabletopTweaks-Base"); 
        }

        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch {
            static bool Initialized;

            [HarmonyAfter()]
            public static void Postfix() {
                if (Initialized) return;
                Initialized = true;
                if (IsekaiContext.AddedContent.Isekai.IsDisabled("Isekai Protagonist")) return;
                if (IsTableTopTweakBaseEnabled()) {
                    Main.Log("TabletopTweaks-Base 2.5.2 Support Enabled.");
                    AutoRime.Add();
                    AutoBurning.Add();
                    AutoFlaring.Add();
                    AutoPiercing.Add();
                    AutoSolidShadows.Add();
                    AutoEncouraging.Add();
                }
                if (IsMysticalMayhemEnabled()) {
                    Main.Log("Mystical Mayhem 0.1.5 Support Enabled.");
                    if (!IsekaiContext.AddedContent.MergeIsekaiSpellList) {
                        BlueprintAbility MeteorSwarmAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d0cd103b15494866b0444c1a961bc40f");
                        IsekaiProtagonistSpellList.Get().SpellsByLevel[9].m_Spells.Add(MeteorSwarmAbility.ToReference<BlueprintAbilityReference>());
                    }
                }
                if (IsExpandedContentEnabled()) {
                    Main.Log("Expanded Content 0.5.2 Support Enabled.");
                    AddExpandedContentSpells(IsekaiProtagonistSpellList.Get());
                    AddExpandedContentDrakes(IsekaiProtagonistClass.Get());
                }
                if (IsSpellbookMergeEnabled()) {
                    Main.Log("Spellbook Merge 1.7.1 Support Enabled.");

                    // Allow Spellbook to be merged with Aeon, Azata, Demon, and Trickster
                    var AeonIncorporateSpellBook = BlueprintTools.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("2b7027ee76cb4c58b2cff0475bc69fbb");
                    var AzataIncorporateSpellbook = BlueprintTools.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("83385d9f4d714e4e94618703be762a20");
                    var DemonIncorporateSpellbook = BlueprintTools.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("f3ff8515355e4738b128c3d01483f1ca");
                    var TricksterIncorporateSpellbook = BlueprintTools.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("c4ef6975167d4cf5acbfd66b60e63f9c");
                    // Add Isekai Protagonist Spellbook
                    ThingsNotHandledByTTTCore.RegisterForPrestigeSpellbook(AeonIncorporateSpellBook, IsekaiProtagonistSpellbook.Get());
                    ThingsNotHandledByTTTCore.RegisterForPrestigeSpellbook(AzataIncorporateSpellbook, IsekaiProtagonistSpellbook.Get());
                    ThingsNotHandledByTTTCore.RegisterForPrestigeSpellbook(DemonIncorporateSpellbook, IsekaiProtagonistSpellbook.Get());
                    ThingsNotHandledByTTTCore.RegisterForPrestigeSpellbook(TricksterIncorporateSpellbook, IsekaiProtagonistSpellbook.Get());
                    // Add Villain Spellbook
                    ThingsNotHandledByTTTCore.RegisterForPrestigeSpellbook(AeonIncorporateSpellBook, VillainSpellbook.Get());
                    ThingsNotHandledByTTTCore.RegisterForPrestigeSpellbook(AzataIncorporateSpellbook, VillainSpellbook.Get());
                    ThingsNotHandledByTTTCore.RegisterForPrestigeSpellbook(DemonIncorporateSpellbook, VillainSpellbook.Get());
                    ThingsNotHandledByTTTCore.RegisterForPrestigeSpellbook(TricksterIncorporateSpellbook, VillainSpellbook.Get());

                }
            }

            public static void AddExpandedContentSpells(BlueprintSpellList spellList) {
                //if enabled we grab these through the merge anyway
                if (IsekaiContext.AddedContent.MergeIsekaiSpellList) return;

                BlueprintAbility FuryOftheSunAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("accc5584b62e4e73aa0a693f725ddf60");
                BlueprintAbility GloomblindBoltsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e28f4633c0a2425d8895adf20cb22f8f");
                BlueprintAbility GoodberryAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f8774451760a427ab4694d10581cfda6");
                BlueprintAbility HollowBladesAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("bad01be5ec684dc39019269c6eff4d6f");
                BlueprintAbility HydraulicPushAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("490cc69049be462eafecf69d7030b07a");
                BlueprintAbility InflictPainAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e023af1af9c147549a8e7bd246967861");
                BlueprintAbility InflictPainMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ff31ae1abe3c418db7842dcc76eca7ee");
                BlueprintAbility InvokeDeityAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("98f9c960637f4934bc4cca02c45cb3bc");
                BlueprintAbility RigorMortisAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("2bba038472a64f67b235674c7e27d90c");
                BlueprintAbility ScourgeOfTheHorsemenAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("dafdc0eef4374785aa827bf5b2059bf0");
                BlueprintAbility SlipstreamAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("fe43fadb91b040b38718e88dd5744413");
                BlueprintAbility SteamRayFusilladeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a8be30ddf37042d5b56ffaa8eae976d6");
                BlueprintAbility WallOfFireAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("80189142f7c640f39195defdc9777b27");
                BlueprintAbility ZephyrsFleetnessAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a49ee6f1ec6744a6b16e3476a504e2a9");
                BlueprintAbility HypnoticPatternAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("56b8f0304a704a67b3c35cbe8c774854");
                BlueprintAbility ClaySkinAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("31ed0a88513246afac5b0bea60a728a9");
                BlueprintAbility EntropicShieldAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ff9b4a7437d44c5fa29a7573a63728f5");
                BlueprintAbility ShieldOfFortificationAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5a20c33fce1c4d90b0d8e71d7918d699");
                BlueprintAbility ShieldOfFortificationGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a848a5aeb1be4bbdbdf79041c5890098");
                BlueprintAbility DanceOfAHundredCutsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7a7877faca0c4e98a5452d29967677e6");
                BlueprintAbility DanceOfAThousandCutsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a4fd2673b9d44b8c8d20714b2ee51df6");

                BlueprintAbility RevivingFinaleAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("9f8ab280738a4578a294ccb8f0b25fa7");
                BlueprintAbility DeadlyFinaleAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("3385edd23aad4795861425acfa798d64");
                BlueprintAbility PurgingFinaleAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("6eff7010684143c5bcd47120718c75ef");
                BlueprintAbility StunningFinaleAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a1f0d4c3ce2c4c2eb705b18861f14708");
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, ShieldOfFortificationAbility, 1);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, EntropicShieldAbility, 1);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, GoodberryAbility, 1);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, HydraulicPushAbility, 1);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, HypnoticPatternAbility, 2);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, FuryOftheSunAbility, 2);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, HollowBladesAbility, 2);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, InflictPainAbility, 2);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, SlipstreamAbility, 2);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, ShieldOfFortificationGreaterAbility, 3);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, ClaySkinAbility, 3);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, ZephyrsFleetnessAbility, 3);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, RevivingFinaleAbility, 3);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, PurgingFinaleAbility, 3);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, GloomblindBoltsAbility, 3);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, DanceOfAHundredCutsAbility, 4);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, WallOfFireAbility, 4);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, InvokeDeityAbility, 4);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, RigorMortisAbility, 4);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, StunningFinaleAbility, 5);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, InflictPainMassAbility, 5);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, DanceOfAThousandCutsAbility, 6);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, DeadlyFinaleAbility, 6);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, SteamRayFusilladeAbility, 7);
                ThingsNotHandledByTTTCore.RegisterSpell(spellList, ScourgeOfTheHorsemenAbility, 9);
            }

            public static void AddExpandedContentDrakes(BlueprintCharacterClass characterClass) {
                // Add Isekai Protagonist Class to Drake Progression
                var DrakeCompanionProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("925c3ece6b9446efa9100fe2cf98542e");
                DrakeCompanionProgression.m_Classes = DrakeCompanionProgression.m_Classes.AddToArray(
                    new ClassWithLevel {
                        m_Class = characterClass.ToReference<BlueprintCharacterClassReference>(),
                        AdditionalLevel = 0
                    });

                // Add Drake Selection to Pet Selection
                var DrakeCompanionSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("d78cdd3dd370473ea1ee3003ea6e83f2");
                IsekaiPetSelection.AddToSelection(DrakeCompanionSelection);
            }
        }

        protected static bool IsModEnabled(string modName) {
            return modEntries.Where(mod => mod.Info.Id.Equals(modName) && mod.Enabled && !mod.ErrorOnLoading).Any();
        }
    }
}
