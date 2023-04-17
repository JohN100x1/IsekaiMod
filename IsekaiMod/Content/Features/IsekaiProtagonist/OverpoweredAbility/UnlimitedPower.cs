using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.Localization;
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
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class UnlimitedPower {
        private const string Name = "Overpowered Ability — Unlimited Power";
        private static readonly LocalizedString Description = Helpers.CreateString(IsekaiContext, "UnlimitedPower.Description",
            "On the brink of defeat, the enemies have surrounded and exhausted you. Just as they are about to deliver the finishing blow, "
            + "you get up and saying the following words: Not today.\nBenefit: As a free action, you restore all abilities and spell slots.");
        private static readonly Sprite Icon_UnlimitedPower = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_UNLIMITED_POWER.png");

        public static void Add() {
            var UnlimitedPowerAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "UnlimitedPowerAbility", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(Description);
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
                bp.m_Icon = Icon_UnlimitedPower;
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
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(Description);
                bp.m_Icon = Icon_UnlimitedPower;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { UnlimitedPowerAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToSelection(UnlimitedPowerFeature);
        }
    }
}