using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Heritages {

    internal class IsekaiFurryHeritage {
        private static readonly BlueprintFeature DestinyBeyondBirthMythicFeat = BlueprintTools.GetBlueprint<BlueprintFeature>("325f078c584318849bfe3da9ea245b9d");

        public static void Add() {
            // Furry Heritage
            var Icon_Furry = AssetLoader.LoadInternal(IsekaiContext, "Heritages", "ICON_FURRY.png");
            var IsekaiFurryHeritage = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiFurryHeritage", bp => {
                bp.SetName(IsekaiContext, "Isekai Furry");
                bp.SetDescription(IsekaiContext, "Otherworldly entities who are reincarnated into the world of Golarion as a Furry have both extreme beauty and power. "
                    + "They are very furry.\n"
                    + "The Isekai furry has a +4 racial {g|Encyclopedia:Bonus}bonus{/g} to {g|Encyclopedia:Dexterity}Dexterity{/g}, a +2 racial bonus to "
                    + "{g|Encyclopedia:Intelligence}Intelligence{/g} and {g|Encyclopedia:Charisma}Charisma{/g}, and a -2 penalty to Strength. "
                    + "They have a +10 bonus to speed and have fast healing equal to their character level.");
                bp.m_Icon = Icon_Furry;

                // Attributes
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Dexterity;
                    c.Value = 4;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Intelligence;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Charisma;
                    c.Value = 2;
                });
                bp.AddComponent<AddStatBonusIfHasFact>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Strength;
                    c.Value = -2;
                    c.InvertCondition = true;
                    c.m_CheckedFacts = new BlueprintUnitFactReference[] { DestinyBeyondBirthMythicFeat.ToReference<BlueprintUnitFactReference>() };
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

                // Extra Speed
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Racial;
                    c.Stat = StatType.Speed;
                    c.Value = 10;
                });

                bp.Groups = new FeatureGroup[0];
                bp.ReapplyOnLevelUp = true;
            });

            StaticReferences.Selections.KitsuneHeritageSelection.AddToSelection(IsekaiFurryHeritage);
        }
    }
}