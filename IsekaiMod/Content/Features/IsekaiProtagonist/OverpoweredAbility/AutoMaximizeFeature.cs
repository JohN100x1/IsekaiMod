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

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class AutoMaximizeFeature
    {
        public static void Add()
        {
            var Icon_MaximizeSpell = Resources.GetBlueprint<BlueprintFeature>("7f2b282626862e345935bbea5e66424b").m_Icon;
            var AutoMaximizeBuff = Helpers.CreateBlueprint<BlueprintBuff>("AutoMaximizeBuff", bp => {
                bp.SetName("Overpowered Ability — Auto Maximize");
                bp.SetDescription("Every time you cast a spell, it becomes maximized, as though using the Maximize Spell feat.");
                bp.m_Icon = Icon_MaximizeSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Maximize;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var AutoMaximizeAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("AutoMaximizeAbility", bp => {
                bp.SetName("Overpowered Ability — Auto Maximize");
                bp.SetDescription("Every time you cast a spell, it becomes maximized, as though using the Maximize Spell feat.");
                bp.m_Icon = Icon_MaximizeSpell;
                bp.m_Buff = AutoMaximizeBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.MetamagicRod;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = false;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var AutoMaximizeFeature = Helpers.CreateBlueprint<BlueprintFeature>("AutoMaximizeFeature", bp => {
                bp.SetName("Overpowered Ability — Auto Maximize");
                bp.SetDescription("Every time you cast a spell, it becomes maximized, as though using the Maximize Spell feat.");
                bp.m_Icon = Icon_MaximizeSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoMaximizeAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.IsClassFeature = true;
            });
        }
    }
}
