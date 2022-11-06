using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace IsekaiMod.Content.Heritages
{
    class IsekaiAngelHeritage
    {
        public static void Add()
        {
            var AngelicBoltAbility = Resources.GetModBlueprint<BlueprintAbility>("AngelicBoltAbility");
            var AngelWingsFeature = Resources.GetBlueprint<BlueprintFeature>("d9bd0fde6deb2e44a93268f2dfb3e169");

            // Angel Heritage
            var Icon_Angel = AssetLoader.LoadInternal("Heritages", "ICON_ANGEL.png");
            var IsekaiAngelHeritage = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiAngelHeritage", bp => {
                bp.SetName("Isekai Angel");
                bp.SetDescription("Otherworldly entities who are reincarnated into the world of Golarion as an Angel have both extreme beauty and power. "
                    + "They serve as exemplars of good and light regardless of the myriad forms they may take.\n"
                    + "The Isekai Angel has a +4 racial {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Strength}Strength{/g} and {g|Encyclopedia:Charisma}Charisma{/g}, "
                    + "and a +2 racial bonus on {g|Encyclopedia:Persuasion}Persuasion{/g} and {g|Encyclopedia:Lore_Religion}Lore (religion){/g} checks. "
                    + "They have DR 10/Evil, and have spell resistance equal to 10 + their character level. "
                    + "They have immunity to acid, cold, and petrification as well as fire and electricity resistance 20. "
                    + "They can also use the Charm spell once per day.");
                bp.m_Icon = Icon_Angel;
                bp.Ranks = 1;
                bp.IsClassFeature = true;

                // Attributes
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Strength;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Charisma;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.SkillLoreReligion;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.SkillPersuasion;
                    c.Value = 2;
                });

                // Add DR/Evil
                bp.AddComponent<AddDamageResistancePhysical>(c => {
                    c.Or = true;
                    c.Value = 10;
                    c.BypassedByAlignment = true;
                    c.Alignment = DamageAlignment.Evil;
                });

                // Add Spell Resistance
                bp.AddComponent<AddSpellResistance>(c => {
                    c.Value = new ContextValue()
                    {
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.StatBonus
                    };
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.BonusValue;
                    c.m_StepLevel = 10;
                });

                // Add Resistance and Immunities
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Acid;
                    c.Value = 20;
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Cold;
                    c.Value = 20;
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Fire;
                    c.Value = 20;
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Electricity;
                    c.Value = 20;
                });
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Acid;
                });
                bp.AddComponent<AddEnergyImmunity>(c => {
                    c.Type = DamageEnergyType.Cold;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Petrified
                    | SpellDescriptor.Acid
                    | SpellDescriptor.Cold;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Petrified
                    | SpellDescriptor.Acid
                    | SpellDescriptor.Cold;
                });

                // Add Abilities
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        AngelicBoltAbility.ToReference<BlueprintUnitFactReference>(),
                        AngelWingsFeature.ToReference<BlueprintUnitFactReference>()
                    };
                });

                bp.Groups = new FeatureGroup[] { FeatureGroup.Racial, FeatureGroup.AasimarHeritage };
                bp.IsClassFeature = true;
                bp.ReapplyOnLevelUp = true;
            });

            // Add to Aasimar Heritage Selection
            var AasimarHeritageSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("67aabcbce8f8ae643a9d08a6ca67cabd");
            AasimarHeritageSelection.m_AllFeatures = AasimarHeritageSelection.m_AllFeatures.AddToArray(IsekaiAngelHeritage.ToReference<BlueprintFeatureReference>());
        }
    }
}
