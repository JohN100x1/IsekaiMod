using IsekaiMod.Components;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero {

    internal class ChuunibyouActualisation {
        private const string Name = "Chuunibyou Actualisation";
        private const string DescriptionBuff = "This character has 1 additional {g|Encyclopedia:Attack}attack{/g} to their main weapon, "
            + "a +10 bonus to speed, and attacks have a 50% chance to miss them.";
        private static readonly LocalizedString Description = Helpers.CreateString(IsekaiContext, "ChuunibyouActualisation.Description",
            "Allies within 120 feet gain 1 additional {g|Encyclopedia:Attack}attack{/g} to their main weapon, "
            + "a +10 bonus to speed, and attacks have a 50% chance to miss them.");

        public static void Add() {
            var Icon_ChuunibyouActualisation = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_CHUUNIBYOU.png");
            var ChuunibyouActualisationBuff = TTCoreExtensions.CreateBuff("ChuunibyouActualisationBuff", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, DescriptionBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_ChuunibyouActualisation;
                bp.AddComponent<AddExtraAttack>(c => {
                    c.Number = 1;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.Speed;
                    c.Value = 10;
                });
                bp.AddComponent<SetAttackerMissChance>(c => {
                    c.m_Type = SetAttackerMissChance.Type.All;
                    c.Value = 50;
                    c.Conditions = ActionFlow.EmptyCondition();
                });
            });
            var ChuunibyouActualisationArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "ChuunibyouActualisationArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = false;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(120);
                bp.Fx = new PrefabLink();
                bp.AddUnconditionalAuraEffect(ChuunibyouActualisationBuff.ToReference<BlueprintBuffReference>());
            });
            var ChuunibyouActualisationAreaBuff = TTCoreExtensions.CreateBuff("ChuunibyouActualisationAreaBuff", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_ChuunibyouActualisation;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = ChuunibyouActualisationArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var ChuunibyouActualisationFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ChuunibyouActualisationFeature", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_ChuunibyouActualisation;
                bp.Ranks = 1;
                bp.AddComponent<AuraFeatureComponent>(c => {
                    c.m_Buff = ChuunibyouActualisationAreaBuff.ToReference<BlueprintBuffReference>();
                });
            });
        }
    }
}