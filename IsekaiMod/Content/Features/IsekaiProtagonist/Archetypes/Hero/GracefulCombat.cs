using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero {

    internal class GracefulCombat {
        private static readonly Sprite Icon_WeaponBondHolyBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("beffc11890fb54a48b855ef14f0a284e").m_Icon;

        public static void Add() {
            var GracefulCombat = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "GracefulCombat", bp => {
                bp.SetName(IsekaiContext, "Graceful Combat");
                bp.SetDescription(IsekaiContext, "The Hero uses their Charisma modifier for their melee attack and damage bonus instead of Strength. "
                    + "In addition, they may use their Charisma in place of their Strength for CMB and to qualify for any feat for which it is a prerequisite.");
                bp.m_Icon = Icon_WeaponBondHolyBuff;
                bp.AddComponent<ReplaceCombatManeuverStat>(c => {
                    c.StatType = StatType.Charisma;
                });
                bp.AddComponent<AttackStatReplacement>(c => {
                    c.ReplacementStat = StatType.Charisma;
                });
                bp.AddComponent<AnyWeaponDamageStatReplacement>(c => {
                    c.Stat = StatType.Charisma;
                    c.OnlyMelee = false;
                    c.CheckSubCategory = false;
                });
                bp.AddComponent<ReplaceStatForPrerequisites>(c => {
                    c.OldStat = StatType.Strength;
                    c.NewStat = StatType.Charisma;
                    c.Policy = ReplaceStatForPrerequisites.StatReplacementPolicy.NewStat;
                });
            });
        }
    }
}