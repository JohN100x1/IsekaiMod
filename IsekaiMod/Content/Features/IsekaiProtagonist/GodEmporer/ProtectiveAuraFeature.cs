using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.GodEmporer
{
    class ProtectiveAuraFeature
    {
        public static void Add()
        {
            var Icon_Protective_Aura = AssetLoader.LoadInternal("Features", "ICON_PROTECTIVE_AURA.png");
            var ProtectiveAuraBuff = Helpers.CreateBlueprint<BlueprintBuff>("ProtectiveAuraBuff", bp => {
                bp.SetName("Protective Aura");
                bp.SetDescription("This character has a +2 bonus on AC and saving throws.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_Protective_Aura;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.None;
                    c.Stat = StatType.AC;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.None;
                    c.Stat = StatType.SaveFortitude;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.None;
                    c.Stat = StatType.SaveReflex;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.None;
                    c.Stat = StatType.SaveWill;
                    c.Value = 2;
                });
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var ProtectiveAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("ProtectiveAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = false;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet() { m_Value = 40 };
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(ProtectiveAuraBuff.ToReference<BlueprintBuffReference>()));
            });
            var ProtectiveAuraAreaBuff = Helpers.CreateBlueprint<BlueprintBuff>("ProtectiveAuraAreaBuff", bp => {
                bp.SetName("Protective Aura");
                bp.SetDescription("Allies within 40 feet of the God Emporer take a +2 bonus on AC, and saving throws.");
                bp.m_Icon = Icon_Protective_Aura;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = ProtectiveAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var ProtectiveAuraAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("ProtectiveAuraAbility", bp => {
                bp.SetName("Protective Aura");
                bp.SetDescription("Allies within 40 feet of the God Emporer take a +2 bonus on AC, and saving throws.");
                bp.m_Icon = Icon_Protective_Aura;
                bp.m_Buff = ProtectiveAuraAreaBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.None;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DoNotTurnOffOnRest = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var ProtectiveAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>("ProtectiveAuraFeature", bp => {
                bp.SetName("Protective Aura");
                bp.SetDescription("At 6th level, allies within 40 feet of the God Emporer take a +2 bonus on AC, and saving throws.");
                bp.m_Icon = Icon_Protective_Aura;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { ProtectiveAuraAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
