using IsekaiMod.Utilities;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using TabletopTweaks.Core.Utilities;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class PerfectRoll {
        public static void Add() {
            const string PerfectRollDesc = "You navigate every conversation and fight with perfect accuracy. "
                + "Every word is predicted; every action is foreseen. "
                + "Your premonitions guide you on your quest, as if you have experienced this before..."
                + "\nBenefit: You always {g|Encyclopedia:Dice}roll{/g} a 20 on all d20 rolls.";
            var Icon_TrickFate = BlueprintTools.GetBlueprint<BlueprintAbility>("6e109d21da9e1c44fb772a9eca2cafdd").m_Icon;

            var PerfectRollFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "PerfectRoll",
                displayName: "Overpowered Ability — Perfect Roll",
                description: PerfectRollDesc,
                displayNameBuff: "Perfect Roll",
                descriptionBuff: "This character always {g|Encyclopedia:Dice}rolls{/g} 20 on all d20 rolls.",
                icon: Icon_TrickFate,
                buffEffect: bp => {
                    bp.AddComponent<ModifyD20>(c => {
                        c.Rule = RuleType.All;
                        c.Replace = true;
                        c.RollResult = 20;
                    });
                });

            OverpoweredAbilitySelection.AddToSelection(PerfectRollFeature);
        }
    }
}