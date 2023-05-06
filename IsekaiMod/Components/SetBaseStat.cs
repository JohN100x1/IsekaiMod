using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic;
using Newtonsoft.Json;
using System;

namespace IsekaiMod.Components {

    [AllowMultipleComponents]
    [TypeId("855a9cc5d06042398707b9085fc92484")]
    [ComponentName("Set base stat")]
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    [AllowedOn(typeof(BlueprintUnit), false)]
    public class SetBaseStat : UnitFactComponentDelegate<SetBaseStat.ComponentData> {
        public StatType Stat;
        public int Value;

        public class ComponentData {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public int BaseStatValue;
        }

        public override void OnActivate() {
            Data.BaseStatValue = Owner.Stats.GetAttribute(Stat).BaseValue;
        }

        public override void OnDeactivate() {
            Owner.Stats.GetAttribute(Stat).BaseValue = Data.BaseStatValue;
        }

        public override void OnTurnOn() {
            ModifiableValueAttributeStat baseStat = Owner.Stats.GetAttribute(Stat);
            if (baseStat == null) return;
            baseStat.BaseValue = Math.Max(baseStat.BaseValue, Value);
        }

        public override void OnTurnOff() {
        }
    }
}