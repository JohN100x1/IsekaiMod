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

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CheatSkill
{
    class AutoExtendFeature
    {
        public static void Add()
        {
            var Icon_ExtendSpell = Resources.GetBlueprint<BlueprintFeature>("f180e72e4a9cbaa4da8be9bc958132ef").m_Icon;
            var AutoExtendBuff = Helpers.CreateBlueprint<BlueprintBuff>("AutoExtendBuff", bp => {
                bp.SetName("Cheat Skill — Auto Extend");
                bp.SetDescription("Every time you cast a spell, it becomes extended, as though using the Extend Spell feat.");
                bp.m_Icon = Icon_ExtendSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Extend;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var AutoExtendAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("AutoExtendAbility", bp => {
                bp.SetName("Cheat Skill — Auto Extend");
                bp.SetDescription("Every time you cast a spell, it becomes extended, as though using the Extend Spell feat.");
                bp.m_Icon = Icon_ExtendSpell;
                bp.m_Buff = AutoExtendBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.MetamagicRod;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = false;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var AutoExtendFeature = Helpers.CreateBlueprint<BlueprintFeature>("AutoExtendFeature", bp => {
                bp.SetName("Cheat Skill — Auto Extend");
                bp.SetDescription("Every time you cast a spell, it becomes extended, as though using the Extend Spell feat.");
                bp.m_Icon = Icon_ExtendSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoExtendAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.IsClassFeature = true;
            });
        }
    }
}
