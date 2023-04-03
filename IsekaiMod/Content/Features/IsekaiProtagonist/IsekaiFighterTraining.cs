﻿using IsekaiMod.Content.Classes.IsekaiProtagonist;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {

    internal class IsekaiFighterTraining {
        private static readonly Sprite Icon_SwordSaintFighterTraining = BlueprintTools.GetBlueprint<BlueprintFeature>("9ab2ec65977cc524a99600babc7fe3b6").m_Icon;

        public static void Add() {
            var IsekaiFighterTraining = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiFighterTraining", bp => {
                bp.SetName(IsekaiContext, "Fighter Training");
                bp.SetDescription(IsekaiContext, "At 3rd level, you count your class level as your fighter level"
                    + " for the purpose of qualifying for {g|Encyclopedia:Feat}feats{/g}. "
                    + "If you have levels in fighter, these levels stack. If you have a martial legacy, the fighter level is doubled.");
                bp.m_Icon = Icon_SwordSaintFighterTraining;
                bp.AddComponent<ClassLevelsForPrerequisites>(c => {
                    c.m_FakeClass = ClassTools.Classes.FighterClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_ActualClass = IsekaiProtagonistClass.GetReference();
                    c.Modifier = 1.0;
                });
            });
        }
    }
}