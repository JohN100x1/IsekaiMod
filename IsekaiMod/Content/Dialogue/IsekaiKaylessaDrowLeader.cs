using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using System.Collections.Generic;

namespace IsekaiMod.Content.Dialogue
{
    class IsekaiKaylessaDrowLeader
    {
        private static readonly BlueprintCue Cue_0067 = Resources.GetBlueprint<BlueprintCue>("a8cc736feec11024eb6a5d3dbcb69f5c");
        public static void Add()
        {
            // Prompt (Tran, at drow ambush)
            /* \"Lady Anemora desires your head! And we'll gladly deliver it!\" {n}The elf, whose voice as Tran was so convincing, lets out a repulsive snicker.{/n}
             */

            // Answer
            var IsekaiKaylessaDrowLeader = Helpers.CreateAnswer("IsekaiKaylessaDrowLeader", bp => {
                bp.Text = Helpers.CreateString("IsekaiKaylessaDrowLeader.Text", "(Isekai Protagonist) [Attack] \"Nice acting, Mr. background character. "
                    + "Now it's time for your unmomentous death scene.\"");
                bp.NextCue = new CueSelection()
                {
                    Cues = new List<BlueprintCueBaseReference>() { Cue_0067.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
                bp.ShowConditions = ActionFlow.IfSingle<PlayerSignificantClassIs>(c =>
                {
                    c.Not = false;
                    c.CheckGroup = false;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                });
            });

            // Add Answer to answers list
            var AnswersList_0062 = Resources.GetBlueprint<BlueprintAnswersList>("b8e680587a76f064fac9a01034c02391");
            AnswersList_0062.Answers.Add(IsekaiKaylessaDrowLeader.ToReference<BlueprintAnswerBaseReference>());
        }
    }
}
