using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.ExceptionalFeats {

    internal class EffectImmunitySelection {

        public static void Add() {
            // Features
            var BlindImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "BlindImmunity", bp => {
                bp.SetName(IsekaiContext, "Blind Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to blindness.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Blindness;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Blindness;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Blindness;
                });
            });
            var NauseatedImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "NauseatedImmunity", bp => {
                bp.SetName(IsekaiContext, "Nauseated Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to the nauseated condition.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Nauseated;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Nauseated;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Nauseated;
                });
            });
            var FatigueImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "FatigueImmunity", bp => {
                bp.SetName(IsekaiContext, "Fatigue Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to fatigue.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Fatigued;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Fatigue;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Fatigue;
                });
            });
            var ParalyzedImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ParalyzedImmunity", bp => {
                bp.SetName(IsekaiContext, "Paralyzed Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to paralysis.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Paralyzed;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Paralysis;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Paralysis;
                });
            });
            var StaggeredImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StaggeredImmunity", bp => {
                bp.SetName(IsekaiContext, "Staggered Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to the staggered condition.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Staggered;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Staggered;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Staggered;
                });
            });
            var PetrifiedImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "PetrifiedImmunity", bp => {
                bp.SetName(IsekaiContext, "Petrified Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to petrification.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Petrified;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Petrified;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Petrified;
                });
            });
            var DazedImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DazedImmunity", bp => {
                bp.SetName(IsekaiContext, "Dazed Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to daze.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Dazed;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Daze;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Daze;
                });
            });
            var SlowImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "SlowImmunity", bp => {
                bp.SetName(IsekaiContext, "Slow Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to slow.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Slowed;
                });
            });
            var EntangledImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "EntangledImmunity", bp => {
                bp.SetName(IsekaiContext, "Entangled Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to the entangled condition.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Entangled;
                });
            });
            var FrightenedImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "FrightenedImmunity", bp => {
                bp.SetName(IsekaiContext, "Frightened Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to the frightened condition.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Frightened;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Frightened;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Frightened;
                });
            });
            var SickenedImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "SickenedImmunity", bp => {
                bp.SetName(IsekaiContext, "Sickened Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to the sickened condition.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Sickened;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Sickened;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Sickened;
                });
            });
            var SleepImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "SleepImmunity", bp => {
                bp.SetName(IsekaiContext, "Sleep Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to sleep.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Sleeping;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Sleep;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Sleep;
                });
            });
            var ShakenImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ShakenImmunity", bp => {
                bp.SetName(IsekaiContext, "Shaken Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to shaken effects.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Shaken;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Shaken;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Shaken;
                });
            });
            var DazzledImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DazzledImmunity", bp => {
                bp.SetName(IsekaiContext, "Dazzled Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to the dazzled condition.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Dazzled;
                });
            });
            var StunImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StunImmunity", bp => {
                bp.SetName(IsekaiContext, "Stun Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to stun effects.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Stunned;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Stun;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Stun;
                });
            });
            var ConfusionImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ConfusionImmunity", bp => {
                bp.SetName(IsekaiContext, "Confusion Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to confusion.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Confusion;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Confusion;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Confusion;
                });
            });
            var MovementImpairingImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "MovementImpairingImmunity", bp => {
                bp.SetName(IsekaiContext, "Movement Impairing Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to movement impairing effects.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.MovementBan;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.MovementImpairing;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.MovementImpairing;
                });
            });
            var CoweringImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "CoweringImmunity", bp => {
                bp.SetName(IsekaiContext, "Cowering Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to cowering.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Cowering;
                });
            });
            var ExhaustedImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ExhaustedImmunity", bp => {
                bp.SetName(IsekaiContext, "Exhausted Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to exhaustion.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Exhausted;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Exhausted;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Exhausted;
                });
            });
            var MindAffectingImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "MindAffectingImmunity", bp => {
                bp.SetName(IsekaiContext, "Mind Affecting Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to mind affecting effects.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.MindAffecting;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.MindAffecting;
                });
            });
            var FearImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "FearImmunity", bp => {
                bp.SetName(IsekaiContext, "Fear Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to fear effects.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Fear;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Fear;
                });
            });
            var CompulsionImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "CompulsionImmunity", bp => {
                bp.SetName(IsekaiContext, "Compulsion Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to compulsion effects.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Compulsion;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Compulsion;
                });
            });
            var PoisonImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "PoisonImmunity", bp => {
                bp.SetName(IsekaiContext, "Poison Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to poison.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Poison;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Poison;
                });
            });
            var DiseaseImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DiseaseImmunity", bp => {
                bp.SetName(IsekaiContext, "Disease Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to disease.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Disease;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Disease;
                });
            });
            var CharmImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "CharmImmunity", bp => {
                bp.SetName(IsekaiContext, "Charm Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to charm.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Charm;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Charm;
                });
            });
            var CurseImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "CurseImmunity", bp => {
                bp.SetName(IsekaiContext, "Curse Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to curses.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Curse;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Curse;
                });
            });
            var DeathImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DeathImmunity", bp => {
                bp.SetName(IsekaiContext, "Death Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to death effects.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Death;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Death;
                });
            });
            var BleedImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "BleedImmunity", bp => {
                bp.SetName(IsekaiContext, "Bleed Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to bleed.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Bleed;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Bleed;
                });
            });
            var HexImmunity = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "HexImmunity", bp => {
                bp.SetName(IsekaiContext, "Hex Immunity");
                bp.SetDescription(IsekaiContext, "You gain immunity to hexes.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Hex;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Hex;
                });
            });

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
    }
}