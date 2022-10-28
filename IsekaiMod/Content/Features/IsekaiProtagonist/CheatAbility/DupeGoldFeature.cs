using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Visual.Animation.Kingmaker.Actions;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CheatAbility
{
    class DupeGoldFeature
    {
        public static void Add()
        {
            // Gold
            var GoldCoins = Resources.GetBlueprint<BlueprintItem>("f2bc0997c24e573448c6c91d2be88afa");

            // Feature
            var Icon_Dupe_Gold = AssetLoader.LoadInternal("Features", "ICON_DUPE_GOLD.png");
            var DupeGoldAbility = Helpers.CreateBlueprint<BlueprintAbility>("DupeGoldAbility", bp => {
                bp.SetName("Cheat Ability — Dupe Gold");
                bp.SetDescription("As a standard action, you gain 1 million gold.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = Helpers.CreateActionList(
                        new AddItemToPlayer()
                        {
                            m_ItemToGive = GoldCoins.ToReference<BlueprintItemReference>(),
                            Silent = false,
                            Quantity = 1000000
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
                bp.LocalizedDuration = Helpers.CreateString($"{bp.name}.Duration", "");
                bp.LocalizedSavingThrow = Helpers.CreateString($"{bp.name}.SavingThrow", "");
            });
            var DupeGoldFeature = Helpers.CreateBlueprint<BlueprintFeature>("DupeGoldFeature", bp => {
                bp.SetName("Cheat Ability — Dupe Gold");
                bp.SetDescription("As a standard action, you gain 1 million gold.");
                bp.m_Icon = Icon_Dupe_Gold;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { DupeGoldAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
