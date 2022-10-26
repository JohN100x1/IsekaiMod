using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.GodEmporer
{
    class GloriousAuraFeature
    {
        public static void Add()
        {
            var Icon_BurstOfGlory = Resources.GetBlueprint<BlueprintAbility>("1bc83efec9f8c4b42a46162d72cbf494").m_Icon;
            var GloriousAuraBuff = Helpers.CreateBlueprint<BlueprintBuff>("GloriousAuraBuff", bp => {
                bp.SetName("Glorious Aura");
                bp.SetDescription("This character has a +4 bonus on attack {g|Encyclopedia:Dice}rolls{/g} and caster level checks made to overcome spell resistance.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_BurstOfGlory;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.None;
                    c.Stat = StatType.AdditionalAttackBonus;
                    c.Value = 4;
                });
                bp.AddComponent<SpellPenetrationBonus>(c => {
                    c.Descriptor = ModifierDescriptor.None;
                    c.Value = 4;
                    c.CheckFact = false;
                });
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var GloriousAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("GloriousAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = false;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet() { m_Value = 40 };
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(GloriousAuraBuff.ToReference<BlueprintBuffReference>()));
            });
            var GloriousAuraAreaBuff = Helpers.CreateBlueprint<BlueprintBuff>("GloriousAuraAreaBuff", bp => {
                bp.SetName("Glorious Aura");
                bp.SetDescription("Allies within 40 feet of the God Emporer gain a +4 bonus on attack {g|Encyclopedia:Dice}rolls{/g} and caster level checks made to overcome spell resistance.");
                bp.m_Icon = Icon_BurstOfGlory;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = GloriousAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var GloriousAuraAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("GloriousAuraAbility", bp => {
                bp.SetName("Glorious Aura");
                bp.SetDescription("Allies within 40 feet of the God Emporer gain a +4 bonus on attack {g|Encyclopedia:Dice}rolls{/g} and caster level checks made to overcome spell resistance.");
                bp.m_Icon = Icon_BurstOfGlory;
                bp.m_Buff = GloriousAuraAreaBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.None;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DoNotTurnOffOnRest = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var GloriousAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>("GloriousAuraFeature", bp => {
                bp.SetName("Glorious Aura");
                bp.SetDescription("At 9th level, allies within 40 feet of the God Emporer gain a +4 bonus on attack {g|Encyclopedia:Dice}rolls{/g} and caster level checks made to overcome spell resistance.");
                bp.m_Icon = Icon_BurstOfGlory;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { GloriousAuraAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
