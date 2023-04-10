using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {

    internal class SecondReincarnation {
        private static readonly Sprite Icon_SecondReincarnation = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_SECOND_REINCARNATION.png");
        public static void Add() {

            const string SecondReincarnationName = "Second Reincarnation";
            const string SecondReincarnationDesc = "Your attacks ignore damage reduction and your spells ignore spell resistance and spell immunity."
                + "\nOnce per day, when your {g|Encyclopedia:HP}HP{/g} drops to 0, you are resurrected to full health.";
            var SecondReincarnationBuff = TTCoreExtensions.CreateBuff("SecondReincarnationBuff", bp => {
                bp.SetName(IsekaiContext, SecondReincarnationName);
                bp.SetDescription(IsekaiContext, SecondReincarnationDesc);
                bp.m_Icon = Icon_SecondReincarnation;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<DeathActions>(c => {
                    c.CheckResource = false;
                    c.Actions = Helpers.CreateActionList(
                        new ContextActionResurrect() { FullRestore = true },
                        new ContextActionSpawnFx() {
                            PrefabLink = new PrefabLink() { AssetId = "749ad3759dc93d64dba70a84d48135b5" }
                        },
                        new ContextActionRemoveSelf()
                        );
                });
            });
            var SecondReincarnation = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "SecondReincarnation", bp => {
                bp.SetName(IsekaiContext, SecondReincarnationName);
                bp.SetDescription(IsekaiContext, SecondReincarnationDesc);
                bp.m_Icon = Icon_SecondReincarnation;
                bp.AddComponent<IgnoreDamageReductionOnAttack>();
                bp.AddComponent<IgnoreSpellImmunity>(c => {
                    c.SpellDescriptor = SpellDescriptor.None;
                    // TODO: IgnoreSpellImmunity doesn't actually affect the target? (search all IgnoreSpellImmunity)
                    // See IgnoreSpellResistanceForSpells and RuleSpellResistanceCheck.TargetIsImmune
                });
                bp.AddComponent<IgnoreSpellResistanceForSpells>(c => {
                    c.m_AbilityList = new BlueprintAbilityReference[0];
                    c.AllSpells = true;
                });
                bp.AddComponent<AddRestTrigger>(c => {
                    c.Action = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                        c.m_Buff = SecondReincarnationBuff.ToReference<BlueprintBuffReference>();
                        c.Permanent = true;
                        c.IsFromSpell = false;
                    });
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { SecondReincarnationBuff.ToReference<BlueprintUnitFactReference>() };
                    c.DoNotRestoreMissingFacts = true;
                });
            });
        }
    }
}