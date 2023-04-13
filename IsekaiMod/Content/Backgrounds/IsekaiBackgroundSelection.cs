using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Backgrounds {

    internal class IsekaiBackgroundSelection {
        public const string DescAppendix = "\nIf the character already has the class skill, {g|Encyclopedia:Weapon_Proficiency}weapon proficiency{/g} "
            + "or armor proficiency granted by the selected background from her class during character creation, then the corresponding "
            + "{g|Encyclopedia:Bonus}bonuses{/g} from background change to a +1 competence bonus in case of skills, a +1 enhancement bonus in case "
            + "of weapon proficiency and a -1 Armor {g|Encyclopedia:Check}Check{/g} {g|Encyclopedia:Penalty}Penalty{/g} reduction in case "
            + "of armor proficiency.";

        public static void Add() {
            var IsekaiBackgroundSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiBackgroundSelection", bp => {
                bp.SetName(IsekaiContext, "Isekai");
                bp.SetDescription(IsekaiContext, "Before you were hit by a truck, you were a...");
                bp.HideInUI = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.BackgroundSelection };

                // Register Backgrounds later
                bp.m_AllFeatures = new BlueprintFeatureReference[0];
            });

            FeatTools.Selections.BackgroundsBaseSelection.AddToSelection(IsekaiBackgroundSelection);
        }

        public static void AddToSelection(BlueprintFeature background) {
            var backgroundSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiBackgroundSelection");
            backgroundSelection.AddToSelection(background);
        }
    }
}