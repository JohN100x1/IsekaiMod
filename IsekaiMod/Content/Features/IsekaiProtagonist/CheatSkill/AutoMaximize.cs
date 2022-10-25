using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CheatSkill
{
    class AutoMaximize
    {
        public static void Add()
        {
            var Icon_MaximizeSpell = Resources.GetBlueprint<BlueprintFeature>("7f2b282626862e345935bbea5e66424b").m_Icon;
            var AutoMaximize = Helpers.CreateBlueprint<BlueprintFeature>("AutoMaximize", bp => {
                bp.SetName("Cheat Skill — Auto Maximize");
                bp.SetDescription("Every time you cast a spell, it becomes maximized, as though using the Maximize Spell feat.");
                bp.m_Icon = Icon_MaximizeSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Maximize;
                });
                bp.IsClassFeature = true;
            });
        }
    }
}
