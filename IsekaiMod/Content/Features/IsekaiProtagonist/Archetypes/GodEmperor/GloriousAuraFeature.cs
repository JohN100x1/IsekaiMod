using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor
{
    class GloriousAuraFeature
    {
        public static void Add()
        {
            var Icon_Glorious_Aura = AssetLoader.LoadInternal("Features", "ICON_GLORIOUS_AURA.png");
            var GloriousAuraBuff = Helpers.CreateBuff("GloriousAuraBuff", bp => {
                bp.SetName("Glorious Aura");
                bp.SetDescription("This character has a +4 sacred bonus to all attributes.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_Glorious_Aura;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.Strength;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.Dexterity;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.Constitution;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.Intelligence;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.Wisdom;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.Charisma;
                    c.Value = 4;
                });
            });
            var GloriousAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("GloriousAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = false;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(GloriousAuraBuff.ToReference<BlueprintBuffReference>()));
            });
            var GloriousAuraAreaBuff = Helpers.CreateBuff("GloriousAuraAreaBuff", bp => {
                bp.SetName("Glorious Aura");
                bp.SetDescription("Allies within 40 feet of the God Emperor gain a +4 sacred bonus to all attributes.");
                bp.m_Icon = Icon_Glorious_Aura;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = GloriousAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var GloriousAuraAbility = Helpers.CreateActivatableAbility("GloriousAuraAbility", bp => {
                bp.SetName("Glorious Aura");
                bp.SetDescription("Allies within 40 feet of the God Emperor gain a +4 sacred bonus to all attributes.");
                bp.m_Icon = Icon_Glorious_Aura;
                bp.m_Buff = GloriousAuraAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var GloriousAuraFeature = Helpers.CreateFeature("GloriousAuraFeature", bp => {
                bp.SetName("Glorious Aura");
                bp.SetDescription("At 9th level, allies within 40 feet of the God Emperor gain a +4 sacred bonus to all attributes.");
                bp.m_Icon = Icon_Glorious_Aura;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { GloriousAuraAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
