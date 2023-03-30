using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord {

    internal class EdgeLordProficiencies {
        public static void Add() {
            var EdgeLordProficiencies = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "EdgeLordProficiencies", bp => {
                bp.SetName(IsekaiContext, "Edge Lord Proficiencies");
                bp.SetDescription(IsekaiContext, "The Edge Lord is proficient with all simple and martial weapons as well as light and medium armor. They can cast {g|Encyclopedia:Spell}spells{/g} from "
                    + "this class while wearing armor without incurring the normal {g|Encyclopedia:Spell_Fail_Chance}arcane spell failure chance{/g}, but they incur the normal arcane spell "
                    + "failure chance for arcane spells received from other classes.");
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        StaticReferences.Proficiencies.LightArmorProficiency.ToReference<BlueprintUnitFactReference>(),
                        StaticReferences.Proficiencies.MediumArmorProficiency.ToReference<BlueprintUnitFactReference>(),
                        StaticReferences.Proficiencies.SimpleWeaponProficiency.ToReference<BlueprintUnitFactReference>(),
                        StaticReferences.Proficiencies.MartialWeaponProficiency.ToReference<BlueprintUnitFactReference>(),
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