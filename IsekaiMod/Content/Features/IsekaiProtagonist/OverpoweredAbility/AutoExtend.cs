using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class AutoExtend
    {
        private static readonly Sprite Icon_ExtendSpell = Resources.GetBlueprint<BlueprintFeature>("f180e72e4a9cbaa4da8be9bc958132ef").m_Icon;
        public static void Add()
        {
            var AutoExtendBuff = Helpers.CreateBuff("AutoExtendBuff", bp => {
                bp.SetName("Overpowered Ability — Auto Extend");
                bp.SetDescription("Every time you cast a spell, it becomes extended, as though using the Extend Spell feat.");
                bp.m_Icon = Icon_ExtendSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Extend;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var AutoExtendAbility = Helpers.CreateActivatableAbility("AutoExtendAbility", bp => {
                bp.SetName("Overpowered Ability — Auto Extend");
                bp.SetDescription("Every time you cast a spell, it becomes extended, as though using the Extend Spell feat.");
                bp.m_Icon = Icon_ExtendSpell;
                bp.m_Buff = AutoExtendBuff.ToReference<BlueprintBuffReference>();
            });
            var AutoExtendFeature = Helpers.CreateFeature("AutoExtendFeature", bp => {
                bp.SetName("Overpowered Ability — Auto Extend");
                bp.SetDescription("Every time you cast a spell, it becomes extended, as though using the Extend Spell feat.");
                bp.m_Icon = Icon_ExtendSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoExtendAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToSelection(AutoExtendFeature);
        }
    }
}
