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

namespace IsekaiMod.Content.Features.IsekaiProtagonist.GodEmporer
{
    class DarkAuraFeature
    {
        public static void Add()
        {
            var Icon_Dark_Aura = AssetLoader.LoadInternal("Features", "ICON_DARK_AURA.png");
            var DarkAuraEffectBuff = Helpers.CreateBlueprint<BlueprintBuff>("DarkAuraEffectBuff", bp => {
                bp.SetName("Dark Aura");
                bp.SetDescription("At 10th level, enemies within 40 feet of the God Emporer take a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}, AC, and saving throws.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_Dark_Aura;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.AdditionalAttackBonus;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.AC;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.SaveFortitude;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.SaveReflex;
                    c.Value = -4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.SaveWill;
                    c.Value = -4;
                });
            });
            var DarkAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("DarkAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Enemy;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = true;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet() { m_Value = 40 };
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(DarkAuraEffectBuff.ToReference<BlueprintBuffReference>()));
            });
            var DarkAuraBuff = Helpers.CreateBlueprint<BlueprintBuff>("DarkAuraBuff", bp => {
                bp.SetName("Dark Aura");
                bp.SetDescription("At 10th level, enemies within 40 feet of the God Emporer take a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}, AC, and saving throws.");
                bp.m_Icon = Icon_Dark_Aura;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = DarkAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var DarkAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>("DarkAuraFeature", bp => {
                bp.SetName("Dark Aura");
                bp.SetDescription("At 10th level, enemies within 40 feet of the God Emporer take a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}, AC, and saving throws.");
                bp.m_Icon = Icon_Dark_Aura;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AuraFeatureComponent>(c => {
                    c.m_Buff = DarkAuraBuff.ToReference<BlueprintBuffReference>();
                });
            });
        }
    }
}
