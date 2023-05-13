using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using System.Collections.Generic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Dialogue {

    internal class IsekaiHorgus {

        // Answers: Answer_0011 = "Two thousand gold."
        private static readonly BlueprintAnswersList AnswersList_0009 = BlueprintTools.GetBlueprint<BlueprintAnswersList>("12e42316950f8c9498afb8b0fb2baaae");
        private static readonly BlueprintAnswer Answer_0011 = BlueprintTools.GetBlueprint<BlueprintAnswer>("3ab564082485b034a9d0a7b550e1a3e2");
        private static readonly BlueprintUnit Horgus = BlueprintTools.GetBlueprint<BlueprintUnit>("c02e641bf8cf0984fb49604afa224563");
        private static readonly BlueprintUnlockableFlag Horgus_GetMeOut_price = BlueprintTools.GetBlueprint<BlueprintUnlockableFlag>("ddfedbdeab95ed941b6968b06162c921");

        public static void Add() {
            // Prompt (Hulrun, at Kenabres festival)
            /* "Be quick about it, before it's too late!" {n}The old man leans over you.{/n}
             * "Now, who are you? I don't remember seeing you before, and I have an excellent memory for faces."
             */

            // Reply
            var IsekaiDialogueHorgusReply = TTCoreExtensions.CreateCue("IsekaiDialogueHorgusReply", bp => {
                bp.SetText(IsekaiContext, "\"My daughter?\" {n}Horgus takes a quick glance at Camellia.{/n} \"I don't think you know what sort of person she is. "
                    + "{n}Horgus takes a breath.{/n} Regardless, it seems my previous offer was somewhat insulting. Two thousand gold it is.\"");
                bp.Speaker = new DialogSpeaker {
                    m_Blueprint = Horgus.ToReference<BlueprintUnitReference>(),
                    MoveCamera = true
                };
                bp.OnStop = ActionFlow.DoSingle<UnlockFlag>(c => {
                    c.m_flag = Horgus_GetMeOut_price.ToReference<BlueprintUnlockableFlagReference>();
                    c.flagValue = 2000;
                });
                bp.Answers = AnswersList_0009.Answers;
            });
            // Answer
            var IsekaiDialogueHorgus = TTCoreExtensions.CreateAnswer("IsekaiDialogueHorgus", bp => {
                bp.SetText(IsekaiContext, "(Isekai Protagonist) \"Two thousand gold... And your daughter joins my harem.\"");
                bp.NextCue = new CueSelection {
                    Cues = new List<BlueprintCueBaseReference>() { IsekaiDialogueHorgusReply.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
                bp.ShowOnce = true;
                bp.OnSelect = ActionFlow.DoSingle<GainExp>(c => {
                    c.Encounter = EncounterType.SkillCheck;
                    c.CR = 2;
                    c.Modifier = 1f;
                });
                bp.AddShowCondition<AnswerSelected>(c => {
                    c.Not = true;
                    c.m_Answer = Answer_0011.ToReference<BlueprintAnswerReference>();
                });
            });

            // Ptach "Two Thousand gold." answer in dialogue
            Answer_0011.ShowConditions.Conditions = Answer_0011.ShowConditions.Conditions.AppendToArray(
                new AnswerSelected {
                    Not = true,
                    m_Answer = IsekaiDialogueHorgus.ToReference<BlueprintAnswerReference>()
                });

            // Add Answer to answers list
            AnswersList_0009.Answers.Insert(0, IsekaiDialogueHorgus.ToReference<BlueprintAnswerBaseReference>());
        }
    }
}