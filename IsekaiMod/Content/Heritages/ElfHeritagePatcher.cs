using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Heritages
{
    class ElfHeritagePatcher
    {
        private static readonly BlueprintFeature DestinyBeyondBirthMythicFeat = Resources.GetBlueprint<BlueprintFeature>("325f078c584318849bfe3da9ea245b9d");
        private static readonly BlueprintRace ElfRace = Resources.GetBlueprint<BlueprintRace>("25a5878d125338244896ebd3238226c8");
        private static readonly BlueprintFeature BaseRaceFeature = Resources.GetBlueprint<BlueprintFeature>("8b2da1d0f9504872809e63b39c24c502");
        public static void Patch()
        {
            // Create and load Elven Heritages
            var BaseElfRaceFeature = Helpers.CreateFeature("BaseElfRaceFeature", bp => {
                bp.m_DisplayName = BaseRaceFeature.m_DisplayName;
                bp.m_Description = BaseRaceFeature.m_Description;
            });
            var BlightBornElf = Resources.GetBlueprint<BlueprintFeature>("2a300f4e0c13495bbde59160809fce7f");
            var LoremasterElf = Resources.GetBlueprint<BlueprintFeature>("fb69a451e7064015b5dbe512c9122ef8");

            // Move Stat bonuses from Elf Race to Heritages
            ElfRace.Components = new BlueprintComponent[0];
            var ElvenStats = new BlueprintComponent[]
            {
                new AddStatBonus()
                {
                    Descriptor = ModifierDescriptor.Racial,
                    Stat = StatType.Dexterity,
                    Value = 2
                },
                new AddStatBonus()
                {
                    Descriptor = ModifierDescriptor.Racial,
                    Stat = StatType.Intelligence,
                    Value = 2
                },
                new AddStatBonusIfHasFact()
                {
                    Descriptor = ModifierDescriptor.Racial,
                    Stat = StatType.Constitution,
                    Value = -2,
                    InvertCondition = true,
                    m_CheckedFacts = new BlueprintUnitFactReference[] { DestinyBeyondBirthMythicFeat.ToReference<BlueprintUnitFactReference>() }
                },
            };
            BaseElfRaceFeature.Components = ElvenStats;
            BlightBornElf.Components = BlightBornElf.Components.AppendToArray(ElvenStats);
            LoremasterElf.Components = LoremasterElf.Components.AppendToArray(ElvenStats);

            // Set Elven Heritage Selection
            var ElvenHeritageSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("5482f879dcfd40f9a3168fdb48bc938c");
            ElvenHeritageSelection.m_AllFeatures = new BlueprintFeatureReference[]
            {
                BaseElfRaceFeature.ToReference<BlueprintFeatureReference>(),
                BlightBornElf.ToReference<BlueprintFeatureReference>(),
                LoremasterElf.ToReference<BlueprintFeatureReference>(),
            };
        }
    }
}
