using JetBrains.Annotations;
using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using Owlcat.QA.Validation;
using System;
using System.Linq;
using UnityEngine;

namespace IsekaiMod.Components {
    [TypeId("bd8d467121614c95a058bf66b6dcd1fa")]
    internal class ContextCalculateAbilityParamsBasedOnClasses : ContextAbilityParamsCalculator {
        public BlueprintCharacterClass[] CharacterClasses {
            get {
                BlueprintCharacterClassReference[] classReferences = m_CharacterClasses;
                if (classReferences == null) return null;
                return m_CharacterClasses.Select(bp => bp.Get()).ToArray();
            }
        }

        public int GetMaxClassLevel([NotNull] UnitEntityData caster) {
            int maxClassLevel = 0;
            foreach (var characterClass in CharacterClasses) {
                if (characterClass == null) continue;
                maxClassLevel = Math.Max(maxClassLevel, caster.Descriptor.Progression.GetClassLevel(characterClass));
            }
            return maxClassLevel;
        }

        public override AbilityParams Calculate(MechanicsContext context) {
            UnitEntityData maybeCaster = context.MaybeCaster;
            if (maybeCaster == null) {
                PFLog.Default.Error(this, "Caster is missing", Array.Empty<object>());
                return context.Params;
            }
            BlueprintScriptableObject associatedBlueprint = context.AssociatedBlueprint;
            UnitEntityData caster = maybeCaster;
            AbilityExecutionContext sourceAbilityContext = context.SourceAbilityContext;
            return Calculate(context, associatedBlueprint, caster, sourceAbilityContext?.Ability);
        }

        public AbilityParams Calculate([NotNull] AbilityData ability) {
            return Calculate(null, ability.Blueprint, ability.Caster, ability);
        }

        public AbilityParams Calculate([CanBeNull] MechanicsContext context, [NotNull] BlueprintScriptableObject blueprint, [NotNull] UnitEntityData caster, [CanBeNull] AbilityData ability) {
            StatType value = StatType;
            if (UseKineticistMainStat) {
                UnitPartKineticist unitPartKineticist = caster?.Get<UnitPartKineticist>();
                if (unitPartKineticist == null) {
                    PFLog.Default.Error(blueprint, string.Format("Caster is not kineticist: {0} ({1})", caster, blueprint.NameSafe()), Array.Empty<object>());
                }
                value = ((unitPartKineticist != null) ? unitPartKineticist.MainStatType : StatType);
            }
            RuleCalculateAbilityParams ruleCalculateAbilityParams = (ability != null) ? new RuleCalculateAbilityParams(caster, ability) : new RuleCalculateAbilityParams(caster, blueprint, null);
            ruleCalculateAbilityParams.ReplaceStat = new StatType?(value);

            int maxClassLevel = GetMaxClassLevel(caster);

            ruleCalculateAbilityParams.ReplaceCasterLevel = new int?(maxClassLevel);
            ruleCalculateAbilityParams.ReplaceSpellLevel = new int?(maxClassLevel / 2);
            if (context != null) return context.TriggerRule(ruleCalculateAbilityParams).Result;
            return Rulebook.Trigger(ruleCalculateAbilityParams).Result;
        }

        public override void ApplyValidation(ValidationContext context, int parentIndex) {
            base.ApplyValidation(context, parentIndex);
            if (!StatType.IsAttribute() && StatType != StatType.BaseAttackBonus) {
                string text = string.Join(", ", from s in StatTypeHelper.Attributes select s.ToString());
                context.AddError("StatType must be Base Attack Bonus or an attribute: {0}", text, Array.Empty<object>());
            }
        }

        public bool UseKineticistMainStat;

        [HideIf("UseKineticistMainStat")]
        public StatType StatType = StatType.Charisma;

        [SerializeField]
        public BlueprintCharacterClassReference[] m_CharacterClasses;
    }
}
