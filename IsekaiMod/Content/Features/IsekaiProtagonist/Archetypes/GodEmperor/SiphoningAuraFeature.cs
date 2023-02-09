using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;
using UnityEngine;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.ActivatableAbilities;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor
{
    class SiphoningAuraFeature
    {
        private static readonly Sprite Icon_SiphoningDebuff = BlueprintTools.GetBlueprint<BlueprintBuff>("886c7407dc629dc499b9f1465ff382df").m_Icon;
        public static void Add()
        {
            var Icon_SiphoningAura = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_SIPHONING_AURA.png");
            var SiphoningAuraBuff = ThingsNotHandledByTTTCore.CreateBuff("SiphoningAuraBuff", bp => {
                bp.SetName(IsekaiContext, "Siphoning Aura");
                bp.SetDescription(IsekaiContext, "This creature has a –4 penalty on all attributes.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_SiphoningDebuff;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Strength;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Dexterity;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Constitution;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Intelligence;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Wisdom;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Charisma;
                    c.Value = -4;
                });
            });
            var SiphoningAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "SiphoningAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Enemy;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = true;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(SiphoningAuraBuff.ToReference<BlueprintBuffReference>()));
            });
            var SiphoningAuraAreaBuff = ThingsNotHandledByTTTCore.CreateBuff("SiphoningAuraAreaBuff", bp => {
                bp.SetName(IsekaiContext, "Siphoning Aura");
                bp.SetDescription(IsekaiContext, "Enemies within 40 feet of the God Emperor take a –4 penalty on all attributes.");
                bp.m_Icon = Icon_SiphoningAura;
                bp.IsClassFeature = true;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = SiphoningAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var SiphoningAuraAbility = ThingsNotHandledByTTTCore.CreateActivatableAbility( "SiphoningAuraAbility", bp => {
                bp.SetName(IsekaiContext, "Siphoning Aura");
                bp.SetDescription(IsekaiContext, "Enemies within 40 feet of the God Emperor take a –4 penalty on all attributes.");
                bp.m_Icon = Icon_SiphoningAura;
                bp.m_Buff = SiphoningAuraAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var SiphoningAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext ,"SiphoningAuraFeature", bp => {
                bp.SetName(IsekaiContext, "Siphoning Aura");
                bp.SetDescription(IsekaiContext, "At 12th level, enemies within 40 feet of the God Emperor take a –4 penalty on all attributes.");
                bp.m_Icon = Icon_SiphoningAura;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { SiphoningAuraAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
