using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.GodEmporer
{
    class GodEmporerTraining
    {
        public static void Add()
        {
            var FighterClass = Resources.GetBlueprint<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var IsekaiProtagonistClass = Resources.GetModBlueprint<BlueprintCharacterClass>("IsekaiProtagonistClass");

            // Feature
            var Icon_SwordSaintFighterTraining = Resources.GetBlueprint<BlueprintFeature>("9ab2ec65977cc524a99600babc7fe3b6").m_Icon;
            var GodEmporerTraining = Helpers.CreateBlueprint<BlueprintFeature>("GodEmporerTraining", bp => {
                bp.SetName("Fighter Training");
                bp.SetDescription("At 4th level, the God Emporer counts their class level as their fighter level for the purpose of qualifying for {g|Encyclopedia:Feat}feats{/g}. If they have levels in fighter, these levels stack.");
                bp.m_Icon = Icon_SwordSaintFighterTraining;
                bp.AddComponent<ClassLevelsForPrerequisites>(c => {
                    c.m_FakeClass = FighterClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_ActualClass = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.Modifier = 1.0;
                    c.Summand = 0;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });
        }
    }
}
