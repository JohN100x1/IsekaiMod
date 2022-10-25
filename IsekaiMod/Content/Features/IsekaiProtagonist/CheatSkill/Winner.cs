using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CheatSkill
{
    class Winner
    {
        public static void Add()
        {
            var Icon_Winner = AssetLoader.LoadInternal("Features", "ICON_WINNER.png");
            var Winner = Helpers.CreateBlueprint<BlueprintFeature>("Winner", bp => {
                bp.SetName("Winner");
                bp.SetDescription("You decide not to have any cheat skills after reincarnating into the new world.");
                bp.m_Icon = Icon_Winner;
                bp.IsClassFeature = true;
            });
        }
    }
}
