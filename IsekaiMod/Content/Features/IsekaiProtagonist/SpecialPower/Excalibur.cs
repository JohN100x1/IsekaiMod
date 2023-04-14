using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {
    internal class Excalibur {
        private const string ExcaliburName = "Excalibur";
        private const string ExcaliburDescBuff = ".............."; // TODO: finish this
        private static readonly LocalizedString ExcaliburDesc = Helpers.CreateString(IsekaiContext, "Excalibur.Description", "..........."); // TODO: finish this

        private static readonly Sprite Icon_Excalibur = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_EXCALIBUR.png");
        public static void Add() {

            var ExcaliburBuff = TTCoreExtensions.CreateBuff("ExcaliburBuff", bp => {
                bp.SetName(IsekaiContext, ExcaliburName);
                bp.SetDescription(IsekaiContext, ExcaliburDescBuff);
                bp.m_Icon = Icon_Excalibur;
                bp.AddComponent<WeaponSizeChange>(c => {
                    c.SizeCategoryChange = 2;
                }); // TODO: finish this
            });
            var ExcaliburAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "ExcaliburAbility", bp => {
                bp.SetName(IsekaiContext, ExcaliburName);
                bp.SetDescription(ExcaliburDesc);
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                        c.m_Buff = ExcaliburBuff.ToReference<BlueprintBuffReference>();
                        c.Permanent = true;
                        c.IsFromSpell = false;
                    });
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Enchantment;
                });
                bp.m_Icon = Icon_Excalibur;
                bp.Type = AbilityType.Supernatural;
                bp.Range = AbilityRange.Personal;
                bp.CanTargetFriends = false;
                bp.CanTargetSelf = true;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Self;
                bp.ActionType = UnitCommand.CommandType.Swift;
                bp.AvailableMetamagic = Metamagic.Quicken;
                bp.LocalizedDuration = StaticReferences.Strings.Duration.OneDay;
                bp.LocalizedSavingThrow = StaticReferences.Strings.Null;
            });
            var ExcaliburFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "ExcaliburFeature", bp => {
                bp.SetName(IsekaiContext, ExcaliburName);
                bp.SetDescription(ExcaliburDesc);
                bp.m_Icon = Icon_Excalibur;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        ExcaliburAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });
            });

            SpecialPowerSelection.AddToSelection(ExcaliburFeature);
        }
    }
}
