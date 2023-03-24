using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using System.Collections.Generic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Dialogue {

    internal class IsekaiKaylessaDrowLeader {
        private static readonly BlueprintCue Cue_0067 = BlueprintTools.GetBlueprint<BlueprintCue>("a8cc736feec11024eb6a5d3dbcb69f5c");

        public static void Add() {
            // Prompt (Tran, at drow ambush)
            /* \"Lady Anemora desires your head! And we'll gladly deliver it!\" {n}The elf, whose voice as Tran was so convincing, lets out a repulsive snicker.{/n}
             */

            // Answer
            var IsekaiKaylessaDrowLeader = ThingsNotHandledByTTTCore.CreateAnswer("IsekaiKaylessaDrowLeader", bp => {
                bp.Text = Helpers.CreateString(IsekaiContext, "IsekaiKaylessaDrowLeader.Text",
                    "(Isekai Protagonist) [Attack] \"Nice acting, Mr. background character. Now it's time for your unmomentous death scene.\"");
                bp.NextCue = new CueSelection() {
                    Cues = new List<BlueprintCueBaseReference>() { Cue_0067.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
                bp.ShowConditions = ActionFlow.IfSingle<PlayerSignificantClassIs>(c => {
                    c.Not = false;
                    c.CheckGroup = false;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                });
            });

            // Add Answer to answers list
            var AnswersList_0062 = BlueprintTools.GetBlueprint<BlueprintAnswersList>("b8e680587a76f064fac9a01034c02391");
            AnswersList_0062.Answers.Add(IsekaiKaylessaDrowLeader.ToReference<BlueprintAnswerBaseReference>());
        }
    }
}