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
    class AutoQuickenFeature
    {
        public static void Add()
        {
            var Icon_QuickenSpell = Resources.GetBlueprint<BlueprintFeature>("ef7ece7bb5bb66a41b256976b27f424e").m_Icon;
            var AutoQuickenBuff = Helpers.CreateBlueprint<BlueprintBuff>("AutoQuickenBuff", bp => {
                bp.SetName("Overpowered Ability — Auto Quicken");
                bp.SetDescription("Every time you cast a spell, it becomes quickened, as though using the Quicken Spell feat.");
                bp.m_Icon = Icon_QuickenSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Quicken;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var AutoQuickenAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("AutoQuickenAbility", bp => {
                bp.SetName("Overpowered Ability — Auto Quicken");
                bp.SetDescription("Every time you cast a spell, it becomes quickened, as though using the Quicken Spell feat.");
                bp.m_Icon = Icon_QuickenSpell;
                bp.m_Buff = AutoQuickenBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.None;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = false;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var AutoQuickenFeature = Helpers.CreateBlueprint<BlueprintFeature>("AutoQuickenFeature", bp => {
                bp.SetName("Overpowered Ability — Auto Quicken");
                bp.SetDescription("Every time you cast a spell, it becomes quickened, as though using the Quicken Spell feat.");
                bp.m_Icon = Icon_QuickenSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoQuickenAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.IsClassFeature = true;
            });
        }
    }
}
