using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.ExceptionalFeats
{
    class EffectImmunitySelection
    {
        public static void Add()
        {
            // Features
            var BlindImmunity = Helpers.CreateBlueprint<BlueprintFeature>("BlindImmunity", bp => {
                bp.SetName("Blind Immunity");
                bp.SetDescription("You gain immunity to blindness.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Blindness;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Blindness;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Blindness;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var NauseatedImmunity = Helpers.CreateBlueprint<BlueprintFeature>("NauseatedImmunity", bp => {
                bp.SetName("Nauseated Immunity");
                bp.SetDescription("You gain immunity to the nauseated condition.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Nauseated;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Nauseated;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Nauseated;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var FatigueImmunity = Helpers.CreateBlueprint<BlueprintFeature>("FatigueImmunity", bp => {
                bp.SetName("Fatigue Immunity");
                bp.SetDescription("You gain immunity to fatigue.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Fatigued;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Fatigue;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Fatigue;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ParalyzedImmunity = Helpers.CreateBlueprint<BlueprintFeature>("ParalyzedImmunity", bp => {
                bp.SetName("Paralyzed Immunity");
                bp.SetDescription("You gain immunity to paralysis.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Paralyzed;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Paralysis;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Paralysis;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var StaggeredImmunity = Helpers.CreateBlueprint<BlueprintFeature>("StaggeredImmunity", bp => {
                bp.SetName("Staggered Immunity");
                bp.SetDescription("You gain immunity to the staggered condition.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Staggered;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Staggered;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Staggered;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var PetrifiedImmunity = Helpers.CreateBlueprint<BlueprintFeature>("PetrifiedImmunity", bp => {
                bp.SetName("Petrified Immunity");
                bp.SetDescription("You gain immunity to petrification.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Petrified;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Petrified;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Petrified;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var DazedImmunity = Helpers.CreateBlueprint<BlueprintFeature>("DazedImmunity", bp => {
                bp.SetName("Dazed Immunity");
                bp.SetDescription("You gain immunity to daze.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Dazed;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Daze;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Daze;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var SlowImmunity = Helpers.CreateBlueprint<BlueprintFeature>("SlowImmunity", bp => {
                bp.SetName("Slow Immunity");
                bp.SetDescription("You gain immunity to slow.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Slowed;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var EntangledImmunity = Helpers.CreateBlueprint<BlueprintFeature>("EntangledImmunity", bp => {
                bp.SetName("Entangled Immunity");
                bp.SetDescription("You gain immunity to the entangled condition.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Entangled;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var FrightenedImmunity = Helpers.CreateBlueprint<BlueprintFeature>("FrightenedImmunity", bp => {
                bp.SetName("Frightened Immunity");
                bp.SetDescription("You gain immunity to the frightened condition.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Frightened;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Frightened;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Frightened;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var SickenedImmunity = Helpers.CreateBlueprint<BlueprintFeature>("SickenedImmunity", bp => {
                bp.SetName("Sickened Immunity");
                bp.SetDescription("You gain immunity to the sickened condition.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Sickened;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Sickened;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Sickened;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var SleepImmunity = Helpers.CreateBlueprint<BlueprintFeature>("SleepImmunity", bp => {
                bp.SetName("Sleep Immunity");
                bp.SetDescription("You gain immunity to sleep.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Sleeping;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Sleep;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Sleep;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ShakenImmunity = Helpers.CreateBlueprint<BlueprintFeature>("ShakenImmunity", bp => {
                bp.SetName("Shaken Immunity");
                bp.SetDescription("You gain immunity to shaken effects.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Shaken;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Shaken;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Shaken;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var DazzledImmunity = Helpers.CreateBlueprint<BlueprintFeature>("DazzledImmunity", bp => {
                bp.SetName("Dazzled Immunity");
                bp.SetDescription("You gain immunity to the dazzled condition.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Dazzled;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var StunImmunity = Helpers.CreateBlueprint<BlueprintFeature>("StunImmunity", bp => {
                bp.SetName("Stun Immunity");
                bp.SetDescription("You gain immunity to stun effects.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Stunned;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Stun;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Stun;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ConfusionImmunity = Helpers.CreateBlueprint<BlueprintFeature>("ConfusionImmunity", bp => {
                bp.SetName("Confusion Immunity");
                bp.SetDescription("You gain immunity to confusion.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Confusion;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Confusion;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Confusion;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var MovementImpairingImmunity = Helpers.CreateBlueprint<BlueprintFeature>("MovementImpairingImmunity", bp => {
                bp.SetName("Movement Impairing Immunity");
                bp.SetDescription("You gain immunity to movement impairing effects.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.MovementBan;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.MovementImpairing;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.MovementImpairing;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var CoweringImmunity = Helpers.CreateBlueprint<BlueprintFeature>("CoweringImmunity", bp => {
                bp.SetName("Cowering Immunity");
                bp.SetDescription("You gain immunity to cowering.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Cowering;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var ExhaustedImmunity = Helpers.CreateBlueprint<BlueprintFeature>("ExhaustedImmunity", bp => {
                bp.SetName("Exhausted Immunity");
                bp.SetDescription("You gain immunity to exhaustion.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Exhausted;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Exhausted;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Exhausted;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var MindAffectingImmunity = Helpers.CreateBlueprint<BlueprintFeature>("MindAffectingImmunity", bp => {
                bp.SetName("Mind Affecting Immunity");
                bp.SetDescription("You gain immunity to mind affecting effects.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.MindAffecting;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.MindAffecting;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var FearImmunity = Helpers.CreateBlueprint<BlueprintFeature>("FearImmunity", bp => {
                bp.SetName("Fear Immunity");
                bp.SetDescription("You gain immunity to fear effects.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Fear;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Fear;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var CompulsionImmunity = Helpers.CreateBlueprint<BlueprintFeature>("CompulsionImmunity", bp => {
                bp.SetName("Compulsion Immunity");
                bp.SetDescription("You gain immunity to compulsion effects.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Compulsion;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Compulsion;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var PoisonImmunity = Helpers.CreateBlueprint<BlueprintFeature>("PoisonImmunity", bp => {
                bp.SetName("Poison Immunity");
                bp.SetDescription("You gain immunity to poison.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Poison;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Poison;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var DiseaseImmunity = Helpers.CreateBlueprint<BlueprintFeature>("DiseaseImmunity", bp => {
                bp.SetName("Disease Immunity");
                bp.SetDescription("You gain immunity to disease.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Disease;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Disease;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var CharmImmunity = Helpers.CreateBlueprint<BlueprintFeature>("CharmImmunity", bp => {
                bp.SetName("Charm Immunity");
                bp.SetDescription("You gain immunity to charm.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Charm;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Charm;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var CurseImmunity = Helpers.CreateBlueprint<BlueprintFeature>("CurseImmunity", bp => {
                bp.SetName("Curse Immunity");
                bp.SetDescription("You gain immunity to curses.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Curse;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Curse;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var DeathImmunity = Helpers.CreateBlueprint<BlueprintFeature>("DeathImmunity", bp => {
                bp.SetName("Death Immunity");
                bp.SetDescription("You gain immunity to death effects.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Death;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Death;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var BleedImmunity = Helpers.CreateBlueprint<BlueprintFeature>("BleedImmunity", bp => {
                bp.SetName("Bleed Immunity");
                bp.SetDescription("You gain immunity to bleed.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Bleed;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Bleed;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
            var HexImmunity = Helpers.CreateBlueprint<BlueprintFeature>("HexImmunity", bp => {
                bp.SetName("Hex Immunity");
                bp.SetDescription("You gain immunity to hexes.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Hex;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Hex;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
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
            var EffectImmunitySelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("EffectImmunitySelection", bp => {
                bp.SetName("Effect Immunity Selection");
                bp.SetDescription("You gain immunity to a specific condition or effect.");
                bp.m_Icon = null;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_Features = EffectImmunityList;
                bp.m_AllFeatures = EffectImmunityList;
            });
            ExceptionalFeatSelection.AddToSelection(EffectImmunitySelection);
        }
    }
}
