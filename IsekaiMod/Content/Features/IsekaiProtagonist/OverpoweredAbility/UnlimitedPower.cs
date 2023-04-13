using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
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
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class UnlimitedPower {

        public static void Add() {
            var Icon_Unlimited_Power = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_UNLIMITED_POWER.png");
            var UnlimitedPowerAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "UnlimitedPowerAbility", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Unlimited Power");
                bp.SetDescription(IsekaiContext, "On the brink of defeat, the enemies have surrounded and exhausted you. "
                    + "Just as they are about to deliver the finishing blow, you get up and saying the following words: Not today."
                    + "\nBenefit: As a free action, you restore all abilities and spell slots.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = Helpers.CreateActionList(
                        new ContextRestoreResource() {
                            m_IsFullRestoreAllResources = true,
                            Value = 0
                        },
                        new ContextActionRestoreAllSpellSlots() {
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
                bp.CanTargetSelf = true;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Self;
                bp.ActionType = UnitCommand.CommandType.Free;
                bp.AvailableMetamagic = Metamagic.Quicken;
                bp.LocalizedDuration = StaticReferences.Strings.Null;
                bp.LocalizedSavingThrow = StaticReferences.Strings.Null;
            });
            var UnlimitedPowerFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "UnlimitedPowerFeature", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Unlimited Power");
                bp.SetDescription(IsekaiContext, "On the brink of defeat, the enemies have surrounded and exhausted you. "
                    + "Just as they are about to deliver the finishing blow, you get up and saying the following words: Not today."
                    + "\nBenefit: As a free action, you restore all abilities and spell slots.");
                bp.m_Icon = Icon_Unlimited_Power;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { UnlimitedPowerAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToNonAutoSelection(UnlimitedPowerFeature);
        }
    }
}