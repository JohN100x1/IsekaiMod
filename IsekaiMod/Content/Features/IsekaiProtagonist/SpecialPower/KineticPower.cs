using HarmonyLib;
using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System;
using System.Collections.Generic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class KineticPower {
        // Tutorial
        // To add a new blast, a blast base and blast feature must be created
        // New blast base must be added into the m_Blasts of AddKineticistPart in KineticPowerBurn
        // New blast feature must be appended to KineticPowerSelection
        // New blast feature must be patched by PatchGatherPowerBuffs if the blast feature is initially selectable

        // Icons
        private static readonly Sprite Icon_InfusionSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("58d6f8e9eea63f6418b107ce64f315ea").m_Icon;

        // Kinetic Power Burn
        private static readonly BlueprintFeature BurnFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("57e3577a0eb53294e9d7cc649d5239a3");

        private static readonly BlueprintAbilityResource BurnResource = BlueprintTools.GetBlueprint<BlueprintAbilityResource>("066ac4b762e32be4b953703174ed925c");
        private static readonly BlueprintBuff BurnEffectBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("95b1c0d55f30996429a3a4eba4d2b4a6");
        private static readonly BlueprintAbility GatherPower = BlueprintTools.GetBlueprint<BlueprintAbility>("6dcbffb8012ba2a4cb4ac374a33e2d9a");
        private static readonly BlueprintFeature GatherPowerFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("0601925a028b788469365d5f8f39e14a");
        private static readonly BlueprintBuff GatherPowerBuffI = BlueprintTools.GetBlueprint<BlueprintBuff>("e6b8b31e1f8c524458dc62e8a763cfb1");
        private static readonly BlueprintBuff GatherPowerBuffII = BlueprintTools.GetBlueprint<BlueprintBuff>("3a2bfdc8bf74c5c4aafb97591f6e4282");
        private static readonly BlueprintBuff GatherPowerBuffIII = BlueprintTools.GetBlueprint<BlueprintBuff>("82eb0c274eddd8849bb89a8e6dbc65f8");
        private static readonly BlueprintBuff KineticBladeEnableBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("426a9c079ee7ac34aa8e0054f2218074");
        private static readonly BlueprintBuff ElementalBastionBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("99953956704788444964899b5b8e96ab");

        // Kinetic Power Features
        private static readonly BlueprintFeature DismissInfusionFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("48bbbb16189443049663ca161bb3e338");

        private static readonly BlueprintFeature GatherPowerAbilitiesFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("71f526b1d4b50b94582b0b9cbe12b0e0");

        // Kineticist Class
        private static readonly BlueprintCharacterClass KineticistClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("42a455d9ec1ad924d889272429eb8391");

        // Kinetic Blasts
        private static readonly BlueprintAbility AirBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("31f668b12011e344aa542aa07ab6c8d9");

        private static readonly BlueprintAbility CycloneAirBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("9fbc4fe045472984aa4a2d15d88bdaf9");
        private static readonly BlueprintAbility ExtendRangeAirBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("cae4cb39eb87a5d47b8ff35fd948dc4f");
        private static readonly BlueprintAbility SpindleAirBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a28e54e4e5fafd1449dd9e926be85160");
        private static readonly BlueprintAbility TorrentAirBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("51ede1faa3cdb3b47a46f7579ca02b0a");
        private static readonly BlueprintAbility WallAirBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d0390bd9ff12cd242a40c384445546cd");

        private static readonly BlueprintAbility EarthBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("b28c336c10eb51c4a8ded0258d5742e1");
        private static readonly BlueprintAbility DeadlyEarthEarthBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e29cf5372f89c40489227edc9ffc52be");
        private static readonly BlueprintAbility ExtendedRangeEarthBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7d4712812818f094297f7d7920d130b1");
        private static readonly BlueprintAbility FragmentationEarthBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d859e796f6177cf449679c677076c577");
        private static readonly BlueprintAbility SpindleEarthBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("44d37b2230390b24e8060fe821068984");
        private static readonly BlueprintAbility WallEarthBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f493e7b18b2a22c438df7ced760dd5b0");

        private static readonly BlueprintAbility FireBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7b4f0c9a06db79345b55c39b2d5fb510");
        private static readonly BlueprintAbility DetonationFireBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d651db4ffb7441548a06b11de5f163a1");
        private static readonly BlueprintAbility EruptionFireBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5b69fce8b7890de4b8b9ab973158fed8");
        private static readonly BlueprintAbility ExtendedRangeFireBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7bc1270b5bb78834192215bc03f161cc");
        private static readonly BlueprintAbility FanOfFlamesFireBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a240a6d61e1aee040bf7d132bfe1dc07");
        private static readonly BlueprintAbility SpindleFireBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("6f299bc4320299c49a291f43a667496d");
        private static readonly BlueprintAbility TorrentFireBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5e4c7cb990de4034bbee9fb99be2e15d");
        private static readonly BlueprintAbility WallFireBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("19309b5551a28d74288f4b6f7d8d838d");

        private static readonly BlueprintAbility WaterBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e3f41966c2d662a4e9582a0497621c46");
        private static readonly BlueprintAbility ExtendedRangeWaterBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("11eba1184c7108846a665d8ca317963f");
        private static readonly BlueprintAbility SpindleWaterBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7021bbe4dca437440a41da4552dce28e");
        private static readonly BlueprintAbility SprayWaterBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("963da934d652bdc41900ed68f63ca1fa");
        private static readonly BlueprintAbility TorrentWaterBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("93cc42235edc6824fa7d54b83ed4e1fe");
        private static readonly BlueprintAbility WallWaterBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1ab8c76ac4983174dbffa35e2a87e582");

        // Projectiles
        private static readonly BlueprintProjectile WindProjectile00 = BlueprintTools.GetBlueprint<BlueprintProjectile>("e093b08cd4cafe946962b339faf2310a");

        private static readonly BlueprintProjectile Kinetic_AirBlastLine00 = BlueprintTools.GetBlueprint<BlueprintProjectile>("03689858955c6bf409be06f35f09946a");
        private static readonly BlueprintProjectile Kinetic_EarthBlast00_Projectile = BlueprintTools.GetBlueprint<BlueprintProjectile>("c28e153e8c212c1458ec2ee4092a794f");
        private static readonly BlueprintProjectile Kinetic_EarthSphere00_Projectile = BlueprintTools.GetBlueprint<BlueprintProjectile>("3751a263d0386ef45807e0111de1a5de");
        private static readonly BlueprintProjectile FireCommonProjectile00 = BlueprintTools.GetBlueprint<BlueprintProjectile>("30a5f408ea9d163418c86a7107fc4326");
        private static readonly BlueprintProjectile ArrowFire00 = BlueprintTools.GetBlueprint<BlueprintProjectile>("cd6fbf24b5f625245960c4b8e6f58292");
        private static readonly BlueprintProjectile FireLine00_Head = BlueprintTools.GetBlueprint<BlueprintProjectile>("7172842b720c3534897ebda2e0624c2d");
        private static readonly BlueprintProjectile FireCone15Feet00 = BlueprintTools.GetBlueprint<BlueprintProjectile>("6dfc5e4c7d9ae3048984744222dbd0fa");
        private static readonly BlueprintProjectile Kinetic_WaterBlast00_Projectile = BlueprintTools.GetBlueprint<BlueprintProjectile>("06e268d6a2b5a3a438c2dd52d68bfef6");
        private static readonly BlueprintProjectile Kinetic_WaterBlastCone00_30Feet_Aoe = BlueprintTools.GetBlueprint<BlueprintProjectile>("0ebec8e9eddc29e4496e163822f68ba5");
        private static readonly BlueprintProjectile Kinetic_WaterLine00 = BlueprintTools.GetBlueprint<BlueprintProjectile>("f3566859ed1664543a18f1e235bc652c");

        // Buffs
        private static readonly BlueprintBuff VolcanicStormDifficultTerrainBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("fe21bf21c3182f743a964de5bcd2033e");

        // Weapon
        private static readonly BlueprintItemWeapon KineticBlastPhysicalWeapon = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("65951e1195848844b8ab8f46d942f6e8");

        private static readonly BlueprintItemWeapon KineticBlastEnergyWeapon = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("4d3265a5b9302ee4cab9c07adddb253f");

        // Frequently used constants
        private static readonly DamageTypeDescription BludgeoningDamage = new() {
            Type = DamageType.Physical,
            Common = new DamageTypeDescription.CommomData(),
            Physical = new DamageTypeDescription.PhysicalData() { Form = PhysicalDamageForm.Bludgeoning }
        };

        private static readonly DamageTypeDescription EarthDamage = new() {
            Type = DamageType.Physical,
            Common = new DamageTypeDescription.CommomData(),
            Physical = new DamageTypeDescription.PhysicalData() {
                Form = PhysicalDamageForm.Bludgeoning | PhysicalDamageForm.Piercing | PhysicalDamageForm.Slashing
            }
        };

        private static readonly DamageTypeDescription FireDamage = new() {
            Type = DamageType.Energy,
            Common = new DamageTypeDescription.CommomData(),
            Physical = new DamageTypeDescription.PhysicalData(),
            Energy = DamageEnergyType.Fire
        };

        private static readonly ContextDiceValue PhysicalBlastDamage = new() {
            DiceType = DiceType.D6,
            DiceCountValue = Values.CreateContextRankValue(AbilityRankType.DamageDice),
            BonusValue = Values.CreateContextSharedValue(AbilitySharedValue.Damage)
        };

        private static readonly ContextDiceValue EnergyBlastDamage = new() {
            DiceType = DiceType.D6,
            DiceCountValue = Values.CreateContextRankValue(AbilityRankType.DamageDice),
            BonusValue = Values.CreateContextRankValue(AbilityRankType.DamageBonus)
        };

        private static readonly ContextDurationValue KineticAreaDuration = new() {
            Rate = DurationRate.Rounds,
            DiceType = DiceType.Zero,
            DiceCountValue = 0,
            BonusValue = Values.CreateContextRankValue(AbilityRankType.DamageBonus),
            m_IsExtendable = true
        };

        public static void Add() {
            // Air Blast
            var IsekaiAirBlastBase = CreatePhysicalBlastAbility("IsekaiAirBlastBase", bp => {
                bp.m_DisplayName = AirBlastAbility.m_DisplayName;
                bp.m_Description = AirBlastAbility.m_Description;
                bp.m_Icon = AirBlastAbility.m_Icon;
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.CachedDamageInfo = new List<AbilityKineticist.DamageInfo>();
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AvailableMetamagic = AirBlastAbility.AvailableMetamagic;
            });
            var IsekaiAirBlastAbility = CreateAirBlastAbility("IsekaiAirBlastAbility", bp => {
                bp.m_DisplayName = AirBlastAbility.m_DisplayName;
                bp.m_Description = AirBlastAbility.m_Description;
                bp.m_Icon = AirBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfSingle<IsEqual>(c => {
                            c.FirstValue = new DeliverEffectLayer();
                            c.SecondValue = new IntConstant();
                        });
                        c.IfTrue = DealPhysicalBlastDamage(c => {
                            c.DamageType = BludgeoningDamage;
                        });
                        c.IfFalse = DealPhysicalBlastDamage(c => {
                            c.DamageType = BludgeoningDamage;
                            c.Half = true;
                        });
                    });
                });
                bp.AddComponent<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[] { WindProjectile00.ToReference<BlueprintProjectileReference>() };
                    c.m_Length = new Feet(0);
                    c.m_LineWidth = new Feet(5);
                    c.NeedAttackRoll = true;
                    c.m_Weapon = KineticBlastPhysicalWeapon.ToReference<BlueprintItemWeaponReference>();
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.CachedDamageInfo = PhysicalDamageCache(BludgeoningDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetEnemies = true;
                bp.ShouldTurnToTarget = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiAirBlastBase.ToReference<BlueprintAbilityReference>();
                bp.m_TargetMapObjects = true;
                bp.AvailableMetamagic = AirBlastAbility.AvailableMetamagic;
            });
            var IsekaiAirBlastCyclone = CreateAirBlastAbility("IsekaiAirBlastCyclone", bp => {
                bp.m_DisplayName = CycloneAirBlastAbility.m_DisplayName;
                bp.m_Description = CycloneAirBlastAbility.m_Description;
                bp.m_Icon = CycloneAirBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Reflex;
                    c.Actions = DealPhysicalBlastDamage(c => {
                        c.DamageType = BludgeoningDamage;
                        c.Half = true;
                        c.IsAoE = true;
                        c.HalfIfSaved = true;
                    });
                });
                bp.AddComponent<AbilityTargetsAround>(c => {
                    c.m_TargetType = TargetType.Any;
                    c.m_Radius = new Feet(20);
                    c.m_Condition = ActionFlow.EmptyCondition();
                    c.m_SpreadSpeed = new Feet(0);
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 3;
                    c.CachedDamageInfo = PhysicalDamageCache(BludgeoningDamage, true);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "2483780330931b64f97cbb6bb7cbd352" };
                });
                bp.Range = AbilityRange.Personal;
                bp.CanTargetSelf = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiAirBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = CycloneAirBlastAbility.AvailableMetamagic;
            });
            var IsekaiAirBlastExtendRange = CreateAirBlastAbility("IsekaiAirBlastExtendRange", bp => {
                bp.m_DisplayName = ExtendRangeAirBlastAbility.m_DisplayName;
                bp.m_Description = ExtendRangeAirBlastAbility.m_Description;
                bp.m_Icon = ExtendRangeAirBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfSingle<IsEqual>(c => {
                            c.FirstValue = new DeliverEffectLayer();
                            c.SecondValue = new IntConstant();
                        });
                        c.IfTrue = DealPhysicalBlastDamage(c => {
                            c.DamageType = BludgeoningDamage;
                        });
                        c.IfFalse = DealPhysicalBlastDamage(c => {
                            c.DamageType = BludgeoningDamage;
                            c.Half = true;
                        });
                    });
                });
                bp.AddComponent<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[] { WindProjectile00.ToReference<BlueprintProjectileReference>() };
                    c.m_Length = new Feet(0);
                    c.m_LineWidth = new Feet(5);
                    c.NeedAttackRoll = true;
                    c.m_Weapon = KineticBlastPhysicalWeapon.ToReference<BlueprintItemWeaponReference>();
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 1;
                    c.CachedDamageInfo = PhysicalDamageCache(BludgeoningDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.Range = AbilityRange.Long;
                bp.CanTargetEnemies = true;
                bp.ShouldTurnToTarget = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiAirBlastBase.ToReference<BlueprintAbilityReference>();
                bp.m_TargetMapObjects = true;
                bp.AvailableMetamagic = ExtendRangeAirBlastAbility.AvailableMetamagic;
            });
            var IsekaiAirBlastSpindle = CreateAirBlastAbility("IsekaiAirBlastSpindle", bp => {
                bp.m_DisplayName = SpindleAirBlastAbility.m_DisplayName;
                bp.m_Description = SpindleAirBlastAbility.m_Description;
                bp.m_Icon = SpindleAirBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Reflex;
                    c.Actions = ActionFlow.DoSingle<ContextActionConditionalSaved>(c => {
                        c.Succeed = ActionFlow.DoNothing();
                        c.Failed = DealPhysicalBlastDamage(c => {
                            c.DamageType = BludgeoningDamage;
                            c.Half = true;
                        });
                    });
                });
                bp.AddComponent<AbilityDeliverChain>(c => {
                    c.m_ProjectileFirst = WindProjectile00.ToReference<BlueprintProjectileReference>();
                    c.m_Projectile = WindProjectile00.ToReference<BlueprintProjectileReference>();
                    c.TargetsCount = Values.CreateContextRankValue(AbilityRankType.ProjectilesCount, 70);
                    c.Radius = new Feet(5);
                    c.m_Condition = ActionFlow.EmptyCondition();
                    c.m_TargetType = TargetType.Any;
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 2;
                    c.CachedDamageInfo = PhysicalDamageCache(BludgeoningDamage, true);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiAirBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = SpindleAirBlastAbility.AvailableMetamagic;
            });
            var IsekaiAirBlastTorrent = CreateAirBlastAbility("IsekaiAirBlastTorrent", bp => {
                bp.m_DisplayName = TorrentAirBlastAbility.m_DisplayName;
                bp.m_Description = TorrentAirBlastAbility.m_Description;
                bp.m_Icon = TorrentAirBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Reflex;
                    c.Actions = DealPhysicalBlastDamage(c => {
                        c.DamageType = BludgeoningDamage;
                        c.Half = true;
                        c.IsAoE = true;
                        c.HalfIfSaved = true;
                    });
                });
                bp.AddComponent<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[] { Kinetic_AirBlastLine00.ToReference<BlueprintProjectileReference>() };
                    c.Type = AbilityProjectileType.Line;
                    c.m_Length = new Feet(30);
                    c.m_LineWidth = new Feet(5);
                    c.NeedAttackRoll = true;
                    c.m_Weapon = KineticBlastPhysicalWeapon.ToReference<BlueprintItemWeaponReference>();
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 2;
                    c.CachedDamageInfo = PhysicalDamageCache(BludgeoningDamage, true);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiAirBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = TorrentAirBlastAbility.AvailableMetamagic;
            });
            var IsekaiAirBlastWallArea = CreatePhysicalAreaEffect("IsekaiAirBlastWallArea", bp => {
                bp.AddComponent<AbilityAreaEffectRunAction>(c => {
                    c.UnitEnter = DealPhysicalBlastDamage(c => {
                        c.DamageType = BludgeoningDamage;
                        c.Half = true;
                    });
                    c.UnitExit = ActionFlow.DoNothing();
                    c.UnitMove = ActionFlow.DoNothing();
                    c.Round = ActionFlow.DoNothing();
                });
                bp.Shape = AreaEffectShape.Wall;
                bp.Size = new Feet(60);
                bp.Fx = new PrefabLink() { AssetId = "4ffc8d2162a215e44a1a728752b762eb" };
            });
            var IsekaiAirBlastWall = CreateAirBlastAbility("IsekaiAirBlastWall", bp => {
                bp.m_DisplayName = WallAirBlastAbility.m_DisplayName;
                bp.m_Description = WallAirBlastAbility.m_Description;
                bp.m_Icon = WallAirBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<ContextActionSpawnAreaEffect>(c => {
                        c.m_AreaEffect = IsekaiAirBlastWallArea.ToReference<BlueprintAbilityAreaEffectReference>();
                        c.DurationValue = KineticAreaDuration;
                    });
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 3;
                    c.CachedDamageInfo = PhysicalDamageCache(BludgeoningDamage, true);
                    c.CachedDamageSource = IsekaiAirBlastWallArea.ToReference<AnyBlueprintReference>();
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiAirBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = WallAirBlastAbility.AvailableMetamagic;
            });
            var IsekaiAirBlastFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiAirBlastFeature", bp => {
                bp.SetName(IsekaiContext, "Air Avatar");
                bp.SetDescription(IsekaiContext, "You gain the ability to use air blast and all its associated form infusions. "
                    + "Your air blast deals bludgeoning damage equal to 1d6+1 + your Constitution modifier, increasing by 1d6+1 for every 2 character levels beyond 1st. "
                    + "The DC of your blast is 10 + 1/2 your character level + your Dexterity modifier.");
                bp.m_Icon = AirBlastAbility.m_Icon;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { IsekaiAirBlastBase.ToReference<BlueprintUnitFactReference>() };
                });
            });
            IsekaiAirBlastBase.AddComponent<AbilityVariants>(c => {
                c.m_Variants = new BlueprintAbilityReference[] {
                    IsekaiAirBlastAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiAirBlastCyclone.ToReference<BlueprintAbilityReference>(),
                    IsekaiAirBlastExtendRange.ToReference<BlueprintAbilityReference>(),
                    IsekaiAirBlastSpindle.ToReference<BlueprintAbilityReference>(),
                    IsekaiAirBlastTorrent.ToReference<BlueprintAbilityReference>(),
                    IsekaiAirBlastWall.ToReference<BlueprintAbilityReference>(),
                };
            });

            // Earth Blast
            var IsekaiEarthBlastBase = CreatePhysicalBlastAbility("IsekaiEarthBlastBase", bp => {
                bp.m_DisplayName = EarthBlastAbility.m_DisplayName;
                bp.m_Description = EarthBlastAbility.m_Description;
                bp.m_Icon = EarthBlastAbility.m_Icon;
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.CachedDamageInfo = new List<AbilityKineticist.DamageInfo>();
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AvailableMetamagic = EarthBlastAbility.AvailableMetamagic;
            });
            var IsekaiEarthBlastAbility = CreateEarthBlastAbility("IsekaiEarthBlastAbility", bp => {
                bp.m_DisplayName = EarthBlastAbility.m_DisplayName;
                bp.m_Description = EarthBlastAbility.m_Description;
                bp.m_Icon = EarthBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfSingle<IsEqual>(c => {
                            c.FirstValue = new DeliverEffectLayer();
                            c.SecondValue = new IntConstant();
                        });
                        c.IfTrue = DealPhysicalBlastDamage(c => {
                            c.DamageType = EarthDamage;
                        });
                        c.IfFalse = DealPhysicalBlastDamage(c => {
                            c.DamageType = EarthDamage;
                            c.Half = true;
                        });
                    });
                });
                bp.AddComponent<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[] { Kinetic_EarthBlast00_Projectile.ToReference<BlueprintProjectileReference>() };
                    c.m_Length = new Feet(0);
                    c.m_LineWidth = new Feet(5);
                    c.NeedAttackRoll = true;
                    c.m_Weapon = KineticBlastPhysicalWeapon.ToReference<BlueprintItemWeaponReference>();
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.CachedDamageInfo = PhysicalDamageCache(EarthDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetEnemies = true;
                bp.ShouldTurnToTarget = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiEarthBlastBase.ToReference<BlueprintAbilityReference>();
                bp.m_TargetMapObjects = true;
                bp.AvailableMetamagic = EarthBlastAbility.AvailableMetamagic;
            });
            var IsekaiEarthBlastDeadlyEarthArea = CreatePhysicalAreaEffect("IsekaiEarthBlastDeadlyEarthArea", bp => {
                bp.AddComponent<AbilityAreaEffectRunAction>(c => {
                    c.UnitEnter = DealPhysicalBlastDamage(c => {
                        c.DamageType = EarthDamage;
                        c.Half = true;
                    });
                    c.UnitExit = ActionFlow.DoNothing();
                    c.UnitMove = ActionFlow.DoNothing();
                    c.Round = DealPhysicalBlastDamage(c => {
                        c.DamageType = EarthDamage;
                        c.Half = true;
                    });
                });
                bp.AddComponent<AbilityAreaEffectBuff>(c => {
                    c.Condition = ActionFlow.EmptyCondition();
                    c.m_Buff = VolcanicStormDifficultTerrainBuff.ToReference<BlueprintBuffReference>();
                });
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet(20);
                bp.Fx = new PrefabLink() { AssetId = "11f5fe5f8ba029b49b5b04c40830e115" };
            });
            var IsekaiEarthBlastDeadlyEarth = CreateEarthBlastAbility("IsekaiEarthBlastDeadlyEarth", bp => {
                bp.m_DisplayName = DeadlyEarthEarthBlastAbility.m_DisplayName;
                bp.m_Description = DeadlyEarthEarthBlastAbility.m_Description;
                bp.m_Icon = DeadlyEarthEarthBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<ContextActionSpawnAreaEffect>(c => {
                        c.m_AreaEffect = IsekaiEarthBlastDeadlyEarthArea.ToReference<BlueprintAbilityAreaEffectReference>();
                        c.DurationValue = KineticAreaDuration;
                    });
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 4;
                    c.CachedDamageInfo = new List<AbilityKineticist.DamageInfo>() {
                        new AbilityKineticist.DamageInfo()
                        {
                            Value = PhysicalBlastDamage,
                            Type = EarthDamage,
                            Half = true
                        },
                        new AbilityKineticist.DamageInfo()
                        {
                            Value = PhysicalBlastDamage,
                            Type = EarthDamage,
                            Half = true
                        },
                    };
                    c.CachedDamageSource = IsekaiEarthBlastDeadlyEarthArea.ToReference<AnyBlueprintReference>();
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<AbilityAoERadius>(c => {
                    c.m_Radius = new Feet(20);
                    c.m_TargetType = TargetType.Any;
                });
                bp.Range = AbilityRange.Long;
                bp.CanTargetPoint = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiEarthBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = DeadlyEarthEarthBlastAbility.AvailableMetamagic;
            });
            var IsekaiEarthBlastExtendRange = CreateEarthBlastAbility("IsekaiEarthBlastExtendRange", bp => {
                bp.m_DisplayName = ExtendedRangeEarthBlastAbility.m_DisplayName;
                bp.m_Description = ExtendedRangeEarthBlastAbility.m_Description;
                bp.m_Icon = ExtendedRangeEarthBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfSingle<IsEqual>(c => {
                            c.FirstValue = new DeliverEffectLayer();
                            c.SecondValue = new IntConstant();
                        });
                        c.IfTrue = DealPhysicalBlastDamage(c => {
                            c.DamageType = EarthDamage;
                        });
                        c.IfFalse = DealPhysicalBlastDamage(c => {
                            c.DamageType = EarthDamage;
                            c.Half = true;
                        });
                    });
                });
                bp.AddComponent<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[] { Kinetic_EarthBlast00_Projectile.ToReference<BlueprintProjectileReference>() };
                    c.m_Length = new Feet(0);
                    c.m_LineWidth = new Feet(5);
                    c.NeedAttackRoll = true;
                    c.m_Weapon = KineticBlastPhysicalWeapon.ToReference<BlueprintItemWeaponReference>();
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 1;
                    c.CachedDamageInfo = PhysicalDamageCache(EarthDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.Range = AbilityRange.Long;
                bp.CanTargetEnemies = true;
                bp.ShouldTurnToTarget = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiEarthBlastBase.ToReference<BlueprintAbilityReference>();
                bp.m_TargetMapObjects = true;
                bp.AvailableMetamagic = ExtendedRangeEarthBlastAbility.AvailableMetamagic;
            });
            var IsekaiEarthBlastFragmentation = CreateEarthBlastAbility("IsekaiEarthBlastFragmentation", bp => {
                bp.m_DisplayName = FragmentationEarthBlastAbility.m_DisplayName;
                bp.m_Description = FragmentationEarthBlastAbility.m_Description;
                bp.m_Icon = FragmentationEarthBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfSingle<ContextConditionIsMainTarget>();
                        c.IfTrue = DealPhysicalBlastDamage(c => {
                            c.DamageType = EarthDamage;
                        });
                        c.IfFalse = ActionFlow.DoSingle<ContextActionSavingThrow>(c => {
                            c.Type = SavingThrowType.Reflex;
                            c.m_ConditionalDCIncrease = new ContextActionSavingThrow.ConditionalDCIncrease[0];
                            c.CustomDC = 0;
                            c.Actions = DealPhysicalBlastDamage(c => {
                                c.DamageType = EarthDamage;
                                c.Half = true;
                                c.IsAoE = true;
                                c.HalfIfSaved = true;
                            });
                        });
                    });
                });
                bp.AddComponent<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[] { Kinetic_EarthSphere00_Projectile.ToReference<BlueprintProjectileReference>() };
                    c.m_Length = new Feet(0);
                    c.m_LineWidth = new Feet(5);
                    c.NeedAttackRoll = true;
                    c.m_Weapon = KineticBlastPhysicalWeapon.ToReference<BlueprintItemWeaponReference>();
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 4;
                    c.CachedDamageInfo = new List<AbilityKineticist.DamageInfo>() {
                        new AbilityKineticist.DamageInfo()
                        {
                            Value = PhysicalBlastDamage,
                            Type = EarthDamage,
                        },
                        new AbilityKineticist.DamageInfo()
                        {
                            Value = PhysicalBlastDamage,
                            Type = EarthDamage,
                            Half = true
                        },
                    };
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<AbilityTargetsAround>(c => {
                    c.m_Radius = new Feet(20);
                    c.m_TargetType = TargetType.Any;
                    c.m_Condition = ActionFlow.EmptyCondition();
                    c.m_SpreadSpeed = new Feet(0);
                });
                bp.Range = AbilityRange.Long;
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiEarthBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = FragmentationEarthBlastAbility.AvailableMetamagic;
            });
            var IsekaiEarthBlastSpindle = CreateEarthBlastAbility("IsekaiEarthBlastSpindle", bp => {
                bp.m_DisplayName = SpindleEarthBlastAbility.m_DisplayName;
                bp.m_Description = SpindleEarthBlastAbility.m_Description;
                bp.m_Icon = SpindleEarthBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Reflex;
                    c.Actions = ActionFlow.DoSingle<ContextActionConditionalSaved>(c => {
                        c.Succeed = ActionFlow.DoNothing();
                        c.Failed = DealPhysicalBlastDamage(c => {
                            c.DamageType = EarthDamage;
                            c.Half = true;
                        });
                    });
                });
                bp.AddComponent<AbilityDeliverChain>(c => {
                    c.m_ProjectileFirst = Kinetic_EarthBlast00_Projectile.ToReference<BlueprintProjectileReference>();
                    c.m_Projectile = Kinetic_EarthBlast00_Projectile.ToReference<BlueprintProjectileReference>();
                    c.TargetsCount = Values.CreateContextRankValue(AbilityRankType.ProjectilesCount, 70);
                    c.Radius = new Feet(5);
                    c.m_Condition = ActionFlow.EmptyCondition();
                    c.m_TargetType = TargetType.Any;
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 2;
                    c.CachedDamageInfo = PhysicalDamageCache(EarthDamage, true);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiEarthBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = SpindleEarthBlastAbility.AvailableMetamagic;
            });
            var IsekaiEarthBlastWallArea = CreatePhysicalAreaEffect("IsekaiEarthBlastWallArea", bp => {
                bp.AddComponent<AbilityAreaEffectRunAction>(c => {
                    c.UnitEnter = DealPhysicalBlastDamage(c => {
                        c.DamageType = EarthDamage;
                        c.Half = true;
                    });
                    c.UnitExit = ActionFlow.DoNothing();
                    c.UnitMove = ActionFlow.DoNothing();
                    c.Round = ActionFlow.DoNothing();
                });
                bp.Shape = AreaEffectShape.Wall;
                bp.Size = new Feet(60);
                bp.Fx = new PrefabLink() { AssetId = "1f26aacd3ad314e4c820d4fe2ac3fd46" };
            });
            var IsekaiEarthBlastWall = CreateEarthBlastAbility("IsekaiEarthBlastWall", bp => {
                bp.m_DisplayName = WallEarthBlastAbility.m_DisplayName;
                bp.m_Description = WallEarthBlastAbility.m_Description;
                bp.m_Icon = WallEarthBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<ContextActionSpawnAreaEffect>(c => {
                        c.m_AreaEffect = IsekaiEarthBlastWallArea.ToReference<BlueprintAbilityAreaEffectReference>();
                        c.DurationValue = KineticAreaDuration;
                    });
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 3;
                    c.CachedDamageInfo = PhysicalDamageCache(EarthDamage, true);
                    c.CachedDamageSource = IsekaiEarthBlastWallArea.ToReference<AnyBlueprintReference>();
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiEarthBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = WallEarthBlastAbility.AvailableMetamagic;
            });
            var IsekaiEarthBlastFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiEarthBlastFeature", bp => {
                bp.SetName(IsekaiContext, "Earth Avatar");
                bp.SetDescription(IsekaiContext, "You gain the ability to use earth blast and all its associated form infusions. "
                    + "Your earth blast deals physical damage equal to 1d6+1 + your Constitution modifier, increasing by 1d6+1 for every 2 character levels beyond 1st. "
                    + "The DC of your blast is 10 + 1/2 your character level + your Dexterity modifier.");
                bp.m_Icon = EarthBlastAbility.m_Icon;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { IsekaiEarthBlastBase.ToReference<BlueprintUnitFactReference>() };
                });
            });
            IsekaiEarthBlastBase.AddComponent<AbilityVariants>(c => {
                c.m_Variants = new BlueprintAbilityReference[] {
                    IsekaiEarthBlastAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiEarthBlastDeadlyEarth.ToReference<BlueprintAbilityReference>(),
                    IsekaiEarthBlastExtendRange.ToReference<BlueprintAbilityReference>(),
                    IsekaiEarthBlastFragmentation.ToReference<BlueprintAbilityReference>(),
                    IsekaiEarthBlastSpindle.ToReference<BlueprintAbilityReference>(),
                    IsekaiEarthBlastWall.ToReference<BlueprintAbilityReference>(),
                };
            });

            // Fire Blast
            var IsekaiFireBlastBase = CreatePhysicalBlastAbility("IsekaiFireBlastBase", bp => {
                bp.m_DisplayName = FireBlastAbility.m_DisplayName;
                bp.m_Description = FireBlastAbility.m_Description;
                bp.m_Icon = FireBlastAbility.m_Icon;
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.CachedDamageInfo = new List<AbilityKineticist.DamageInfo>();
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Fire;
                });
                bp.CanTargetEnemies = true;
                bp.SpellResistance = true;
                bp.AvailableMetamagic = FireBlastAbility.AvailableMetamagic;
            });
            var IsekaiFireBlastAbility = CreateFireBlastAbility("IsekaiFireBlastAbility", bp => {
                bp.m_DisplayName = FireBlastAbility.m_DisplayName;
                bp.m_Description = FireBlastAbility.m_Description;
                bp.m_Icon = FireBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfSingle<IsEqual>(c => {
                            c.FirstValue = new DeliverEffectLayer();
                            c.SecondValue = new IntConstant();
                        });
                        c.IfTrue = DealEnergyBlastDamage(c => {
                            c.DamageType = FireDamage;
                        });
                        c.IfFalse = DealEnergyBlastDamage(c => {
                            c.DamageType = FireDamage;
                            c.Half = true;
                        });
                    });
                });
                bp.AddComponent<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[] { FireCommonProjectile00.ToReference<BlueprintProjectileReference>() };
                    c.m_Length = new Feet(0);
                    c.m_LineWidth = new Feet(5);
                    c.NeedAttackRoll = true;
                    c.m_Weapon = KineticBlastEnergyWeapon.ToReference<BlueprintItemWeaponReference>();
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.CachedDamageInfo = EnergyDamageCache(FireDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetEnemies = true;
                bp.ShouldTurnToTarget = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiFireBlastBase.ToReference<BlueprintAbilityReference>();
                bp.m_TargetMapObjects = true;
                bp.AvailableMetamagic = FireBlastAbility.AvailableMetamagic;
            });
            var IsekaiFireBlastDetonation = CreateFireBlastAbility("IsekaiFireBlastDetonation", bp => {
                bp.m_DisplayName = DetonationFireBlastAbility.m_DisplayName;
                bp.m_Description = DetonationFireBlastAbility.m_Description;
                bp.m_Icon = DetonationFireBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Reflex;
                    c.Actions = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfSingle<ContextConditionIsCaster>();
                        c.IfTrue = ActionFlow.DoNothing();
                        c.IfFalse = DealEnergyBlastDamage(c => {
                            c.DamageType = FireDamage;
                            c.IsAoE = true;
                            c.HalfIfSaved = true;
                        });
                    });
                });
                bp.AddComponent<AbilityTargetsAround>(c => {
                    c.m_TargetType = TargetType.Any;
                    c.m_Radius = new Feet(20);
                    c.m_Condition = ActionFlow.EmptyCondition();
                    c.m_SpreadSpeed = new Feet(0);
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "749ad3759dc93d64dba70a84d48135b5" };
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 3;
                    c.CachedDamageInfo = EnergyDamageCache(FireDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.Range = AbilityRange.Personal;
                bp.CanTargetEnemies = true;
                bp.CanTargetSelf = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiFireBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = DetonationFireBlastAbility.AvailableMetamagic;
            });
            var IsekaiFireBlastEruption = CreateFireBlastAbility("IsekaiFireBlastEruption", bp => {
                bp.m_DisplayName = EruptionFireBlastAbility.m_DisplayName;
                bp.m_Description = EruptionFireBlastAbility.m_Description;
                bp.m_Icon = EruptionFireBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Reflex;
                    c.Actions = DealEnergyBlastDamage(c => {
                        c.DamageType = FireDamage;
                        c.IsAoE = true;
                        c.HalfIfSaved = true;
                    });
                });
                bp.AddComponent<AbilityTargetsAround>(c => {
                    c.m_TargetType = TargetType.Any;
                    c.m_Radius = new Feet(10);
                    c.m_Condition = ActionFlow.EmptyCondition();
                    c.m_SpreadSpeed = new Feet(0);
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.Time = AbilitySpawnFxTime.OnPrecastStart;
                    c.Anchor = AbilitySpawnFxAnchor.Caster;
                    c.PrefabLink = new PrefabLink() { AssetId = "d45354c34bdaa254bb597ce5222f2973" };
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.Time = AbilitySpawnFxTime.OnStart;
                    c.Anchor = AbilitySpawnFxAnchor.Caster;
                    c.PrefabLink = new PrefabLink() { AssetId = "16e01c58cc00371448191803fc1e9368" };
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.Anchor = AbilitySpawnFxAnchor.ClickedTarget;
                    c.PrefabLink = new PrefabLink() { AssetId = "a4464254a634f9f41a91a37cb8ef48fd" };
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 2;
                    c.CachedDamageInfo = EnergyDamageCache(FireDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.Range = AbilityRange.Long;
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiFireBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = EruptionFireBlastAbility.AvailableMetamagic;
            });
            var IsekaiFireBlastExtendRange = CreateFireBlastAbility("IsekaiFireBlastExtendRange", bp => {
                bp.m_DisplayName = ExtendedRangeFireBlastAbility.m_DisplayName;
                bp.m_Description = ExtendedRangeFireBlastAbility.m_Description;
                bp.m_Icon = ExtendedRangeFireBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfSingle<IsEqual>(c => {
                            c.FirstValue = new DeliverEffectLayer();
                            c.SecondValue = new IntConstant();
                        });
                        c.IfTrue = DealEnergyBlastDamage(c => {
                            c.DamageType = FireDamage;
                        });
                        c.IfFalse = DealEnergyBlastDamage(c => {
                            c.DamageType = FireDamage;
                            c.Half = true;
                        });
                    });
                });
                bp.AddComponent<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[] { FireCommonProjectile00.ToReference<BlueprintProjectileReference>() };
                    c.m_Length = new Feet(0);
                    c.m_LineWidth = new Feet(5);
                    c.NeedAttackRoll = true;
                    c.m_Weapon = KineticBlastEnergyWeapon.ToReference<BlueprintItemWeaponReference>();
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 1;
                    c.CachedDamageInfo = EnergyDamageCache(FireDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.Range = AbilityRange.Long;
                bp.CanTargetEnemies = true;
                bp.ShouldTurnToTarget = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiFireBlastBase.ToReference<BlueprintAbilityReference>();
                bp.m_TargetMapObjects = true;
                bp.AvailableMetamagic = ExtendedRangeFireBlastAbility.AvailableMetamagic;
            });
            var IsekaiFireBlastFanOfFlames = CreateFireBlastAbility("IsekaiFireBlastFanOfFlames", bp => {
                bp.m_DisplayName = FanOfFlamesFireBlastAbility.m_DisplayName;
                bp.m_Description = FanOfFlamesFireBlastAbility.m_Description;
                bp.m_Icon = FanOfFlamesFireBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Reflex;
                    c.Actions = DealEnergyBlastDamage(c => {
                        c.DamageType = FireDamage;
                        c.IsAoE = true;
                        c.HalfIfSaved = true;
                    });
                });
                bp.AddComponent<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[] { FireCone15Feet00.ToReference<BlueprintProjectileReference>() };
                    c.Type = AbilityProjectileType.Cone;
                    c.m_Length = new Feet(15);
                    c.m_LineWidth = new Feet(5);
                    c.NeedAttackRoll = true;
                    c.m_Weapon = KineticBlastEnergyWeapon.ToReference<BlueprintItemWeaponReference>();
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 1;
                    c.CachedDamageInfo = EnergyDamageCache(FireDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.Range = AbilityRange.Projectile;
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiFireBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = FanOfFlamesFireBlastAbility.AvailableMetamagic;
            });
            var IsekaiFireBlastSpindle = CreateFireBlastAbility("IsekaiFireBlastSpindle", bp => {
                bp.m_DisplayName = SpindleFireBlastAbility.m_DisplayName;
                bp.m_Description = SpindleFireBlastAbility.m_Description;
                bp.m_Icon = SpindleFireBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Reflex;
                    c.Actions = ActionFlow.DoSingle<ContextActionConditionalSaved>(c => {
                        c.Succeed = ActionFlow.DoNothing();
                        c.Failed = DealEnergyBlastDamage(c => {
                            c.DamageType = FireDamage;
                        });
                    });
                });
                bp.AddComponent<AbilityDeliverChain>(c => {
                    c.m_ProjectileFirst = FireCommonProjectile00.ToReference<BlueprintProjectileReference>();
                    c.m_Projectile = FireCommonProjectile00.ToReference<BlueprintProjectileReference>();
                    c.TargetsCount = Values.CreateContextRankValue(AbilityRankType.ProjectilesCount, 70);
                    c.Radius = new Feet(5);
                    c.m_Condition = ActionFlow.EmptyCondition();
                    c.m_TargetType = TargetType.Any;
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 2;
                    c.CachedDamageInfo = EnergyDamageCache(FireDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiFireBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = SpindleFireBlastAbility.AvailableMetamagic;
            });
            var IsekaiFireBlastTorrent = CreateFireBlastAbility("IsekaiFireBlastTorrent", bp => {
                bp.m_DisplayName = TorrentFireBlastAbility.m_DisplayName;
                bp.m_Description = TorrentFireBlastAbility.m_Description;
                bp.m_Icon = TorrentFireBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Reflex;
                    c.Actions = DealEnergyBlastDamage(c => {
                        c.DamageType = FireDamage;
                        c.IsAoE = true;
                        c.HalfIfSaved = true;
                    });
                });
                bp.AddComponent<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[] { FireLine00_Head.ToReference<BlueprintProjectileReference>() };
                    c.Type = AbilityProjectileType.Line;
                    c.m_Length = new Feet(30);
                    c.m_LineWidth = new Feet(5);
                    c.NeedAttackRoll = true;
                    c.m_Weapon = KineticBlastEnergyWeapon.ToReference<BlueprintItemWeaponReference>();
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 2;
                    c.CachedDamageInfo = EnergyDamageCache(FireDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiFireBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = TorrentFireBlastAbility.AvailableMetamagic;
            });
            var IsekaiFireBlastWallArea = CreateEnergyAreaEffect("IsekaiFireBlastWallArea", bp => {
                bp.AddComponent<AbilityAreaEffectRunAction>(c => {
                    c.UnitEnter = DealEnergyBlastDamage(c => {
                        c.DamageType = FireDamage;
                    });
                    c.UnitExit = ActionFlow.DoNothing();
                    c.UnitMove = ActionFlow.DoNothing();
                    c.Round = ActionFlow.DoNothing();
                });
                bp.Shape = AreaEffectShape.Wall;
                bp.Size = new Feet(60);
                bp.Fx = new PrefabLink() { AssetId = "098a29fefbbc4564281afa5a6887cd2c" };
            });
            var IsekaiFireBlastWall = CreateFireBlastAbility("IsekaiFireBlastWall", bp => {
                bp.m_DisplayName = WallFireBlastAbility.m_DisplayName;
                bp.m_Description = WallFireBlastAbility.m_Description;
                bp.m_Icon = WallFireBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<ContextActionSpawnAreaEffect>(c => {
                        c.m_AreaEffect = IsekaiFireBlastWallArea.ToReference<BlueprintAbilityAreaEffectReference>();
                        c.DurationValue = KineticAreaDuration;
                    });
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 3;
                    c.CachedDamageInfo = EnergyDamageCache(FireDamage, false);
                    c.CachedDamageSource = IsekaiFireBlastWallArea.ToReference<AnyBlueprintReference>();
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiFireBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = WallFireBlastAbility.AvailableMetamagic;
            });
            var IsekaiFireBlastFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiFireBlastFeature", bp => {
                bp.SetName(IsekaiContext, "Fire Avatar");
                bp.SetDescription(IsekaiContext, "You gain the ability to use fire blast and all its associated form infusions. "
                    + "Your fire blast deals fire damage equal to 1d6 + 1/2 your Constitution modifier, increasing by 1d6 for every 2 character levels beyond 1st. "
                    + "The DC of your blast is 10 + 1/2 your character level + your Dexterity modifier.");
                bp.m_Icon = FireBlastAbility.m_Icon;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { IsekaiFireBlastBase.ToReference<BlueprintUnitFactReference>() };
                });
            });
            IsekaiFireBlastBase.AddComponent<AbilityVariants>(c => {
                c.m_Variants = new BlueprintAbilityReference[] {
                    IsekaiFireBlastAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiFireBlastDetonation.ToReference<BlueprintAbilityReference>(),
                    IsekaiFireBlastEruption.ToReference<BlueprintAbilityReference>(),
                    IsekaiFireBlastExtendRange.ToReference<BlueprintAbilityReference>(),
                    IsekaiFireBlastFanOfFlames.ToReference<BlueprintAbilityReference>(),
                    IsekaiFireBlastSpindle.ToReference<BlueprintAbilityReference>(),
                    IsekaiFireBlastTorrent.ToReference<BlueprintAbilityReference>(),
                    IsekaiFireBlastWall.ToReference<BlueprintAbilityReference>(),
                };
            });

            // Water Blast
            var IsekaiWaterBlastBase = CreatePhysicalBlastAbility("IsekaiWaterBlastBase", bp => {
                bp.m_DisplayName = WaterBlastAbility.m_DisplayName;
                bp.m_Description = WaterBlastAbility.m_Description;
                bp.m_Icon = WaterBlastAbility.m_Icon;
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.CachedDamageInfo = new List<AbilityKineticist.DamageInfo>();
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AvailableMetamagic = WaterBlastAbility.AvailableMetamagic;
            });
            var IsekaiWaterBlastAbility = CreateWaterBlastAbility("IsekaiWaterBlastAbility", bp => {
                bp.m_DisplayName = WaterBlastAbility.m_DisplayName;
                bp.m_Description = WaterBlastAbility.m_Description;
                bp.m_Icon = WaterBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfSingle<IsEqual>(c => {
                            c.FirstValue = new DeliverEffectLayer();
                            c.SecondValue = new IntConstant();
                        });
                        c.IfTrue = DealPhysicalBlastDamage(c => {
                            c.DamageType = BludgeoningDamage;
                        });
                        c.IfFalse = DealPhysicalBlastDamage(c => {
                            c.DamageType = BludgeoningDamage;
                            c.Half = true;
                        });
                    });
                });
                bp.AddComponent<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[] { Kinetic_WaterBlast00_Projectile.ToReference<BlueprintProjectileReference>() };
                    c.m_Length = new Feet(0);
                    c.m_LineWidth = new Feet(5);
                    c.NeedAttackRoll = true;
                    c.m_Weapon = KineticBlastPhysicalWeapon.ToReference<BlueprintItemWeaponReference>();
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.CachedDamageInfo = PhysicalDamageCache(BludgeoningDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetEnemies = true;
                bp.ShouldTurnToTarget = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiWaterBlastBase.ToReference<BlueprintAbilityReference>();
                bp.m_TargetMapObjects = true;
                bp.AvailableMetamagic = WaterBlastAbility.AvailableMetamagic;
            });
            var IsekaiWaterBlastExtendRange = CreateWaterBlastAbility("IsekaiWaterBlastExtendRange", bp => {
                bp.m_DisplayName = ExtendedRangeWaterBlastAbility.m_DisplayName;
                bp.m_Description = ExtendedRangeWaterBlastAbility.m_Description;
                bp.m_Icon = ExtendedRangeWaterBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfSingle<IsEqual>(c => {
                            c.FirstValue = new DeliverEffectLayer();
                            c.SecondValue = new IntConstant();
                        });
                        c.IfTrue = DealPhysicalBlastDamage(c => {
                            c.DamageType = BludgeoningDamage;
                        });
                        c.IfFalse = DealPhysicalBlastDamage(c => {
                            c.DamageType = BludgeoningDamage;
                            c.Half = true;
                        });
                    });
                });
                bp.AddComponent<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[] { Kinetic_WaterBlast00_Projectile.ToReference<BlueprintProjectileReference>() };
                    c.m_Length = new Feet(0);
                    c.m_LineWidth = new Feet(5);
                    c.NeedAttackRoll = true;
                    c.m_Weapon = KineticBlastPhysicalWeapon.ToReference<BlueprintItemWeaponReference>();
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 1;
                    c.CachedDamageInfo = PhysicalDamageCache(BludgeoningDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.Range = AbilityRange.Long;
                bp.CanTargetEnemies = true;
                bp.ShouldTurnToTarget = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiWaterBlastBase.ToReference<BlueprintAbilityReference>();
                bp.m_TargetMapObjects = true;
                bp.AvailableMetamagic = ExtendedRangeWaterBlastAbility.AvailableMetamagic;
            });
            var IsekaiWaterBlastSpindle = CreateWaterBlastAbility("IsekaiWaterBlastSpindle", bp => {
                bp.m_DisplayName = SpindleWaterBlastAbility.m_DisplayName;
                bp.m_Description = SpindleWaterBlastAbility.m_Description;
                bp.m_Icon = SpindleWaterBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Reflex;
                    c.Actions = ActionFlow.DoSingle<ContextActionConditionalSaved>(c => {
                        c.Succeed = ActionFlow.DoNothing();
                        c.Failed = DealPhysicalBlastDamage(c => {
                            c.DamageType = BludgeoningDamage;
                            c.Half = true;
                        });
                    });
                });
                bp.AddComponent<AbilityDeliverChain>(c => {
                    c.m_ProjectileFirst = Kinetic_WaterBlast00_Projectile.ToReference<BlueprintProjectileReference>();
                    c.m_Projectile = Kinetic_WaterBlast00_Projectile.ToReference<BlueprintProjectileReference>();
                    c.TargetsCount = Values.CreateContextRankValue(AbilityRankType.ProjectilesCount, 70);
                    c.Radius = new Feet(5);
                    c.m_Condition = ActionFlow.EmptyCondition();
                    c.m_TargetType = TargetType.Any;
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 2;
                    c.CachedDamageInfo = PhysicalDamageCache(BludgeoningDamage, true);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiWaterBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = SpindleWaterBlastAbility.AvailableMetamagic;
            });
            var IsekaiWaterBlastSpray = CreateWaterBlastAbility("IsekaiWaterBlastSpray", bp => {
                bp.m_DisplayName = SprayWaterBlastAbility.m_DisplayName;
                bp.m_Description = SprayWaterBlastAbility.m_Description;
                bp.m_Icon = SprayWaterBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Reflex;
                    c.Actions = ActionFlow.DoSingle<ContextActionConditionalSaved>(c => {
                        c.Succeed = ActionFlow.DoNothing();
                        c.Failed = DealPhysicalBlastDamage(c => {
                            c.DamageType = BludgeoningDamage;
                            c.Half = true;
                            c.IsAoE = true;
                            c.HalfIfSaved = true;
                        });
                    });
                });
                bp.AddComponent<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[] { Kinetic_WaterBlastCone00_30Feet_Aoe.ToReference<BlueprintProjectileReference>() };
                    c.Type = AbilityProjectileType.Cone;
                    c.m_Length = new Feet(30);
                    c.m_LineWidth = new Feet(5);
                    c.NeedAttackRoll = true;
                    c.m_Weapon = KineticBlastPhysicalWeapon.ToReference<BlueprintItemWeaponReference>();
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 2;
                    c.CachedDamageInfo = PhysicalDamageCache(BludgeoningDamage, true);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiWaterBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = SprayWaterBlastAbility.AvailableMetamagic;
            });
            var IsekaiWaterBlastTorrent = CreateWaterBlastAbility("IsekaiWaterBlastTorrent", bp => {
                bp.m_DisplayName = TorrentWaterBlastAbility.m_DisplayName;
                bp.m_Description = TorrentWaterBlastAbility.m_Description;
                bp.m_Icon = TorrentWaterBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Reflex;
                    c.Actions = DealPhysicalBlastDamage(c => {
                        c.DamageType = BludgeoningDamage;
                        c.Half = true;
                        c.IsAoE = true;
                        c.HalfIfSaved = true;
                    });
                });
                bp.AddComponent<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[] { Kinetic_WaterLine00.ToReference<BlueprintProjectileReference>() };
                    c.Type = AbilityProjectileType.Line;
                    c.m_Length = new Feet(30);
                    c.m_LineWidth = new Feet(5);
                    c.NeedAttackRoll = true;
                    c.m_Weapon = KineticBlastPhysicalWeapon.ToReference<BlueprintItemWeaponReference>();
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 2;
                    c.CachedDamageInfo = PhysicalDamageCache(BludgeoningDamage, true);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiWaterBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = TorrentWaterBlastAbility.AvailableMetamagic;
            });
            var IsekaiWaterBlastWallArea = CreatePhysicalAreaEffect("IsekaiWaterBlastWallArea", bp => {
                bp.AddComponent<AbilityAreaEffectRunAction>(c => {
                    c.UnitEnter = DealPhysicalBlastDamage(c => {
                        c.DamageType = BludgeoningDamage;
                        c.Half = true;
                    });
                    c.UnitExit = ActionFlow.DoNothing();
                    c.UnitMove = ActionFlow.DoNothing();
                    c.Round = ActionFlow.DoNothing();
                });
                bp.Shape = AreaEffectShape.Wall;
                bp.Size = new Feet(60);
                bp.Fx = new PrefabLink() { AssetId = "b4dedddd430fced45be3ae71dae8c2d8" };
            });
            var IsekaiWaterBlastWall = CreateWaterBlastAbility("IsekaiWaterBlastWall", bp => {
                bp.m_DisplayName = WallWaterBlastAbility.m_DisplayName;
                bp.m_Description = WallWaterBlastAbility.m_Description;
                bp.m_Icon = WallWaterBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<ContextActionSpawnAreaEffect>(c => {
                        c.m_AreaEffect = IsekaiWaterBlastWallArea.ToReference<BlueprintAbilityAreaEffectReference>();
                        c.DurationValue = KineticAreaDuration;
                    });
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 3;
                    c.CachedDamageInfo = PhysicalDamageCache(BludgeoningDamage, true);
                    c.CachedDamageSource = IsekaiWaterBlastWallArea.ToReference<AnyBlueprintReference>();
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiWaterBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = WallWaterBlastAbility.AvailableMetamagic;
            });
            var IsekaiWaterBlastFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiWaterBlastFeature", bp => {
                bp.SetName(IsekaiContext, "Water Avatar");
                bp.SetDescription(IsekaiContext, "You gain the ability to use water blast and all its associated form infusions. "
                    + "Your water blast deals bludgeoning damage equal to 1d6+1 + your Constitution modifier, increasing by 1d6+1 for every 2 character levels beyond 1st. "
                    + "The DC of your blast is 10 + 1/2 your character level + your Dexterity modifier.");
                bp.m_Icon = WaterBlastAbility.m_Icon;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { IsekaiWaterBlastBase.ToReference<BlueprintUnitFactReference>() };
                });
            });
            IsekaiWaterBlastBase.AddComponent<AbilityVariants>(c => {
                c.m_Variants = new BlueprintAbilityReference[] {
                    IsekaiWaterBlastAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiWaterBlastExtendRange.ToReference<BlueprintAbilityReference>(),
                    IsekaiWaterBlastSpindle.ToReference<BlueprintAbilityReference>(),
                    IsekaiWaterBlastSpray.ToReference<BlueprintAbilityReference>(),
                    IsekaiWaterBlastTorrent.ToReference<BlueprintAbilityReference>(),
                    IsekaiWaterBlastWall.ToReference<BlueprintAbilityReference>(),
                };
            });

            // Kinetic Power
            var KineticBlastProficiency = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "KineticBlastProficiency", bp => {
                bp.SetName(IsekaiContext, "Kinetic Blast Proficiency");
                bp.SetDescription(IsekaiContext, "You gain the proficiency with kinetic blasts.");
                bp.AddComponent<AddProficiencies>(c => {
                    c.ArmorProficiencies = new ArmorProficiencyGroup[0];
                    c.WeaponProficiencies = new WeaponCategory[] { WeaponCategory.KineticBlast };
                });
            });
            var KineticPowerBurnPerRoundResource = Helpers.CreateBlueprint<BlueprintAbilityResource>(IsekaiContext, "KineticPowerBurnPerRoundResource", bp => {
                bp.m_MaxAmount = new BlueprintAbilityResource.Amount {
                    BaseValue = 1,
                    IncreasedByLevel = true,
                    m_Class = new BlueprintCharacterClassReference[] { IsekaiProtagonistClass.GetReference() },
                    m_Archetypes = new BlueprintArchetypeReference[0],
                    LevelIncrease = 0,
                    IncreasedByLevelStartPlusDivStep = true,
                    StartingLevel = 6,
                    StartingIncrease = 1,
                    LevelStep = 3,
                    PerStepIncrease = 1,
                    MinClassLevelIncrease = 0,
                    m_ClassDiv = new BlueprintCharacterClassReference[] { IsekaiProtagonistClass.GetReference() },
                    m_ArchetypesDiv = new BlueprintArchetypeReference[0],
                    OtherClassesModifier = 0.0f,
                    IncreasedByStat = false,
                    ResourceBonusStat = StatType.Unknown,
                };
            });
            var KineticPowerBurn = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "KineticPowerBurn", bp => {
                bp.m_DisplayName = BurnFeature.m_DisplayName;
                bp.m_Description = BurnFeature.m_Description;
                bp.AddComponent<AddAbilityResources>(c => {
                    c.m_Resource = BurnResource.ToReference<BlueprintAbilityResourceReference>();
                });
                bp.AddComponent<AddKineticistPart>(c => {
                    c.m_Class = IsekaiProtagonistClass.GetReference();
                    c.MainStat = StatType.Constitution;
                    c.m_MaxBurn = BurnResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_MaxBurnPerRound = KineticPowerBurnPerRoundResource.ToReference<BlueprintAbilityResourceReference>();
                    c.m_GatherPowerAbility = GatherPower.ToReference<BlueprintAbilityReference>();
                    c.m_GatherPowerIncreaseFeature = GatherPowerFeature.ToReference<BlueprintFeatureReference>();
                    c.m_GatherPowerBuff1 = GatherPowerBuffI.ToReference<BlueprintBuffReference>();
                    c.m_GatherPowerBuff2 = GatherPowerBuffII.ToReference<BlueprintBuffReference>();
                    c.m_GatherPowerBuff3 = GatherPowerBuffIII.ToReference<BlueprintBuffReference>();
                    c.m_Blasts = new BlueprintAbilityReference[] {
                        IsekaiAirBlastBase.ToReference<BlueprintAbilityReference>(),
                        IsekaiEarthBlastBase.ToReference<BlueprintAbilityReference>(),
                        IsekaiFireBlastBase.ToReference<BlueprintAbilityReference>(),
                        IsekaiWaterBlastBase.ToReference<BlueprintAbilityReference>(),
                    };
                    c.m_BladeActivatedBuff = KineticBladeEnableBuff.ToReference<BlueprintBuffReference>();
                    c.m_CanGatherPowerWithShieldBuff = ElementalBastionBuff.ToReference<BlueprintBuffReference>();
                });
                bp.AddComponent<AddAbilityResources>(c => {
                    c.m_Resource = KineticPowerBurnPerRoundResource.ToReference<BlueprintAbilityResourceReference>();
                    c.RestoreOnLevelUp = true;
                });
                bp.AddComponent<AddKineticistBurnValueChangedTrigger>(c => {
                    c.Action = ActionFlow.DoSingle<ContextActionApplyBuff>(c => {
                        c.m_Buff = BurnEffectBuff.ToReference<BlueprintBuffReference>();
                        c.Permanent = true;
                        c.DurationValue = Values.Duration.Zero;
                        c.AsChild = true;
                    });
                });
            });
            var KineticPowerSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "KineticPowerSelection", bp => {
                bp.SetName(IsekaiContext, "Kinetic Power");
                bp.SetDescription(IsekaiContext, "You gain the ability to use a kinetic blast.\nWARNING: This is a deprecated feature and will be removed in version 5.0.0.");
                bp.m_Icon = Icon_InfusionSelection;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<ClassLevelsForPrerequisites>(c => {
                    c.m_FakeClass = KineticistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_ActualClass = IsekaiProtagonistClass.GetReference();
                    c.Modifier = 1.0;
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] {
                        KineticBlastProficiency.ToReference<BlueprintUnitFactReference>(),
                        KineticPowerBurn.ToReference<BlueprintUnitFactReference>(),
                        GatherPowerAbilitiesFeature.ToReference<BlueprintUnitFactReference>(),
                        DismissInfusionFeature.ToReference<BlueprintUnitFactReference>(),
                    };
                });

                // Add features later
                bp.m_Features = new BlueprintFeatureReference[0];
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    IsekaiAirBlastFeature.ToReference<BlueprintFeatureReference>(),
                    IsekaiEarthBlastFeature.ToReference<BlueprintFeatureReference>(),
                    IsekaiFireBlastFeature.ToReference<BlueprintFeatureReference>(),
                    IsekaiWaterBlastFeature.ToReference<BlueprintFeatureReference>(),
                };
            });

            PatchGatherPowerBuffs(IsekaiAirBlastFeature, IsekaiEarthBlastFeature, IsekaiFireBlastFeature, IsekaiWaterBlastFeature);

            SpecialPowerSelection.AddToSelection(KineticPowerSelection);
        }

        private static void PatchGatherPowerBuffs(BlueprintFeature airBlastFeature, BlueprintFeature earthBlastFeature, BlueprintFeature fireBlastFeature, BlueprintFeature waterBlastFeature) {
            BlueprintBuff[] buffs = new BlueprintBuff[] { GatherPowerBuffI, GatherPowerBuffII, GatherPowerBuffIII };
            foreach (BlueprintBuff buff in buffs) {
                var airConditional = (Conditional)buff.GetComponent<AddFactContextActions>().Activated.Actions[0];
                var airCondition = new ContextConditionHasFact() { m_Fact = airBlastFeature.ToReference<BlueprintUnitFactReference>() };
                airConditional.ConditionsChecker.Conditions = airConditional.ConditionsChecker.Conditions.AddToArray(airCondition);
                var earthConditional = (Conditional)buff.GetComponent<AddFactContextActions>().Activated.Actions[1];
                var earthCondition = new ContextConditionHasFact() { m_Fact = earthBlastFeature.ToReference<BlueprintUnitFactReference>() };
                earthConditional.ConditionsChecker.Conditions = earthConditional.ConditionsChecker.Conditions.AddToArray(earthCondition);
                var fireConditional = (Conditional)buff.GetComponent<AddFactContextActions>().Activated.Actions[2];
                var fireCondition = new ContextConditionHasFact() { m_Fact = fireBlastFeature.ToReference<BlueprintUnitFactReference>() };
                fireConditional.ConditionsChecker.Conditions = fireConditional.ConditionsChecker.Conditions.AddToArray(fireCondition);
                var waterConditional = (Conditional)buff.GetComponent<AddFactContextActions>().Activated.Actions[3];
                var waterCondition = new ContextConditionHasFact() { m_Fact = waterBlastFeature.ToReference<BlueprintUnitFactReference>() };
                waterConditional.ConditionsChecker.Conditions = waterConditional.ConditionsChecker.Conditions.AddToArray(waterCondition);
            }
        }

        private static BlueprintAbility CreatePhysicalBlastAbility(string name, Action<BlueprintAbility> init = null) {
            var result = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, name, bp => {
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.DamageDice;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.OnePlusDiv2;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.DamageBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.StatBonus;
                    c.m_Stat = StatType.Constitution;
                });
                bp.AddComponent<ContextCalculateSharedValue>(c => {
                    c.ValueType = AbilitySharedValue.Damage;
                    c.Value = new ContextDiceValue() {
                        DiceType = DiceType.One,
                        DiceCountValue = Values.CreateContextRankValue(AbilityRankType.DamageDice),
                        BonusValue = Values.CreateContextRankValue(AbilityRankType.DamageBonus)
                    };
                    c.Modifier = 1.0;
                });
                bp.AddComponent<ContextCalculateAbilityParams>(c => {
                    c.StatType = StatType.Dexterity;
                });
                bp.Type = AbilityType.Special;
                bp.Range = AbilityRange.Close;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Kineticist;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.LocalizedDuration = new LocalizedString();
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            init?.Invoke(result);
            return result;
        }

        private static BlueprintAbility CreateEnergyBlastAbility(string name, Action<BlueprintAbility> init = null) {
            var result = Helpers.CreateBlueprint<BlueprintAbility>(IsekaiContext, name, bp => {
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.DamageDice;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.OnePlusDiv2;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.DamageBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.StatBonus;
                    c.m_Progression = ContextRankProgression.Div2;
                    c.m_Stat = StatType.Constitution;
                });
                bp.AddComponent<ContextCalculateSharedValue>(c => {
                    c.ValueType = AbilitySharedValue.Damage;
                    c.Value = new ContextDiceValue() {
                        DiceType = DiceType.One,
                        DiceCountValue = Values.CreateContextRankValue(AbilityRankType.DamageDice),
                        BonusValue = Values.CreateContextRankValue(AbilityRankType.DamageBonus)
                    };
                    c.Modifier = 1.0;
                });
                bp.AddComponent<ContextCalculateAbilityParams>(c => {
                    c.StatType = StatType.Dexterity;
                });
                bp.Type = AbilityType.Special;
                bp.Range = AbilityRange.Close;
                bp.SpellResistance = true;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Kineticist;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.LocalizedDuration = new LocalizedString();
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            init?.Invoke(result);
            return result;
        }

        private static BlueprintAbility CreateAirBlastAbility(string name, Action<BlueprintAbility> init = null) {
            var result = CreatePhysicalBlastAbility(name, bp => {
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "a0b5b95a9a139944c965c593a0a77ff7" };
                    c.Time = AbilitySpawnFxTime.OnPrecastStart;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "4daa50efa21f9564fb3c5cd35d022cbf" };
                    c.Time = AbilitySpawnFxTime.OnStart;
                });
            });
            init?.Invoke(result);
            return result;
        }

        private static BlueprintAbility CreateEarthBlastAbility(string name, Action<BlueprintAbility> init = null) {
            var result = CreatePhysicalBlastAbility(name, bp => {
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "69a83b56c1265464f8626a2ab414364a" };
                    c.Time = AbilitySpawnFxTime.OnPrecastStart;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "852b687aad7863e438c61339dd35d85d" };
                    c.Time = AbilitySpawnFxTime.OnStart;
                });
            });
            init?.Invoke(result);
            return result;
        }

        private static BlueprintAbility CreateFireBlastAbility(string name, Action<BlueprintAbility> init = null) {
            var result = CreateEnergyBlastAbility(name, bp => {
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Fire;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "d45354c34bdaa254bb597ce5222f2973" };
                    c.Time = AbilitySpawnFxTime.OnPrecastStart;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "16e01c58cc00371448191803fc1e9368" };
                    c.Time = AbilitySpawnFxTime.OnStart;
                });
            });
            init?.Invoke(result);
            return result;
        }

        private static BlueprintAbility CreateWaterBlastAbility(string name, Action<BlueprintAbility> init = null) {
            var result = CreatePhysicalBlastAbility(name, bp => {
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "705bc7676de67a4449986d9c69876486" };
                    c.Time = AbilitySpawnFxTime.OnPrecastStart;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "e05061bbc743af545b923c88662c9e65" };
                    c.Time = AbilitySpawnFxTime.OnStart;
                });
            });
            init?.Invoke(result);
            return result;
        }

        private static BlueprintAbilityAreaEffect CreatePhysicalAreaEffect(string name, Action<BlueprintAbilityAreaEffect> init = null) {
            var t = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, name, bp => {
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.DamageDice;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.OnePlusDiv2;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.DamageBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.StatBonus;
                    c.m_Stat = StatType.Constitution;
                });
                bp.AddComponent<ContextCalculateSharedValue>(c => {
                    c.ValueType = AbilitySharedValue.Damage;
                    c.Value = new ContextDiceValue() {
                        DiceType = DiceType.One,
                        DiceCountValue = Values.CreateContextRankValue(AbilityRankType.DamageDice),
                        BonusValue = Values.CreateContextRankValue(AbilityRankType.DamageBonus)
                    };
                    c.Modifier = 1.0;
                });
                bp.AddComponent<ContextCalculateAbilityParams>(c => {
                    c.StatType = StatType.Dexterity;
                });
                bp.m_Tags = AreaEffectTags.DestroyableInCutscene;
                bp.AffectEnemies = true;
                bp.AggroEnemies = true;
            });
            init?.Invoke(t);
            return t;
        }

        private static BlueprintAbilityAreaEffect CreateEnergyAreaEffect(string name, Action<BlueprintAbilityAreaEffect> init = null) {
            var t = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(IsekaiContext, name, bp => {
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.DamageDice;
                    c.m_BaseValueType = ContextRankBaseValueType.CharacterLevel;
                    c.m_Progression = ContextRankProgression.OnePlusDiv2;
                });
                bp.AddComponent<ContextRankConfig>(c => {
                    c.m_Type = AbilityRankType.DamageBonus;
                    c.m_BaseValueType = ContextRankBaseValueType.StatBonus;
                    c.m_Progression = ContextRankProgression.Div2;
                    c.m_Stat = StatType.Constitution;
                });
                bp.AddComponent<ContextCalculateSharedValue>(c => {
                    c.ValueType = AbilitySharedValue.Damage;
                    c.Value = new ContextDiceValue() {
                        DiceType = DiceType.One,
                        DiceCountValue = Values.CreateContextRankValue(AbilityRankType.DamageDice),
                        BonusValue = Values.CreateContextRankValue(AbilityRankType.DamageBonus)
                    };
                    c.Modifier = 1.0;
                });
                bp.AddComponent<ContextCalculateAbilityParams>(c => {
                    c.StatType = StatType.Dexterity;
                });
                bp.m_Tags = AreaEffectTags.DestroyableInCutscene;
                bp.AffectEnemies = true;
                bp.AggroEnemies = true;
            });
            init?.Invoke(t);
            return t;
        }

        private static List<AbilityKineticist.DamageInfo> PhysicalDamageCache(DamageTypeDescription damageType, bool half) {
            return new List<AbilityKineticist.DamageInfo>()
            {
                new AbilityKineticist.DamageInfo()
                {
                    Value = PhysicalBlastDamage,
                    Type = damageType,
                    Half = half
                }
            };
        }

        private static List<AbilityKineticist.DamageInfo> EnergyDamageCache(DamageTypeDescription damageType, bool half) {
            return new List<AbilityKineticist.DamageInfo>()
            {
                new AbilityKineticist.DamageInfo()
                {
                    Value = EnergyBlastDamage,
                    Type = damageType,
                    Half = half
                }
            };
        }

        private static ActionList DealPhysicalBlastDamage(Action<ContextActionDealDamage> init = null) {
            var t = new ContextActionDealDamage() {
                m_Type = ContextActionDealDamage.Type.Damage,
                Duration = Values.Duration.Zero,
                Value = PhysicalBlastDamage,
                UseWeaponDamageModifiers = true
            };
            init?.Invoke(t);
            return Helpers.CreateActionList(t);
        }

        private static ActionList DealEnergyBlastDamage(Action<ContextActionDealDamage> init = null) {
            var t = new ContextActionDealDamage() {
                m_Type = ContextActionDealDamage.Type.Damage,
                Duration = Values.Duration.Zero,
                Value = EnergyBlastDamage,
                UseWeaponDamageModifiers = true
            };
            init?.Invoke(t);
            return Helpers.CreateActionList(t);
        }
    }
}