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

namespace IsekaiMod.Content.Features.IsekaiProtagonist
{
    class FriendlyAuraFeature
    {
        public static void Add()
        {
            var Icon_Friendly_Aura = AssetLoader.LoadInternal("Features", "ICON_FRIENDLY_AURA.png");
            var FriendlyAuraBuff = Helpers.CreateBlueprint<BlueprintBuff>("FriendlyAuraBuff", bp => {
                bp.SetName("Friendly Aura");
                bp.SetDescription("This creature has a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_Friendly_Aura;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.AdditionalAttackBonus;
                    c.Value = -4;
                });
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var FriendlyAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("FriendlyAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Enemy;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = true;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(FriendlyAuraBuff.ToReference<BlueprintBuffReference>()));
            });
            var FriendlyAuraAreaBuff = Helpers.CreateBlueprint<BlueprintBuff>("FriendlyAuraAreaBuff", bp => {
                bp.SetName("Friendly Aura");
                bp.SetDescription("Enemies within 40 feet of the Isekai Protagonist take a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}.");
                bp.m_Icon = Icon_Friendly_Aura;
                bp.IsClassFeature = true;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = FriendlyAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var FriendlyAuraAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("FriendlyAuraAbility", bp => {
                bp.SetName("Friendly Aura");
                bp.SetDescription("Enemies within 40 feet of the Isekai Protagonist take a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}.");
                bp.m_Icon = Icon_Friendly_Aura;
                bp.m_Buff = FriendlyAuraAreaBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.None;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DoNotTurnOffOnRest = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var FriendlyAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>("FriendlyAuraFeature", bp => {
                bp.SetName("Friendly Aura");
                bp.SetDescription("At 9th level, enemies within 40 feet of the Isekai Protagonist take a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}.");
                bp.m_Icon = Icon_Friendly_Aura;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { FriendlyAuraAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
