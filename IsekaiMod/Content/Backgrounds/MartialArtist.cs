using IsekaiMod.Utilities;
using IsekaiMod.Extensions;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Blueprints;
using Kingmaker.Enums;

namespace IsekaiMod.Content.Backgrounds
{
    internal class MartialArtist
    {
        public static void Add()
        {
            // Background
            var ExoticWeaponProficiency = Resources.GetModBlueprint<BlueprintFeature>("ExoticWeaponProficiency");
            var BackgroundMartialArtist = Helpers.CreateFeature("BackgroundMartialArtist", bp => {
                bp.SetName("Martial Artist");
                bp.SetDescription("The Martial Artist is proficient with all exotic weapons.\n"
                    + "If the character already has the class skill, {g|Encyclopedia:Weapon_Proficiency}weapon proficiency{/g} or armor proficiency granted by the selected background "
                    + "from her class during character creation, then the corresponding {g|Encyclopedia:Bonus}bonuses{/g} from background change to a +1 competence bonus in case of skills, "
                    + "a +1 enhancement bonus in case of weapon proficiency and a -1 Armor {g|Encyclopedia:Check}Check{/g} {g|Encyclopedia:Penalty}Penalty{/g} reduction in case of armor proficiency.");
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
            });

            // Register Background
            IsekaiBackgroundSelection.Register(BackgroundMartialArtist);
        }
    }
}
