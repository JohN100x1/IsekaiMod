using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord
{
    class EdgeLordProficiencies
    {
        private static readonly BlueprintFeature LightArmorProficiency = Resources.GetBlueprint<BlueprintFeature>("6d3728d4e9c9898458fe5e9532951132");
        private static readonly BlueprintFeature MediumArmorProficiency = Resources.GetBlueprint<BlueprintFeature>("46f4fb320f35704488ba3d513397789d");
        private static readonly BlueprintFeature SimpleWeaponProficiency = Resources.GetBlueprint<BlueprintFeature>("e70ecf1ed95ca2f40b754f1adb22bbdd");
        private static readonly BlueprintFeature MartialWeaponProficiency = Resources.GetBlueprint<BlueprintFeature>("203992ef5b35c864390b4e4a1e200629");
        public static void Add()
        {
            var EdgeLordProficiencies = Helpers.CreateFeature("EdgeLordProficiencies", bp => {
                bp.SetName("Edge Lord Proficiencies");
                bp.SetDescription("The Edge Lord is proficient with all simple and martial weapons as well as light and medium armor. They can cast {g|Encyclopedia:Spell}spells{/g} from "
                    + "this class while wearing armor without incurring the normal {g|Encyclopedia:Spell_Fail_Chance}arcane spell failure chance{/g}, but they incur the normal arcane spell "
                    + "failure chance for arcane spells received from other classes.");
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        LightArmorProficiency.ToReference<BlueprintUnitFactReference>(),
                        MediumArmorProficiency.ToReference<BlueprintUnitFactReference>(),
                        SimpleWeaponProficiency.ToReference<BlueprintUnitFactReference>(),
                        MartialWeaponProficiency.ToReference<BlueprintUnitFactReference>(),
                    };
                });
                bp.AddComponent<ArcaneArmorProficiency>(c => {
                    c.Armor = new ArmorProficiencyGroup[] {
                        ArmorProficiencyGroup.Light,
                        ArmorProficiencyGroup.Medium,
                    };
                });
            });
        }
    }
}
