using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class DupeGold {
        private const string Name = "Overpowered Ability — Dupe Gold";
        private const string Description = "In this new world, you will never be cold or hungry again."
            + "\nBenefit: As a standard action, you gain 1 million gold.";

        // Referenced blueprints
        private static readonly BlueprintItem GoldCoins = BlueprintTools.GetBlueprint<BlueprintItem>("f2bc0997c24e573448c6c91d2be88afa");

        public static void Add() {
            var Icon_Dupe_Gold = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_DUPE_GOLD.png");
            var DupeGoldAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "DupeGoldAbility", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<AddItemToPlayer>(c => {
                        c.m_ItemToGive = GoldCoins.ToReference<BlueprintItemReference>();
                        c.Silent = false;
                        c.Quantity = 1_000_000;
                    });
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Transmutation;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "358e9c4bd0b52f443b72ad2332e038a4" };
                    c.Time = AbilitySpawnFxTime.OnApplyEffect;
                    c.Anchor = AbilitySpawnFxAnchor.Caster;
                });
                bp.m_Icon = Icon_Dupe_Gold;
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
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Quicken;
                bp.m_TargetMapObjects = false;
                bp.LocalizedDuration = new LocalizedString();
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            var DupeGoldFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DupeGoldFeature", bp => {
                bp.SetName(IsekaiContext, Name);
                bp.SetDescription(IsekaiContext, Description);
                bp.m_Icon = Icon_Dupe_Gold;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { DupeGoldAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToSelection(DupeGoldFeature);
        }
    }
}