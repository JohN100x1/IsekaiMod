using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System.Collections.Generic;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.Localization;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class UnlimitedPower
    {
        public static void Add()
        {
            var Icon_Unlimited_Power = AssetLoader.LoadInternal("Features", "ICON_UNLIMITED_POWER.png");
            var UnlimitedPowerAbility = Helpers.CreateBlueprint<BlueprintAbility>("UnlimitedPowerAbility", bp => {
                bp.SetName("Overpowered Ability — Unlimited Power");
                bp.SetDescription("As a free action, you restore all abilities and spell slots.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = Helpers.CreateActionList(
                        new ContextRestoreResource() {
                            m_IsFullRestoreAllResources = true,
                            ContextValueRestoration = false,
                            Value = 0
                        },
                        new ContextActionRestoreAllSpellSlots()
                        {
                            m_Target = new ContextTargetUnit(),
                            m_UpToSpellLevel = 11,
                            m_ExcludeSpellbooks = new List<BlueprintSpellbookReference>()
                        });
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Enchantment;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "0c07afb9ee854184cb5110891324e3ad" };
                    c.Time = AbilitySpawnFxTime.OnApplyEffect;
                    c.Anchor = AbilitySpawnFxAnchor.Caster;
                });
                bp.m_Icon = Icon_Unlimited_Power;
                bp.Type = AbilityType.Special;
                bp.Range = AbilityRange.Personal;
                bp.CanTargetPoint = false;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = true;
                bp.SpellResistance = false;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Self;
                bp.ActionType = UnitCommand.CommandType.Free;
                bp.AvailableMetamagic = Metamagic.Quicken;
                bp.m_TargetMapObjects = false;
                bp.LocalizedDuration = new LocalizedString();
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            var UnlimitedPowerFeature = Helpers.CreateBlueprint<BlueprintFeature>("UnlimitedPowerFeature", bp => {
                bp.SetName("Overpowered Ability — Unlimited Power");
                bp.SetDescription("As a free action, you restore all abilities and spell slots.");
                bp.m_Icon = Icon_Unlimited_Power;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { UnlimitedPowerAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToSelection(UnlimitedPowerFeature);
        }
    }
}
