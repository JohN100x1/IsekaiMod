using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Mastermind {

    internal class Masterplan {
        private const string Name = "Masterplan";
        private static readonly Sprite Icon_Masterplan = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_MASTERPLAN.png");

        public static void Add() {
            var MasterplanBuff = TTCoreExtensions.CreateBuff("MasterplanBuff", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, "This character cannot cast spells or use magic items.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_Masterplan;
                bp.AddComponent<ForbidSpellCasting>(c => {
                    c.ForbidMagicItems = true;
                });
            });
            var MasterplanArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "MasterplanArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Enemy;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = true;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(120);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(MasterplanBuff.ToReference<BlueprintBuffReference>()));
            });
            var MasterplanAreaBuff = TTCoreExtensions.CreateBuff("MasterplanAreaBuff", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, "Enemies within 120 feet cannot cast spells or use magic items.");
                bp.m_Icon = Icon_Masterplan;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = MasterplanArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var MasterplanFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "MasterplanFeature", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, "Your spells ignore spell resistance and spell immunity. "
                    + "Enemies within 120 feet cannot cast spells or use magic items.");
                bp.m_Icon = Icon_Masterplan;
                bp.Ranks = 1;
                bp.AddComponent<IgnoreSpellImmunity>(c => {
                    c.SpellDescriptor = SpellDescriptor.None;
                    // TODO: IgnoreSpellImmunity doesn't actually affect the target? (search all IgnoreSpellImmunity)
                    // See IgnoreSpellResistanceForSpells and RuleSpellResistanceCheck.TargetIsImmune
                });
                bp.AddComponent<IgnoreSpellResistanceForSpells>(c => {
                    c.m_AbilityList = new BlueprintAbilityReference[0];
                    c.AllSpells = true;
                });
                bp.AddComponent<AuraFeatureComponent>(c => {
                    c.m_Buff = MasterplanAreaBuff.ToReference<BlueprintBuffReference>();
                });
            });
        }
    }
}