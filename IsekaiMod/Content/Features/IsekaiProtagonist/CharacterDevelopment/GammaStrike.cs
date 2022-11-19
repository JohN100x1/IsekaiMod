using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class GammaStrike
    {
        private static readonly Sprite Icon_BladeSense = Resources.GetBlueprint<BlueprintFeature>("112bf4c6943097942b24eadfa750215f").m_Icon;
        public static void Add()
        {
            var GammaStrike = Helpers.CreateBlueprint<BlueprintFeature>("GammaStrike", bp => {
                bp.SetName("Gamma Strike");
                bp.SetDescription("Your attacks ignore concealment and are treated as adamantite for the purpose of overcoming {g|Encyclopedia:Damage_Reduction}damage reduction{/g}.");
                bp.m_Icon = Icon_BladeSense;
                bp.AddComponent<IgnoreConcealment>();
                bp.AddComponent<AddOutgoingPhysicalDamageProperty>(c => {
                    c.AddMaterial = true;
                    c.Material = PhysicalDamageMaterial.Adamantite;
                });
                bp.Ranks = 1;
                bp.IsClassFeature = true;
            });

            CharacterDevelopmentSelection.AddToSelection(GammaStrike);
        }
    }
}
