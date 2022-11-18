using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using System.Linq;
using static UnityModManagerNet.UnityModManager;
using Kingmaker.Blueprints.Classes.Selection;
using IsekaiMod.Extensions;
using Kingmaker.Blueprints.Classes;
using static Kingmaker.Blueprints.Classes.BlueprintProgression;
using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist;

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
                if (IsMysticalMayhemEnabled())
                {
                    Main.Log("Mystical Mayhem 0.1.3 Support Enabled.");
                    BlueprintAbility MeteorSwarmAbility = Resources.GetBlueprint<BlueprintAbility>("d0cd103b15494866b0444c1a961bc40f");
                    IsekaiProtagonistSpellList.Get().SpellsByLevel[9].m_Spells.Add(MeteorSwarmAbility.ToReference<BlueprintAbilityReference>());
                }
                if (IsExpandedContentEnabled())
                {
                    Main.Log("Expanded Content 0.4.40 Support Enabled.");
                    AddExpandedContentSpells(IsekaiProtagonistSpellList.Get());
                    AddExpandedContentDrakes(IsekaiProtagonistClass.Get());
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
                // Add Isekai Protagonist Class to Drake Progression
                var DrakeCompanionProgression = Resources.GetBlueprint<BlueprintProgression>("925c3ece6b9446efa9100fe2cf98542e");
                DrakeCompanionProgression.m_Classes = DrakeCompanionProgression.m_Classes.AddToArray(
                    new ClassWithLevel
                    {
                        m_Class = characterClass.ToReference<BlueprintCharacterClassReference>(),
                        AdditionalLevel = 0
                    });

                // Add Drake Selection to Pet Selection
                var DrakeCompanionSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("d78cdd3dd370473ea1ee3003ea6e83f2");
                IsekaiPetSelection.AddToSelection(DrakeCompanionSelection);
            }
        }
        protected static bool IsModEnabled(string modName)
        {
            return modEntries.Where(mod => mod.Info.Id.Equals(modName) && mod.Enabled && !mod.ErrorOnLoading).Any();
        }
    }
}
