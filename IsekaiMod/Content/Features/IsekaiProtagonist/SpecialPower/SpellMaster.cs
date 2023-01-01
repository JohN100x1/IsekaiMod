using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using UnityEngine;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;
using Kingmaker.Blueprints.Classes;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower
{
    class SpellMaster
    {
        private static readonly Sprite Icon_BatteringBlast = BlueprintTools.GetBlueprint<BlueprintAbility>("0a2f7c6aa81bc6548ac7780d8b70bcbc").m_Icon;
        public static void Add()
        {
            var SpellMaster = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext,"SpellMaster", bp => {
                bp.SetName(IsekaiContext, "Spell Master");
                bp.SetDescription(IsekaiContext, "The DC of spells you cast increases by 4.");
                bp.m_Icon = Icon_BatteringBlast;
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
