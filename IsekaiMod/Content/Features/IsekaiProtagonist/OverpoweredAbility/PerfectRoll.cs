using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class MetaLuck {
        private static readonly Sprite Icon_Fortune = BlueprintTools.GetBlueprint<BlueprintAbility>("eaf7077a8ff35644883df6d4f7b2084c").m_Icon;

        public static void Add() {
            var MetaLuckBuff = ThingsNotHandledByTTTCore.CreateBuff("MetaLuckBuff", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Meta Luck");
                bp.SetDescription(IsekaiContext, "This character always takes the higher of three d20 rolls.");
                bp.m_Icon = Icon_Fortune;
                bp.AddComponent<ModifyD20>(c => {
                    c.Rule = RuleType.All;
                    c.RollsAmount = 1;
                    c.TakeBest = true;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var MetaLuckAbility = ThingsNotHandledByTTTCore.CreateActivatableAbility("MetaLuckAbility", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Meta Luck");
                bp.SetDescription(IsekaiContext, "You always take the higher of three d20 rolls.");
                bp.m_Icon = Icon_Fortune;
                bp.m_Buff = MetaLuckBuff.ToReference<BlueprintBuffReference>();
            });
            var MetaLuckFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "MetaLuckFeature", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Meta Luck");
                bp.SetDescription(IsekaiContext, "You always take the higher of three d20 rolls.");
                bp.m_Icon = Icon_Fortune;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { MetaLuckAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToSelection(MetaLuckFeature);
        }
    }
}