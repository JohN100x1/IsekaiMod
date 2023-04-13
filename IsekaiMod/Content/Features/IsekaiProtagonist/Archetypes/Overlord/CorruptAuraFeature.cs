using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord {

    internal class CorruptAuraFeature {
        private const string CorruptAuraName = "Corrupt Aura";
        private const string CorruptAuraDescBuff = "This character has a +4 profane bonus to attack, damage, AC and saving throws. "
            + "Their attacks are treated as evil for the purpose of overcoming {g|Encyclopedia:Damage_Reduction}damage reduction{/g}.";
        private static readonly LocalizedString CorruptAuraDesc = Helpers.CreateString(IsekaiContext, "CorruptAura.Description",
            "Allies within 40 feet of the Overlord has a +4 profane bonus to attack, damage, AC and saving throws. "
            + "Their attacks are treated as evil for the purpose of overcoming {g|Encyclopedia:Damage_Reduction}damage reduction{/g}.");
        private static readonly Sprite Icon_Corrupt_Aura = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_AURA_CORRUPT.png");

        public static void Add() {
            var CorruptAuraBuff = TTCoreExtensions.CreateBuff("CorruptAuraBuff", bp => {
                bp.SetName(IsekaiContext, CorruptAuraName);
                bp.SetDescription(IsekaiContext, CorruptAuraDescBuff);
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_Corrupt_Aura;
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
            var CorruptAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, "CorruptAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = false;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(CorruptAuraBuff.ToReference<BlueprintBuffReference>()));
            });
            var CorruptAuraAreaBuff = TTCoreExtensions.CreateBuff("CorruptAuraAreaBuff", bp => {
                bp.SetName(IsekaiContext, CorruptAuraName);
                bp.SetDescription(CorruptAuraDesc);
                bp.m_Icon = Icon_Corrupt_Aura;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = CorruptAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var CorruptAuraAbility = TTCoreExtensions.CreateActivatableAbility("CorruptAuraAbility", bp => {
                bp.SetName(IsekaiContext, CorruptAuraName);
                bp.SetDescription(CorruptAuraDesc);
                bp.m_Icon = Icon_Corrupt_Aura;
                bp.m_Buff = CorruptAuraAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var CorruptAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "CorruptAuraFeature", bp => {
                bp.SetName(IsekaiContext, CorruptAuraName);
                bp.SetDescription(CorruptAuraDesc);
                bp.m_Icon = Icon_Corrupt_Aura;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { CorruptAuraAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}