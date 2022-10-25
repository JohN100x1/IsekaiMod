using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CheatSkill
{
    class AutoQuicken
    {
        public static void Add()
        {
            var Icon_QuickenSpell = Resources.GetBlueprint<BlueprintFeature>("ef7ece7bb5bb66a41b256976b27f424e").m_Icon;
            var AutoQuicken = Helpers.CreateBlueprint<BlueprintFeature>("AutoQuicken", bp => {
                bp.SetName("Cheat Skill — Auto Quicken");
                bp.SetDescription("Every time you cast a spell, it becomes quickened, as though using the Quicken Spell feat.");
                bp.m_Icon = Icon_QuickenSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Quicken;
                });
                bp.IsClassFeature = true;
            });
        }
    }
}
