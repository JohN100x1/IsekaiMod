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

    internal class Aqua {

        // Allowed Domain & Energy
        private static readonly BlueprintFeature WaterDomainAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("8f49469c40e2c6e4db61296558e08966");
        private static readonly BlueprintFeature HealingDomainAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("73ae164c388990c43ade94cfe8ed5755");
        private static readonly BlueprintFeature GoodDomainAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("882521af8012fc749930b03dc18a69de");
        private static readonly BlueprintFeature ProtectionDomainAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("d4ce7592bd12d63439907ad64e986e59");
        private static readonly BlueprintFeature ChannelPositiveAllowed = BlueprintTools.GetBlueprint<BlueprintFeature>("8c769102f3996684fb6e09a2c4e7e5b9");

        // Excluded Archetypes
        private static readonly BlueprintArchetype FeralChampionArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("f68ca492c9c15e241ab73735fbd0fb9f");
        private static readonly BlueprintArchetype PriestOfBalance = BlueprintTools.GetBlueprint<BlueprintArchetype>("a4560e3fb5d247d68fb1a2738fcc0855");

        // Favored Weapon
        private static readonly BlueprintFeature QuarterstaffProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("aed4f88b52ae0fb468895f90da854ad4");
        private static readonly BlueprintItem QuarterstaffPlus1 = BlueprintTools.GetBlueprint<BlueprintItem>("2c4a3077efc2378499c60b03d2b0527a");

        public static void Add() {
            var Icon_Aqua = AssetLoader.LoadInternal(IsekaiContext, "Deities", "ICON_AQUA.png");
            var GoddessAquaFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "GoddessAquaFeature", (bp => {
                bp.SetName(IsekaiContext, "Aqua");
                bp.SetDescription(IsekaiContext,
                    "Aqua is the goddess of water who guided humans in the afterlife and oversaw the reincarnation of people into other worlds. "
                    + "She is an extremely useful goddess, so much so that she worked multiple part-time jobs in another world. "
                    + "As a goddess that cries alot, it is said that her tears can purify the foulest waters and even the most wretched undead."
                    + "\nDomains: Water, Healing, Good, Protection"
                    + "\nFavoured Weapon: Quarterstaff");
                bp.m_Icon = Icon_Aqua;
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
                    c.Alignment = AlignmentMaskType.ChaoticNeutral | AlignmentMaskType.ChaoticGood | AlignmentMaskType.NeutralGood;
                });

                // Domains & Energy Channel
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        WaterDomainAllowed.ToReference<BlueprintUnitFactReference>(),
                        HealingDomainAllowed.ToReference<BlueprintUnitFactReference>(),
                        GoodDomainAllowed.ToReference<BlueprintUnitFactReference>(),
                        ProtectionDomainAllowed.ToReference<BlueprintUnitFactReference>(),
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
                    c.m_Feature = QuarterstaffProficiency.ToReference<BlueprintFeatureReference>();
                    c.Level = 1;
                    c.m_Archetypes = null;
                    c.m_AdditionalClasses = new BlueprintCharacterClassReference[2] {
                        ClassTools.ClassReferences.InquisitorClass,
                        ClassTools.ClassReferences.WarpriestClass
                    };
                });
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { QuarterstaffPlus1.ToReference<BlueprintItemReference>() };
                    c.m_RestrictedByClass = new BlueprintCharacterClassReference[3] {
                        ClassTools.ClassReferences.ClericClass,
                        ClassTools.ClassReferences.InquisitorClass,
                        ClassTools.ClassReferences.WarpriestClass
                    };
                });
            }));

            // Add to Isekai Deity Selection
            IsekaiDeitySelection.AddToSelection(GoddessAquaFeature);
        }
    }
}