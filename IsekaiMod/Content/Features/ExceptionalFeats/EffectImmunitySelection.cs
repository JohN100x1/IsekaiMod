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
            // Features
            var BlindImmunity = CreateImmunity("BlindImmunity", "You gain immunity to blindness.", UnitCondition.Blindness, SpellDescriptor.Blindness);
            var NauseatedImmunity = CreateImmunity("NauseatedImmunity", "You gain immunity to the nauseated condition.", UnitCondition.Nauseated, SpellDescriptor.Nauseated);
            var FatigueImmunity = CreateImmunity("FatigueImmunity", "You gain immunity to fatigue.", UnitCondition.Fatigued, SpellDescriptor.Fatigue);
            var ParalyzedImmunity = CreateImmunity("ParalyzedImmunity", "You gain immunity to paralysis.", UnitCondition.Paralyzed, SpellDescriptor.Paralysis);
            var StaggeredImmunity = CreateImmunity("StaggeredImmunity", "You gain immunity to the staggered condition.", UnitCondition.Staggered, SpellDescriptor.Staggered);
            var PetrifiedImmunity = CreateImmunity("PetrifiedImmunity", "You gain immunity to petrification.", UnitCondition.Petrified, SpellDescriptor.Petrified);
            var DazedImmunity = CreateImmunity("DazedImmunity", "You gain immunity to daze.", UnitCondition.Dazed, SpellDescriptor.Daze);
            var SlowImmunity = CreateImmunity("SlowImmunity", "You gain immunity to slow.", UnitCondition.Slowed);
            var EntangledImmunity = CreateImmunity("EntangledImmunity", "You gain immunity to the entangled condition.", UnitCondition.Entangled);
            var FrightenedImmunity = CreateImmunity("FrightenedImmunity", "You gain immunity to the frightened condition.", UnitCondition.Frightened);
            var SickenedImmunity = CreateImmunity("SickenedImmunity", "You gain immunity to the sickened condition.", UnitCondition.Sickened);
            var SleepImmunity = CreateImmunity("SleepImmunity", "You gain immunity to sleep.", UnitCondition.Sleeping);
            var ShakenImmunity = CreateImmunity("ShakenImmunity", "You gain immunity to shaken effects.", UnitCondition.Shaken);
            var DazzledImmunity = CreateImmunity("DazzledImmunity", "You gain immunity to the dazzled condition.", UnitCondition.Dazzled);
            var StunImmunity = CreateImmunity("StunImmunity", "You gain immunity to stun effects.", UnitCondition.Stunned);
            var ConfusionImmunity = CreateImmunity("ConfusionImmunity", "You gain immunity to confusion.", UnitCondition.Confusion);
            var MovementImpairingImmunity = CreateImmunity("MovementImpairingImmunity", "You gain immunity to movement impairing effects.", UnitCondition.MovementBan);
            var CoweringImmunity = CreateImmunity("CoweringImmunity", "You gain immunity to cowering.", UnitCondition.Cowering);
            var ExhaustedImmunity = CreateImmunity("ExhaustedImmunity", "You gain immunity to exhaustion.", UnitCondition.Exhausted);
            var MindAffectingImmunity = CreateImmunity("MindAffectingImmunity", "You gain immunity to mind affecting effects.", SpellDescriptor.MindAffecting);
            var FearImmunity = CreateImmunity("FearImmunity", "You gain immunity to fear effects.", SpellDescriptor.Fear);
            var CompulsionImmunity = CreateImmunity("CompulsionImmunity", "You gain immunity to compulsion effects.", SpellDescriptor.Compulsion);
            var PoisonImmunity = CreateImmunity("PoisonImmunity", "You gain immunity to poison.", SpellDescriptor.Poison);
            var DiseaseImmunity = CreateImmunity("DiseaseImmunity", "You gain immunity to disease.", SpellDescriptor.Disease);
            var CharmImmunity = CreateImmunity("CharmImmunity", "You gain immunity to charm.", SpellDescriptor.Charm);
            var CurseImmunity = CreateImmunity("CurseImmunity", "You gain immunity to curses.", SpellDescriptor.Curse);
            var DeathImmunity = CreateImmunity("DeathImmunity", "You gain immunity to death effects.", SpellDescriptor.Death);
            var BleedImmunity = CreateImmunity("BleedImmunity", "You gain immunity to bleed.", SpellDescriptor.Bleed);
            var HexImmunity = CreateImmunity("HexImmunity", "You gain immunity to hexes.", SpellDescriptor.Hex);

            var EffectImmunityList = new BlueprintFeatureReference[29] {
                BlindImmunity.ToReference<BlueprintFeatureReference>(),
                NauseatedImmunity.ToReference<BlueprintFeatureReference>(),
                FatigueImmunity.ToReference<BlueprintFeatureReference>(),
                ParalyzedImmunity.ToReference<BlueprintFeatureReference>(),
                StaggeredImmunity.ToReference<BlueprintFeatureReference>(),
                PetrifiedImmunity.ToReference<BlueprintFeatureReference>(),
                DazedImmunity.ToReference<BlueprintFeatureReference>(),
                SlowImmunity.ToReference<BlueprintFeatureReference>(),
                EntangledImmunity.ToReference<BlueprintFeatureReference>(),
                FrightenedImmunity.ToReference<BlueprintFeatureReference>(),
                SickenedImmunity.ToReference<BlueprintFeatureReference>(),
                SleepImmunity.ToReference<BlueprintFeatureReference>(),
                ShakenImmunity.ToReference<BlueprintFeatureReference>(),
                DazzledImmunity.ToReference<BlueprintFeatureReference>(),
                StunImmunity.ToReference<BlueprintFeatureReference>(),
                ConfusionImmunity.ToReference<BlueprintFeatureReference>(),
                MovementImpairingImmunity.ToReference<BlueprintFeatureReference>(),
                CoweringImmunity.ToReference<BlueprintFeatureReference>(),
                ExhaustedImmunity.ToReference<BlueprintFeatureReference>(),
                MindAffectingImmunity.ToReference<BlueprintFeatureReference>(),
                FearImmunity.ToReference<BlueprintFeatureReference>(),
                CompulsionImmunity.ToReference<BlueprintFeatureReference>(),
                PoisonImmunity.ToReference<BlueprintFeatureReference>(),
                DiseaseImmunity.ToReference<BlueprintFeatureReference>(),
                CharmImmunity.ToReference<BlueprintFeatureReference>(),
                CurseImmunity.ToReference<BlueprintFeatureReference>(),
                DeathImmunity.ToReference<BlueprintFeatureReference>(),
                BleedImmunity.ToReference<BlueprintFeatureReference>(),
                HexImmunity.ToReference<BlueprintFeatureReference>()
            };

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