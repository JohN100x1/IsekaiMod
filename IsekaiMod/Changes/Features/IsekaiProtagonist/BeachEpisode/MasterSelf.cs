using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist.BeachEpisode
{
    class MasterSelf
    {
        public static void Add()
        {
            var Icon_Serenity = Resources.GetBlueprint<BlueprintAbility>("d316d3d94d20c674db2c24d7de96f6a7").m_Icon;
            var MasterSelf = Helpers.CreateBlueprint<BlueprintFeature>("MasterSelf", bp => {
                bp.SetName("Master Self-Control");
                bp.SetDescription("You gain immunity to dazed, dazzled, sleep, confusion, charm, emotion, complusion, and mind-affecting effects.");
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
                bp.m_Icon = Icon_Serenity;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
