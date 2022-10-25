using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.EdgeLord
{
    class SupersonicCombat
    {
        public static void Add()
        {
            var Icon_SuperiorReflexes = Resources.GetBlueprint<BlueprintFeature>("b89373001e05f1f4aa9b9bb4f420c40f").m_Icon;
            var SupersonicCombat = Helpers.CreateBlueprint<BlueprintFeature>("SupersonicCombat", bp => {
                bp.SetName("Supersonic Combat");
                bp.SetDescription("The Edge Lord uses their Dexterity modifier for their melee attack and damage bonus instead of Strength.");
                bp.m_Icon = Icon_SuperiorReflexes;
                bp.AddComponent<AttackStatReplacement>(c => {
                    c.ReplacementStat = StatType.Dexterity;
                });
                bp.AddComponent<AnyWeaponDamageStatReplacement>(c => {
                    c.Stat = StatType.Dexterity;
                    c.OnlyMelee = true;
                    c.CheckSubCategory = false;
                });
                bp.IsClassFeature = true;
            });
        }
    }
}
