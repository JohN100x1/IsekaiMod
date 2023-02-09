using IsekaiMod.Content.Classes.Deathsnatcher;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.Deathsnatcher {

    internal class DeathsnatcherSizeBaby {
        private static readonly BlueprintUnitFact NaturalArmor10 = BlueprintTools.GetBlueprint<BlueprintUnitFact>("4179c5c08d606a6439a62bf178b738e1");
        private static readonly BlueprintUnitFact NaturalArmor16 = BlueprintTools.GetBlueprint<BlueprintUnitFact>("73a90b2a70d576f429ad401e7a5a8a4f");

        public static void Add() {
            var DeathsnatcherSizeBabyBuff = ThingsNotHandledByTTTCore.CreateBuff("DeathsnatcherSizeBabyBuff", bp => {
                bp.SetName(IsekaiContext, "Baby Deathsnatcher");
                bp.SetDescription(IsekaiContext, "The Deathsnatcher matures at 4th level. When this occurs, the Deathsnatcher’s natural armor bonus to its AC increases by 6, and gains "
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
            var DeathsnatcherSizeBaby = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherSizeBaby", bp => {
                bp.HideInUI = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        DeathsnatcherSizeBabyBuff.ToReference<BlueprintUnitFactReference>(),
                        NaturalArmor10.ToReference<BlueprintUnitFactReference>(),
                    };
                });
            });
            var DeathsnatcherNaturalArmor = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherNaturalArmor", bp => {
                bp.SetName(IsekaiContext, "Deathsnatcher Armor");
                bp.SetDescription(IsekaiContext, "The Deathsnatcher has +16 natural armor bonus to AC.");
                bp.HideInUI = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        NaturalArmor16.ToReference<BlueprintUnitFactReference>()
                    };
                });
            });
            var DeathsnatcherSizeBabyFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherSizeBabyFeature", bp => {
                bp.SetName(IsekaiContext, "Baby Deathsnatcher");
                bp.SetDescription(IsekaiContext, "The Deathsnatcher matures at 4th level. When this occurs, the Deathsnatcher’s natural armor bonus to its AC increases by 6, and gains "
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