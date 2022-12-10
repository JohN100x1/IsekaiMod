using IsekaiMod.Components;
using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower
{
    class AuraOfPeerlessStrength
    {
        public static void Add()
        {
            var Icon_AuraOfPeerlessStrength = AssetLoader.LoadInternal("Features", "ICON_AURA_GOLDEN_PROTECTION.png");
            var AuraOfPeerlessStrengthBuff = Helpers.CreateBuff("AuraOfPeerlessStrengthBuff", bp => {
                bp.SetName("Aura of Peerless Strength");
                bp.SetDescription("This creature has a +10 sacred bonus to attack damage and hit point damage from spells.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_AuraOfPeerlessStrength;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.AdditionalDamage;
                    c.Value = 10;
                });
                bp.AddComponent<IncreaseSpellDamage>(c => {
                    c.DamageBonus = 10;
                });
            });
            var AuraOfPeerlessStrengthArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("AuraOfPeerlessStrengthArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(AuraOfPeerlessStrengthBuff.ToReference<BlueprintBuffReference>()));
            });
            var AuraOfPeerlessStrengthAreaBuff = Helpers.CreateBuff("AuraOfPeerlessStrengthAreaBuff", bp => {
                bp.SetName("Aura of Peerless Strength");
                bp.SetDescription("Allies within 40 feet of you has a +10 sacred bonus to attack damage and hit point damage from spells.");
                bp.m_Icon = Icon_AuraOfPeerlessStrength;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = AuraOfPeerlessStrengthArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var AuraOfPeerlessStrengthAbility = Helpers.CreateActivatableAbility("AuraOfPeerlessStrengthAbility", bp => {
                bp.SetName("Aura of Peerless Strength");
                bp.SetDescription("Allies within 40 feet of you has a +10 sacred bonus to attack damage and hit point damage from spells.");
                bp.m_Icon = Icon_AuraOfPeerlessStrength;
                bp.m_Buff = AuraOfPeerlessStrengthAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var AuraOfPeerlessStrengthFeature = Helpers.CreateFeature("AuraOfPeerlessStrengthFeature", bp => {
                bp.SetName("Aura of Peerless Strength");
                bp.SetDescription("Allies within 40 feet of you has a +10 sacred bonus to attack damage and hit point damage from spells.");
                bp.m_Icon = Icon_AuraOfPeerlessStrength;
                bp.AddComponent<PrerequisiteCharacterLevel>(c => {
                    c.Level = 15;
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AuraOfPeerlessStrengthAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
