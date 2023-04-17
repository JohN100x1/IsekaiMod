using IsekaiMod.Content.Classes.Deathsnatcher;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.Deathsnatcher {

    internal class DeathsnatcherResistances {

        public static void Add() {
            var DeathsnatcherResistances = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DeathsnatcherResistances", bp => {
                bp.SetName(IsekaiContext, "Deathsnatcher Resistances");
                bp.SetDescription(IsekaiContext, "The Deathsnatcher is immune to negative energy and deaths effects, and has cold and fire resistance 30. "
                    + "It also has spell resistance equal to 10 + the Deathsnatcher's level.");
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Death
                    | SpellDescriptor.ChannelNegativeHarm;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Death
                    | SpellDescriptor.ChannelNegativeHarm;
                });
                bp.AddComponent<AddEnergyDamageImmunity>(c => {
                    c.EnergyType = DamageEnergyType.NegativeEnergy;
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Cold;
                    c.Value = 30;
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Fire;
                    c.Value = 30;
                });
                // Add Spell Resistance
                bp.AddComponent<AddSpellResistance>(c => {
                    c.Value = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                    c.m_Progression = ContextRankProgression.BonusValue;
                    c.m_StepLevel = 10;
                    c.m_Class = new BlueprintCharacterClassReference[] { DeathsnatcherClass.GetReference() };
                });
                bp.ReapplyOnLevelUp = true;
            });
        }
    }
}