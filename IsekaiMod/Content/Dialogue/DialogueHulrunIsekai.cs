using IsekaiMod.Utilities;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Alignments;
using System.Collections.Generic;

namespace IsekaiMod.Content.Dialogue
{
    class IsekaiWelcomeDialogue
    {
        public static void Add()
        {
            // Has Plot Armor
            var PlotArmor = Resources.GetModBlueprint<BlueprintFeature>("PlotArmor");

            // Next Cue and Etude
            var DontRememberCue = Resources.GetBlueprint<BlueprintCue>("ba9c82193a32275408973a8aebdb3a6d");
            var DontRememberEtude = Resources.GetBlueprint<BlueprintEtude>("d6c6161d2cf0ac44786f9df67fca5ce9");

            // Isekai Answer
            var AnswerIsekai = Helpers.CreateBlueprint<BlueprintAnswer>("AnswerIsekai", bp => {
                bp.Text = Helpers.CreateString("AnswerIsekai.Text", "Other than being hit by a truck, I don't remember anything at all...");
                bp.NextCue = new CueSelection()
                {
                    Cues = new List<BlueprintCueBaseReference>() { DontRememberCue.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
                bp.ShowOnce = false;
                bp.ShowOnceCurrentDialog = false;
                bp.ShowCheck = new ShowCheck() { Type = StatType.Unknown, DC = 0 };
                bp.Experience = DialogExperience.NoExperience;
                bp.DebugMode = false;
                bp.CharacterSelection = new CharacterSelection() { SelectionType = CharacterSelection.Type.Clear, ComparisonStats = new StatType[0] };
                bp.ShowConditions = new ConditionsChecker() {
                    Operation = Operation.And,
                    Conditions = new Condition[] {
                        new HasFact()
                        {
                            Not = false,
                            Unit = new PlayerCharacter(),
                            m_Fact = PlotArmor.ToReference<BlueprintUnitFactReference>()
                        }
                    }
                };
                bp.SelectConditions = new ConditionsChecker();
                bp.RequireValidCue = false;
                bp.AddToHistory = true;
                bp.OnSelect = Helpers.CreateActionList(
                    new StartEtude()
                    {
                        Etude = DontRememberEtude.ToReference<BlueprintEtudeReference>(),
                        Evaluate = false
                    });
                bp.FakeChecks = new CheckData[0];
                bp.AlignmentShift = new AlignmentShift() { Direction = AlignmentShiftDirection.TrueNeutral, Value = 0, Description = new LocalizedString() };
            });

            // Add Answer to answers list
            var AnswersList_0020 = Resources.GetBlueprint<BlueprintAnswersList>("e27807b731f3b1a4eb19c1a04fdfcf53");
            AnswersList_0020.Answers.Insert(0, AnswerIsekai.ToReference<BlueprintAnswerBaseReference>());
        }
    }
}
