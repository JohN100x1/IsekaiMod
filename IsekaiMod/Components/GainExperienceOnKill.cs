using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints;
using Kingmaker.Armies.TacticalCombat.Parts;
using Kingmaker.Armies.TacticalCombat;
using IsekaiMod.Utilities;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.RuleSystem;

namespace IsekaiMod.Components {

    [ComponentName("Killed Enemy Trigger")]
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    [TypeId("83ffe0002e564ab2a97029983b4b409a")]
    public class GainExperienceOnKill : UnitFactComponentDelegate<AddOutgoingDamageTrigger.ComponentData>, IRulebookHandler<RuleDealDamage>, IRulebookHandler<RuleDrainEnergy>, IInitiatorRulebookHandler<RuleDealDamage>, IInitiatorRulebookHandler<RuleDealStatDamage>, IRulebookHandler<RuleDealStatDamage>, IInitiatorRulebookHandler<RuleDrainEnergy>, ISubscriber, IInitiatorRulebookSubscriber {

        public class ComponentData {
            public bool WasTargetAlive;
        }

        public void OnEventAboutToTrigger(RuleDealDamage evt) {
            SetDataTargetWasAlive(evt);
        }

        public void OnEventAboutToTrigger(RuleDrainEnergy evt) {
            SetDataTargetWasAlive(evt);
        }

        public void OnEventAboutToTrigger(RuleDealStatDamage evt) {
            SetDataTargetWasAlive(evt);
        }

        public void OnEventDidTrigger(RuleDealDamage evt) {
            GainExperience(evt);
        }

        public void OnEventDidTrigger(RuleDrainEnergy evt) {
            GainExperience(evt);
        }

        public void OnEventDidTrigger(RuleDealStatDamage evt) {
            GainExperience(evt);
        }

        private void SetDataTargetWasAlive(RulebookTargetEvent evt) {
            if (TacticalCombatHelper.IsActive) {
                UnitPartTacticalCombat unitPartTacticalCombat = evt.Target.Get<UnitPartTacticalCombat>();
                int num = (unitPartTacticalCombat != null) ? unitPartTacticalCombat.Count : 1;
                Data.WasTargetAlive = (num > TacticalCombatHelper.GetDeathCount(evt.Target, evt.Target.HPLeft, num));
                return;
            }
            Data.WasTargetAlive = !evt.Target.Descriptor.State.IsDead;
        }

        private void GainExperience(RulebookTargetEvent evt) {
            bool deathFlag;
            if (TacticalCombatHelper.IsActive) {
                UnitPartTacticalCombat unitPartTacticalCombat = evt.Target.Get<UnitPartTacticalCombat>();
                int num = (unitPartTacticalCombat != null) ? unitPartTacticalCombat.Count : 1;
                deathFlag = (num <= TacticalCombatHelper.GetDeathCount(evt.Target, evt.Target.HPLeft, num));
            } else {
                deathFlag = evt.Target.Stats.HitPoints <= evt.Target.Damage;
            }
            if (!Data.WasTargetAlive || !deathFlag || Fact is not IFactContextOwner factContextOwner) {
                return;
            }
            Experience experience = evt.Target.Blueprint.GetComponent<Experience>();
            if (experience == null) return;
            ActionList actionList = ActionFlow.DoSingle<GainExp>(c => {
                c.GainPureExp = false;
                c.Encounter = experience.Encounter;
                c.CR = experience.CR;
                c.Modifier = experience.Modifier;
                c.Count = new IntConstant() {
                    Value = 1
                };
            });
            factContextOwner.RunActionInContext(actionList, Owner);
        }
    }
}