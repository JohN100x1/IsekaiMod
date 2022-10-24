using IsekaiMod.Extensions;
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
using Kingmaker.Utility;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist.GodEmporer
{
    class SiphoningAuraFeature
    {
        public static void Add()
        {
            var Icon_SiphoningAura = AssetLoader.LoadInternal("Features", "ICON_SIPHONING_AURA.png");
            var SiphoningAuraEffectBuff = Helpers.CreateBlueprint<BlueprintBuff>("SiphoningAuraEffectBuff", bp => {
                bp.SetName("Siphoning Aura");
                bp.SetDescription("At 12th level, enemies within 40 feet of the God Emporer take a –4 penalty on all attributes.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_SiphoningAura;
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
            var SiphoningAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("SiphoningAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Enemy;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = true;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet() { m_Value = 40 };
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(SiphoningAuraEffectBuff.ToReference<BlueprintBuffReference>()));
            });
            var SiphoningAuraBuff = Helpers.CreateBlueprint<BlueprintBuff>("SiphoningAuraBuff", bp => {
                bp.SetName("Siphoning Aura");
                bp.SetDescription("At 12th level, enemies within 40 feet of the God Emporer take a –4 penalty on all attributes.");
                bp.m_Icon = Icon_SiphoningAura;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = SiphoningAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var SiphoningAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>("SiphoningAuraFeature", bp => {
                bp.SetName("Siphoning Aura");
                bp.SetDescription("At 12th level, enemies within 40 feet of the God Emporer take a –4 penalty on all attributes.");
                bp.m_Icon = Icon_SiphoningAura;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AuraFeatureComponent>(c => {
                    c.m_Buff = SiphoningAuraBuff.ToReference<BlueprintBuffReference>();
                });
            });
        }
    }
}
