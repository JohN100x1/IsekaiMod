using IsekaiMod.Content.Classes.Deathsnatcher;
using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.Deathsnatcher
{
    class DeathsnatcherSizeBaby
    {
        private static readonly BlueprintUnitFact NaturalArmor10 = Resources.GetBlueprint<BlueprintUnitFact>("4179c5c08d606a6439a62bf178b738e1");
        private static readonly BlueprintUnitFact NaturalArmor16 = Resources.GetBlueprint<BlueprintUnitFact>("73a90b2a70d576f429ad401e7a5a8a4f");
        public static void Add()
        {
            var DeathsnatcherSizeBabyBuff = Helpers.CreateBuff("DeathsnatcherSizeBabyBuff", bp => {
                bp.SetName("Baby Deathsnatcher");
                bp.SetDescription("The Deathsnatcher matures at 4th level. When this occurs, the Deathsnatcher’s natural armor bonus to its AC increases by 6, and gains "
                    + "the following ability scores adjustments: Str +6, Dex –4, Con +4.");
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi | BlueprintBuff.Flags.StayOnDeath;
                bp.AddComponent<ChangeUnitSize>(c => {
                    c.m_Type = ChangeUnitSize.ChangeType.Delta;
                    c.SizeDelta = -2;
                    c.Size = Size.Fine;
                });
                bp.AddComponent<AddGenericStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Size;
                    c.Stat = StatType.Strength;
                    c.Value = -6;
                });
                bp.AddComponent<AddGenericStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Size;
                    c.Stat = StatType.Dexterity;
                    c.Value = +4;
                });
                bp.AddComponent<AddGenericStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Size;
                    c.Stat = StatType.Constitution;
                    c.Value = -4;
                });
            });
            var DeathsnatcherSizeBaby = Helpers.CreateFeature("DeathsnatcherSizeBaby", bp => {
                bp.HideInUI = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        DeathsnatcherSizeBabyBuff.ToReference<BlueprintUnitFactReference>(),
                        NaturalArmor10.ToReference<BlueprintUnitFactReference>(),
                    };
                });
            });
            var DeathsnatcherNaturalArmor = Helpers.CreateFeature("DeathsnatcherNaturalArmor", bp => {
                bp.SetName("Deathsnatcher Armor");
                bp.SetDescription("The Deathsnatcher has +16 natural armor bonus to AC.");
                bp.HideInUI = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        NaturalArmor16.ToReference<BlueprintUnitFactReference>()
                    };
                });
            });
            var DeathsnatcherSizeBabyFeature = Helpers.CreateFeature("DeathsnatcherSizeBabyFeature", bp => {
                bp.SetName("Baby Deathsnatcher");
                bp.SetDescription("The Deathsnatcher matures at 4th level. When this occurs, the Deathsnatcher’s natural armor bonus to its AC increases by 6, and gains "
                    + "the following ability scores adjustments: Str +6, Dex –4, Con +4.");
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = DeathsnatcherClass.GetReference();
                    c.Level = 4;
                    c.m_Feature = DeathsnatcherSizeBaby.ToReference<BlueprintFeatureReference>();
                    c.BeforeThisLevel = true;
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = DeathsnatcherClass.GetReference();
                    c.Level = 4;
                    c.m_Feature = DeathsnatcherNaturalArmor.ToReference<BlueprintFeatureReference>();
                    c.BeforeThisLevel = false;
                });
            });
        }
    }
}
