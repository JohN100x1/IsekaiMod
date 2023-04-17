using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Backgrounds {

    internal class RebornDemonLord {

        public static void Add() {
            // Background
            var BackgroundRebornDemonLord = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "BackgroundRebornDemonLord", bp => {
                bp.SetName(IsekaiContext, "Reborn Demon Lord");
                bp.SetBackgroundDescription(IsekaiContext, "The Reborn Demon Lord has a +2 bonus to strength and electricity resistance 20.");
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Trait;
                    c.Stat = StatType.Strength;
                    c.Value = 2;
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Electricity;
                    c.Value = 20;
                });
            });

            // Register Background
            IsekaiBackgroundSelection.AddToSelection(BackgroundRebornDemonLord);
        }
    }
}