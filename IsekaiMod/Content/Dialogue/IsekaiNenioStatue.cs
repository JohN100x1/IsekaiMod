using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using System.Collections.Generic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Dialogue {

    internal class IsekaiNenioStatue {
        public static void Add() {
            var BeholdTheTruthCue = BlueprintTools.GetBlueprint<BlueprintCue>("1701cb6cba55ed04cac7908e072563ac");

            // Prompt (Statue in Nameless Ruins)
            /* {n}But then something changes. The emptiness takes notice of you. It stares at you, measures and assesses you.
             * Then a question comes — as simple and as deep as the emptiness itself.{/n} "Who are you?"
             */

            //Reply
            var IsekaiDialogueNenioStatueReply = TTCoreExtensions.CreateCue("IsekaiDialogueNenioStatueReply", bp => {
                bp.SetText(IsekaiContext, "{n}The emptiness is bewildered and confused, but cannot deny what you say to be truth.{/n}");
                bp.Continue = new CueSelection {
                    Cues = new List<BlueprintCueBaseReference>() { BeholdTheTruthCue.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
            });
            // Answer
            var IsekaiDialogueNenioStatueAnswer1 = TTCoreExtensions.CreateAnswer("IsekaiDialogueNenioStatueAnswer1", bp => {
                bp.SetText(IsekaiContext, "(Isekai Protagonist) \"I am the bone of my sword.\"");
                bp.NextCue = new CueSelection {
                    Cues = new List<BlueprintCueBaseReference>() { IsekaiDialogueNenioStatueReply.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
                bp.ShowOnce = true;
            });
            var IsekaiDialogueNenioStatueAnswer2 = TTCoreExtensions.CreateAnswer("IsekaiDialogueNenioStatueAnswer2", bp => {
                bp.SetText(IsekaiContext, "(Isekai Protagonist) \"I am the hope of the universe.\"");
                bp.NextCue = new CueSelection {
                    Cues = new List<BlueprintCueBaseReference>() { IsekaiDialogueNenioStatueReply.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
                bp.ShowOnce = true;
            });
            var IsekaiDialogueNenioStatueAnswer3 = TTCoreExtensions.CreateAnswer("IsekaiDialogueNenioStatueAnswer3", bp => {
                bp.SetText(IsekaiContext, "(Isekai Protagonist) \"I am just a guy who's a hero for fun.\"");
                bp.NextCue = new CueSelection {
                    Cues = new List<BlueprintCueBaseReference>() { IsekaiDialogueNenioStatueReply.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
                bp.ShowOnce = true;
            });
            var IsekaiDialogueNenioStatueAnswer4 = TTCoreExtensions.CreateAnswer("IsekaiDialogueNenioStatueAnswer4", bp => {
                bp.SetText(IsekaiContext, "(Isekai Protagonist) \"I am Atomic.\"");
                bp.NextCue = new CueSelection {
                    Cues = new List<BlueprintCueBaseReference>() { IsekaiDialogueNenioStatueReply.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
                bp.ShowOnce = true;
            });
            var IsekaiDialogueNenioStatueAnswer5 = TTCoreExtensions.CreateAnswer("IsekaiDialogueNenioStatueAnswer5", bp => {
                bp.SetText(IsekaiContext, "(Isekai Protagonist) \"I am God.\"");
                bp.NextCue = new CueSelection {
                    Cues = new List<BlueprintCueBaseReference>() { IsekaiDialogueNenioStatueReply.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
                bp.ShowOnce = true;
            });
            var IsekaiDialogueNenioStatueAnswer6 = TTCoreExtensions.CreateAnswer("IsekaiDialogueNenioStatueAnswer6", bp => {
                bp.SetText(IsekaiContext, "(Isekai Protagonist) \"I am just some guy who got hit by a truck and somehow ended up in this world.\"");
                bp.NextCue = new CueSelection {
                    Cues = new List<BlueprintCueBaseReference>() { IsekaiDialogueNenioStatueReply.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
                bp.ShowOnce = true;
            });

            // Add Answer to answers list
            var AnswersList_0006 = BlueprintTools.GetBlueprint<BlueprintAnswersList>("db068bf5b388cce4c9f828d389ca537d");
            AnswersList_0006.Answers.Insert(0, IsekaiDialogueNenioStatueAnswer6.ToReference<BlueprintAnswerBaseReference>());
            AnswersList_0006.Answers.Insert(0, IsekaiDialogueNenioStatueAnswer5.ToReference<BlueprintAnswerBaseReference>());
            AnswersList_0006.Answers.Insert(0, IsekaiDialogueNenioStatueAnswer4.ToReference<BlueprintAnswerBaseReference>());
            AnswersList_0006.Answers.Insert(0, IsekaiDialogueNenioStatueAnswer3.ToReference<BlueprintAnswerBaseReference>());
            AnswersList_0006.Answers.Insert(0, IsekaiDialogueNenioStatueAnswer2.ToReference<BlueprintAnswerBaseReference>());
            AnswersList_0006.Answers.Insert(0, IsekaiDialogueNenioStatueAnswer1.ToReference<BlueprintAnswerBaseReference>());
        }
    }
}