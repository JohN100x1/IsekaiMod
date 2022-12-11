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
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower
{
    class AuraOfDivineFury
    {
        private static readonly Sprite Icon_AngelBladeOfTheSun = Resources.GetBlueprint<BlueprintAbility>("cc8be337fff61284caabe3340fc48294").m_Icon;
        public static void Add()
        {
            var AuraOfDivineFuryBuff = Helpers.CreateBuff("AuraOfDivineFuryBuff", bp => {
                bp.SetName("Aura of Divine Fury");
                bp.SetDescription("This creature has a +10 sacred bonus to attack damage and hit point damage from spells.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_AngelBladeOfTheSun;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Sacred;
                    c.Stat = StatType.AdditionalDamage;
                    c.Value = 10;
                });
                bp.AddComponent<IncreaseSpellDamage>(c => {
                    c.DamageBonus = 10;
                });
            });
            var AuraOfDivineFuryArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("AuraOfDivineFuryArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(40);
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(AuraOfDivineFuryBuff.ToReference<BlueprintBuffReference>()));
            });
            var AuraOfDivineFuryAreaBuff = Helpers.CreateBuff("AuraOfDivineFuryAreaBuff", bp => {
                bp.SetName("Aura of Divine Fury");
                bp.SetDescription("Allies within 40 feet of you has a +10 sacred bonus to attack damage and hit point damage from spells.");
                bp.m_Icon = Icon_AngelBladeOfTheSun;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = AuraOfDivineFuryArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });
            var AuraOfDivineFuryAbility = Helpers.CreateActivatableAbility("AuraOfDivineFuryAbility", bp => {
                bp.SetName("Aura of Divine Fury");
                bp.SetDescription("Allies within 40 feet of you has a +10 sacred bonus to attack damage and hit point damage from spells.");
                bp.m_Icon = Icon_AngelBladeOfTheSun;
                bp.m_Buff = AuraOfDivineFuryAreaBuff.ToReference<BlueprintBuffReference>();
                bp.DoNotTurnOffOnRest = true;
            });
            var AuraOfDivineFuryFeature = Helpers.CreateFeature("AuraOfDivineFuryFeature", bp => {
                bp.SetName("Aura of Divine Fury");
                bp.SetDescription("Allies within 40 feet of you has a +10 sacred bonus to attack damage and hit point damage from spells.");
                bp.m_Icon = Icon_AngelBladeOfTheSun;
                bp.AddComponent<PrerequisiteCharacterLevel>(c => {
                    c.Level = 15;
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AuraOfDivineFuryAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
