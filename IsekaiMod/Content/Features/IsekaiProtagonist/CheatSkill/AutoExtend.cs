using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CheatSkill
{
    class AutoExtend
    {
        public static void Add()
        {
            var Icon_ExtendSpell = Resources.GetBlueprint<BlueprintFeature>("f180e72e4a9cbaa4da8be9bc958132ef").m_Icon;
            var AutoExtend = Helpers.CreateBlueprint<BlueprintFeature>("AutoExtend", bp => {
                bp.SetName("Cheat Skill — Auto Extend");
                bp.SetDescription("Every time you cast a spell, it becomes extended, as though using the Extend Spell feat.");
                bp.m_Icon = Icon_ExtendSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Extend;
                });
                bp.IsClassFeature = true;
            });
        }
    }
}
