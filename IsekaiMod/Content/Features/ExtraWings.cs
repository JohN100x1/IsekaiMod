using IsekaiMod.Utilities;
using IsekaiMod.Extensions;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.ActivatableAbilities.Restrictions;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.ResourceLinks;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Formations.Facts;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using UnityEngine;


namespace IsekaiMod.Content.Features
{
    class ExtraWings
    {
        // Wings
        private static readonly BlueprintBuff BuffWingsMutagen = Resources.GetBlueprint<BlueprintBuff>("e4979934bdb39d842b28bee614606823");
        private static readonly BlueprintBuff WingsAngelBlack = Resources.GetBlueprint<BlueprintBuff>("a19cda073f4c2b64ca1f8bf8fe285ece");
        private static readonly BlueprintBuff BuffWingsAngelGhost = Resources.GetBlueprint<BlueprintBuff>("bd6980649fd60fa4085c34aa74ac47f2");
        private static readonly BlueprintBuff BuffWingsDemon = Resources.GetBlueprint<BlueprintBuff>("3c958be25ab34dc448569331488bee27");

        // Icon
        private static readonly Sprite Icon_Wings = Resources.GetBlueprint<BlueprintBuff>("4113178a8d5bf4841b8f15b1b39e004f").m_Icon;
        public static void Add()
        {
            var BlackWingsAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("BlackWingsAbility", bp => {
                bp.SetName("Wings (Black)");
                bp.SetDescription("You gain a pair of wings that grant a +3 dodge {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Armor_Class}AC{/g} "
                    + "against {g|Encyclopedia:MeleeAttack}melee attacks{/g} and an immunity to ground based effects, such as difficult terrain.");
                bp.m_Icon = Icon_Wings;
                bp.AddComponent<RestrictionHasFact>(c => {
                    c.m_Feature = BuffWingsMutagen.ToReference<BlueprintUnitFactReference>();
                    c.Not = true;
                });
                bp.m_Buff = WingsAngelBlack.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.Wings;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var GhostWingsAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("GhostWingsAbility", bp => {
                bp.SetName("Wings (Ghostly)");
                bp.SetDescription("You gain a pair of wings that grant a +3 dodge {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Armor_Class}AC{/g} "
                    + "against {g|Encyclopedia:MeleeAttack}melee attacks{/g} and an immunity to ground based effects, such as difficult terrain.");
                bp.m_Icon = Icon_Wings;
                bp.AddComponent<RestrictionHasFact>(c => {
                    c.m_Feature = BuffWingsMutagen.ToReference<BlueprintUnitFactReference>();
                    c.Not = true;
                });
                bp.m_Buff = BuffWingsAngelGhost.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.Wings;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });

            var DevilWingsBuff = Helpers.CreateBlueprint<BlueprintBuff>("DevilWingsBuff", bp => {
                bp.SetName("Wings");
                bp.SetDescription("You gain a pair of wings that grant a +3 dodge {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Armor_Class}AC{/g} "
                    + "against {g|Encyclopedia:MeleeAttack}melee attacks{/g} and an immunity to ground based effects, such as difficult terrain.");
                bp.AddComponent<ACBonusAgainstAttacks>(c => {
                    c.AgainstMeleeOnly = true;
                    c.AgainstRangedOnly = false;
                    c.OnlySneakAttack = false;
                    c.NotTouch = false;
                    c.IsTouch = false;
                    c.OnlyAttacksOfOpportunity = false;
                    c.Value = 0;
                    c.ArmorClassBonus = 3;
                    c.Descriptor = ModifierDescriptor.Dodge;
                    c.CheckArmorCategory = false;
                    c.NotArmorCategory = new ArmorProficiencyGroup[0];
                    c.NoShield = false;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.DifficultTerrain;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Ground;
                    c.CheckFact = false;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Ground;
                });
                bp.AddComponent<FormationACBonus>(c => {
                    c.UnitProperty = false;
                    c.Bonus = 3;
                    c.m_IgnoreIfHasAnyFact = new BlueprintUnitFactReference[0];
                });
                bp.AddComponent<AddEquipmentEntity>(c => {
                    c.EquipmentEntity = new EquipmentEntityLink() { AssetId = "214b59c14bada944c83041f18dcec3d2" };
                });
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.Stacking = StackingType.Replace;
                bp.Ranks = 0;
                bp.TickEachSecond = false;
                bp.Frequency = DurationRate.Rounds;
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var DevilWingsAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("DevilWingsAbility", bp => {
                bp.SetName("Wings (Devilish)");
                bp.SetDescription("You gain a pair of wings that grant a +3 dodge {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Armor_Class}AC{/g} "
                    + "against {g|Encyclopedia:MeleeAttack}melee attacks{/g} and an immunity to ground based effects, such as difficult terrain.");
                bp.m_Icon = Icon_Wings;
                bp.AddComponent<RestrictionHasFact>(c => {
                    c.m_Feature = BuffWingsMutagen.ToReference<BlueprintUnitFactReference>();
                    c.Not = true;
                });
                bp.m_Buff = DevilWingsBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.Wings;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var DemonWingsAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("DemonWingsAbility", bp => {
                bp.SetName("Wings (Demonic)");
                bp.SetDescription("You gain a pair of wings that grant a +3 dodge {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Armor_Class}AC{/g} "
                    + "against {g|Encyclopedia:MeleeAttack}melee attacks{/g} and an immunity to ground based effects, such as difficult terrain.");
                bp.m_Icon = Icon_Wings;
                bp.AddComponent<RestrictionHasFact>(c => {
                    c.m_Feature = BuffWingsMutagen.ToReference<BlueprintUnitFactReference>();
                    c.Not = true;
                });
                bp.m_Buff = BuffWingsDemon.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.Wings;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });

            // Patch pit spells
            PatchPitAreaEffects(DevilWingsBuff);
        }
        private static void PatchPitAreaEffects(BlueprintBuff wingsBuff)
        {
            BlueprintAbilityAreaEffect[] pitAbilityAreaEffects = new BlueprintAbilityAreaEffect[]
            {
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("b905a3c987f22cb49a246f0ab211f34c"), // PitOfDespairArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("bf68ec704dc186549a7c6fbf22d3d661"), // TricksterRecreationalPitArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("cf742a1d377378e4c8799f6a3afff1ba"), // CreatePitArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("beccc33f543b1f8469c018982c23ac06"), // SpikedPitArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("e122151e93e44e0488521aed9e51b617"), // AcidPitArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("d086b1aeb367a5b43808d34c321955d1"), // HungryPitArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("9b51157a5305dbf4184bf15bdad39226")  // RiftOfRuinArea
            };
            foreach (BlueprintAbilityAreaEffect pitAbilityAreaEffect in pitAbilityAreaEffects)
            {
                var areaEffectPit = pitAbilityAreaEffect.GetComponent<AreaEffectPit>();
                areaEffectPit.m_EffectsImmunityFacts = areaEffectPit.m_EffectsImmunityFacts.AddToArray(wingsBuff.ToReference<BlueprintUnitFactReference>());
            }
        }

    }
}
