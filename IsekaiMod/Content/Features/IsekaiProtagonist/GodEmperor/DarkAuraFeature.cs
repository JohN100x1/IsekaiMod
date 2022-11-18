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

namespace IsekaiMod.Content.Features.IsekaiProtagonist.GodEmperor
{
    class DarkAuraFeature
    {
        public static void Add()
        {
            var Icon_Dark_Aura = AssetLoader.LoadInternal("Features", "ICON_DARK_AURA.png");
            var DarkAuraBuff = Helpers.CreateBlueprint<BlueprintBuff>("DarkAuraBuff", bp => {
                bp.SetName("Dark Aura");
                bp.SetDescription("This creature has a –2 penalty on attack {g|Encyclopedia:Dice}rolls{/g}, AC, and saving throws.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_Dark_Aura;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.AdditionalAttackBonus;
                    c.Value = -2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.AC;
                    c.Value = -2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.SaveFortitude;
                    c.Value = -2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.SaveReflex;
                    c.Value = -2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.SaveWill;
                    c.Value = -2;
                });
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var DarkAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("DarkAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Enemy;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = true;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(DarkAuraBuff.ToReference<BlueprintBuffReference>()));
            });
            var DarkAuraAreaBuff = Helpers.CreateBlueprint<BlueprintBuff>("DarkAuraAreaBuff", bp => {
                bp.SetName("Dark Aura");
                bp.SetDescription("Enemies within 40 feet take a –2 penalty on attack {g|Encyclopedia:Dice}rolls{/g}, AC, and saving throws.");
                bp.m_Icon = Icon_Dark_Aura;
                bp.IsClassFeature = true;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = DarkAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var DarkAuraAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("DarkAuraAbility", bp => {
                bp.SetName("Dark Aura");
                bp.SetDescription("Enemies within 40 feet take a –2 penalty on attack {g|Encyclopedia:Dice}rolls{/g}, AC, and saving throws.");
                bp.m_Icon = Icon_Dark_Aura;
                bp.m_Buff = DarkAuraAreaBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.None;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DoNotTurnOffOnRest = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var DarkAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>("DarkAuraFeature", bp => {
                bp.SetName("Dark Aura");
                bp.SetDescription("At 10th level, enemies within 40 feet take a –2 penalty on attack {g|Encyclopedia:Dice}rolls{/g}, AC, and saving throws.");
                bp.m_Icon = Icon_Dark_Aura;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { DarkAuraAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
