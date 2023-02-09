using IsekaiMod.Content.Classes.IsekaiProtagonist;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {

    internal class IsekaiProtagonistCantrips {

        public static void Add() {
            var IsekaiProtagonistCantripsFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistCantripsFeature", bp => {
                bp.SetName(IsekaiContext, "Cantrips");
                bp.SetDescription(IsekaiContext, "You can cast a number of {g|Encyclopedia:Cantrips_Orisons}cantrips{/g}, or 0-level {g|Encyclopedia:Spell}spells{/g}. "
                    + "These spells are cast like any other spell, but they are not expended when cast and may be used again.");
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[]
                    {
                        IsekaiProtagonistSpellList.MageLightAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonistSpellList.JoltAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonistSpellList.DisruptUndeadAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonistSpellList.AcidSplashAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonistSpellList.DismissAreaEffectAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonistSpellList.DazeAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonistSpellList.TouchOfFatigueAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonistSpellList.FlareAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonistSpellList.RayOfFrostAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonistSpellList.ResistanceAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonistSpellList.DivineZapAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonistSpellList.GuidanceAbility.ToReference<BlueprintUnitFactReference>(),
                        IsekaiProtagonistSpellList.VirtueAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });
            });
        }
    }
}