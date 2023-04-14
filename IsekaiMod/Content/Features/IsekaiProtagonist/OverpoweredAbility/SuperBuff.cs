using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System.Collections.Generic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class SuperBuff {
        private static readonly LocalizedString Description = Helpers.CreateString(IsekaiContext, "SuperBuff.Description",
            "You are able to buff you and your allies with the following effects for 24 hours: resist energy, protection from energy, "
            + "protection from arrows, haste, mage armor, shield, shield of faith, veil of heaven, veil of positive energy, blur, "
            + "bull's strength, cat's grace, bear's endurance, fox's cunning, owl's wisdom, eagle's splendor, mirror image, false life, "
            + "barkskin, aid, protection from evil, bestow grace, aura of greater courage, displacement, magical vestiment, delay poison, "
            + "invisibility greater, stone skin, death ward, freedom of movement, false life greater, burst of glory, spell resistance, "
            + "eagle soul, legendary proportions, frightful aspect, seamantle, foresight, unbreakable heart, remove fear, divine favor, "
            + "magic fang, align weapon good, crusaders edge, magic weapon greater, divine power, true seeing, shield of law, "
            + "angelic aspect greater, winds of vengeance, hurricane bow, sense vitals, heroism greater, echolocation, life bubble, "
            + "protection from spells, mind blank, and heroic invocation.");

        public static void Add() {
            // Buffs
            BlueprintBuff[] Buffs = new BlueprintBuff[]
            {
                BlueprintTools.GetBlueprint<BlueprintBuff>("468877871a8e3ba41813a9697ec4eb4e"), // ResistFireBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("dfedc0bf1d93f024d85546314c42b56a"), // ResistColdBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("8d8f20391422c0e41a1650e7a9b7a21f"), // ResistAcidBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("c0f3b16ff3f79b749b121905d659a2d4"), // ResistSonicBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("17aee23103aee674082ff9891c82ae2f"), // ResistElectricityBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("52a2552185c4a7c4ba30e421b9e27224"), // ProtectionFromFireBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("ebf84606d5179af4baf9d4589d191c05"), // ProtectionFromColdBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("6f9d4b5d2fe2f684e816a54b4973cc58"), // ProtectionFromAcidBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("e40277752759edb49b557ce8399596bc"), // ProtectionFromSonicBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("1b0cd0ee398bd9b46888fe58cac4bda9"), // ProtectionFromElectricityBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("241ee6bd8c8767343994bce5dc1a95e0"), // ProtectionFromArrowsBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("03464790f40c3c24aa684b57155f3280"), // HasteBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("355be0688dabc21409f37942d637cdab"), // MageArmorBuffMythic
                BlueprintTools.GetBlueprint<BlueprintBuff>("9c0fa9b438ada3f43864be8dd8b3e741"), // MageShieldBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("5274ddc289f4a7447b7ace68ad8bebb0"), // ShieldOfFaithBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("f5d3311a675a7174dad7ffa99a81ad56"), // VeilOfHeavenBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("d72cc6b3a65d31247b37faf600a17977"), // VeilOfPositiveEnergyBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("dd3ad347240624d46a11a092b4dd4674"), // BlurBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("b175001b42b1a02479881b72fe132116"), // BullsStrengthBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("f011d0ab4a405e54aa0e83cd10e54430"), // CatsGraceBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("c3de8cc9a0f50e2418dde526d8855faa"), // BearsEnduranceBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("c8c9872e9e02026479d82b9264b9cc6b"), // FoxsCunningBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("73fc1d19f14339042ba5af34872c1745"), // OwlsWisdomBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("7ed853ffcfd29914cb098cd7b1c46cc4"), // EaglesSplendorBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("98dc7e7cc6ef59f4abe20c65708ac623"), // MirrorImageBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("0fdb3cca6744fd94b9436459e6d9b947"), // FalseLifeBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("533592a86adecda4e9fd5ed37a028432"), // BarkSkinBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("319b4679f25779e4e9d04360381254e1"), // AidBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("4a6911969911ce9499bf27dde9bfcedc"), // ProtectionFromEvilBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("1561924f60cbe384283b0788050eca2a"), // BestowGraceBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("ff183ce55a2896e43bb2dd9f5d989119"), // AuraOfGreaterCourageBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("00402bae4442a854081264e498e7a833"), // DisplacementBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("9e265139cf6c07c4fb8298cb8b646de9"), // MagicalVestimentArmorBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("2e8446f820936a44f951b50d70a82b16"), // MagicalVestimentShieldBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("51ebd62ee464b1446bb01fa1e214942f"), // DelayPoisonBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("e6b35473a237a6045969253beb09777c"), // InvisibilityGreaterBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("37a956d0e7a84ab0bb66baf784767047"), // StoneSkinBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("b0253e57a75b621428c1b89de5a937d1"), // DeathWardBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("1533e782fca42b84ea370fc1dcbf4fc1"), // FreedomOfMovementBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("4814db563c105e64d948161162715661"), // FalseLifeGreaterBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("81005a24695910f4cb9b7c8ab4d932e1"), // BurstOfGloryBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("50a77710a7c4914499d0254e76a808e5"), // SpellResistanceBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("fb0ae0908b3d5c3459be94e11e0c1687"), // EagleSoulBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("4ce640f9800d444418779a214598d0a3"), // LegendaryProportionsBuff
                // BlueprintTools.GetBlueprint<BlueprintBuff>("a6da7d6a5c9377047a7bd2680912860f"), // IceBodyBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("906262fda0fbda442b27f9b0a04e5aa0"), // FrightfulAspectBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("1c05dd3a1c78b0e4e9f7438a43e7a9fd"), // SeamantleBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("8c385a7610aa409468f3a6c0f904ac92"), // ForesightBuff
                // BlueprintTools.GetBlueprint<BlueprintBuff>("b574e1583768798468335d8cdb77e94c"), // FieryBodyBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("6603b27034f694e44a407a9cdf77c67e"), // UnbreakableHeartBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("c5c86809a1c834e42a2eb33133e90a28"), // RemoveFearBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("5d2833d39901b844b828f9f13a0353fe"), // DivineFavorBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("e7646b1dfdd22ce4ab340f295938ab8e"), // MagicFangBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("cbe785a099249164eb2204f553437e3d"), // AlignWeaponGoodBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("7ca348639a91ae042967f796098e3bc3"), // CrusadersEdgeBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("31848cce6c6246c19aa050e7e693ddee"), // MagicWeaponGreaterBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("208ce0902f20b1e4896a85b2339468ff"), // DivinePowerBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("09b4b69169304474296484c74aa12027"), // TrueSeeingBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("0da7299aac601d445a355152084c251a"), // ShieldOfLawBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("87fcda72043d20840b4cdc2adcc69c63"), // AngelicAspectGreaterBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("796a2fe600e5ead41b29cd9963cf2de9"), // WindsOfVengeanceBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("002c51d933574824c8ef2b04c9d09ff5"), // HurricaneBowBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("dea0dba1f7bff064987e03f1307bfa84"), // SenseVitalsBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("b8da3ec045ec04845a126948e1f4fc1a"), // HeroismGreaterBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("cbfd2f5279f5946439fe82570fd61df2"), // EcholocationBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("4aa87d3319124a2daf74d80ca5d4595e"), // LifeBubbleBuff
                // BlueprintTools.GetBlueprint<BlueprintBuff>("c6cc1c5356db4674dbd2be20ea205c86"), // FirebrandBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("e9947402c84e8bc4e958b9be08d7a720"), // ProtectionFromSpellsBuffSpell
                BlueprintTools.GetBlueprint<BlueprintBuff>("4f0064bea5b14554f809f5e075a0070d"), // ProtectionFromSpellsBuffSpellLike
                BlueprintTools.GetBlueprint<BlueprintBuff>("35f3724d4e8877845af488d167cb8a89"), // MindBlankBuff
                BlueprintTools.GetBlueprint<BlueprintBuff>("fd8fb2c1d622556468a04bea949eb7da")  // HeroicInvocationBuff
            };
            List<GameAction> ApplyBuffActions = CreateApplyBuffActionList(Buffs);
            List<GameAction> RemoveBuffActions = CreateRemoveBuffActionList(Buffs);

            var Icon_SuperBuff = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_SUPER_BUFF.png");
            var Icon_SuperBuffDismiss = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_SUPER_BUFF_DISMISS.png");
            var SuperBuffAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "SuperBuffAbility", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Super Buff");
                bp.SetDescription(Description);
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList() { Actions = ApplyBuffActions.ToArray() };
                });
                bp.AddComponent<AbilityTargetsAround>(c => {
                    c.m_Radius = new Feet(60);
                    c.m_TargetType = TargetType.Ally;
                    c.m_Condition = ActionFlow.EmptyCondition();
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Universalist;
                });
                bp.m_Icon = Icon_SuperBuff;
                bp.Type = AbilityType.Supernatural;
                bp.Range = AbilityRange.Personal;
                bp.CanTargetFriends = true;
                bp.CanTargetSelf = true;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Self;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Reach;
                bp.LocalizedDuration = StaticReferences.Strings.Duration.OneDay;
                bp.LocalizedSavingThrow = StaticReferences.Strings.Null;
            });
            var SuperBuffDismissAbility = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, "SuperBuffDismissAbility", bp => {
                bp.SetName(IsekaiContext, "Dismiss Super Buff");
                bp.SetDescription(IsekaiContext, "You dispell all buffs from you and your allies.");
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList() { Actions = RemoveBuffActions.ToArray() };
                });
                bp.AddComponent<AbilityTargetsAround>(c => {
                    c.m_Radius = new Feet(60);
                    c.m_TargetType = TargetType.Ally;
                    c.m_Condition = ActionFlow.EmptyCondition();
                });
                bp.AddComponent<SpellComponent>(c => {
                    c.School = SpellSchool.Universalist;
                });
                bp.m_Icon = Icon_SuperBuffDismiss;
                bp.Type = AbilityType.Supernatural;
                bp.Range = AbilityRange.Personal;
                bp.CanTargetFriends = true;
                bp.CanTargetSelf = true;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Self;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Reach;
                bp.LocalizedDuration = StaticReferences.Strings.Null;
                bp.LocalizedSavingThrow = StaticReferences.Strings.Null;
            });
            var SuperBuffFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "SuperBuffFeature", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Super Buff");
                bp.SetDescription(Description);
                bp.m_Icon = Icon_SuperBuff;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        SuperBuffAbility.ToReference<BlueprintUnitFactReference>(),
                        SuperBuffDismissAbility.ToReference<BlueprintUnitFactReference>()
                    };
                });
            });

            OverpoweredAbilitySelection.AddToNonAutoSelection(SuperBuffFeature);
        }

        private static List<GameAction> CreateApplyBuffActionList(BlueprintBuff[] buffs) {
            List<GameAction> actions = new();
            foreach (BlueprintBuff buff in buffs) {
                actions.Add(
                    new ContextActionApplyBuff() {
                        m_Buff = buff.ToReference<BlueprintBuffReference>(),
                        DurationValue = Values.Duration.OneDay,
                    });
            }
            return actions;
        }

        private static List<GameAction> CreateRemoveBuffActionList(BlueprintBuff[] buffs) {
            List<GameAction> actions = new();
            foreach (BlueprintBuff buff in buffs) {
                actions.Add(
                    new ContextActionRemoveBuff() {
                        m_Buff = buff.ToReference<BlueprintBuffReference>(),
                        OnlyFromCaster = true
                    });
            }
            return actions;
        }
    }
}