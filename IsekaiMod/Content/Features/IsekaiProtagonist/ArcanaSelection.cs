using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {

    internal class ArcanaSelection {

        public static void Configure() {
            BlueprintParametrizedFeature IsekaiArcana = Helpers.CreateBlueprint<BlueprintParametrizedFeature>(IsekaiContext, "IsekaiProtagonistArcana", bp => {
                bp.m_DisplayName = StaticReferences.SorcererArcana.m_DisplayName;
                bp.m_Description = StaticReferences.SorcererArcana.m_Description;
                bp.m_Icon = StaticReferences.SorcererArcana.m_Icon;
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = false;
                bp.IsClassFeature = true;
                bp.ParameterType = FeatureParameterType.LearnSpell;
                bp.m_SpellcasterClass = Classes.IsekaiProtagonist.IsekaiProtagonistClass.GetReference();
                bp.m_SpellList = Classes.IsekaiProtagonist.IsekaiProtagonistSpellList.Get().ToReference<BlueprintSpellListReference>();
                bp.SpecificSpellLevel = false;
                bp.SpellLevelPenalty = 0;
                bp.SpellLevel = 0;
                bp.DisallowSpellsInSpellList = false;
                bp.AddComponent<LearnSpellParametrized>(c => {
                    c.m_SpellcasterClass = Classes.IsekaiProtagonist.IsekaiProtagonistClass.GetReference();
                    c.m_SpellList = Classes.IsekaiProtagonist.IsekaiProtagonistSpellList.Get().ToReference<BlueprintSpellListReference>();
                    c.SpecificSpellLevel = false;
                    c.SpellLevelPenalty = 0;
                    c.SpellLevel = 0;
                });
            });
            InheritedClassFeature.ExtraBloodlineSelection.Get().AddFeatures(IsekaiArcana);
            InheritedClassFeature.ExtraOracleSelection.Get().AddFeatures(IsekaiArcana);
            InheritedClassFeature.ShamanSelection.Get().AddFeatures(IsekaiArcana);
            InheritedClassFeature.WitchPatronSelection.Get().AddFeatures(IsekaiArcana);
            StaticReferences.SorcererBloodlineArcanaSelection.AddFeatures(IsekaiArcana);
        }

        public static BlueprintParametrizedFeature get() {
            return BlueprintTools.GetModBlueprint<BlueprintParametrizedFeature>(IsekaiContext, "IsekaiProtagonistArcana");
        }

        public static BlueprintFeatureReference getReference() {
            return BlueprintTools.GetModBlueprint<BlueprintParametrizedFeature>(IsekaiContext, "IsekaiProtagonistArcana").ToReference<BlueprintFeatureReference>();
        }
    }
}