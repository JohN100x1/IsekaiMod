using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using System.Linq;
using static UnityModManagerNet.UnityModManager;
using Kingmaker.Blueprints.Classes.Selection;
using IsekaiMod.Extensions;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Blueprints.Classes;
using static Kingmaker.Blueprints.Classes.BlueprintProgression;

namespace IsekaiMod.Utilities
{
    class ModSupport
    {
        protected static bool IsExpandedContentEnabled() { return IsModEnabled("ExpandedContent"); }
        protected static bool IsMysticalMayhemEnabled() { return IsModEnabled("MysticalMayhem"); }
        [HarmonyLib.HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch
        {
            static bool Initialized;

            [HarmonyLib.HarmonyAfter()]
            public static void Postfix()
            {
                if (Initialized) return;
                Initialized = true;
                if (Config.ModSettings.AddedContent.Classes.IsDisabled("Isekai Protagonist")) return;
                var IsekaiProtagonistClass = Resources.GetModBlueprint<BlueprintCharacterClass>("IsekaiProtagonistClass");
                var IsekaiProtagonistSpellList = Resources.GetModBlueprint<BlueprintSpellList>("IsekaiProtagonistSpellList");

                if (IsMysticalMayhemEnabled())
                {
                    Main.Log("Mystical Mayhem 0.1.3 Support Enabled.");
                    BlueprintAbility MeteorSwarmAbility = Resources.GetBlueprint<BlueprintAbility>("d0cd103b15494866b0444c1a961bc40f");
                    IsekaiProtagonistSpellList.SpellsByLevel[9].m_Spells.Add(MeteorSwarmAbility.ToReference<BlueprintAbilityReference>());
                }
                if (IsExpandedContentEnabled())
                {
                    Main.Log("Expanded Content 0.4.40 Support Enabled.");
                    AddExpandedContentSpells(IsekaiProtagonistSpellList);
                    AddExpandedContentDrakes(IsekaiProtagonistClass);
                }
            }

            public static void AddExpandedContentSpells(BlueprintSpellList spellList)
            {
                BlueprintAbility FuryOftheSunAbility = Resources.GetBlueprint<BlueprintAbility>("accc5584b62e4e73aa0a693f725ddf60");
                BlueprintAbility GloomblindBoltsAbility = Resources.GetBlueprint<BlueprintAbility>("e28f4633c0a2425d8895adf20cb22f8f");
                BlueprintAbility GoodberryAbility = Resources.GetBlueprint<BlueprintAbility>("f8774451760a427ab4694d10581cfda6");
                BlueprintAbility HollowBladesAbility = Resources.GetBlueprint<BlueprintAbility>("bad01be5ec684dc39019269c6eff4d6f");
                BlueprintAbility HydraulicPushAbility = Resources.GetBlueprint<BlueprintAbility>("490cc69049be462eafecf69d7030b07a");
                BlueprintAbility InflictPainAbility = Resources.GetBlueprint<BlueprintAbility>("e023af1af9c147549a8e7bd246967861");
                BlueprintAbility InflictPainMassAbility = Resources.GetBlueprint<BlueprintAbility>("ff31ae1abe3c418db7842dcc76eca7ee");
                BlueprintAbility InvokeDeityAbility = Resources.GetBlueprint<BlueprintAbility>("98f9c960637f4934bc4cca02c45cb3bc");
                BlueprintAbility RigorMortisAbility = Resources.GetBlueprint<BlueprintAbility>("2bba038472a64f67b235674c7e27d90c");
                BlueprintAbility ScourgeOfTheHorsemenAbility = Resources.GetBlueprint<BlueprintAbility>("dafdc0eef4374785aa827bf5b2059bf0");
                BlueprintAbility SlipstreamAbility = Resources.GetBlueprint<BlueprintAbility>("fe43fadb91b040b38718e88dd5744413");
                BlueprintAbility SteamRayFusilladeAbility = Resources.GetBlueprint<BlueprintAbility>("a8be30ddf37042d5b56ffaa8eae976d6");
                spellList.SpellsByLevel[2].m_Spells.Add(FuryOftheSunAbility.ToReference<BlueprintAbilityReference>());
                spellList.SpellsByLevel[3].m_Spells.Add(GloomblindBoltsAbility.ToReference<BlueprintAbilityReference>());
                spellList.SpellsByLevel[1].m_Spells.Add(GoodberryAbility.ToReference<BlueprintAbilityReference>());
                spellList.SpellsByLevel[2].m_Spells.Add(HollowBladesAbility.ToReference<BlueprintAbilityReference>());
                spellList.SpellsByLevel[1].m_Spells.Add(HydraulicPushAbility.ToReference<BlueprintAbilityReference>());
                spellList.SpellsByLevel[2].m_Spells.Add(InflictPainAbility.ToReference<BlueprintAbilityReference>());
                spellList.SpellsByLevel[5].m_Spells.Add(InflictPainMassAbility.ToReference<BlueprintAbilityReference>());
                spellList.SpellsByLevel[4].m_Spells.Add(InvokeDeityAbility.ToReference<BlueprintAbilityReference>());
                spellList.SpellsByLevel[4].m_Spells.Add(RigorMortisAbility.ToReference<BlueprintAbilityReference>());
                spellList.SpellsByLevel[9].m_Spells.Add(ScourgeOfTheHorsemenAbility.ToReference<BlueprintAbilityReference>());
                spellList.SpellsByLevel[2].m_Spells.Add(SlipstreamAbility.ToReference<BlueprintAbilityReference>());
                spellList.SpellsByLevel[7].m_Spells.Add(SteamRayFusilladeAbility.ToReference<BlueprintAbilityReference>());
            }

            public static void AddExpandedContentDrakes(BlueprintCharacterClass characterClass)
            {
                var DrakeCompanionFeatureGreen = Resources.GetBlueprint<BlueprintFeature>("bef2fb86de284ccfbf7cb391754c9d63");
                var DrakeCompanionFeatureSilver = Resources.GetBlueprint<BlueprintFeature>("c58b42a62ce14cb797e516d8608225ea");
                var DrakeCompanionFeatureBlack = Resources.GetBlueprint<BlueprintFeature>("8a41c6c006474b5fb442a3232fb39034");
                var DrakeCompanionFeatureBlue = Resources.GetBlueprint<BlueprintFeature>("3e1f0d4d82784b18b8eb28206a475737");
                var DrakeCompanionFeatureBrass = Resources.GetBlueprint<BlueprintFeature>("863864d6b19c41e0b3adc353adb01dcf");
                var DrakeCompanionFeatureRed = Resources.GetBlueprint<BlueprintFeature>("9780a4d19ca04717853aae86daa86d88");
                var DrakeCompanionFeatureWhite = Resources.GetBlueprint<BlueprintFeature>("8446d2aeb66446e78df7affbb603dccc");
                var DrakeCompanionFeatureGold = Resources.GetBlueprint<BlueprintFeature>("b7bb60773879480b8e8d49b4bbae7750");
                var DrakeCompanionProgression = Resources.GetBlueprint<BlueprintProgression>("925c3ece6b9446efa9100fe2cf98542e");
                var AnimalCompanionRank = Resources.GetBlueprint<BlueprintFeature>("1670990255e4fe948a863bafd5dbda5d");

                var DrakeCompanionSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("DrakeCompanionSelection", bp => {
                    bp.SetName("Drake Companion");
                    bp.SetDescription("You can choose a drake companion instead of an animal companion.");
                    bp.AddComponent<AddFeatureOnApply>(c => {
                        c.m_Feature = DrakeCompanionProgression.ToReference<BlueprintFeatureReference>();
                    });
                    bp.AddComponent<AddFeatureOnApply>(c => {
                        c.m_Feature = AnimalCompanionRank.ToReference<BlueprintFeatureReference>();
                    });
                    bp.m_AllowNonContextActions = false;
                    bp.IsClassFeature = true;
                    bp.Group = FeatureGroup.None;
                    bp.m_AllFeatures = new BlueprintFeatureReference[] {
                        DrakeCompanionFeatureBlack.ToReference<BlueprintFeatureReference>(),
                        DrakeCompanionFeatureBlue.ToReference<BlueprintFeatureReference>(),
                        DrakeCompanionFeatureBrass.ToReference<BlueprintFeatureReference>(),
                        DrakeCompanionFeatureGold.ToReference<BlueprintFeatureReference>(),
                        DrakeCompanionFeatureGreen.ToReference<BlueprintFeatureReference>(),
                        DrakeCompanionFeatureRed.ToReference<BlueprintFeatureReference>(),
                        DrakeCompanionFeatureSilver.ToReference<BlueprintFeatureReference>(),
                        DrakeCompanionFeatureWhite.ToReference<BlueprintFeatureReference>()
                    };
                });
                DrakeCompanionProgression.m_Classes = DrakeCompanionProgression.m_Classes.AddToArray(
                    new ClassWithLevel
                    {
                        m_Class = characterClass.ToReference<BlueprintCharacterClassReference>(),
                        AdditionalLevel = 0
                    });

                // Add Drake Selection to Pet Selection
                var IsekaiPetSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("IsekaiPetSelection");
                IsekaiPetSelection.m_AllFeatures = IsekaiPetSelection.m_AllFeatures.AddToArray(DrakeCompanionSelection.ToReference<BlueprintFeatureReference>());
                IsekaiPetSelection.m_Features = IsekaiPetSelection.m_Features.AddToArray(DrakeCompanionSelection.ToReference<BlueprintFeatureReference>());
            }
        }
        protected static bool IsModEnabled(string modName)
        {
            return modEntries.Where(mod => mod.Info.Id.Equals(modName) && mod.Enabled && !mod.ErrorOnLoading).Any();
        }
    }
}
