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
    class AutoReachFeature
    {
        private static readonly Sprite Icon_ReachSpell = Resources.GetBlueprint<BlueprintFeature>("46fad72f54a33dc4692d3b62eca7bb78").m_Icon;
        public static void Add()
        {
            var AutoReachBuff = Helpers.CreateBlueprint<BlueprintBuff>("AutoReachBuff", bp => {
                bp.SetName("Overpowered Ability — Auto Reach");
                bp.SetDescription("Every time you cast a spell, it increases its range by one range category, as though using the Reach Spell feat.");
                bp.m_Icon = Icon_ReachSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Reach;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var AutoReachAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("AutoReachAbility", bp => {
                bp.SetName("Overpowered Ability — Auto Reach");
                bp.SetDescription("Every time you cast a spell, it increases its range by one range category, as though using the Reach Spell feat.");
                bp.m_Icon = Icon_ReachSpell;
                bp.m_Buff = AutoReachBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.None;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var AutoReachFeature = Helpers.CreateBlueprint<BlueprintFeature>("AutoReachFeature", bp => {
                bp.SetName("Overpowered Ability — Auto Reach");
                bp.SetDescription("Every time you cast a spell, it increases its range by one range category, as though using the Reach Spell feat.");
                bp.m_Icon = Icon_ReachSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoReachAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.IsClassFeature = true;
            });

            OverpoweredAbilitySelection.AddToSelection(AutoReachFeature);
        }
    }
}
