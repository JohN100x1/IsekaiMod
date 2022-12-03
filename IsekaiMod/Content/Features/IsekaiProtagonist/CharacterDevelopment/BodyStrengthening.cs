using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class BodyStrengthening
    {
        private static readonly Sprite Icon_IronBody = Resources.GetBlueprint<BlueprintAbility>("198fcc43490993f49899ed086fe723c1").m_Icon;
        public static void Add()
        {
            var BodyStrengthening = Helpers.CreateFeature("BodyStrengthening", bp => {
                bp.SetName("Body Strengthening");
                bp.SetDescription("After extensive strengthening of your body, you gain {g|Encyclopedia:Damage_Reduction}DR{/g} 20/—.");
                bp.m_Icon = Icon_IronBody;
                bp.AddComponent<AddDamageResistancePhysical>(c => {
                    c.Value = 20;
                });
                bp.AddComponent<PrerequisiteCharacterLevel>(c => {
                    c.Level = 10;
                });
                bp.ReapplyOnLevelUp = true;
            });

            CharacterDevelopmentSelection.AddToSelection(BodyStrengthening);
        }
    }
}
