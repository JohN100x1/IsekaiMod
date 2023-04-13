using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Backgrounds {

    internal class MartialArtist {

        public static void Add() {
            // Background
            var ExoticWeaponProficiency = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ExoticWeaponProficiency");
            var BackgroundMartialArtist = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "BackgroundMartialArtist", bp => {
                bp.SetName(IsekaiContext, "Martial Artist");
                bp.SetBackgroundDescription(IsekaiContext, "The Martial Artist is proficient with all exotic weapons.");
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { ExoticWeaponProficiency.ToReference<BlueprintUnitFactReference>() };
                });
                bp.AddComponent<AddBackgroundWeaponProficiency>(c => {
                    c.Proficiency = WeaponCategory.BastardSword;
                    c.StackBonusType = ModifierDescriptor.Enhancement;
                    c.StackBonus = 1;
                });
                bp.AddComponent<AddBackgroundWeaponProficiency>(c => {
                    c.Proficiency = WeaponCategory.DuelingSword;
                    c.StackBonusType = ModifierDescriptor.Enhancement;
                    c.StackBonus = 1;
                });
                bp.AddComponent<AddBackgroundWeaponProficiency>(c => {
                    c.Proficiency = WeaponCategory.DwarvenWaraxe;
                    c.StackBonusType = ModifierDescriptor.Enhancement;
                    c.StackBonus = 1;
                });
                bp.AddComponent<AddBackgroundWeaponProficiency>(c => {
                    c.Proficiency = WeaponCategory.ElvenCurvedBlade;
                    c.StackBonusType = ModifierDescriptor.Enhancement;
                    c.StackBonus = 1;
                });
                bp.AddComponent<AddBackgroundWeaponProficiency>(c => {
                    c.Proficiency = WeaponCategory.Estoc;
                    c.StackBonusType = ModifierDescriptor.Enhancement;
                    c.StackBonus = 1;
                });
                bp.AddComponent<AddBackgroundWeaponProficiency>(c => {
                    c.Proficiency = WeaponCategory.Falcata;
                    c.StackBonusType = ModifierDescriptor.Enhancement;
                    c.StackBonus = 1;
                });
                bp.AddComponent<AddBackgroundWeaponProficiency>(c => {
                    c.Proficiency = WeaponCategory.Fauchard;
                    c.StackBonusType = ModifierDescriptor.Enhancement;
                    c.StackBonus = 1;
                });
                bp.AddComponent<AddBackgroundWeaponProficiency>(c => {
                    c.Proficiency = WeaponCategory.Kama;
                    c.StackBonusType = ModifierDescriptor.Enhancement;
                    c.StackBonus = 1;
                });
                bp.AddComponent<AddBackgroundWeaponProficiency>(c => {
                    c.Proficiency = WeaponCategory.Sai;
                    c.StackBonusType = ModifierDescriptor.Enhancement;
                    c.StackBonus = 1;
                });
                bp.AddComponent<AddBackgroundWeaponProficiency>(c => {
                    c.Proficiency = WeaponCategory.Tongi;
                    c.StackBonusType = ModifierDescriptor.Enhancement;
                    c.StackBonus = 1;
                });
                bp.AddComponent<AddBackgroundWeaponProficiency>(c => {
                    c.Proficiency = WeaponCategory.SlingStaff;
                    c.StackBonusType = ModifierDescriptor.Enhancement;
                    c.StackBonus = 1;
                });
                bp.AddComponent<AddBackgroundWeaponProficiency>(c => {
                    c.Proficiency = WeaponCategory.DoubleAxe;
                    c.StackBonusType = ModifierDescriptor.Enhancement;
                    c.StackBonus = 1;
                });
                bp.AddComponent<AddBackgroundWeaponProficiency>(c => {
                    c.Proficiency = WeaponCategory.DoubleSword;
                    c.StackBonusType = ModifierDescriptor.Enhancement;
                    c.StackBonus = 1;
                });
                bp.AddComponent<AddBackgroundWeaponProficiency>(c => {
                    c.Proficiency = WeaponCategory.Urgrosh;
                    c.StackBonusType = ModifierDescriptor.Enhancement;
                    c.StackBonus = 1;
                });
                bp.AddComponent<AddBackgroundWeaponProficiency>(c => {
                    c.Proficiency = WeaponCategory.HookedHammer;
                    c.StackBonusType = ModifierDescriptor.Enhancement;
                    c.StackBonus = 1;
                });
                bp.AddComponent<AddBackgroundWeaponProficiency>(c => {
                    c.Proficiency = WeaponCategory.Nunchaku;
                    c.StackBonusType = ModifierDescriptor.Enhancement;
                    c.StackBonus = 1;
                });
            });

            // Register Background
            IsekaiBackgroundSelection.AddToSelection(BackgroundMartialArtist);
        }
    }
}