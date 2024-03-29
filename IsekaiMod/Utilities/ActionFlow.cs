﻿using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System;
using TabletopTweaks.Core.Utilities;

namespace IsekaiMod.Utilities {

    public static class ActionFlow {

        public static ActionList DoNothing() => Helpers.CreateActionList();

        public static ActionList DoSingle<T>(Action<T> init = null) where T : GameAction, new() {
            var t = new T();
            init?.Invoke(t);
            return Helpers.CreateActionList(t);
        }

        public static ActionList DealDamage(Action<ContextActionDealDamage> init = null) {
            var t = new ContextActionDealDamage() {
                m_Type = ContextActionDealDamage.Type.Damage,
                Duration = Values.Duration.Zero,
                UseWeaponDamageModifiers = true
            };
            init?.Invoke(t);
            return Helpers.CreateActionList(t);
        }

        public static ConditionsChecker IfSingle<T>(Action<T> init = null) where T : Condition, new() {
            var t = new T();
            init?.Invoke(t);
            return new ConditionsChecker() {
                Conditions = new Condition[] { t }
            };
        }

        public static ConditionsChecker IfAll(params Condition[] conditions) {
            return new ConditionsChecker() {
                Conditions = conditions,
                Operation = Operation.And
            };
        }

        public static ConditionsChecker IfAny(params Condition[] conditions) {
            return new ConditionsChecker() {
                Conditions = conditions,
                Operation = Operation.Or
            };
        }

        public static ConditionsChecker EmptyCondition() {
            return new ConditionsChecker() {
                Conditions = new Condition[0]
            };
        }
    }
}