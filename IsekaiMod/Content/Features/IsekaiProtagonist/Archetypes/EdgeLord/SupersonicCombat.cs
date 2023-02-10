using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord {

    internal class SupersonicCombat {
        private static readonly Sprite Icon_SuperiorReflexes = BlueprintTools.GetBlueprint<BlueprintFeature>("b89373001e05f1f4aa9b9bb4f420c40f").m_Icon;

        public static void Add() {
            var SupersonicCombat = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "SupersonicCombat", bp => {
                bp.SetName(IsekaiContext, "Supersonic Combat");
                bp.SetDescription(IsekaiContext, "The Edge Lord uses their Dexterity modifier for their melee attack and damage bonus instead of Strength. "
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
                    c.OnlyMelee = false;
                    c.CheckSubCategory = false;
                });
                bp.AddComponent<ReplaceStatForPrerequisites>(c => {
                    c.OldStat = StatType.Strength;
                    c.NewStat = StatType.Dexterity;
                    c.Policy = ReplaceStatForPrerequisites.StatReplacementPolicy.NewStat;
                });
            });
        }
    }
}