using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Hero
{
    class GracefulCombat
    {
        private static readonly Sprite Icon_HolySword = Resources.GetBlueprint<BlueprintAbility>("bea9deffd3ab6734c9534153ddc70bde").m_Icon;
        public static void Add()
        {
            var GracefulCombat = Helpers.CreateBlueprint<BlueprintFeature>("GracefulCombat", bp => {
                bp.SetName("Graceful Combat");
                bp.SetDescription("The Hero uses their Charisma modifier for their melee attack and damage bonus instead of Strength. "
                    + "In addition, they may use their Charisma in place of their Strength for CMB and to qualify for any feat for which it is a prerequisite.");
                bp.m_Icon = Icon_HolySword;
                bp.AddComponent<ReplaceCombatManeuverStat>(c => {
                    c.StatType = StatType.Charisma;
                });
                bp.AddComponent<AttackStatReplacement>(c => {
                    c.ReplacementStat = StatType.Charisma;
                });
                bp.AddComponent<AnyWeaponDamageStatReplacement>(c => {
                    c.Stat = StatType.Charisma;
                    c.OnlyMelee = true;
                    c.CheckSubCategory = false;
                });
                bp.AddComponent<ReplaceStatForPrerequisites>(c => {
                    c.OldStat = StatType.Strength;
                    c.NewStat = StatType.Charisma;
                    c.Policy = ReplaceStatForPrerequisites.StatReplacementPolicy.NewStat;
                });
                bp.IsClassFeature = true;
            });
        }
    }
}
