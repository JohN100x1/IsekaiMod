using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {
    internal class ArcanaSelection {
        public static BlueprintFeatureSelection BloodlineArcanaSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("20a2435574bdd7f4e947f405df2b25ce");
        public static readonly BlueprintParametrizedFeature SorcererArcana = BlueprintTools.GetBlueprint<BlueprintParametrizedFeature>("4a2e8388c2f0dd3478811d9c947bebfb");

        public static void Configure() {
            BlueprintParametrizedFeature IsekaiArcana = Helpers.CreateBlueprint<BlueprintParametrizedFeature>(IsekaiContext, "IsekaiProtagonistArcana", bp => {
                bp.m_DisplayName = SorcererArcana.m_DisplayName;
                bp.m_Description = SorcererArcana.m_Description;
                bp.m_Icon = SorcererArcana.m_Icon;
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = false;
                bp.IsClassFeature= true;
                bp.ParameterType = FeatureParameterType.LearnSpell;
                bp.m_SpellcasterClass = Classes.IsekaiProtagonist.IsekaiProtagonistClass.GetReference();
                bp.m_SpellList = Classes.IsekaiProtagonist.IsekaiProtagonistSpellList.Get().ToReference<BlueprintSpellListReference>();
                bp.SpecificSpellLevel = false;
                bp.SpellLevelPenalty= 0;
                bp.SpellLevel = 0;
                bp.DisallowSpellsInSpellList= false;
                bp.AddComponent<LearnSpellParametrized>(c => {
                    c.m_SpellcasterClass = Classes.IsekaiProtagonist.IsekaiProtagonistClass.GetReference();
                    c.m_SpellList = Classes.IsekaiProtagonist.IsekaiProtagonistSpellList.Get().ToReference<BlueprintSpellListReference>();
                    c.SpecificSpellLevel = false;
                    c.SpellLevelPenalty = 0;
                    c.SpellLevel = 0;
                });
            });

            BloodlineArcanaSelection.m_AllFeatures = BloodlineArcanaSelection.m_AllFeatures.AppendToArray(IsekaiArcana.ToReference<BlueprintFeatureReference>());

        }
    }
}
