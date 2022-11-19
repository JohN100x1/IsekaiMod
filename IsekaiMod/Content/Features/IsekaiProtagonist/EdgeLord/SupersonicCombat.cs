using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.EdgeLord
{
    class SupersonicCombat
    {
        private static readonly Sprite Icon_SuperiorReflexes = Resources.GetBlueprint<BlueprintFeature>("b89373001e05f1f4aa9b9bb4f420c40f").m_Icon;
        public static void Add()
        {
            var SupersonicCombat = Helpers.CreateBlueprint<BlueprintFeature>("SupersonicCombat", bp => {
                bp.SetName("Supersonic Combat");
                bp.SetDescription("The Edge Lord uses their Dexterity modifier for their melee attack and damage bonus instead of Strength. "
                    + "In addition, they may use their Dexterity in place of their Strength for CMB and to qualify for any feat for which it is a prerequisite.");
                bp.m_Icon = Icon_SuperiorReflexes;
                bp.AddComponent<ReplaceCombatManeuverStat>(c => {
                    c.StatType = StatType.Dexterity;
                });
                bp.AddComponent<AttackStatReplacement>(c => {
                    c.ReplacementStat = StatType.Dexterity;
                });
                bp.AddComponent<AnyWeaponDamageStatReplacement>(c => {
                    c.Stat = StatType.Dexterity;
                    c.OnlyMelee = true;
                    c.CheckSubCategory = false;
                });
                bp.AddComponent<ReplaceStatForPrerequisites>(c => {
                    c.OldStat = StatType.Strength;
                    c.NewStat = StatType.Dexterity;
                    c.Policy = ReplaceStatForPrerequisites.StatReplacementPolicy.NewStat;
                });
                bp.IsClassFeature = true;
            });
        }
    }
}
