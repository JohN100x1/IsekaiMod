using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain
{
    class CorruptAuraFeature
    {
        public static void Add()
        {
            var Icon_Corrupt_Aura = AssetLoader.LoadInternal("Features", "ICON_CORRUPT_AURA.png");
            var CorruptAuraBuff = Helpers.CreateBuff("CorruptAuraBuff", bp => {
                bp.SetName("Corrupt Aura");
                bp.SetDescription("This character has a +4 profane bonus to attack, damage, AC and saving throws. "
                    + "Their attacks are treated as evil for the purpose of overcoming {g|Encyclopedia:Damage_Reduction}damage reduction{/g}.");
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
            var CorruptAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("CorruptAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = false;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(CorruptAuraBuff.ToReference<BlueprintBuffReference>()));
            });
            var CorruptAuraAreaBuff = Helpers.CreateBuff("CorruptAuraAreaBuff", bp => {
                bp.SetName("Corrupt Aura");
                bp.SetDescription("Allies within 40 feet of the Villain has a +4 profane bonus to attack, damage, AC and saving throws. "
                    + "Their attacks are treated as evil for the purpose of overcoming {g|Encyclopedia:Damage_Reduction}damage reduction{/g}.");
                bp.m_Icon = Icon_Corrupt_Aura;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = CorruptAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var CorruptAuraAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("CorruptAuraAbility", bp => {
                bp.SetName("Corrupt Aura");
                bp.SetDescription("Allies within 40 feet of the Villain has a +4 profane bonus to attack, damage, AC and saving throws. "
                    + "Their attacks are treated as evil for the purpose of overcoming {g|Encyclopedia:Damage_Reduction}damage reduction{/g}.");
                bp.m_Icon = Icon_Corrupt_Aura;
                bp.m_Buff = CorruptAuraAreaBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.None;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DoNotTurnOffOnRest = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var CorruptAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>("CorruptAuraFeature", bp => {
                bp.SetName("Corrupt Aura");
                bp.SetDescription("At 9th level, allies within 40 feet of the Villain has a +4 profane bonus to attack, damage, AC and saving throws. "
                    + "Their attacks are treated as evil for the purpose of overcoming {g|Encyclopedia:Damage_Reduction}damage reduction{/g}.");
                bp.m_Icon = Icon_Corrupt_Aura;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { CorruptAuraAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
