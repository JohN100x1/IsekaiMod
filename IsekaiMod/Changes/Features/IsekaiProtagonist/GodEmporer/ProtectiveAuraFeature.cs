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
    class ProtectiveAuraFeature
    {
        public static void Add()
        {
            var Icon_ShieldOfFaith = Resources.GetBlueprint<BlueprintAbility>("183d5bb91dea3a1489a6db6c9cb64445").m_Icon;
            var ProtectiveAuraEffectBuff = Helpers.CreateBlueprint<BlueprintBuff>("ProtectiveAuraEffectBuff", bp => {
                bp.SetName("Protective Aura");
                bp.SetDescription("At 6th level, allies within 40 feet of the God Emporer gain a +4 competence bonus on AC and saving throws.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_ShieldOfFaith;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.AC;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SaveFortitude;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SaveReflex;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.SaveWill;
                    c.Value = 4;
                });
            });
            var ProtectiveAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("ProtectiveAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = false;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet() { m_Value = 40 };
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(ProtectiveAuraEffectBuff.ToReference<BlueprintBuffReference>()));
            });
            var ProtectiveAuraBuff = Helpers.CreateBlueprint<BlueprintBuff>("ProtectiveAuraBuff", bp => {
                bp.SetName("Protective Aura");
                bp.SetDescription("At 6th level, allies within 40 feet of the God Emporer take a +4 competence bonus on AC, and saving throws.");
                bp.m_Icon = Icon_ShieldOfFaith;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = ProtectiveAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var ProtectiveAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>("ProtectiveAuraFeature", bp => {
                bp.SetName("Protective Aura");
                bp.SetDescription("At 6th level, allies within 40 feet of the God Emporer take a +4 competence bonus on AC, and saving throws.");
                bp.m_Icon = Icon_ShieldOfFaith;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AuraFeatureComponent>(c => {
                    c.m_Buff = ProtectiveAuraBuff.ToReference<BlueprintBuffReference>();
                });
            });
        }
    }
}
