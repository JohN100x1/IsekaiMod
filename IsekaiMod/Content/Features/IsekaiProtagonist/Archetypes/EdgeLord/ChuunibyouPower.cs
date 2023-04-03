using IsekaiMod.Components;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
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

    internal class ChuunibyouPower {
        private const string Name = "Chuunibyou Power";
        private const string Description = "Allies within 120 feet gain 1 additional {g|Encyclopedia:Attack}attack{/g} to their main weapon, "
            + "a +10 bonus to speed, and attacks have a 50% chance to miss them.";
        private const string DescriptionBuff = "This character has 1 additional {g|Encyclopedia:Attack}attack{/g} to their main weapon, "
            + "a +10 bonus to speed, and attacks have a 50% chance to miss them.";

        public static void Add() {
            var Icon_ChuunibyouPower = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_CHUUNIBYOU.png");
            var ChuunibyouPowerBuff = ThingsNotHandledByTTTCore.CreateBuff("ChuunibyouPowerBuff", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, DescriptionBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_ChuunibyouPower;
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
            var ChuunibyouPowerArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "ChuunibyouPowerArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = false;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(120);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(ChuunibyouPowerBuff.ToReference<BlueprintBuffReference>()));
            });
            var ChuunibyouPowerAreaBuff = ThingsNotHandledByTTTCore.CreateBuff("ChuunibyouPowerAreaBuff", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_ChuunibyouPower;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = ChuunibyouPowerArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var ChuunibyouPowerFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ChuunibyouPowerFeature", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_ChuunibyouPower;
                bp.Ranks = 1;
                bp.AddComponent<AuraFeatureComponent>(c => {
                    c.m_Buff = ChuunibyouPowerAreaBuff.ToReference<BlueprintBuffReference>();
                });
            });
        }
    }
}