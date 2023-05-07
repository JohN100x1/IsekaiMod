using IsekaiMod.Components;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using TabletopTweaks.Core.Utilities;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class Unreactable {
        private static readonly Sprite Icon_TieflingHeritageDiv = BlueprintTools.GetBlueprint<BlueprintFeature>("e3d324eb309cdf44a87d666c7a27715c").m_Icon;

        public static void Add() {

            var UnreactableFeature = TTCoreExtensions.CreateToggleBuffFeature(
                name: "Unreactable",
                description: "Enemies you attack are treated as flat-footed.",
                icon: Icon_TieflingHeritageDiv,
                buffEffect: bp => {
                    bp.AddComponent<SetFlatFootedOnAttack>();
                });
            UnreactableFeature.AddPrerequisite<PrerequisiteCharacterLevel>(c => {
                c.Level = 15;
            });

            SpecialPowerSelection.AddToSelection(UnreactableFeature);
        }
    }
}