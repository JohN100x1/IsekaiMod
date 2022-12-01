using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero
{
    class HerosPresence
    {
        public static void Add()
        {
            var Icon_Heros_Presence = AssetLoader.LoadInternal("Features", "ICON_HEROS_PRESENCE.png");
            var HerosPresenceBuff = Helpers.CreateBuff("HerosPresenceBuff", bp => {
                bp.SetName("Hero's Presence");
                bp.SetDescription("This character has a +10 sacred bonus to AC, saving throws, attack, and damage rolls against evil creatures and 20 DR/Evil.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_Heros_Presence;
                bp.AddComponent<ArmorClassBonusAgainstAlignment>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.alignment = AlignmentComponent.Evil;
                    c.Value = 10;
                    c.Bonus = 0;
                });
                bp.AddComponent<AttackBonusAgainstAlignment>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Alignment = AlignmentComponent.Evil;
                    c.OnlyMelee = true;
                    c.DamageBonus = 10;
                    c.Bonus = 0;
                });
                bp.AddComponent<DamageBonusAgainstAlignment>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Alignment = AlignmentComponent.Evil;
                    c.OnlyMelee = true;
                    c.DamageBonus = 10;
                    c.Bonus = 0;
                });
                bp.AddComponent<SavingThrowBonusAgainstAlignment>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Alignment = AlignmentComponent.Evil;
                    c.Value = 10;
                    c.Bonus = 0;
                });
                bp.AddComponent<AddDamageResistancePhysical>(c => {
                    c.Or = true;
                    c.Value = 20;
                    c.BypassedByAlignment = true;
                    c.Alignment = DamageAlignment.Evil;
                });
            });
            var HerosPresenceArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("HerosPresenceArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = false;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(HerosPresenceBuff.ToReference<BlueprintBuffReference>()));
            });
            var HerosPresenceAreaBuff = Helpers.CreateBuff("HerosPresenceAreaBuff", bp => {
                bp.SetName("Hero's Presence");
                bp.SetDescription("Allies within 40 feet of the Hero has a +10 sacred bonus to AC, saving throws, attack, and damage rolls against evil creatures and 20 DR/Evil.");
                bp.m_Icon = Icon_Heros_Presence;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = HerosPresenceArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var HerosPresenceFeature = Helpers.CreateFeature("HerosPresenceFeature", bp => {
                bp.SetName("Hero's Presence");
                bp.SetDescription("At 20th level, allies within 40 feet of the Hero has a +10 sacred bonus to AC, saving throws, attack, and damage rolls against evil creatures and 20 DR/Evil.");
                bp.m_Icon = Icon_Heros_Presence;
                bp.AddComponent<AuraFeatureComponent>(c => {
                    c.m_Buff = HerosPresenceAreaBuff.ToReference<BlueprintBuffReference>();
                });
            });
        }
    }
}
