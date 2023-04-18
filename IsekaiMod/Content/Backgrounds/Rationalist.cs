using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Backgrounds {

    internal class Rationalist {

        public static void Add() {
            // Background
            var BackgroundRationalist = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "BackgroundRationalist", bp => {
                bp.SetName(IsekaiContext, "Rationalist");
                bp.SetBackgroundDescription(IsekaiContext, "The Rationalist is immune to any {g|Encyclopedia:Spell}spell{/g} or "
                    + "{g|Encyclopedia:Special_Abilities}spell-like ability{/g} that allows {g|Encyclopedia:Spell_Resistance}spell resistance{/g} "
                    + "but cannot cast any spells");
                bp.AddComponent<AddSpellImmunity>();
                bp.AddComponent<AreaEffectImmunity>(c => {
                    c.m_CasterType = TargetType.Enemy;
                    c.m_SpecificAreaEffects = false;
                });
                bp.AddComponent<AddCondition>(c => {
                    c.Condition = UnitCondition.SpellcastingForbidden;
                });
            });

            // Register Background
            IsekaiBackgroundSelection.AddToSelection(BackgroundRationalist);
        }
    }
}