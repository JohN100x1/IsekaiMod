using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.BeachEpisode
{
    class HealthyBody
    {
        public static void Add()
        {
            var Icon_PurityOfBody = Resources.GetBlueprint<BlueprintFeature>("9b02f77c96d6bba4daf9043eff876c76").m_Icon;
            var HealthyBody = Helpers.CreateBlueprint<BlueprintFeature>("HealthyBody", bp => {
                bp.SetName("Healthy Body");
                bp.SetDescription("You gain immunity to bleed, blindness, curses, poison, disease, sickened, and nauseated conditions.");
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Sickened;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Nauseated;
                });
                bp.AddComponent<AddConditionImmunity>(c => {
                    c.Condition = UnitCondition.Blindness;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Sickened
                    | SpellDescriptor.Nauseated
                    | SpellDescriptor.Bleed
                    | SpellDescriptor.Blindness
                    | SpellDescriptor.Curse
                    | SpellDescriptor.Disease
                    | SpellDescriptor.Poison;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Sickened
                    | SpellDescriptor.Nauseated
                    | SpellDescriptor.Bleed
                    | SpellDescriptor.Blindness
                    | SpellDescriptor.Curse
                    | SpellDescriptor.Disease
                    | SpellDescriptor.Poison;
                });
                bp.m_Icon = Icon_PurityOfBody;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
