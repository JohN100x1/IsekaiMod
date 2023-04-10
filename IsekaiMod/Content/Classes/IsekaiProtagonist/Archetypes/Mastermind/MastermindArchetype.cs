using IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Mastermind;
using IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes {

    internal class MastermindArchetype {
        private static readonly LocalizedString Name = Helpers.CreateString(IsekaiContext, $"MastermindArchetype.Name", "Mastermind");
        private static readonly LocalizedString Description = Helpers.CreateString(IsekaiContext, $"MastermindArchetype.Description",
            "The mastermind has an unparalleled intellect in the new world. They are able to predict the enemies' movements "
            + "four parallel universes in advance, outsmarting them with mind-boggling strategies using knowledge from their old world."
            + "\nYou cast spells like an Arcanist with a number of slots equal to your spells per day.");

        public static void Add() {
            // Archetype features
            var MastermindProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "MastermindProficiencies");
            var MastermindQuickFooted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "MastermindQuickFooted");
            var SignatureAbility = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SignatureAbility");

            var ArcanistArcaneReservoirFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("55db1859bd72fd04f9bd3fe1f10e4cbb");
            var ArcanistConsumeSpells = BlueprintTools.GetBlueprint<BlueprintFeature>("69cfb4ab0d9812249b924b8f23d6d19f");

            var OverpoweredAbilitySelectionMastermind = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelectionMastermind");

            // Removed features
            var IsekaiProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProficiencies");
            var ReleaseEnergy = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ReleaseEnergy");
            var Gifted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "Gifted");
            var IsekaiFighterTraining = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiFighterTraining");
            var IsekaiQuickFooted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiQuickFooted");
            var SecondReincarnation = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondReincarnation");

            var SecretPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SecretPowerSelection");
            var HaxSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "HaxSelection");
            var SignatureMoveBonusSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SignatureMoveBonusSelection");
            var SignatureMoveSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SignatureMoveSelection");
            var IsekaiBonusFeatSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiBonusFeatSelection");
            var OverpoweredAbilitySelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection");
            var SpecialPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerSelection");

            // Archetype
            var MastermindArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(IsekaiContext, "MastermindArchetype", bp => {
                bp.LocalizedName = Name;
                bp.LocalizedDescription = Description;
                bp.LocalizedDescriptionShort = Description;
                bp.IsArcaneCaster = true;
                bp.IsDivineCaster = true;
                bp.ChangeCasterType = true;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, IsekaiBonusFeatSelection, IsekaiProficiencies, Gifted, LegacySelection.GetClassFeature()),
                    Helpers.CreateLevelEntry(2, IsekaiBonusFeatSelection),
                    Helpers.CreateLevelEntry(3, IsekaiFighterTraining, ReleaseEnergy),
                    Helpers.CreateLevelEntry(4, IsekaiBonusFeatSelection),
                    Helpers.CreateLevelEntry(6, IsekaiBonusFeatSelection, SignatureMoveSelection, SignatureMoveBonusSelection),
                    Helpers.CreateLevelEntry(8, IsekaiBonusFeatSelection),
                    Helpers.CreateLevelEntry(10, IsekaiBonusFeatSelection, OverpoweredAbilitySelection, SecretPowerSelection),
                    Helpers.CreateLevelEntry(12, IsekaiBonusFeatSelection),
                    Helpers.CreateLevelEntry(14, IsekaiBonusFeatSelection),
                    Helpers.CreateLevelEntry(15, IsekaiQuickFooted, SecondReincarnation),
                    Helpers.CreateLevelEntry(16, IsekaiBonusFeatSelection),
                    Helpers.CreateLevelEntry(18, IsekaiBonusFeatSelection),
                    Helpers.CreateLevelEntry(20, IsekaiBonusFeatSelection, HaxSelection),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, MastermindProficiencies, OverpoweredAbilitySelectionMastermind, ArcanistArcaneReservoirFeature, ArcanistConsumeSpells, MastermindLegacySelection.getClassFeature()),
                    Helpers.CreateLevelEntry(5, OverpoweredAbilitySelectionMastermind),
                    Helpers.CreateLevelEntry(6, SignatureAbility),
                    Helpers.CreateLevelEntry(9, OverpoweredAbilitySelectionMastermind),
                    Helpers.CreateLevelEntry(13, OverpoweredAbilitySelectionMastermind),
                    Helpers.CreateLevelEntry(15, MastermindQuickFooted),
                    Helpers.CreateLevelEntry(17, OverpoweredAbilitySelectionMastermind),
                };
                bp.OverrideAttributeRecommendations = true;
                bp.m_ReplaceSpellbook = MastermindSpellbook.GetReference();
                bp.RecommendedAttributes = new StatType[] { StatType.Intelligence };
            });

            // Add Archetype to Class
            IsekaiProtagonistClass.RegisterArchetype(MastermindArchetype);
        }

        public static BlueprintArchetype Get() {
            return BlueprintTools.GetModBlueprint<BlueprintArchetype>(IsekaiContext, "MastermindArchetype");
        }

        public static BlueprintArchetypeReference GetReference() {
            return Get().ToReference<BlueprintArchetypeReference>();
        }

        public static void PatchMastermindArcanistFeatures() {
            var ArcanistArcaneReservoirResource = BlueprintTools.GetBlueprint<BlueprintAbilityResource>("cac948cbbe79b55459459dd6a8fe44ce");
            var ArcanistArcaneReservoirResourceBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("1dd776b7b27dcd54ab3cedbbaf440cf3");
            var ArcanistArcaneReservoirCLBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("33e0c3a2a54c0e7489fa4ec4d79a581b");
            var ArcanistArcaneReservoirDCBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("db4b91a8a297c4247b13cfb6ea228bf3");
            
            var ArcanistConsumeSpells = BlueprintTools.GetBlueprint<BlueprintFeature>("69cfb4ab0d9812249b924b8f23d6d19f");
            var ArcanistConsumeSpellsResource = BlueprintTools.GetBlueprint<BlueprintAbilityResource>("d67ddd98ad019854d926f3d6a4e681c5");

            BlueprintCharacterClassReference myClassRef = IsekaiProtagonistClass.GetReference();
            BlueprintSpellbookReference mySpellbookRef = MastermindSpellbook.GetReference();

            ArcanistArcaneReservoirResource.m_MaxAmount.m_Class = ArcanistArcaneReservoirResource.m_MaxAmount.m_Class.AppendToArray(myClassRef);
            ArcanistArcaneReservoirResourceBuff.GetComponent<ContextRankConfig>().m_Class = ArcanistArcaneReservoirResourceBuff.GetComponent<ContextRankConfig>().m_Class.AppendToArray(myClassRef);
            ArcanistArcaneReservoirCLBuff.GetComponent<AddAbilityUseTrigger>().m_Spellbooks = ArcanistArcaneReservoirCLBuff.GetComponent<AddAbilityUseTrigger>().m_Spellbooks.AppendToArray(mySpellbookRef);
            ArcanistArcaneReservoirCLBuff.GetComponent<AddCasterLevelForSpellbook>().m_Spellbooks = ArcanistArcaneReservoirCLBuff.GetComponent<AddCasterLevelForSpellbook>().m_Spellbooks.AppendToArray(mySpellbookRef);
            ArcanistArcaneReservoirDCBuff.GetComponent<AddAbilityUseTrigger>().m_Spellbooks = ArcanistArcaneReservoirDCBuff.GetComponent<AddAbilityUseTrigger>().m_Spellbooks.AppendToArray(mySpellbookRef);
            ArcanistArcaneReservoirDCBuff.GetComponent<IncreaseSpellSpellbookDC>().m_Spellbooks = ArcanistArcaneReservoirDCBuff.GetComponent<IncreaseSpellSpellbookDC>().m_Spellbooks.AppendToArray(mySpellbookRef);

            var ArcanistConsumeSpellAbilities = ArcanistConsumeSpells.GetComponent<SpontaneousSpellConversion>().m_SpellsByLevel;
            ArcanistConsumeSpells.AddComponent<SpontaneousSpellConversion>(c => {
                c.m_CharacterClass = myClassRef;
                c.m_SpellsByLevel = ArcanistConsumeSpellAbilities;
            });
            ArcanistConsumeSpellsResource.m_MaxAmount.m_Class = ArcanistConsumeSpellsResource.m_MaxAmount.m_Class.AppendToArray(myClassRef);
        }
    }
}