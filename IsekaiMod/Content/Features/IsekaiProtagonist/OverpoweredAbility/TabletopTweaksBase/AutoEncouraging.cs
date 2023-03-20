using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;
using static TabletopTweaks.Core.MechanicsChanges.MetamagicExtention;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility.TabletopTweaksBase {

    internal class AutoEncouraging {
        private static readonly Sprite Icon_EncouragingSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("392608e8033a409ab96afdfbf315e028").m_Icon;

        public static void Add() {
            var AutoEncouragingBuff = ThingsNotHandledByTTTCore.CreateBuff("AutoEncouragingBuff", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Encouraging");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, increase its morale bonus by 1, as though using the Encouraging Spell feat.");
                bp.m_Icon = Icon_EncouragingSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = (Metamagic)CustomMetamagic.Encouraging;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var AutoEncouragingAbility = ThingsNotHandledByTTTCore.CreateActivatableAbility("AutoEncouragingAbility", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Encouraging");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, increase its morale bonus by 1, as though using the Encouraging Spell feat.");
                bp.m_Icon = Icon_EncouragingSpell;
                bp.m_Buff = AutoEncouragingBuff.ToReference<BlueprintBuffReference>();
            });
            var AutoEncouragingFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "AutoEncouragingFeature", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Encouraging");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, increase its morale bonus by 1, as though using the Encouraging Spell feat.");
                bp.m_Icon = Icon_EncouragingSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoEncouragingAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToSelection(AutoEncouragingFeature);
        }
    }
}