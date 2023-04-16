using IsekaiMod.Components;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class PowerLeveling {

        public static void Add() {
            Sprite Icon_DimensionalAnchor = BlueprintTools.GetBlueprint<BlueprintAbility>("c0aa77246b26433fa79c8ac09b1e70d9").m_Icon;

            LocalizedString PowerLevelingName = Helpers.CreateString(IsekaiContext, "PowerLeveling.Name", "Overpowered Ability — Power Leveling");
            LocalizedString PowerLevelingDesc = Helpers.CreateString(IsekaiContext, "PowerLeveling.Description",
                "You are Overpowered but overly catious. You use overwhelming force to ensure all the enemies you kill are dead."
                + "\nBenefit: Enemies killed by you or by allies within 120 feet of you give double the amount of experience.");

            var PowerLevelingBuff = TTCoreExtensions.CreateBuff("PowerLevelingBuff", bp => {
                bp.SetName(PowerLevelingName);
                bp.SetDescription(PowerLevelingDesc);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_DimensionalAnchor;
                bp.AddComponent<GainExperienceOnKill>();
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi | BlueprintBuff.Flags.StayOnDeath;
            });
            var PowerLevelingArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "PowerLevelingArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = false;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(120);
                bp.Fx = new PrefabLink();
                bp.AddUnconditionalAuraEffect(PowerLevelingBuff.ToReference<BlueprintBuffReference>());
            });
            var PowerLevelingAreaBuff = TTCoreExtensions.CreateBuff("PowerLevelingAreaBuff", bp => {
                bp.SetName(PowerLevelingName);
                bp.SetDescription(PowerLevelingDesc);
                bp.m_Icon = Icon_DimensionalAnchor;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = PowerLevelingArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var PowerLevelingFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "PowerLevelingFeature", bp => {
                bp.SetName(PowerLevelingName);
                bp.SetDescription(PowerLevelingDesc);
                bp.m_Icon = Icon_DimensionalAnchor;
                bp.AddComponent<AuraFeatureComponent>(c => {
                    c.m_Buff = PowerLevelingAreaBuff.ToReference<BlueprintBuffReference>();
                });
            });

            OverpoweredAbilitySelection.AddToSelection(PowerLevelingFeature);
        }
    }
}