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

    internal class IsekaiRadiance {

        // Next Cue and Etude
        private static readonly BlueprintCue UpgradeRadianceCue = BlueprintTools.GetBlueprint<BlueprintCue>("6603e3274d42438faa38af673024a832");

        public static void Add() {
            // Prompt (Seelah, after finding Radiance)
            /* {n}Seelah stares at you in amazement.{/n} "Just look at that! The sword seemed to greet you! It senses the hand of a {d|c0 paladin radiance}paladin{/d}.
             * And it seems relieved that we're freeing it from the demons' clutches. A good omen and a good find!"
             *
             * {n}Seelah laughs.{/n} "I have this weird feeling, like I'm rescuing a fellow warrior from a dungeon. We can't just abandon it, even if it's no use to us.
             * It's no use to anyone down here. But what if it could be repaired?"
             *
             * {n}Seelah frowns.{/n} "Now... nothing, I guess. But this sword was legendary in its day! People say that when Yaniel held it, the blade would glow, striking demons left
             * and right. Soldiers would see Radiance's light from afar and take heart, rushing into the fray and winning. But I don't know what's wrong with it now, or how to restore
             * its power. All I can sense is that they made a mockery of it."
             *
             * "She died as she lived — with pride. She was one of the people defending {g|drezen}Drezen{/g} to the very end — that's where she perished." {n}Seelah frowns.{/n}
             * "Don't take this the wrong way, but I really hope that she died quickly — a hero's death. Because if she didn't... that means she was taken prisoner and had to endure
             * unspeakable horrors. I wouldn't wish that on anyone."
             *
             * "Sensitive in a way, yes. We're highly attuned to evil and everything wrought by demons. Radiance was in evil hands, and, as a paladin, I can tell you they did nothing
             * good to it."
             *
             * "You don't get it — I've seen this sword a hundred times, in paintings and in the hands of the Yaniel statue. I've even thought of going to the Estrod museum to see the
             * real thing in person... How did it get here?"
             *
             * "I suppose you could say that." {n}Seelah chuckles.{/n} "I've always felt an affinity with Yaniel. I know what it's like to not be what your commanders want you to be.
             * Whenever I used to feel under pressure, I always thought of Yaniel: maybe some people didn't like how she was, but to the people she pulled out of the Worldwound, she
             * was perfect. And to the people she saved on the battlefield, she was incredible. And to those who keep her memory alive, she is a hero. That's what counts."
             *
             * "She died as she lived — proudly. She was covering the escape of the refugees fleeing {g|drezen}Drezen{/g} — that's where she perished. She wasn't even forty, very young
             * for a half-elf. But I guess I don't have to explain that to you! You half-elves live twice as long as we do. If you think about it, the crusades aren't even a hundred
             * years old. That's how little time separates us from the heroes of legend. Yaniel could still have been alive today... But fate decided otherwise."
             *
             * "She died the same way she lived — proudly. She was covering the escape of the refugees fleeing {g|drezen}Drezen{/g} — that's where she perished. She wasn't even forty,
             * very young for a half-elf. Yaniel could have still been alive today... after all, the crusades are less than a hundred years old. That's how little time separates us from
             * the heroes of legend. But I guess I don't have to explain that to you — it mustn't seem like a long time to you at all. Not even a generation has passed since the Wound
             * first tainted the world and started taking the lives of the brave heroes who opposed it."
             *
             * "I hope you're right. Inheritor in Heaven, can you hear us? We need your help now more than ever."
             *
             * "This is more than just a blade. This is a part of our history, a legacy of the crusaders of the past. But you're right, it's also an impressive piece of craftsmanship!"
             *
             * "I can't speak for all crusaders, but I'm doing just fine without any lessons from Asmodeus."
             */

            // Answer
            var IsekaiDialogueRadiance = TTCoreExtensions.CreateAnswer("IsekaiDialogueRadiance", bp => {
                bp.SetText(IsekaiContext, "(Isekai Protagonist) [Pound the sword repeatedly] \"You better power up right now or you're going to reincarnate as a broken blade.\"");
                bp.NextCue = new CueSelection {
                    Cues = new List<BlueprintCueBaseReference>() { UpgradeRadianceCue.ToReference<BlueprintCueBaseReference>() },
                    Strategy = Strategy.First
                };
                bp.ShowConditions = ActionFlow.IfSingle<PlayerSignificantClassIs>(c => {
                    c.Not = false;
                    c.CheckGroup = false;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                });
            });

            // Add Answer to answers list
            var AnswersList_0002 = BlueprintTools.GetBlueprint<BlueprintAnswersList>("d7669703a6d923d4e8b34bc56ec16c31");
            AnswersList_0002.Answers.Insert(0, IsekaiDialogueRadiance.ToReference<BlueprintAnswerBaseReference>());
        }
    }
}