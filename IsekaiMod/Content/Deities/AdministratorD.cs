using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Items;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Deities {

    internal class AdministratorD {

        // Allowed Domain & Energy
        private static readonly BlueprintFeature ChaosDomainAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("8c7d778bc39fec642befc1435b00f613");
        private static readonly BlueprintFeature EvilDomainAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("351235ac5fc2b7e47801f63d117b656c");
        private static readonly BlueprintFeature KnowledgeDomainAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("443d44b3e0ea84046a9bf304c82a0425");
        private static readonly BlueprintFeature DeathDomainAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("a099afe1b0b32554199b230699a69525");
        private static readonly BlueprintFeature DestructionDomainAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("6832681c9a91bf946a1d9da28c5be4b4");
        private static readonly BlueprintFeature ChannelNegativeAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("dab5255d809f77c4395afc2b713e9cd6");

        // Excluded Archetypes
        private static readonly BlueprintArchetype FeralChampionArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("f68ca492c9c15e241ab73735fbd0fb9f");
        private static readonly BlueprintArchetype PriestOfBalance = BlueprintTools.GetBlueprint<BlueprintArchetype>("a4560e3fb5d247d68fb1a2738fcc0855");
        private static readonly BlueprintArchetype AngelfireApostle = BlueprintTools.GetBlueprint<BlueprintArchetype>("857bc9fadf70f294795a9cba974a48b8");

        // Favored Weapon
        private static readonly BlueprintFeature ScytheProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("96c174b0ebca7b246b82d4bc4aac4574");
        private static readonly BlueprintItem ScythePlus1 = BlueprintTools.GetBlueprint<BlueprintItem>("8933943621eca2d45b99d851bd9100d9");

        public static void Add() {
            var Icon_AdministratorD = AssetLoader.LoadInternal(IsekaiContext, "Deities", "ICON_ADMIN_D.png");
            var AdministratorDFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "AdministratorDFeature", (bp => {
                bp.SetName(IsekaiContext, "Administrator D");
                bp.SetDescription(IsekaiContext,
                    "Administrator D is a playful, self-proclaimed \"Ultimate evil god\" that does things simply for entertainment. "
                    + "She is sadistic and enjoys watching the protagonist struggle for survival in the new world for her own amusement."
                    + "\nDomains: Chaos, Evil, Knowledge, Death, Destruction"
                    + "\nFavoured Weapon: Scythe");
                bp.m_Icon = Icon_AdministratorD;
                bp.HideInCharacterSheetAndLevelUp = false;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Deities };

                // Exclude from Archetypes
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.m_CharacterClass = ClassTools.ClassReferences.ClericClass;
                    c.m_Archetype = PriestOfBalance.ToReference<BlueprintArchetypeReference>();
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.m_CharacterClass = ClassTools.ClassReferences.ClericClass;
                    c.m_Archetype = AngelfireApostle.ToReference<BlueprintArchetypeReference>();
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.m_CharacterClass = ClassTools.ClassReferences.WarpriestClass;
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
                        SpellTools.Spellbook.CrusaderSpellbook.ToReference<BlueprintSpellbookReference>(),
                        SpellTools.Spellbook.ClericSpellbook.ToReference<BlueprintSpellbookReference>(),
                        SpellTools.Spellbook.InquisitorSpellbook.ToReference<BlueprintSpellbookReference>(),
                    };
                });

                // Cleric, Inquistor, Warpriest starting proficiency and weapon
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = ClassTools.ClassReferences.ClericClass;
                    c.m_Feature = ScytheProficiency.ToReference<BlueprintFeatureReference>();
                    c.Level = 1;
                    c.m_Archetypes = null;
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[2] {
                        ClassTools.ClassReferences.InquisitorClass,
                        ClassTools.ClassReferences.WarpriestClass
                    };
                });
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { ScythePlus1.ToReference<BlueprintItemReference>() };
                    c.m_RestrictedByClass = new BlueprintCharacterClassReference[3] {
                        ClassTools.ClassReferences.ClericClass,
                        ClassTools.ClassReferences.InquisitorClass,
                        ClassTools.ClassReferences.WarpriestClass
                    };
                });
            }));

            // Add to Isekai Deity Selection
            IsekaiDeitySelection.AddToSelection(AdministratorDFeature);
        }
    }
}