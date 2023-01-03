using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist;
using IsekaiMod.Extensions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System.Linq;
using static Kingmaker.Blueprints.Classes.BlueprintProgression;
using static UnityModManagerNet.UnityModManager;

namespace IsekaiMod.Utilities
{
    class ModSupport
    {
        protected static bool IsExpandedContentEnabled() { return IsModEnabled("ExpandedContent"); }
        protected static bool IsMysticalMayhemEnabled() { return IsModEnabled("MysticalMayhem"); }
        protected static bool IsSpellbookMergeEnabled() { return IsModEnabled("SpellbookMerge"); }
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
                    IsekaiProtagonistSpellList.Get().AddUniqueAbility(9, MeteorSwarmAbility);
                }
                if (IsExpandedContentEnabled())
                {
                    Main.Log("Expanded Content 0.4.40 Support Enabled.");
                    AddExpandedContentSpells(IsekaiProtagonistSpellList.Get());
                    AddExpandedContentDrakes(IsekaiProtagonistClass.Get());
                }
                if (IsSpellbookMergeEnabled())
                {
                    Main.Log("Spellbook Merge 1.7.0 Support Enabled.");

                    // Allow Spellbook to be merged with Aeon, Azata, Demon, and Trickster
                    var AeonIncorporateSpellBook = Resources.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("2b7027ee76cb4c58b2cff0475bc69fbb");
                    var AzataIncorporateSpellbook = Resources.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("83385d9f4d714e4e94618703be762a20");
                    var DemonIncorporateSpellbook = Resources.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("f3ff8515355e4738b128c3d01483f1ca");
                    var TricksterIncorporateSpellbook = Resources.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("c4ef6975167d4cf5acbfd66b60e63f9c");

                    // Add Isekai Protagonist Spellbook
                    AeonIncorporateSpellBook.m_AllowedSpellbooks = AeonIncorporateSpellBook.m_AllowedSpellbooks.AddToArray(IsekaiProtagonistSpellbook.GetReference());
                    AzataIncorporateSpellbook.m_AllowedSpellbooks = AzataIncorporateSpellbook.m_AllowedSpellbooks.AddToArray(IsekaiProtagonistSpellbook.GetReference());
                    DemonIncorporateSpellbook.m_AllowedSpellbooks = DemonIncorporateSpellbook.m_AllowedSpellbooks.AddToArray(IsekaiProtagonistSpellbook.GetReference());
                    TricksterIncorporateSpellbook.m_AllowedSpellbooks = TricksterIncorporateSpellbook.m_AllowedSpellbooks.AddToArray(IsekaiProtagonistSpellbook.GetReference());

                    // Add Villain Spellbook
                    AeonIncorporateSpellBook.m_AllowedSpellbooks = AeonIncorporateSpellBook.m_AllowedSpellbooks.AddToArray(VillainSpellbook.GetReference());
                    AzataIncorporateSpellbook.m_AllowedSpellbooks = AzataIncorporateSpellbook.m_AllowedSpellbooks.AddToArray(VillainSpellbook.GetReference());
                    DemonIncorporateSpellbook.m_AllowedSpellbooks = DemonIncorporateSpellbook.m_AllowedSpellbooks.AddToArray(VillainSpellbook.GetReference());
                    TricksterIncorporateSpellbook.m_AllowedSpellbooks = TricksterIncorporateSpellbook.m_AllowedSpellbooks.AddToArray(VillainSpellbook.GetReference());
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
                spellList.AddUniqueAbility(2, FuryOftheSunAbility);
                spellList.AddUniqueAbility(3, GloomblindBoltsAbility);
                spellList.AddUniqueAbility(1, GoodberryAbility);
                spellList.AddUniqueAbility(2, HollowBladesAbility);
                spellList.AddUniqueAbility(1, HydraulicPushAbility);
                spellList.AddUniqueAbility(2, InflictPainAbility);
                spellList.AddUniqueAbility(5, InflictPainMassAbility);
                spellList.AddUniqueAbility(4, InvokeDeityAbility);
                spellList.AddUniqueAbility(4, RigorMortisAbility);
                spellList.AddUniqueAbility(9, ScourgeOfTheHorsemenAbility);
                spellList.AddUniqueAbility(2, SlipstreamAbility);
                spellList.AddUniqueAbility(7, SteamRayFusilladeAbility);
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
