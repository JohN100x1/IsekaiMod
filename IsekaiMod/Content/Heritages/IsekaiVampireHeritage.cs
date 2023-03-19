﻿using HarmonyLib;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Heritages {

    internal class IsekaiVampireHeritage {
        private static readonly BlueprintFeature DestinyBeyondBirthMythicFeat = BlueprintTools.GetBlueprint<BlueprintFeature>("325f078c584318849bfe3da9ea245b9d");

        public static void Add() {
            // Vampire Heritage
            var Icon_Vampire = AssetLoader.LoadInternal(IsekaiContext, "Heritages", "ICON_VAMPIRE.png");
            var IsekaiVampireHeritage = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiVampireHeritage", bp => {
                bp.SetName(IsekaiContext, "Isekai Vampire");
                bp.SetDescription(IsekaiContext, "Otherworldly entities who are reincarnated into the world of Golarion as a Vampire have both extreme beauty and power. Incredibly beautiful but "
                    + "strikingly grim shades that straddle the line between humanity and vampirekind, they are often single-minded loners intent on a specific goal.\n"
                    + "The Isekai Vampire has a +4 racial {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Dexterity}Dexterity{/g} and {g|Encyclopedia:Charisma}Charisma{/g}, "
                    + "a -2 {g|Encyclopedia:Penalty}penalty{/g} to {g|Encyclopedia:Constitution}Constitution{/g}, and a +2 racial bonus on {g|Encyclopedia:Persuasion}Persuasion{/g} and "
                    + "{g|Encyclopedia:Perception}Perception checks{/g}. "
                    + "They have DR 10/Magic and Silver, and have fast healing equal to their character level. "
                    + "They have immunity to poison, disease, mind-affecting and death effects as well as cold and electricity resistance 20.");
                bp.m_Icon = Icon_Vampire;

                // Attributes
                bp.AddComponent<AddStatBonusIfHasFact>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Constitution;
                    c.Value = -2;
                    c.InvertCondition = true;
                    c.m_CheckedFacts = new BlueprintUnitFactReference[] { DestinyBeyondBirthMythicFeat.ToReference<BlueprintUnitFactReference>() };
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Dexterity;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Charisma;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.SkillPerception;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.SkillPersuasion;
                    c.Value = 2;
                });

                // Add DR/magic and silver
                bp.AddComponent<AddDamageResistancePhysical>(c => {
                    c.Or = false;
                    c.Value = 10;
                    c.BypassedByMaterial = true;
                    c.Material = PhysicalDamageMaterial.Silver;
                    c.BypassedByMagic = true;
                    c.MinEnhancementBonus = 1;
                });

                // Add Fast Healing
                bp.AddComponent<AddEffectFastHealing>(c => {
                    c.Heal = 0;
                    c.Bonus = Values.CreateContextRankValue(AbilityRankType.StatBonus);
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.StatBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                });

                // Add Resistance and Immunities
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Cold;
                    c.Value = 20;
                });
                bp.AddComponent<AddDamageResistanceEnergy>(c => {
                    c.Type = DamageEnergyType.Electricity;
                    c.Value = 20;
                });
                bp.AddComponent<BuffDescriptorImmunity>(c => {
                    c.Descriptor = SpellDescriptor.Poison
                    | SpellDescriptor.Disease
                    | SpellDescriptor.MindAffecting
                    | SpellDescriptor.Compulsion
                    | SpellDescriptor.Charm
                    | SpellDescriptor.Death;
                });
                bp.AddComponent<SpellImmunityToSpellDescriptor>(c => {
                    c.Descriptor = SpellDescriptor.Poison
                    | SpellDescriptor.Disease
                    | SpellDescriptor.MindAffecting
                    | SpellDescriptor.Compulsion
                    | SpellDescriptor.Charm
                    | SpellDescriptor.Death;
                });

                bp.Groups = new FeatureGroup[] { FeatureGroup.Racial, FeatureGroup.DhampirHeritage };
                bp.ReapplyOnLevelUp = true;
            });

            StaticReferences.Selections.DhampirHeritageSelection.AddToSelection(IsekaiVampireHeritage);
        }
    }
}