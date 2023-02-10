using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.BeachEpisode {

    internal class MasterSelf {
        private static readonly Sprite Icon_Serenity = BlueprintTools.GetBlueprint<BlueprintAbility>("d316d3d94d20c674db2c24d7de96f6a7").m_Icon;

        public static void Add() {
            var MasterSelf = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "MasterSelf", bp => {
                bp.SetName(IsekaiContext, "Master Self-Control");
                bp.SetDescription(IsekaiContext, "You gain immunity to dazed, dazzled, sleep, confusion, charm, emotion, complusion, and mind-affecting effects.");
                bp.m_Icon = Icon_Serenity;
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Dazed;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Dazzled;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Confusion;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Sleeping;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Compulsion
                    | SpellDescriptor.Charm
                    | SpellDescriptor.MindAffecting
                    | SpellDescriptor.Daze
                    | SpellDescriptor.Emotion
                    | SpellDescriptor.NegativeEmotion
                    | SpellDescriptor.Confusion
                    | SpellDescriptor.Sleep;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Compulsion
                    | SpellDescriptor.Charm
                    | SpellDescriptor.MindAffecting
                    | SpellDescriptor.Daze
                    | SpellDescriptor.Emotion
                    | SpellDescriptor.NegativeEmotion
                    | SpellDescriptor.Confusion
                    | SpellDescriptor.Sleep;
                });
            });

            BeachEpisodeSelection.AddToSelection(MasterSelf);
        }
    }
}