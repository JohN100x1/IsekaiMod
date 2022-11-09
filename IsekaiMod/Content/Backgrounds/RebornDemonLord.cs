using IsekaiMod.Utilities;
using IsekaiMod.Extensions;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums.Damage;

namespace IsekaiMod.Content.Backgrounds
{
    internal class RebornDemonLord
    {
        public static void Add()
        {
            var BackgroundRebornDemonLord = Helpers.CreateBlueprint<BlueprintFeature>("BackgroundRebornDemonLord", bp => {
                bp.SetName("Reborn Demon Lord");
                bp.SetDescription("The Reborn Demon Lord has a +2 bonus to strength and electricity resistance 20.\n"
                    + "If the character already has the class skill, {g|Encyclopedia:Weapon_Proficiency}weapon proficiency{/g} or armor proficiency granted by the selected background "
                    + "from her class during character creation, then the corresponding {g|Encyclopedia:Bonus}bonuses{/g} from background change to a +1 competence bonus in case of skills, "
                    + "a +1 enhancement bonus in case of weapon proficiency and a -1 Armor {g|Encyclopedia:Check}Check{/g} {g|Encyclopedia:Penalty}Penalty{/g} reduction in case of armor proficiency.");
                bp.m_Icon = null;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Stat = StatType.Strength;
                    c.Value = 2;
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Electricity;
                    c.Value = 20;
                });
            });
        }
    }
}
