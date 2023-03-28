using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Deities {

    internal class TruckKun {

        // Allowed Domain & Energy
        private static readonly BlueprintFeature ArtificeDomainAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("9656b1c7214180f4b9a6ab56f83b92fb");
        private static readonly BlueprintFeature DestructionDomainAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("6832681c9a91bf946a1d9da28c5be4b4");
        private static readonly BlueprintFeature ReposeDomainAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("076ba1e3a05fac146acfc956a9f41e95");
        private static readonly BlueprintFeature TravelDomainAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("c008853fe044bd442ae8bd22260592b7");
        private static readonly BlueprintFeature ChannelPositiveAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("8c769102f3996684fb6e09a2c4e7e5b9");
        private static readonly BlueprintFeature ChannelNegativeAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("dab5255d809f77c4395afc2b713e9cd6");

        // Excluded Archetypes
        private static readonly BlueprintArchetype FeralChampionArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("f68ca492c9c15e241ab73735fbd0fb9f");
        private static readonly BlueprintArchetype AngelfireApostle = BlueprintTools.GetBlueprint<BlueprintArchetype>("857bc9fadf70f294795a9cba974a48b8");

        // Effective Class
        private static readonly BlueprintCharacterClass ClericClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
        private static readonly BlueprintCharacterClass InquistorClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("f1a70d9e1b0b41e49874e1fa9052a1ce");
        private static readonly BlueprintCharacterClass WarpriestClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("30b5e47d47a0e37438cc5a80c96cfb99");

        // Effective Spellbook
        private static readonly BlueprintSpellbook CrusaderSpellbook = BlueprintTools.GetBlueprint<BlueprintSpellbook>("673d39f7da699aa408cdda6282e7dcc0");
        private static readonly BlueprintSpellbook ClericSpellbook = BlueprintTools.GetBlueprint<BlueprintSpellbook>("4673d19a0cf2fab4f885cc4d1353da33");
        private static readonly BlueprintSpellbook InquisitorSpellbook = BlueprintTools.GetBlueprint<BlueprintSpellbook>("57fab75111f377248810ece84193a5a5");

        // Favored Weapon
        private static readonly BlueprintFeature ShieldsProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("cb8686e7357a68c42bdd9d4e65334633");
        private static readonly BlueprintFeature ShieldBashFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("121811173a614534e8720d7550aae253");
        private static readonly BlueprintItem HeavyShieldPlus1 = BlueprintTools.GetBlueprint<BlueprintItem>("5c7b898a1bfb6cb4f8c14a0ebc143abe");

        public static void Add() {
            var Icon_Truck = AssetLoader.LoadInternal(IsekaiContext, "Deities", "ICON_TRUCK.png");
            var TruckKunFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "TruckKunFeature", (bp => {
                bp.SetName(IsekaiContext, "Truck-kun");
                bp.SetDescription(IsekaiContext,
                    "Truck-kun is a menace of the streets, a killer that prowls the road before it smashes their victim so hard they get transported into another world. "
                    + "Many fear death brought by Truck-kun, but there are some who believe that their reincarnation will bring them into a harem paradise. "
                    + "Beware of the streets, and look at both sides of the road, or else you might be its latest victim."
                    + "\nDomains: Artifice, Destruction, Repose, Travel"
                    + "\nFavoured Weapon: Heavy Shield Bash");
                bp.m_Icon = Icon_Truck;
                bp.HideInCharacterSheetAndLevelUp = false;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Deities };

                // Exclude from Archetypes
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.m_CharacterClass = ClericClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_Archetype = AngelfireApostle.ToReference<BlueprintArchetypeReference>();
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.m_CharacterClass = WarpriestClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_Archetype = FeralChampionArchetype.ToReference<BlueprintArchetypeReference>();
                });

                // Alignment
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Alignment = AlignmentMaskType.LawfulNeutral | AlignmentMaskType.ChaoticNeutral | AlignmentMaskType.TrueNeutral | AlignmentMaskType.NeutralGood | AlignmentMaskType.NeutralEvil;
                });

                // Domains & Energy Channel
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        ArtificeDomainAllowed.ToReference<BlueprintUnitFactReference>(),
                        DestructionDomainAllowed.ToReference<BlueprintUnitFactReference>(),
                        ReposeDomainAllowed.ToReference<BlueprintUnitFactReference>(),
                        TravelDomainAllowed.ToReference<BlueprintUnitFactReference>(),
                        ChannelPositiveAllowed.ToReference<BlueprintUnitFactReference>(),
                        ChannelNegativeAllowed.ToReference<BlueprintUnitFactReference>()
                    };
                });

                // Lock Spellbook on off-alignment
                bp.AddComponent<ForbidSpellbookOnAlignmentDeviation>(c => {
                    c.m_Spellbooks = new BlueprintSpellbookReference[] {
                        CrusaderSpellbook.ToReference<BlueprintSpellbookReference>(),
                        ClericSpellbook.ToReference<BlueprintSpellbookReference>(),
                        InquisitorSpellbook.ToReference<BlueprintSpellbookReference>()
                    };
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

            // Add to Isekai Deity Selection
            IsekaiDeitySelection.AddToSelection(TruckKunFeature);
        }
    }
}