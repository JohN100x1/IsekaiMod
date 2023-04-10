using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor {

    internal class GodlyVessel {

        public static void Add() {
            var Icon_PureForm = BlueprintTools.GetBlueprint<BlueprintAbility>("33e53b74891b4c34ba6ee3baa322beeb").m_Icon;
            var GodlyVessel = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "GodlyVessel", bp => {
                bp.SetName(IsekaiContext, "Godly Vessel");
                bp.SetDescription(IsekaiContext, "At 17th level, the God Emperor gains immunity to ..."
                    );
                bp.m_Icon = Icon_PureForm;
            });
        }
    }
}