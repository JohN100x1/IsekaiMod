using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class SneakyMagic
    {
        private static readonly Sprite Icon_InvisibilityAlmostGreater = Resources.GetBlueprint<BlueprintAbility>("8dcb9c02148a704489948eaf84ab04bf").m_Icon;
        private static readonly BlueprintFeature SneakAttack = Resources.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");
        public static void Add()
        {
            var SneakyMagic = Helpers.CreateFeature("SneakyMagic", bp => {
                bp.SetName("Sneaky Magic");
                bp.SetDescription("You can add your sneak {g|Encyclopedia:Attack}attack{/g} {g|Encyclopedia:Damage}damage{/g} to any {g|Encyclopedia:Spell}spell{/g} that deals damage, "
                    + "if the targets are {g|Encyclopedia:Flat_Footed}flat-footed{/g}. This additional damage only applies to spells that deal hit point damage, and the additional damage "
                    + "is of the same type as the spell. If the spell allows a {g|Encyclopedia:Saving_Throw}saving throw{/g} to negate or halve the damage, it also negates or halves "
                    + "the sneak attack damage.");
                bp.m_Icon = Icon_InvisibilityAlmostGreater;
                bp.AddComponent<SurpriseSpells>();
                bp.AddComponent<PrerequisiteFeature>(c => {
                    c.m_Feature = SneakAttack.ToReference<BlueprintFeatureReference>();
                });
            });
            CharacterDevelopmentSelection.AddToSelection(SneakyMagic);
        }
    }
}
