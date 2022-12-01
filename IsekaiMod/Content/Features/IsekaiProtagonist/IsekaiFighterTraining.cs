using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist
{
    class IsekaiFighterTraining
    {
        private static readonly Sprite Icon_SwordSaintFighterTraining = Resources.GetBlueprint<BlueprintFeature>("9ab2ec65977cc524a99600babc7fe3b6").m_Icon;
        private static readonly BlueprintCharacterClass FighterClass = Resources.GetBlueprint<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
        public static void Add()
        {
            var IsekaiFighterTraining = Helpers.CreateFeature("IsekaiFighterTraining", bp => {
                bp.SetName("Fighter Training");
                bp.SetDescription("At 3rd level, you count your class level as your fighter level for the purpose of qualifying for {g|Encyclopedia:Feat}feats{/g}. If you have levels in fighter, these levels stack.");
                bp.m_Icon = Icon_SwordSaintFighterTraining;
                bp.AddComponent<ClassLevelsForPrerequisites>(c => {
                    c.m_FakeClass = FighterClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_ActualClass = IsekaiProtagonistClass.GetReference();
                    c.Modifier = 1.0;
                });
            });
        }
    }
}