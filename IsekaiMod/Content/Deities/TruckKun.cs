using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Deities
{
    class TruckKun
    {
        public static void Add()
        {
            var ArtificeDomainAllowed = Resources.GetBlueprint<BlueprintFeature>("9656b1c7214180f4b9a6ab56f83b92fb");
            var DestructionDomainAllowed = Resources.GetBlueprint<BlueprintFeature>("6832681c9a91bf946a1d9da28c5be4b4");
            var ReposeDomainAllowed = Resources.GetBlueprint<BlueprintFeature>("076ba1e3a05fac146acfc956a9f41e95");
            var TravelDomainAllowed = Resources.GetBlueprint<BlueprintFeature>("c008853fe044bd442ae8bd22260592b7");

            var CrusaderSpellbook = Resources.GetBlueprint<BlueprintSpellbook>("673d39f7da699aa408cdda6282e7dcc0");
            var ClericSpellbook = Resources.GetBlueprint<BlueprintSpellbook>("4673d19a0cf2fab4f885cc4d1353da33");
            var InquisitorSpellbook = Resources.GetBlueprint<BlueprintSpellbook>("57fab75111f377248810ece84193a5a5");

            var ClericClass = Resources.GetBlueprint<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var InquistorClass = Resources.GetBlueprint<BlueprintCharacterClass>("f1a70d9e1b0b41e49874e1fa9052a1ce");
            var WarpriestClass = Resources.GetBlueprint<BlueprintCharacterClass>("30b5e47d47a0e37438cc5a80c96cfb99");

            var FeralChampionArchetype = Resources.GetBlueprint<BlueprintArchetype>("f68ca492c9c15e241ab73735fbd0fb9f");
            var PriestOfBalance = Resources.GetBlueprint<BlueprintArchetype>("a4560e3fb5d247d68fb1a2738fcc0855");

            var ChannelPositiveAllowed = Resources.GetBlueprint<BlueprintFeature>("8c769102f3996684fb6e09a2c4e7e5b9");
            var ChannelNegativeAllowed = Resources.GetBlueprint<BlueprintFeature>("dab5255d809f77c4395afc2b713e9cd6");

            var ShieldsProficiency = Resources.GetBlueprint<BlueprintFeature>("cb8686e7357a68c42bdd9d4e65334633");
            var ShieldBashFeature = Resources.GetBlueprint<BlueprintFeature>("121811173a614534e8720d7550aae253");
            var HeavyShieldPlus1 = Resources.GetBlueprint<BlueprintItem>("5c7b898a1bfb6cb4f8c14a0ebc143abe");

            var Icon_Truck = AssetLoader.LoadInternal("Deities", "ICON_TRUCK.png");
            var TruckKunFeature = Helpers.CreateBlueprint<BlueprintFeature>("TruckKunFeature", (bp => {
                bp.SetName("Truck-kun");
                bp.SetDescription(
                    "Truck-kun is a menance of the streets, a killer that prowls the road before it smashes their victim so hard they get transported into another world. "
                    + "Many fear death brought by Truck-kun, but there are some who believe that their reincarnation will bring them into a harem paradise. "
                    + "Beware of the streets, and look on both sides of the road, or else you might be its latest victim."
                    + "\nDomains: Artifice, Destruction, Repose, Travel"
                    + "\nFavoured Weapon: Heavy Shield Bash");
                bp.m_Icon = Icon_Truck;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.HideInCharacterSheetAndLevelUp = false;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Deities };

                // Exclude from Archetypes
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.m_CharacterClass = ClericClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_Archetype = PriestOfBalance.ToReference<BlueprintArchetypeReference>();
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.m_CharacterClass = WarpriestClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_Archetype = FeralChampionArchetype.ToReference<BlueprintArchetypeReference>();
                });

                // Alignment
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Alignment = AlignmentMaskType.LawfulNeutral | AlignmentMaskType.ChaoticNeutral | AlignmentMaskType.TrueNeutral | AlignmentMaskType.NeutralGood | AlignmentMaskType.NeutralEvil;
                });

                // Domains
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[1] { ArtificeDomainAllowed.ToReference<BlueprintUnitFactReference>() };
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[1] { DestructionDomainAllowed.ToReference<BlueprintUnitFactReference>() };
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[1] { ReposeDomainAllowed.ToReference<BlueprintUnitFactReference>() };
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[1] { TravelDomainAllowed.ToReference<BlueprintUnitFactReference>() };
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[1] { ChannelPositiveAllowed.ToReference<BlueprintUnitFactReference>() };
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[1] { ChannelNegativeAllowed.ToReference<BlueprintUnitFactReference>() };
                });

                // Lock Spellbook on off-alignment
                bp.AddComponent<ForbidSpellbookOnAlignmentDeviation>(c => {
                    c.m_Spellbooks = new BlueprintSpellbookReference[1] { CrusaderSpellbook.ToReference<BlueprintSpellbookReference>() };
                    c.m_Spellbooks = new BlueprintSpellbookReference[1] { ClericSpellbook.ToReference<BlueprintSpellbookReference>() };
                    c.m_Spellbooks = new BlueprintSpellbookReference[1] { InquisitorSpellbook.ToReference<BlueprintSpellbookReference>() };
                });

                // Cleric, Inquistor, Warpriest starting proficiency and weapon
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = ClericClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_Feature = ShieldsProficiency.ToReference<BlueprintFeatureReference>();
                    c.Level = 1;
                    c.m_Archetypes = null;
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[2] {
                        InquistorClass.ToReference<BlueprintCharacterClassReference>(),
                        WarpriestClass.ToReference<BlueprintCharacterClassReference>()
                    };
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = ClericClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_Feature = ShieldBashFeature.ToReference<BlueprintFeatureReference>();
                    c.Level = 1;
                    c.m_Archetypes = null;
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[2] {
                        InquistorClass.ToReference<BlueprintCharacterClassReference>(),
                        WarpriestClass.ToReference<BlueprintCharacterClassReference>()
                    };
                });
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { HeavyShieldPlus1.ToReference<BlueprintItemReference>() };
                    c.m_RestrictedByClass = new BlueprintCharacterClassReference[3] {
                        ClericClass.ToReference<BlueprintCharacterClassReference>(),
                        InquistorClass.ToReference<BlueprintCharacterClassReference>(),
                        WarpriestClass.ToReference<BlueprintCharacterClassReference>()
                    };
                });
            }));

            // Add to Deity Selection
            var DeitySelection = Resources.GetBlueprint<BlueprintFeatureSelection>("59e7a76987fe3b547b9cce045f4db3e4");
            DeitySelection.m_AllFeatures = DeitySelection.m_AllFeatures.AddToArray(TruckKunFeature.ToReference<BlueprintFeatureReference>());
        }
    }
}
