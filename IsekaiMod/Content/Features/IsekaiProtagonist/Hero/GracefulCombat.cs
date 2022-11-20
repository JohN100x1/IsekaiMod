using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Hero
{
    class GracefulCombat
    {
        public static void Add()
        {
            var Icon_Graceful_Combat = AssetLoader.LoadInternal("Features", "ICON_GRACEFUL_COMBAT.png");
            var GracefulCombat = Helpers.CreateBlueprint<BlueprintFeature>("GracefulCombat", bp => {
                bp.SetName("Graceful Combat");
                bp.SetDescription("The Hero uses their Charisma modifier for their melee attack and damage bonus instead of Strength. "
                    + "In addition, they may use their Charisma in place of their Strength for CMB and to qualify for any feat for which it is a prerequisite.");
                bp.m_Icon = Icon_Graceful_Combat;
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
