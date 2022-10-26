using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CheatSkill
{
    class AutoReach
    {
        public static void Add()
        {
            var Icon_ReachSpell = Resources.GetBlueprint<BlueprintFeature>("46fad72f54a33dc4692d3b62eca7bb78").m_Icon;
            var AutoReach = Helpers.CreateBlueprint<BlueprintFeature>("AutoReach", bp => {
                bp.SetName("Cheat Skill — Auto Reach");
                bp.SetDescription("Every time you cast a spell, it increases its range by one range category, as though using the Reach Spell feat.");
                bp.m_Icon = Icon_ReachSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Reach;
                });
                bp.IsClassFeature = true;
            });
        }
    }
}
