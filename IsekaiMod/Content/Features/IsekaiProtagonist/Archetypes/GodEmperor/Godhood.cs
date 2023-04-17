using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor {

    internal class Godhood {

        public static void Add() {
            var Icon_Godhood = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_GODHOOD.png");
            var Godhood = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "Godhood", bp => {
                bp.SetName(IsekaiContext, "Godhood");
                bp.SetDescription(IsekaiContext, "At 20th level, you surpass the pinnacle of this physical reality. "
                    + "You are immune to all spells and {g|Encyclopedia:Physical_Damage}physical damage{/g}. "
                    + "Your attacks ignore concealment and damage reduction. Your spells ignore spell resistance and spell immunity.");
                bp.m_Icon = Icon_Godhood;
                bp.AddComponent<AddSpellImmunity>();
                bp.AddComponent<AreaEffectImmunity>(c => {
                    c.m_CasterType = TargetType.Enemy;
                    c.m_SpecificAreaEffects = false;
                });
                bp.AddComponent<AddPhysicalImmunity>();
                bp.AddComponent<IgnoreConcealment>();
                bp.AddComponent<IgnoreDamageReductionOnAttack>();
                bp.AddComponent<IgnoreSpellImmunity>(c => {
                    c.SpellDescriptor = SpellDescriptor.None;
                });
                bp.AddComponent<IgnoreSpellResistanceForSpells>(c => {
                    c.m_AbilityList = new BlueprintAbilityReference[0];
                    c.AllSpells = true;
                });
            });
        }
    }
}