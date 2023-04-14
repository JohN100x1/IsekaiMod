using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class AuraOfRighteousWrath {
        public static void Add() {

            var Icon_AuraOfRighteousWrath = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_AURA_RIGHTEOUS_WRATH.png");
            var AuraOfRighteousWrathEnchantment = Helpers.CreateBlueprint<BlueprintWeaponEnchantment>(IsekaiContext, "AuraOfRighteousWrathEnchantment", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Aura of Righteous Wrath");
                bp.SetDescription(IsekaiContext, "This creature has two extra attacks and deal an additional 5d6 physical damage. It also has additional sneak attack damage.");
                bp.m_Prefix = StaticReferences.Strings.Null;
                bp.m_Suffix = StaticReferences.Strings.Null;
                bp.AddComponent<WeaponConditionalDamageDice>(c => {
                    c.Damage = new DamageDescription() {
                        Dice = new DiceFormula() {
                            m_Dice = DiceType.D6,
                            m_Rolls = 5
                        },
                        TypeDescription = new DamageTypeDescription() {
                            Type = DamageType.Physical,
                            Common = new DamageTypeDescription.CommomData(),
                            Physical = new DamageTypeDescription.PhysicalData() {
                                Form = PhysicalDamageForm.Bludgeoning | PhysicalDamageForm.Piercing | PhysicalDamageForm.Slashing
                            }
                        }
                    };
                    c.Conditions = ActionFlow.EmptyCondition();
                });
            });

            var AuraOfRighteousWrathFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "AuraOfRighteousWrath",
                displayName: "Overpowered Ability — Aura of Righteous Wrath",
                description: "Allies within 120 feet of you has two extra attacks and deal an additional 5d6 physical damage. They also gain 1d6 sneak attack equal to 1/2 your character level.",
                displayNameBuff: "Aura of Righteous Wrath",
                descriptionBuff: "This character has two extra attacks and deal an additional 5d6 physical damage. It also has additional sneak attack damage.",
                icon: Icon_AuraOfRighteousWrath,
                buffEffect: bp => {
                    bp.AddComponent<BuffExtraAttack>(c => {
                        c.Number = 2;
                    });
                    bp.AddComponent<AddContextStatBonus>(c => {
                        c.Stat = StatType.SneakAttack;
                        c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                    });
                    bp.AddComponent<ContextRankConfig>(c => {
                        c.m_Type = AbilityRankType.StatBonus;
                        c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                        c.m_Progression = ContextRankProgression.Div2;
                    });
                    bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                        c.m_EnchantmentBlueprint = AuraOfRighteousWrathEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                        c.Slot = EquipSlotBase.SlotType.PrimaryHand;
                    });
                    bp.AddComponent<BuffEnchantAnyWeapon>(c => {
                        c.m_EnchantmentBlueprint = AuraOfRighteousWrathEnchantment.ToReference<BlueprintItemEnchantmentReference>();
                        c.Slot = EquipSlotBase.SlotType.SecondaryHand;
                    });
                }); // TODO: multiple versions

            OverpoweredAbilitySelection.AddToNonAutoSelection(AuraOfRighteousWrathFeature);
        }
    }
}