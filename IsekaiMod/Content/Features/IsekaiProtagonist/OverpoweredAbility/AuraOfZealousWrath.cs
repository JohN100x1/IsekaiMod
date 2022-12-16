using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower
{
    class AuraOfZealousWrath
    {
        public static void Add()
        {
            var Icon_AuraOfZealousWrath = AssetLoader.LoadInternal("Features", "ICON_AURA_ZEALOUS_WRATH.png");
            var AuraOfZealousWrathEnchantment = Helpers.CreateWeaponEnchantment("AuraOfZealousWrathEnchantment", bp => {
                bp.m_EnchantName = Helpers.CreateString("AuraOfZealousWrathEnchantment.Name", "Aura of Zealous Wrath");
                bp.m_Description = Helpers.CreateString("AuraOfZealousWrathEnchantment.Description", "This creature has two extra attacks and deal an additional 5d6 physical damage. "
                    + "It also has additional sneak attack damage.");
                bp.AddComponent<WeaponConditionalDamageDice>(c => {
                    c.Damage = new DamageDescription()
                    {
                        Dice = new DiceFormula()
                        {
                            m_Dice = DiceType.D6,
                            m_Rolls = 5
                        },
                        TypeDescription = new DamageTypeDescription()
                        {
                            Type = DamageType.Physical,
                            Common = new DamageTypeDescription.CommomData(),
                            Physical = new DamageTypeDescription.PhysicalData()
                            {
                                Form = PhysicalDamageForm.Bludgeoning | PhysicalDamageForm.Piercing | PhysicalDamageForm.Slashing
                            }
                        }
                    };
                    c.Conditions = ActionFlow.EmptyCondition();
                });
            });
            var AuraOfZealousWrathBuff = Helpers.CreateBuff("AuraOfZealousWrathBuff", bp => {
                bp.SetName("Aura of Zealous Wrath");
                bp.SetDescription("This creature has two extra attacks and deal an additional 5d6 physical damage. It also has additional sneak attack damage.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_AuraOfZealousWrath;
                bp.AddComponent<BuffExtraAttack>(c => {
                    c.Number = 2;
                });
                bp.AddComponent<AddContextStatBonus>(c => {
                    c.Stat = StatType.SneakAttack;
                    c.Value = Values.ContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.Div2;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = AuraOfZealousWrathEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = AuraOfZealousWrathEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                });
                bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                    c.m_EnchantmentBlueprint = AuraOfZealousWrathEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                    c.Slot = EquipSlotBase.SlotType.AdditionalLimb;
                });
            });
            var AuraOfZealousWrathArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("AuraOfZealousWrathArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(AuraOfZealousWrathBuff.ToReference<BlueprintBuffReference>()));
            });
            var AuraOfZealousWrathAreaBuff = Helpers.CreateBuff("AuraOfZealousWrathAreaBuff", bp => {
                bp.SetName("Aura of Zealous Wrath");
                bp.SetDescription("Allies within 40 feet of you has two extra attacks and deal an additional 5d6 physical damage. "
                    + "They also gain a number of sneak attack dice equal to 1/2 your character level.");
                bp.m_Icon = Icon_AuraOfZealousWrath;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = AuraOfZealousWrathArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var AuraOfZealousWrathAbility = Helpers.CreateActivatableAbility("AuraOfZealousWrathAbility", bp => {
                bp.SetName("Aura of Zealous Wrath");
                bp.SetDescription("Allies within 40 feet of you has two extra attacks and deal an additional 5d6 physical damage. "
                    + "They also gain a number of sneak attack dice equal to 1/2 your character level.");
                bp.m_Icon = Icon_AuraOfZealousWrath;
                bp.m_Buff = AuraOfZealousWrathAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var AuraOfZealousWrathFeature = Helpers.CreateFeature("AuraOfZealousWrathFeature", bp => {
                bp.SetName("Aura of Zealous Wrath");
                bp.SetDescription("Allies within 40 feet of you has two extra attacks and deal an additional 5d6 physical damage. "
                    + "They also gain a number of sneak attack dice equal to 1/2 your character level.");
                bp.m_Icon = Icon_AuraOfZealousWrath;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AuraOfZealousWrathAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
