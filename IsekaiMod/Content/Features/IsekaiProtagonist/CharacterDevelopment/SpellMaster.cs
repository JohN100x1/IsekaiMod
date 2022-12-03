using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class SpellMaster
    {
        private static readonly Sprite Icon_BatteringBlast = Resources.GetBlueprint<BlueprintAbility>("0a2f7c6aa81bc6548ac7780d8b70bcbc").m_Icon;
        public static void Add()
        {
            var SpellMaster = Helpers.CreateFeature("SpellMaster", bp => {
                bp.SetName("Spell Master");
                bp.SetDescription("The DC of spells you cast increases by 4.");
                bp.m_Icon = Icon_BatteringBlast;
                bp.AddComponent<IncreaseAllSpellsDC>(c => {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Value = 4;
                    c.SpellsOnly = true;
                });
            });
            CharacterDevelopmentSelection.AddToSelection(SpellMaster);
        }
    }
}
