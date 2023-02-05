using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;
using Kingmaker.UnitLogic.ActivatableAbilities;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class AutoQuicken
    {
        private static readonly Sprite Icon_QuickenSpell = BlueprintTools.GetBlueprint<BlueprintFeature>("ef7ece7bb5bb66a41b256976b27f424e").m_Icon;
        public static void Add()
        {
            var AutoQuickenBuff = ThingsNotHandledByTTTCore.CreateBuff("AutoQuickenBuff", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Quicken");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, it becomes quickened, as though using the Quicken Spell feat.");
                bp.m_Icon = Icon_QuickenSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Quicken;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var AutoQuickenAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>(IsekaiContext, "AutoQuickenAbility", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Quicken");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, it becomes quickened, as though using the Quicken Spell feat.");
                bp.m_Icon = Icon_QuickenSpell;
                bp.m_Buff = AutoQuickenBuff.ToReference<BlueprintBuffReference>();
            });
            var AutoQuickenFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext,"AutoQuickenFeature", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Auto Quicken");
                bp.SetDescription(IsekaiContext, "Every time you cast a spell, it becomes quickened, as though using the Quicken Spell feat.");
                bp.m_Icon = Icon_QuickenSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoQuickenAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToSelection(AutoQuickenFeature);
        }
    }
}
