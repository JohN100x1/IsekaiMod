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
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist
{
    class FriendlyAuraFeature
    {
        public static void Add()
        {
            var Icon_Friendly_Aura = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_FRIENDLY_AURA.png");
            var FriendlyAuraBuff = ThingsNotHandledByTTTCore.CreateBuff("FriendlyAuraBuff", bp => {
                bp.SetName(IsekaiContext, "Friendly Aura");
                bp.SetDescription(IsekaiContext, "This creature has a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_Friendly_Aura;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.AdditionalAttackBonus;
                    c.Value = -4;
                });
            });
            var FriendlyAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "FriendlyAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Enemy;
                bp.AffectEnemies = true;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(FriendlyAuraBuff.ToReference<BlueprintBuffReference>()));
            });
            var FriendlyAuraAreaBuff = ThingsNotHandledByTTTCore.CreateBuff("FriendlyAuraAreaBuff", bp => {
                bp.SetName(IsekaiContext, "Friendly Aura");
                bp.SetDescription(IsekaiContext, "Enemies within 40 feet of the Isekai Protagonist take a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}.");
                bp.m_Icon = Icon_Friendly_Aura;
                bp.IsClassFeature = true;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = FriendlyAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
            });
            var FriendlyAuraAbility = ThingsNotHandledByTTTCore.CreateActivatableAbility( "FriendlyAuraAbility", bp => {
                bp.SetName(IsekaiContext, "Friendly Aura");
                bp.SetDescription(IsekaiContext, "Enemies within 40 feet of the Isekai Protagonist take a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}.");
                bp.m_Icon = Icon_Friendly_Aura;
                bp.m_Buff = FriendlyAuraAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var FriendlyAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext,"FriendlyAuraFeature", bp => {
                bp.SetName(IsekaiContext, "Friendly Aura");
                bp.SetDescription(IsekaiContext, "At 9th level, enemies within 40 feet of the Isekai Protagonist take a –4 penalty on attack {g|Encyclopedia:Dice}rolls{/g}.");
                bp.m_Icon = Icon_Friendly_Aura;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { FriendlyAuraAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
