using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class AutoBolster
    {
        private static readonly Sprite Icon_BolsterSpell = Resources.GetBlueprint<BlueprintFeature>("fbf5d9ce931f47f3a0c818b3f8ef8414").m_Icon;
        public static void Add()
        {
            var AutoBolsterBuff = Helpers.CreateBlueprint<BlueprintBuff>("AutoBolsterBuff", bp => {
                bp.SetName("Overpowered Ability — Auto Bolster");
                bp.SetDescription("Every time you cast a spell, it becomes bolstered, as though using the Bolster Spell feat.");
                bp.m_Icon = Icon_BolsterSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Bolstered;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var AutoBolsterAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("AutoBolsterAbility", bp => {
                bp.SetName("Overpowered Ability — Auto Bolster");
                bp.SetDescription("Every time you cast a spell, it becomes bolstered, as though using the Bolster Spell feat.");
                bp.m_Icon = Icon_BolsterSpell;
                bp.m_Buff = AutoBolsterBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.None;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var AutoBolsterFeature = Helpers.CreateBlueprint<BlueprintFeature>("AutoBolsterFeature", bp => {
                bp.SetName("Overpowered Ability — Auto Bolster");
                bp.SetDescription("Every time you cast a spell, it becomes bolstered, as though using the Bolster Spell feat.");
                bp.m_Icon = Icon_BolsterSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoBolsterAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.IsClassFeature = true;
            });

            OverpoweredAbilitySelection.AddToSelection(AutoBolsterFeature);
        }
    }
}
