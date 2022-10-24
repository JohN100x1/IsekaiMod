using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist
{
    class GodlyBody
    {
        public static void Add()
        {
            var Icon_PureForm = Resources.GetBlueprint<BlueprintAbility>("33e53b74891b4c34ba6ee3baa322beeb").m_Icon;
            var GodlyBody = Helpers.CreateBlueprint<BlueprintFeature>("GodlyBody", bp => {
                bp.SetName("Godly Body");
                bp.SetDescription("At 10th level, the God Emporer gains immunity to sickened, nauseated, blindness, shaken, frightened, cowering, "
                    + "paralyzed, petrified, confusion, sleeping, slowed, staggered, stunned, dazed, dazzled, entangled, fatigued, exhausted, and movement impairing conditions, "
                    + "bleed, curse, posion, fear, death, compulsion, charm, mind-affecting, emotion effects, {g|Encyclopedia:Ability_Scores}ability score{/g} {g|Encyclopedia:Damage}damage{/g}, "
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
