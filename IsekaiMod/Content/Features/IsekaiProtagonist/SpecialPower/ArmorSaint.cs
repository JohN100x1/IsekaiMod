using IsekaiMod.Components;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class ArmorSaint {
        private static readonly Sprite Icon_ArmorSaint = BlueprintTools.GetBlueprint<BlueprintFeature>("ae177f17cfb45264291d4d7c2cb64671").m_Icon;

        public static void Add() {
            var ArmorSaint = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ArmorSaint", bp => {
                bp.SetName(IsekaiContext, "Armor Saint");
                bp.SetDescription(IsekaiContext, "You can move at normal speed while wearing armor. You also reduce your armor check penalty to zero and increase your max dexterity bonus by 20.");
                bp.m_Icon = Icon_ArmorSaint;
                bp.AddComponent<ArmorNoSpeedPenalty>();
                bp.AddComponent<ArmorCheckPenaltyIncrease>(c => {
                    c.Bonus = 100;
                });
                bp.AddComponent<MaxDexBonusIncrease>(c => {
                    c.Bonus = 20;
                });
            });

            SpecialPowerSelection.AddToSelection(ArmorSaint);
        }
    }
}