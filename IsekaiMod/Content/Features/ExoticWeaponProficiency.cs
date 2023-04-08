using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features {

    internal class ExoticWeaponProficiency {
        private static readonly BlueprintCharacterClass AnimalCompanionClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("26b10d4340839004f960f9816f6109fe");
        private static readonly Sprite Icon_ExcoticWeaponProficiency = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("9a01b6815d6c3684cb25f30b8bf20932").m_Icon;

        public static void Add() {
            WeaponCategory[] exoticWeaponCategories = new WeaponCategory[]
                    {
                        WeaponCategory.BastardSword,
                        WeaponCategory.DuelingSword,
                        WeaponCategory.DwarvenWaraxe,
                        WeaponCategory.ElvenCurvedBlade,
                        WeaponCategory.Estoc,
                        WeaponCategory.Falcata,
                        WeaponCategory.Fauchard,
                        WeaponCategory.Kama,
                        WeaponCategory.Sai,
                        WeaponCategory.Tongi,
                        WeaponCategory.SlingStaff,
                        WeaponCategory.DoubleAxe,
                        WeaponCategory.DoubleSword,
                        WeaponCategory.Urgrosh,
                        WeaponCategory.HookedHammer,
                        WeaponCategory.Nunchaku,
                    };
            var ExoticWeaponProficiency = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ExoticWeaponProficiency", bp => {
                bp.SetName(IsekaiContext, "Exotic Weapon Proficiency");
                bp.SetDescription(IsekaiContext, "You become proficient with all Exotic Weapons.");
                bp.m_Icon = Icon_ExcoticWeaponProficiency;
                bp.AddComponent<AddProficiencies>(c => {
                    c.WeaponProficiencies = exoticWeaponCategories;
                });
                bp.AddComponent<PrerequisiteNotProficient>(c => {
                    c.Group = Prerequisite.GroupType.All;
                    c.HideInUI = true;
                    c.WeaponProficiencies = exoticWeaponCategories;
                });
                bp.AddComponent<PrerequisiteClassLevel>(c => {
                    c.Group = Prerequisite.GroupType.Any;
                    c.HideInUI = true;
                    c.m_CharacterClass = AnimalCompanionClass.ToReference<BlueprintCharacterClassReference>();
                    c.Level = 1;
                    c.Not = true;
                });
                bp.Groups = new FeatureGroup[] { FeatureGroup.Feat, FeatureGroup.CombatFeat };
            });
        }
    }
}