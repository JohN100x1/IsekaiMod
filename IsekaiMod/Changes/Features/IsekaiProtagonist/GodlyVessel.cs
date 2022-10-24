using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist
{
    class GodlyVessel
    {
        public static void Add()
        {
            var Icon_PureForm = Resources.GetBlueprint<BlueprintAbility>("33e53b74891b4c34ba6ee3baa322beeb").m_Icon;
            var GodlyVessel = Helpers.CreateBlueprint<BlueprintFeature>("GodlyVessel", bp => {
                bp.SetName("Godly Vessel");
                bp.SetDescription("At 13th level, the God Emporer gains immunity to sickening effects, nauseated effects, blindness, shaken effects, frightening effects, cowering, "
                    + "paralysis, petrification, confusion, sleep effects, slow effects, staggered effects, stun, daze, dazzle, entanglement, fatigue, exhaustion, movement impairing conditions, "
                    + "bleed, curses, hexes, posion, fear effects, death effects, compulsion effects, charm effects, mind-affecting effects, emotion effects, {g|Encyclopedia:Ability_Scores}ability score{/g} {g|Encyclopedia:Damage}damage{/g}, "
                    + "energy drain and negative levels."
                    );
                bp.m_Icon = Icon_PureForm;
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Sickened;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Nauseated;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Blindness;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Shaken;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Frightened;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Cowering;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Paralyzed;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Petrified;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Confusion;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Sleeping;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Slowed;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Staggered;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Stunned;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Dazed;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Dazzled;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.CantMove;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.MovementBan;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Entangled;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Fatigued;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Exhausted;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Sickened
                    | SpellDescriptor.Nauseated
                    | SpellDescriptor.Bleed
                    | SpellDescriptor.Blindness
                    | SpellDescriptor.Hex
                    | SpellDescriptor.Curse
                    | SpellDescriptor.Poison
                    | SpellDescriptor.Shaken
                    | SpellDescriptor.Frightened
                    | SpellDescriptor.Fear
                    | SpellDescriptor.Petrified
                    | SpellDescriptor.Paralysis
                    | SpellDescriptor.Death
                    | SpellDescriptor.Compulsion
                    | SpellDescriptor.Charm
                    | SpellDescriptor.MindAffecting
                    | SpellDescriptor.Emotion
                    | SpellDescriptor.NegativeEmotion
                    | SpellDescriptor.Confusion
                    | SpellDescriptor.Sleep
                    | SpellDescriptor.Staggered
                    | SpellDescriptor.Stun
                    | SpellDescriptor.Daze
                    | SpellDescriptor.MovementImpairing
                    | SpellDescriptor.Fatigue
                    | SpellDescriptor.Exhausted
                    | SpellDescriptor.NegativeLevel;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Sickened
                    | SpellDescriptor.Nauseated
                    | SpellDescriptor.Bleed
                    | SpellDescriptor.Blindness
                    | SpellDescriptor.Hex
                    | SpellDescriptor.Curse
                    | SpellDescriptor.Poison
                    | SpellDescriptor.Shaken
                    | SpellDescriptor.Frightened
                    | SpellDescriptor.Fear
                    | SpellDescriptor.Petrified
                    | SpellDescriptor.Paralysis
                    | SpellDescriptor.Death
                    | SpellDescriptor.Compulsion
                    | SpellDescriptor.Charm
                    | SpellDescriptor.MindAffecting
                    | SpellDescriptor.Emotion
                    | SpellDescriptor.NegativeEmotion
                    | SpellDescriptor.Confusion
                    | SpellDescriptor.Sleep
                    | SpellDescriptor.Staggered
                    | SpellDescriptor.Stun
                    | SpellDescriptor.Daze
                    | SpellDescriptor.MovementImpairing
                    | SpellDescriptor.Fatigue
                    | SpellDescriptor.Exhausted
                    | SpellDescriptor.NegativeLevel;
                });
                bp.AddComponent<AddImmunityToAbilityScoreDamage>();
                bp.AddComponent<AddImmunityToEnergyDrain>();
                bp.IsClassFeature = true;
            });
        }
    }
}
