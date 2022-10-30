using IsekaiMod.Utilities;
using IsekaiMod.Extensions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.ActivatableAbilities;

namespace IsekaiMod.Content.Features.IsekaiSuccubus
{
    class SuccubusWingsAbility
    {
        public static void Add()
        {
            // Buff
            var DominatePersonBuff = Resources.GetBlueprint<BlueprintBuff>("c0f4e1c24c9cd334ca988ed1bd9d201f");

            // Ability
            var ICON_CHARM = AssetLoader.LoadInternal("Abilities", "ICON_CHARM.png");



            var SuccubusWingsAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("SuccubusWingsAbility", bp => {
                bp.SetName("Succubus Wings");
                bp.SetDescription("You gain a pair of wings that grant a +3 dodge {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Armor_Class}AC{/g} "
                    + "against {g|Encyclopedia:MeleeAttack}melee attacks{/g} and an immunity to ground based effects, such as difficult terrain.");
                bp.m_Icon = ICON_CHARM;
            });
        }
    }
}
