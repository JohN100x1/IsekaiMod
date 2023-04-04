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

    internal class Ristarte {

        // Allowed Domain & Energy
        private static readonly BlueprintFeature HealingDomainAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("73ae164c388990c43ade94cfe8ed5755");
        private static readonly BlueprintFeature GoodDomainAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("882521af8012fc749930b03dc18a69de");
        private static readonly BlueprintFeature TravelDomainAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("c008853fe044bd442ae8bd22260592b7");
        private static readonly BlueprintFeature LuckDomainAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("d4e192475bb1a1045859c7664addd461");
        private static readonly BlueprintFeature ChannelPositiveAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("8c769102f3996684fb6e09a2c4e7e5b9");

        // Excluded Archetypes
        private static readonly BlueprintArchetype FeralChampionArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("f68ca492c9c15e241ab73735fbd0fb9f");
        private static readonly BlueprintArchetype PriestOfBalance = BlueprintTools.GetBlueprint<BlueprintArchetype>("a4560e3fb5d247d68fb1a2738fcc0855");

        // Favored Weapon
        private static readonly BlueprintFeature LongswordProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("62e27ffd9d53e14479f73da29760f64e");
        private static readonly BlueprintItem ColdIronLongsword = BlueprintTools.GetBlueprint<BlueprintItem>("533e10c8b4c6a4940a3767d096f4f05d");

        public static void Add() {
            var Icon_Ristarte = AssetLoader.LoadInternal(IsekaiContext, "Deities", "ICON_RISTARTE.png");
            var GoddessRistarteFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "GoddessRistarteFeature", (bp => {
                bp.SetName(IsekaiContext, "Ristarte");
                bp.SetDescription(IsekaiContext,
                    "Ristarte is the goddess of healing who aids reincarnated heroes in their journey to defeat the demon lord in their new world. "
                    + "Though the healing abilities of Ristarte are only as good as a common herb, her kind and caring smile provide an even greater emotional healing."
                    + "\nDomains: Healing, Good, Travel, Luck"
                    + "\nFavoured Weapon: Longsword");
                bp.m_Icon = Icon_Ristarte;
                bp.HideInCharacterSheetAndLevelUp = false;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Deities };

                // Exclude from Archetypes
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.m_CharacterClass = ClassTools.ClassReferences.ClericClass;
                    c.m_Archetype = PriestOfBalance.ToReference<BlueprintArchetypeReference>();
                });
                bp.AddComponent<PrerequisiteNoArchetype>(c => {
                    c.m_CharacterClass = ClassTools.ClassReferences.WarpriestClass;
                    c.m_Archetype = FeralChampionArchetype.ToReference<BlueprintArchetypeReference>();
                });

                // Alignment
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Alignment = AlignmentMaskType.Good | AlignmentMaskType.TrueNeutral;
                });

                // Domains & Energy Channel
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        HealingDomainAllowed.ToReference<BlueprintUnitFactReference>(),
                        GoodDomainAllowed.ToReference<BlueprintUnitFactReference>(),
                        TravelDomainAllowed.ToReference<BlueprintUnitFactReference>(),
                        LuckDomainAllowed.ToReference<BlueprintUnitFactReference>(),
                        ChannelPositiveAllowed.ToReference<BlueprintUnitFactReference>()
                    };
                });

                // Lock Spellbook on off-alignment
                bp.AddComponent<ForbidSpellbookOnAlignmentDeviation>(c => {
                    c.m_Spellbooks = new BlueprintSpellbookReference[] {
                        SpellTools.Spellbook.CrusaderSpellbook.ToReference<BlueprintSpellbookReference>(),
                        SpellTools.Spellbook.ClericSpellbook.ToReference<BlueprintSpellbookReference>(),
                        SpellTools.Spellbook.InquisitorSpellbook.ToReference<BlueprintSpellbookReference>()
                    };
                });

                // Cleric, Inquistor, Warpriest starting proficiency and weapon
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = ClassTools.ClassReferences.ClericClass;
                    c.m_Feature = LongswordProficiency.ToReference<BlueprintFeatureReference>();
                    c.Level = 1;
                    c.m_Archetypes = null;
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[2] {
                        ClassTools.ClassReferences.InquisitorClass,
                        ClassTools.ClassReferences.WarpriestClass
                    };
                });
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { ColdIronLongsword.ToReference<BlueprintItemReference>() };
                    c.m_RestrictedByClass = new BlueprintCharacterClassReference[3] {
                        ClassTools.ClassReferences.ClericClass,
                        ClassTools.ClassReferences.InquisitorClass,
                        ClassTools.ClassReferences.WarpriestClass
                    };
                });
            }));

            // Add to Isekai Deity Selection
            IsekaiDeitySelection.AddToSelection(GoddessRistarteFeature);
        }
    }
}