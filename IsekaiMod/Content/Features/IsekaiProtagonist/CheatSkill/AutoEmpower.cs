using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CheatSkill
{
    class AutoEmpower
    {
        public static void Add()
        {
            var Icon_EmpowerSpell = Resources.GetBlueprint<BlueprintFeature>("a1de1e4f92195b442adb946f0e2b9d4e").m_Icon;
            var AutoEmpower = Helpers.CreateBlueprint<BlueprintFeature>("AutoEmpower", bp => {
                bp.SetName("Cheat Skill — Auto Empower");
                bp.SetDescription("Every time you cast a spell, it becomes empowered, as though using the Empower Spell feat.");
                bp.m_Icon = Icon_EmpowerSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Empower;
                });
                bp.IsClassFeature = true;
            });
        }
    }
}
