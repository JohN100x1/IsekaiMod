using IsekaiMod.Content.Backgrounds;
using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Utilities;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using System.Collections.Generic;

namespace IsekaiMod.Content.Dialogue
{
    class IsekaiHulrun
    {
        // Next Cue and Etude
        private static readonly BlueprintCue DontRememberCue = Resources.GetBlueprint<BlueprintCue>("ba9c82193a32275408973a8aebdb3a6d");
        private static readonly BlueprintEtude DontRememberEtude = Resources.GetBlueprint<BlueprintEtude>("d6c6161d2cf0ac44786f9df67fca5ce9");
        public static void Add()
        {
            // Prompt (Hulrun, at Kenabres festival)
            /* "Be quick about it, before it's too late!" {n}The old man leans over you.{/n}
             * "Now, who are you? I don't remember seeing you before, and I have an excellent memory for faces."
             */

            // Answer
            var IsekaiDialogueHulrun = Helpers.CreateAnswer("IsekaiDialogueHulrun", bp => {
                bp.Text = Helpers.CreateString("IsekaiDialogueHulrun.Text", "(Isekai Protagonist) \"Other than being hit by a truck, I don't remember anything at all...\"");
                bp.NextCue = new CueSelection()
                {
                    Cues = new List<BlueprintCueBaseReference>() { DontRememberCue.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
                bp.ShowConditions = ActionFlow.IfAny(
                    new PlayerSignificantClassIs()
                    {
                        Not = false,
                        CheckGroup = false,
                        m_CharacterClass = IsekaiProtagonistClass.GetReference(),
                    },
                    new ContextConditionHasFact()
                    {
                        m_Fact = IsekaiBackgroundSelection.Get().ToReference<BlueprintUnitFactReference>(),
                        Not = false
                    });
                bp.OnSelect = ActionFlow.DoSingle<StartEtude>(c => {
                    c.Etude = DontRememberEtude.ToReference<BlueprintEtudeReference>();
                    c.Evaluate = false;
                });
            });

            // Add Answer to answers list
            var AnswersList_0020 = Resources.GetBlueprint<BlueprintAnswersList>("e27807b731f3b1a4eb19c1a04fdfcf53");
            AnswersList_0020.Answers.Insert(0, IsekaiDialogueHulrun.ToReference<BlueprintAnswerBaseReference>());
        }
    }
}
