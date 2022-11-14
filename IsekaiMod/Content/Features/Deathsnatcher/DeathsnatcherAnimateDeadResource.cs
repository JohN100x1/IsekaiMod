using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;

namespace IsekaiMod.Content.Features.Deathsnatcher
{
    class DeathsnatcherAnimateDeadResource
    {
        public static void Add()
        {
            var DeathsnatcherAnimateDeadResource = Helpers.CreateBlueprint<BlueprintAbilityResource>("DeathsnatcherAnimateDeadResource", bp => {
                bp.m_MaxAmount = new BlueprintAbilityResource.Amount
                {
                    BaseValue = 3,
                    IncreasedByLevel = false,
                    LevelIncrease = 1,
                    IncreasedByLevelStartPlusDivStep = false,
                    StartingLevel = 0,
                    StartingIncrease = 0,
                    LevelStep = 0,
                    PerStepIncrease = 0,
                    MinClassLevelIncrease = 0,
                    OtherClassesModifier = 0,
                    IncreasedByStat = false,
                    ResourceBonusStat = StatType.Unknown,
                };
            });
        }
        public static BlueprintAbilityResource Get()
        {
            return Resources.GetModBlueprint<BlueprintAbilityResource>("DeathsnatcherAnimateDeadResource");
        }
        public static BlueprintAbilityResourceReference GetReference()
        {
            return Get().ToReference<BlueprintAbilityResourceReference>();
        }
    }
}
