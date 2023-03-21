using IsekaiMod.Components;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class Reflect {
        private static readonly Sprite Icon_ShieldOfDawn = BlueprintTools.GetBlueprint<BlueprintAbility>("62888999171921e4dafb46de83f4d67d").m_Icon;

        public static void Add() {
            var ReflectBuff = ThingsNotHandledByTTTCore.CreateBuff("ReflectBuff", bp => {
                bp.SetName(IsekaiContext, "Reflect");
                bp.SetDescription(IsekaiContext, "You deal damage to enemies equal to the damage you receive.");
                bp.m_Icon = Icon_ShieldOfDawn;
                bp.AddComponent<ReflectDamage>();
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var ReflectAbility = ThingsNotHandledByTTTCore.CreateActivatableAbility("ReflectAbility", bp => {
                bp.SetName(IsekaiContext, "Reflect");
                bp.SetDescription(IsekaiContext, "You deal damage to enemies equal to the damage you receive.");
                bp.m_Icon = Icon_ShieldOfDawn;
                bp.m_Buff = ReflectBuff.ToReference<BlueprintBuffReference>();
            });
            var ReflectFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ReflectFeature", bp => {
                bp.SetName(IsekaiContext, "Reflect");
                bp.SetDescription(IsekaiContext, "You deal damage to enemies equal to the damage you receive.");
                bp.m_Icon = Icon_ShieldOfDawn;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { ReflectAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
            SpecialPowerSelection.AddToSelection(ReflectFeature);
        }
    }
}