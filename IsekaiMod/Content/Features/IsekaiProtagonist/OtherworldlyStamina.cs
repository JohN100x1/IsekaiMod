using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {

    internal class OtherworldlyStamina {
        private static readonly Sprite Icon_Bravery = BlueprintTools.GetBlueprint<BlueprintFeature>("f6388946f9f472f4585591b80e9f2452").m_Icon;

        public static void Add() {
            var OtherworldlyStamina = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "OtherworldlyStamina", bp => {
                bp.SetName(IsekaiContext, "Otherworldly Stamina");
                bp.SetDescription(IsekaiContext, "At 13th Level, you become immune to fatigue and exhaustion.");
                bp.m_Icon = Icon_Bravery;
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Fatigued;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Exhausted;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Fatigue | SpellDescriptor.Exhausted;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Fatigue | SpellDescriptor.Exhausted;
                });
            });
        }
    }
}