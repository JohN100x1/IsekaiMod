using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {

    internal class IsekaiProtagonistProficiencies {
        private static readonly BlueprintFeature LightArmorProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("6d3728d4e9c9898458fe5e9532951132");
        private static readonly BlueprintFeature MediumArmorProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("46f4fb320f35704488ba3d513397789d");
        private static readonly BlueprintFeature HeavyArmorProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("1b0f68188dcc435429fb87a022239681");
        private static readonly BlueprintFeature SimpleWeaponProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("e70ecf1ed95ca2f40b754f1adb22bbdd");
        private static readonly BlueprintFeature MartialWeaponProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("203992ef5b35c864390b4e4a1e200629");
        private static readonly BlueprintFeature ShieldsProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("cb8686e7357a68c42bdd9d4e65334633");
        private static readonly BlueprintFeature TowerShieldProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("6105f450bb2acbd458d277e71e19d835");

        public static void Add() {
            var IsekaiProtagonistProficiencies = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistProficiencies", bp => {
                bp.SetName(IsekaiContext, "Isekai Protagonist Proficiences");
                bp.SetDescription(IsekaiContext, "Isekai Protagonists are proficient with all simple and {g|Encyclopedia:Weapon_Proficiency}martial weapons{/g} and with all armor "
                    + "(heavy, light, and medium) and shields (including tower shields). They can cast {g|Encyclopedia:Spell}spells{/g} from this class while wearing armor and shields "
                    + "(including tower shields) without incurring the normal {g|Encyclopedia:Spell_Fail_Chance}arcane spell failure chance{/g}, but they incur the normal arcane spell "
                    + "failure chance for arcane spells received from other classes.");
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        LightArmorProficiency.ToReference<BlueprintUnitFactReference>(),
                        MediumArmorProficiency.ToReference<BlueprintUnitFactReference>(),
                        HeavyArmorProficiency.ToReference<BlueprintUnitFactReference>(),
                        SimpleWeaponProficiency.ToReference<BlueprintUnitFactReference>(),
                        MartialWeaponProficiency.ToReference<BlueprintUnitFactReference>(),
                        ShieldsProficiency.ToReference<BlueprintUnitFactReference>(),
                        TowerShieldProficiency.ToReference<BlueprintUnitFactReference>(),
                    };
                });
                bp.AddComponent<ArcaneArmorProficiency>(c => {
                    c.Armor = new ArmorProficiencyGroup[] {
                        ArmorProficiencyGroup.Light,
                        ArmorProficiencyGroup.Medium,
                        ArmorProficiencyGroup.Heavy,
                        ArmorProficiencyGroup.Buckler,
                        ArmorProficiencyGroup.LightShield,
                        ArmorProficiencyGroup.HeavyShield,
                        ArmorProficiencyGroup.TowerShield
                    };
                });
            });
        }
    }
}