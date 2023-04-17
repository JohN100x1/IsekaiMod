using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord {

    internal class OverlordProficiencies {
        public static void Add() {
            var OverlordProficiencies = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "OverlordProficiencies", bp => {
                bp.SetName(IsekaiContext, "Overlord Proficiences");
                bp.SetDescription(IsekaiContext, "The Overlord is proficient with all simple, martial, and exotic weapons and with all armor (heavy, light, and medium) and shields "
                    + "(including tower shields). They can cast {g|Encyclopedia:Spell}spells{/g} from this class while wearing armor and shields (including tower shields) without "
                    + "incurring the normal {g|Encyclopedia:Spell_Fail_Chance}arcane spell failure chance{/g}, but they incur the normal arcane spell failure chance for arcane spells "
                    + "received from other classes.");
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        StaticReferences.Proficiencies.LightArmorProficiency.ToReference<BlueprintUnitFactReference>(),
                        StaticReferences.Proficiencies.MediumArmorProficiency.ToReference<BlueprintUnitFactReference>(),
                        StaticReferences.Proficiencies.HeavyArmorProficiency.ToReference<BlueprintUnitFactReference>(),
                        StaticReferences.Proficiencies.SimpleWeaponProficiency.ToReference<BlueprintUnitFactReference>(),
                        StaticReferences.Proficiencies.MartialWeaponProficiency.ToReference<BlueprintUnitFactReference>(),
                        StaticReferences.Proficiencies.ExoticWeaponProficiency.ToReference<BlueprintUnitFactReference>(),
                        StaticReferences.Proficiencies.ShieldsProficiency.ToReference<BlueprintUnitFactReference>(),
                        StaticReferences.Proficiencies.TowerShieldProficiency.ToReference<BlueprintUnitFactReference>(),
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