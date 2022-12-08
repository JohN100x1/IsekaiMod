using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower
{
    class SpellMaster
    {
        private static readonly Sprite Icon_MutagenResource = Resources.GetBlueprint<BlueprintAbilityResource>("3b163587f010382408142fc8a97852b6").m_Icon;
        public static void Add()
        {
            var SpellMaster = Helpers.CreateFeature("SpellMaster", bp => {
                bp.SetName("Spell Master");
                bp.SetDescription("The DC of spells you cast increases by 4.");
                bp.m_Icon = Icon_MutagenResource;
                bp.AddComponent<IncreaseAllSpellsDC>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Value = 4;
                    c.SpellsOnly = true;
                });
            });
            SpecialPowerSelection.AddToSelection(SpellMaster);
        }
    }
}
