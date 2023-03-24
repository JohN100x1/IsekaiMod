using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using TabletopTweaks.Core.NewComponents.AbilitySpecific;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class MagusLegacy {
        private static BlueprintProgression prog;
        private static BlueprintFeature training;

        private static BlueprintFeature SpellStrike = BlueprintTools.GetBlueprint<BlueprintFeature>("be50f4e97fff8a24ba92561f1694a945");
        private static BlueprintFeature SpellCombat = BlueprintTools.GetBlueprint<BlueprintFeature>("2464ba53317c7fc4d88f383fac2b45f9");
        private static BlueprintFeature SpellCombatImproved = BlueprintTools.GetBlueprint<BlueprintFeature>("836879fcd5b29754eb664a090bd6c22f");
        private static BlueprintFeature SpellCombatGreater = BlueprintTools.GetBlueprint<BlueprintFeature>("379887a82a7248946bbf6d0158663b5e");


        private static BlueprintFeature ArcanaPoolFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("3ce9bb90749c21249adc639031d5eed1");
        private static BlueprintAbilityResource ArcanaPoolResource = BlueprintTools.GetBlueprint<BlueprintAbilityResource>("effc3e386331f864e9e06d19dc218b37");
        private static BlueprintFeature ArcanaWeapon2 = BlueprintTools.GetBlueprint<BlueprintFeature>("36b609a6946733c42930c55ac540416b");
        private static BlueprintFeature ArcanaWeapon3 = BlueprintTools.GetBlueprint<BlueprintFeature>("70be888059f99a245a79d6d61b90edc5");
        private static BlueprintFeature ArcanaWeapon4 = BlueprintTools.GetBlueprint<BlueprintFeature>("1804187264121cd439d70a96234d4ddb");
        private static BlueprintFeature ArcanaWeapon5 = BlueprintTools.GetBlueprint<BlueprintFeature>("3cbe3e308342b3247ba2f4fbaf5e6307");

        private static BlueprintFeatureSelection ArcanaSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("e9dc4dfc73eaaf94aae27e0ed6cc9ada");


        /* Magus
         * Arcana Weapon
         * 
         */

        public static void Configure() {
            var IsekaiKMagusTraining = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiKMagusTraining", bp => {
                bp.SetName(IsekaiContext, "Magus Training");
                bp.SetDescription(IsekaiContext, "You count your Isekai Hero Level to qualify for Magus feats. If you also have actual Magus Levels this ability stacks.");
                bp.m_Icon = StaticReferences.SorcererArcana.m_Icon;
                bp.AddComponent<ClassLevelsForPrerequisites>(c => {
                    c.m_FakeClass = ClassTools.ClassReferences.MagusClass;
                    c.m_ActualClass = IsekaiProtagonistClass.GetReference();
                    c.Modifier = 1.0;
                });
            });
            training = IsekaiKMagusTraining;
            ArcanaPoolResource.m_MaxAmount.m_ClassDiv.AppendToArray(IsekaiProtagonistClass.GetReference());

            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "MagusLegacy", bp => {
                bp.SetName(IsekaiContext, "Magus Legacy - Spellblade");
                bp.SetDescription(IsekaiContext, "Meh, let us be honest, Kinetic Knights only wish they were us, the true masters of melee spellcasting.");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }
                };
                bp.LevelEntries = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, IsekaiKMagusTraining, SpellCombat,ArcanaPoolFeature),
                    Helpers.CreateLevelEntry(2, SpellStrike),
                    Helpers.CreateLevelEntry(3, ArcanaSelection),
                    Helpers.CreateLevelEntry(5, ArcanaWeapon2),
                    Helpers.CreateLevelEntry(6, ArcanaSelection),
                    Helpers.CreateLevelEntry(8, SpellCombatImproved),
                    Helpers.CreateLevelEntry(9, ArcanaSelection, ArcanaWeapon3),
                    Helpers.CreateLevelEntry(12, ArcanaSelection),
                    Helpers.CreateLevelEntry(13, ArcanaWeapon4),
                    Helpers.CreateLevelEntry(14, SpellCombatGreater),
                    Helpers.CreateLevelEntry(15, ArcanaSelection),
                    Helpers.CreateLevelEntry(17, ArcanaWeapon5),
                    Helpers.CreateLevelEntry(18, ArcanaSelection),

            };
                bp.UIGroups = new UIGroup[] {
                    Helpers.CreateUIGroup(SpellCombat,SpellCombatImproved,SpellCombatGreater,SpellStrike,ArcanaSelection),
                    Helpers.CreateUIGroup(ArcanaPoolFeature,ArcanaWeapon2,ArcanaWeapon3,ArcanaWeapon4,ArcanaWeapon5),
                };
            });
            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Register(prog);
            HeroLegacySelection.Register(prog);
            VillainLegacySelection.Prohibit(prog);
            GodEmperorLegacySelection.Prohibit(prog);
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "MagusLegacy");
        }

        public static void PatchForBroadStudy() {
            if (training == null) {
                training = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiKMagusTraining");
            }
            training.AddComponent<BroadStudyComponent>(c => {
                c.CharacterClass = IsekaiProtagonistClass.GetReference();
            });
        }
    }
}
