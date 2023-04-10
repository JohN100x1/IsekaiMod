using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.ExceptionalFeats {

    internal class EffectImmunitySelection {

        public static void Add() {
            var StatDamageNegativeLevelImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StatDamageNegativeLevelImmunity", bp => {
                bp.SetName(IsekaiContext, "Energy Drain and Negative level Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to ability score damage and negative levels.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.StatDebuff | SpellDescriptor.NegativeLevel;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.StatDebuff | SpellDescriptor.NegativeLevel;
                });
                bp.AddComponent<AddImmunityToAbilityScoreDamage>(c => {
                    c.Drain = true;
                });
                bp.AddComponent<AddImmunityToEnergyDrain>();
            });
            var SneakAttackImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "SneakAttackImmunity", bp => {
                bp.SetName(IsekaiContext, "Sneak attack Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to sneak attacks.");
                bp.AddComponent<AddImmunityToPrecisionDamage>();
            });
            var CriticalHitImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "CriticalHitImmunity", bp => {
                bp.SetName(IsekaiContext, "Critical hit Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to critical hits.");
                bp.AddComponent<AddImmunityToCriticalHits>();
            });

            // Immunities
            var EffectImmunities = new BlueprintFeature[31] {
                CreateImmunity("BlindImmunity", "You gain immunity to blindness.", UnitCondition.Blindness, SpellDescriptor.Blindness),
                CreateImmunity("NauseatedImmunity", "You gain immunity to the nauseated condition.", UnitCondition.Nauseated, SpellDescriptor.Nauseated),
                CreateImmunity("FatigueImmunity", "You gain immunity to fatigue.", UnitCondition.Fatigued, SpellDescriptor.Fatigue),
                CreateImmunity("ParalyzedImmunity", "You gain immunity to paralysis.", UnitCondition.Paralyzed, SpellDescriptor.Paralysis),
                CreateImmunity("StaggeredImmunity", "You gain immunity to the staggered condition.", UnitCondition.Staggered, SpellDescriptor.Staggered),
                CreateImmunity("PetrifiedImmunity", "You gain immunity to petrification.", UnitCondition.Petrified, SpellDescriptor.Petrified),
                CreateImmunity("DazedImmunity", "You gain immunity to daze.", UnitCondition.Dazed, SpellDescriptor.Daze),
                CreateImmunity("SlowImmunity", "You gain immunity to slow.", UnitCondition.Slowed),
                CreateImmunity("EntangledImmunity", "You gain immunity to the entangled condition.", UnitCondition.Entangled),
                CreateImmunity("FrightenedImmunity", "You gain immunity to the frightened condition.", UnitCondition.Frightened, SpellDescriptor.Frightened),
                CreateImmunity("SickenedImmunity", "You gain immunity to the sickened condition.", UnitCondition.Sickened, SpellDescriptor.Sickened),
                CreateImmunity("SleepImmunity", "You gain immunity to sleep.", UnitCondition.Sleeping, SpellDescriptor.Sleep),
                CreateImmunity("ShakenImmunity", "You gain immunity to shaken effects.", UnitCondition.Shaken, SpellDescriptor.Shaken),
                CreateImmunity("DazzledImmunity", "You gain immunity to the dazzled condition.", UnitCondition.Dazzled),
                CreateImmunity("StunImmunity", "You gain immunity to stun effects.", UnitCondition.Stunned, SpellDescriptor.Stun),
                CreateImmunity("ConfusionImmunity", "You gain immunity to confusion.", UnitCondition.Confusion, SpellDescriptor.Confusion),
                CreateImmunity("MovementImpairingImmunity", "You gain immunity to movement impairing effects.", UnitCondition.MovementBan, SpellDescriptor.MovementImpairing),
                CreateImmunity("CoweringImmunity", "You gain immunity to cowering.", UnitCondition.Cowering),
                CreateImmunity("ExhaustedImmunity", "You gain immunity to exhaustion.", UnitCondition.Exhausted),
                CreateImmunity("MindAffectingImmunity", "You gain immunity to mind affecting effects.", SpellDescriptor.MindAffecting),
                CreateImmunity("FearImmunity", "You gain immunity to fear effects.", SpellDescriptor.Fear),
                CreateImmunity("CompulsionImmunity", "You gain immunity to compulsion effects.", SpellDescriptor.Compulsion),
                CreateImmunity("PoisonImmunity", "You gain immunity to poison.", SpellDescriptor.Poison),
                CreateImmunity("DiseaseImmunity", "You gain immunity to disease.", SpellDescriptor.Disease),
                CreateImmunity("CharmImmunity", "You gain immunity to charm.", SpellDescriptor.Charm),
                CreateImmunity("CurseImmunity", "You gain immunity to curses.", SpellDescriptor.Curse),
                CreateImmunity("DeathImmunity", "You gain immunity to death effects.", SpellDescriptor.Death),
                CreateImmunity("BleedImmunity", "You gain immunity to bleed.", SpellDescriptor.Bleed),
                CreateImmunity("HexImmunity", "You gain immunity to hexes.", SpellDescriptor.Hex),
                SneakAttackImmunity,
                CriticalHitImmunity
            };

            BlueprintFeatureReference[] EffectImmunityList = EffectImmunities.Select(bp => bp.ToReference<BlueprintFeatureReference>()).ToArray();


            // Effect Immunity Selection
            var EffectImmunitySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "EffectImmunitySelection", bp => {
                bp.SetName(IsekaiContext, "Effect Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to a specific condition or effect.");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Features = EffectImmunityList;
                bp.m_AllFeatures = EffectImmunityList;
            });
            var EffectImmunityBonusSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "EffectImmunityBonusSelection", bp => {
                bp.SetName(IsekaiContext, "Effect Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to a specific condition or effect.");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Features = EffectImmunityList;
                bp.m_AllFeatures = EffectImmunityList;
            });
            ExceptionalFeatSelection.AddToSelection(EffectImmunitySelection, EffectImmunityBonusSelection);
        }
        private static BlueprintFeature CreateImmunity(string name, string description, UnitCondition condition, SpellDescriptor descriptor) {
            return CreateImmunity(name, description, bp => {
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = condition;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = descriptor;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = descriptor;
                });
            });
        }
        private static BlueprintFeature CreateImmunity(string name, string description, UnitCondition condition) {
            return CreateImmunity(name, description, bp => {
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = condition;
                });
            });
        }
        private static BlueprintFeature CreateImmunity(string name, string description, SpellDescriptor descriptor) {
            return CreateImmunity(name, description, bp => {
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = descriptor;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = descriptor;
                });
            });
        }
        private static BlueprintFeature CreateImmunity(string name, string description, Action<BlueprintFeature> init = null) {
            var result = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, name, bp => {
                bp.SetName(IsekaiContext, string.Concat(name.Select(x => char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' '));
                bp.SetDescription(IsekaiContext, description);
            });
            init?.Invoke(result);
            return result;
        }
    }
}