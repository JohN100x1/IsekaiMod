using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower
{
    class SpellMaster
    {
        private static readonly Sprite Icon_TelekineticBurst = Resources.GetBlueprint<BlueprintAbility>("9ccd404771c25e24490e4f8838ea8ebb").m_Icon;
        public static void Add()
        {
            var SpellMaster = Helpers.CreateFeature("SpellMaster", bp => {
                bp.SetName("Spell Master");
                bp.SetDescription("The DC of spells you cast increases by 4.");
                bp.m_Icon = Icon_TelekineticBurst;
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
