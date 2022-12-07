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
        private static readonly Sprite Icon_TelekineticFist = Resources.GetBlueprint<BlueprintAbility>("810992c76efdde84db707a0444cf9a1c").m_Icon;
        public static void Add()
        {
            var SpellMaster = Helpers.CreateFeature("SpellMaster", bp => {
                bp.SetName("Spell Master");
                bp.SetDescription("The DC of spells you cast increases by 4.");
                bp.m_Icon = Icon_TelekineticFist;
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
