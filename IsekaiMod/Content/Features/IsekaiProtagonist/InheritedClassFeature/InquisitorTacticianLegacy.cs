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
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class InquisitorTacticianLegacy {
        private static BlueprintProgression prog;
        private static BlueprintFeatureSelection domains;


        public static void Configure() {
            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "InquisitorTacticianLegacy", bp => {
                bp.SetName(IsekaiContext, "Inquisitor Legacy - Tactician");
                bp.SetDescription(IsekaiContext,
                    "You are used to telling people what to do. \n" +
                    "You were the tactician who led your guild to first kill Onyxia. \n" +
                    "This, as far as you are concerned, is just another raid to conquer with your brilliant tactics and perfect preparation... \n" +
                    "Using your good Judgement you can quickly spot the weaknesses of the opponent and exploit them even as you tactically help your allies to avoid their own.");
                bp.GiveFeaturesForPreviousLevels = true;
            });
            domains = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "InquisitorDomains", bp => {
                bp.SetName(FeatTools.Selections.DomainsSelection.m_DisplayName);
                bp.SetDescription(FeatTools.Selections.DomainsSelection.m_Description);
                bp.Ranks = 1;
                bp.IgnorePrerequisites= true;
                bp.IsClassFeature = true;
            });

            LegacySelection.Register(prog);
            EdgeLordLegacySelection.Prohibit(prog);
            HeroLegacySelection.Register(prog);
            VillainLegacySelection.Register(prog);
            GodEmperorLegacySelection.Register(prog);
        }

        public static void PatchProgression() {
            if (prog != null) {
                LevelEntry[] addentries = new LevelEntry[] { };
                LevelEntry[] removeentries = new LevelEntry[] { };
                BlueprintFeatureSelection alternateCapstone = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("208662443a1e46d5a97a5e1bff663da1");
                BlueprintFeature teamLeader = BlueprintTools.GetBlueprint<BlueprintFeature>("dd442ac7be344355887d937fd74e9ff7");
                if (ModSupport.IsTableTopTweakBaseEnabled() && alternateCapstone != null && teamLeader != null) {
                    removeentries = removeentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(20, alternateCapstone));
                    addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(20, teamLeader));
                }
                removeentries = removeentries.AppendToArray(Helpers.CreateLevelEntry(1,FeatTools.Selections.DomainsSelection));
                domains.SetFeatures(FeatTools.Selections.DomainsSelection.Features.m_Array);

                BlueprintFeature share = BlueprintTools.GetBlueprint<BlueprintFeature>("93e78cad499b1b54c859a970cbe4f585");
                BlueprintFeature shareswift = BlueprintTools.GetBlueprint<BlueprintFeature>("4ca47c023f1c158428bd55deb44c735f");
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(1, domains));
                // Animal Teamwork
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(3, BlueprintTools.GetBlueprint<BlueprintFeature>("1b9916f7675d6ef4fb427081250d49de"), share));
                //Summon Tactics
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(5, BlueprintTools.GetBlueprint<BlueprintFeature>("c3abcce19f9f80640a867c9e75f880b2")));
                addentries = addentries.AppendToArray<LevelEntry>(Helpers.CreateLevelEntry(12, shareswift));
                prog = StaticReferences.PatchClassProgressionBasedOnSeparateLists(prog, ClassTools.Classes.InquisitorClass, addentries, removeentries);

                BlueprintCharacterClassReference myClass = IsekaiProtagonistClass.GetReference();
                StaticReferences.PatchProgressionFeaturesBasedOnReferenceClass(prog, myClass, ClassTools.ClassReferences.InquisitorClass);
                StaticReferences.PatchClassIntoFeatureOfReferenceClass(share, myClass, ClassTools.ClassReferences.InquisitorClass, 0, new BlueprintFeatureBase[] { });
                StaticReferences.PatchClassIntoFeatureOfReferenceClass(shareswift, myClass, ClassTools.ClassReferences.InquisitorClass, 0, new BlueprintFeatureBase[] { });

                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = InquisitorJudgeLegacy.Get().ToReference<BlueprintFeatureReference>(); });
                prog.AddPrerequisite<PrerequisiteNoFeature>(c => { c.m_Feature = InquisitorDomainLordLegacy.Get().ToReference<BlueprintFeatureReference>(); });
            }
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "InquisitorTacticianLegacy");
        }
        public static BlueprintFeatureSelection GetDomains() {
            if (domains != null) return domains;
            return BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "InquisitorDomains");
        }
    }
}
