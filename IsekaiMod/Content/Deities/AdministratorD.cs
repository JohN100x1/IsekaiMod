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
    class AdministratorD
    {
        public static void Add()
        {
            var ChaosDomainAllowed = Resources.GetBlueprint<BlueprintFeature>("8c7d778bc39fec642befc1435b00f613");
            var EvilDomainAllowed = Resources.GetBlueprint<BlueprintFeature>("351235ac5fc2b7e47801f63d117b656c");
            var KnowledgeDomainAllowed = Resources.GetBlueprint<BlueprintFeature>("443d44b3e0ea84046a9bf304c82a0425");
            var DeathDomainAllowed = Resources.GetBlueprint<BlueprintFeature>("a099afe1b0b32554199b230699a69525");
            var DestructionDomainAllowed = Resources.GetBlueprint<BlueprintFeature>("6832681c9a91bf946a1d9da28c5be4b4");

            var CrusaderSpellbook = Resources.GetBlueprint<BlueprintSpellbook>("673d39f7da699aa408cdda6282e7dcc0");
            var ClericSpellbook = Resources.GetBlueprint<BlueprintSpellbook>("4673d19a0cf2fab4f885cc4d1353da33");
            var InquisitorSpellbook = Resources.GetBlueprint<BlueprintSpellbook>("57fab75111f377248810ece84193a5a5");

            var ClericClass = Resources.GetBlueprint<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var InquistorClass = Resources.GetBlueprint<BlueprintCharacterClass>("f1a70d9e1b0b41e49874e1fa9052a1ce");
            var WarpriestClass = Resources.GetBlueprint<BlueprintCharacterClass>("30b5e47d47a0e37438cc5a80c96cfb99");

            var FeralChampionArchetype = Resources.GetBlueprint<BlueprintArchetype>("f68ca492c9c15e241ab73735fbd0fb9f");
            var PriestOfBalance = Resources.GetBlueprint<BlueprintArchetype>("a4560e3fb5d247d68fb1a2738fcc0855");
            var AngelfireApostle = Resources.GetBlueprint<BlueprintArchetype>("857bc9fadf70f294795a9cba974a48b8");

            var ChannelNegativeAllowed = Resources.GetBlueprint<BlueprintFeature>("dab5255d809f77c4395afc2b713e9cd6");

            var ScytheProficiency = Resources.GetBlueprint<BlueprintFeature>("96c174b0ebca7b246b82d4bc4aac4574");
            var ScythePlus1 = Resources.GetBlueprint<BlueprintItem>("8933943621eca2d45b99d851bd9100d9");

            var Icon_AdministratorD = AssetLoader.LoadInternal("Deities", "ICON_ADMIN_D.png");
            var AdministratorDFeature = Helpers.CreateBlueprint<BlueprintFeature>("AdministratorDFeature", (bp => {
                bp.SetName("Administrator D");
                bp.SetDescription(
                    "Administrator D is a playful, self-proclaimed \"Ultimate evil god\" that does things simply for entertainment. "
                    + "She is sadistic and enjoys watching the protagonist struggle for survival in the new world for her own amusement."
                    + "\nDomains: Chaos, Evil, Knowledge, Death, Destruction"
                    + "\nFavoured Weapon: Scythe");
                bp.m_Icon = Icon_AdministratorD;
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
                    c.m_CharacterClass = ClericClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_Archetype = AngelfireApostle.ToReference<BlueprintArchetypeReference>();
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.m_CharacterClass = WarpriestClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_Archetype = FeralChampionArchetype.ToReference<BlueprintArchetypeReference>();
                });

                // Alignment
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Alignment = AlignmentMaskType.ChaoticEvil | AlignmentMaskType.ChaoticNeutral | AlignmentMaskType.NeutralEvil;
                });

                // Domains & Energy Channel
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        ChaosDomainAllowed.ToReference<BlueprintUnitFactReference>(),
                        EvilDomainAllowed.ToReference<BlueprintUnitFactReference>(),
                        KnowledgeDomainAllowed.ToReference<BlueprintUnitFactReference>(),
                        DeathDomainAllowed.ToReference<BlueprintUnitFactReference>(),
                        DestructionDomainAllowed.ToReference<BlueprintUnitFactReference>(),
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
                    c.m_Feature = ScytheProficiency.ToReference<BlueprintFeatureReference>();
                    c.Level = 1;
                    c.m_Archetypes = null;
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[2] {
                        InquistorClass.ToReference<BlueprintCharacterClassReference>(),
                        WarpriestClass.ToReference<BlueprintCharacterClassReference>()
                    };
                });
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { ScythePlus1.ToReference<BlueprintItemReference>() };
                    c.m_RestrictedByClass = new BlueprintCharacterClassReference[3] {
                        ClericClass.ToReference<BlueprintCharacterClassReference>(),
                        InquistorClass.ToReference<BlueprintCharacterClassReference>(),
                        WarpriestClass.ToReference<BlueprintCharacterClassReference>()
                    };
                });
            }));

            // Add to Deity Selection
            var IsekaiDeitySelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("IsekaiDeitySelection");
            IsekaiDeitySelection.m_AllFeatures = IsekaiDeitySelection.m_AllFeatures.AddToArray(AdministratorDFeature.ToReference<BlueprintFeatureReference>());
        }
    }
}
