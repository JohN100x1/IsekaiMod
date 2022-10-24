using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist.GodEmporer
{
    class GloriousAuraFeature
    {
        public static void Add()
        {
            var Icon_BurstOfGlory = Resources.GetBlueprint<BlueprintAbility>("1bc83efec9f8c4b42a46162d72cbf494").m_Icon;
            var GloriousAuraEffectBuff = Helpers.CreateBlueprint<BlueprintBuff>("GloriousAuraEffectBuff", bp => {
                bp.SetName("Glorious Aura");
                bp.SetDescription("At 9th level, allies within 40 feet of the God Emporer gain a +4 competence bonus on attack {g|Encyclopedia:Dice}rolls{/g} and caster level.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_BurstOfGlory;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.AdditionalAttackBonus;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Stat = StatType.BonusCasterLevel;
                    c.Value = 4;
                });
            });
            var GloriousAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("GloriousAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = false;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet() { m_Value = 40 };
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(GloriousAuraEffectBuff.ToReference<BlueprintBuffReference>()));
            });
            var GloriousAuraBuff = Helpers.CreateBlueprint<BlueprintBuff>("GloriousAuraBuff", bp => {
                bp.SetName("Glorious Aura");
                bp.SetDescription("At 9th level, allies within 40 feet of the God Emporer gain a +4 competence bonus on attack {g|Encyclopedia:Dice}rolls{/g} and caster level.");
                bp.m_Icon = Icon_BurstOfGlory;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = GloriousAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var GloriousAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>("GloriousAuraFeature", bp => {
                bp.SetName("Glorious Aura");
                bp.SetDescription("At 9th level, allies within 40 feet of the God Emporer gain a +4 competence bonus on attack {g|Encyclopedia:Dice}rolls{/g} and caster level.");
                bp.m_Icon = Icon_BurstOfGlory;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AuraFeatureComponent>(c => {
                    c.m_Buff = GloriousAuraBuff.ToReference<BlueprintBuffReference>();
                });
            });
        }
    }
}
