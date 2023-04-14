using IsekaiMod.Utilities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord {

    internal class CorruptAuraFeature {
        private static readonly Sprite Icon_CorruptAura = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_AURA_CORRUPT.png");

        public static void Add() {

            var CorruptAuraFeature = TTCoreExtensions.CreateToggleAuraFeature(
                name: "CorruptAura",
                description: "Allies within 40 feet of the Overlord has a +4 profane bonus to attack, damage, AC and saving throws. Their attacks are treated as evil for the purpose of overcoming {g|Encyclopedia:Damage_Reduction}damage reduction{/g}.",
                descriptionBuff: "This character has a +4 profane bonus to attack, damage, AC and saving throws. Their attacks are treated as evil for the purpose of overcoming {g|Encyclopedia:Damage_Reduction}damage reduction{/g}.",
                icon: Icon_CorruptAura,
                targetType: BlueprintAbilityAreaEffect.TargetType.Ally,
                auraSize: new Feet(40),
                buffEffect: bp => {
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.Profane;
                        c.Stat = StatType.AdditionalAttackBonus;
                        c.Value = 4;
                    });
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.Profane;
                        c.Stat = StatType.AdditionalDamage;
                        c.Value = 4;
                    });
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.Profane;
                        c.Stat = StatType.AC;
                        c.Value = 4;
                    });
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.Profane;
                        c.Stat = StatType.SaveFortitude;
                        c.Value = 4;
                    });
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.Profane;
                        c.Stat = StatType.SaveReflex;
                        c.Value = 4;
                    });
                    bp.AddComponent<AddStatBonus>(c => {
                        c.Descriptor = ModifierDescriptor.Profane;
                        c.Stat = StatType.SaveWill;
                        c.Value = 4;
                    });
                    bp.AddComponent<AddOutgoingPhysicalDamageProperty>(c => {
                        c.AddAlignment = true;
                        c.Alignment = DamageAlignment.Evil;
                    });
                });
        }
    }
}