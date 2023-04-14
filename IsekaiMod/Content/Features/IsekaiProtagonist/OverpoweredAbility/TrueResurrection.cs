using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class TrueResurrection {
        private const string Name = "Overpowered Ability — True Resurrection";
        private static readonly LocalizedString Description = Helpers.CreateString(IsekaiContext, "TrueResurrection.Description",
            "Restore life and complete {g|Encyclopedia:Strength}strength{/g} to any deceased creature. Upon completion of this ability, "
            + "the creature is immediately restored to full {g|Encyclopedia:HP}hit points{/g}, vigor, and {g|Encyclopedia:Healing}health{/g}, "
            + "with no loss of prepared spells.\nThis ability does not require diamonds.");
        private static readonly Sprite Icon_Resurrection = BlueprintTools.GetBlueprint<BlueprintAbility>("80a1a388ee938aa4e90d427ce9a7a3e9").m_Icon;

        public static void Add() {
            var TrueResurrectionAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "TrueResurrectionAbility", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(Description);
                bp.m_Icon = Icon_Resurrection;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<ContextActionResurrect>(c => {
                        c.FullRestore = true;
                    });
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Conjuration;
                });
                bp.AddComponent<AbilityTargetIsDeadCompanion>();
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "ee0c5b9397ffec54d86acf56c94f4b06" };
                    c.Time = AbilitySpawnFxTime.OnPrecastFinished;
                    c.Anchor = AbilitySpawnFxAnchor.SelectedTarget;
                });
                bp.Type = AbilityType.Supernatural;
                bp.Range = AbilityRange.Unlimited;
                bp.CanTargetFriends = true;
                bp.CanTargetSelf = true;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Point;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.m_IsFullRoundAction = true;
                bp.AvailableMetamagic = Metamagic.Quicken | Metamagic.Heighten | Metamagic.CompletelyNormal;
                bp.LocalizedDuration = StaticReferences.Strings.Duration.OneRoundPerLevel;
                bp.LocalizedSavingThrow = StaticReferences.Strings.Null;
            });
            var TrueResurrectionFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "TrueResurrectionFeature", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(Description);
                bp.m_Icon = Icon_Resurrection;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { TrueResurrectionAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToNonAutoSelection(TrueResurrectionFeature);
        }
    }
}