using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.BeachEpisode
{
    class Unstoppable
    {
        public static void Add()
        {
            var Icon_DextrousDuelist = Resources.GetBlueprint<BlueprintFeature>("b701196306bb4674bb902c9f1160180f").m_Icon;
            var Unstoppable = Helpers.CreateBlueprint<BlueprintFeature>("Unstoppable", bp => {
                bp.SetName("Unstoppable");
                bp.SetDescription("You gain immunity to stunned, staggered, slowed, entangled, petrified, paralysis, and movement impairing effects.");
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
                    c.Condition = UnitCondition.CantMove;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.MovementBan;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Entangled;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Paralyzed;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Petrified;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Staggered
                    | SpellDescriptor.Stun
                    | SpellDescriptor.Petrified
                    | SpellDescriptor.Paralysis
                    | SpellDescriptor.MovementImpairing;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Staggered
                    | SpellDescriptor.Stun
                    | SpellDescriptor.Petrified
                    | SpellDescriptor.Paralysis
                    | SpellDescriptor.MovementImpairing;
                });
                bp.m_Icon = Icon_DextrousDuelist;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
