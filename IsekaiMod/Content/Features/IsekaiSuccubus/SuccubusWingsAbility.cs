using IsekaiMod.Utilities;
using IsekaiMod.Extensions;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.ActivatableAbilities.Restrictions;

namespace IsekaiMod.Content.Features.IsekaiSuccubus
{
    class SuccubusWingsAbility
    {
        public static void Add()
        {
            // Buff
            var BuffWingsMutagen = Resources.GetBlueprint<BlueprintBuff>("e4979934bdb39d842b28bee614606823");
            var WingsDiabolic = Resources.GetBlueprint<BlueprintBuff>("4113178a8d5bf4841b8f15b1b39e004f");

            // Ability
            var Icon_Wings = Resources.GetBlueprint<BlueprintActivatableAbility>("13143852b74718144ac4267b949615f0").m_Icon;
            var SuccubusWingsAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("SuccubusWingsAbility", bp => {
                bp.SetName("Succubus Wings");
                bp.SetDescription("You gain a pair of wings that grant a +3 dodge {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Armor_Class}AC{/g} "
                    + "against {g|Encyclopedia:MeleeAttack}melee attacks{/g} and an immunity to ground based effects, such as difficult terrain.");
                bp.m_Icon = Icon_Wings;
                bp.AddComponent<RestrictionHasFact>(c => {
                    c.m_Feature = BuffWingsMutagen.ToReference<BlueprintUnitFactReference>();
                    c.Not = true;
                });
                bp.m_Buff = WingsDiabolic.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.Wings;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
        }
    }
}
