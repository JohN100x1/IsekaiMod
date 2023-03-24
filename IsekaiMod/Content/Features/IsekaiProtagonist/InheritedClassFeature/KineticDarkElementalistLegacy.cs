﻿using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.GodEmperor;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Hero;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using TabletopTweaks.Core.Utilities;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Blueprints.Classes.Prerequisites;
using static IsekaiMod.Main;


namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class KineticDarkElementalistLegacy {
        private static BlueprintArchetype BaseArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("f12f18ae8842425489d29f302e69134c");

        private static BlueprintProgression prog;

        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "KineticDarkElementalistLegacy", bp => {
                bp.SetName(IsekaiContext, "Kinetic Legacy - Soulbinder");
                bp.SetDescription(IsekaiContext,
                    "You have discovered a dark secret of elemental manipulation: you can use the souls of your enemies as fuel for your powers. \n" +
                    "Instead of straining your own body, you can use souls of those who oppose you and unleash devastating blasts of elemental energy. \n" +
                    "You are a master of soulbinding, a technique that some consider to be unnatural and morbid. \n" +
                    "But you don’t care about such moral qualms; you only care about your own survival and dominance.");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.AddComponent<AddProficiencies>(c => {
                    c.WeaponProficiencies = new Kingmaker.Enums.WeaponCategory[] { Kingmaker.Enums.WeaponCategory.KineticBlast };
                });
                bp.AddComponent<PrerequisiteAlignment>(c => { c.Alignment = Kingmaker.UnitLogic.Alignments.AlignmentMaskType.Evil; });
            });

            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Prohibit(prog);
            HeroLegacySelection.Prohibit(prog);
            VillainLegacySelection.Register(prog);
            //GodEmperorLegacySelection.Prohibit(prog);
        }
        public static void PatchProgression() {
             

            BlueprintCharacterClassReference refClass = ClassTools.ClassReferences.KineticistClass;
            BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
            prog = StaticReferences.PatchClassProgressionBasedonRefArchetype(prog, ClassTools.Classes.KineticistClass, BaseArchetype, null);
            StaticReferences.PatchProgressionFeaturesBasedOnReferenceArchetype(myClass, refClass, BaseArchetype);

            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = KineticKnightLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = KineticLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = KineticOverwhelmingSoulLegacy.Get().ToReference<BlueprintFeatureReference>(); });
        }
        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "KineticDarkElementalistLegacy");
        }
    }
}