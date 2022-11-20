using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist
{
    class IsekaiProtagonistCantripsFeature
    {
        public static void Add()
        {
            var IsekaiProtagonistCantripsFeature = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiProtagonistCantripsFeature", bp => {
                bp.SetName("Cantrips");
                bp.SetDescription("You can cast a number of {g|Encyclopedia:Cantrips_Orisons}cantrips{/g}, or 0-level {g|Encyclopedia:Spell}spells{/g}. "
                    + "These spells are cast like any other spell, but they are not expended when cast and may be used again.");
                bp.m_Icon = null;
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
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
