using IsekaiMod.Components;
using IsekaiMod.Utilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using TabletopTweaks.Core.Utilities;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class MasterSummoner {
        public static void Add() {
            const string MasterSummonerDesc = "Each time you cast a summoning {g|Encyclopedia:Spell}spell{/g}, "
                + "add the highest modifier of Intelligence, Wisdom and Charisma to the total number of creatures summoned.";
            var Icon_TrickFate = BlueprintTools.GetBlueprint<BlueprintAbility>("7f4b66a2b1fdab142904a263c7866d46").m_Icon;

            var MasterSummonerFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "MasterSummoner",
                displayName: "Overpowered Ability — Master Summoner",
                description: MasterSummonerDesc,
                icon: Icon_TrickFate,
                buffEffect: bp => {
                    bp.AddComponent<ExtraSummonCount>();
                });

            OverpoweredAbilitySelection.AddToSelection(MasterSummonerFeature);
        }
    }
}