using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Extensions;
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
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CharacterDevelopment
{
    class KineticPower
    {
        // TODO: move to character development

        // Icons
        private static readonly Sprite Icon_InfusionSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("58d6f8e9eea63f6418b107ce64f315ea").m_Icon;

        // Kinetic Power Burn
        private static readonly BlueprintFeature BurnFeature = Resources.GetBlueprint<BlueprintFeature>("57e3577a0eb53294e9d7cc649d5239a3");
        private static readonly BlueprintAbilityResource BurnResource = Resources.GetBlueprint<BlueprintAbilityResource>("066ac4b762e32be4b953703174ed925c");
        private static readonly BlueprintBuff BurnEffectBuff = Resources.GetBlueprint<BlueprintBuff>("95b1c0d55f30996429a3a4eba4d2b4a6");
        private static readonly BlueprintAbility GatherPower = Resources.GetBlueprint<BlueprintAbility>("6dcbffb8012ba2a4cb4ac374a33e2d9a");
        private static readonly BlueprintFeature GatherPowerFeature = Resources.GetBlueprint<BlueprintFeature>("0601925a028b788469365d5f8f39e14a");
        private static readonly BlueprintBuff GatherPowerBuffI = Resources.GetBlueprint<BlueprintBuff>("e6b8b31e1f8c524458dc62e8a763cfb1");
        private static readonly BlueprintBuff GatherPowerBuffII = Resources.GetBlueprint<BlueprintBuff>("3a2bfdc8bf74c5c4aafb97591f6e4282");
        private static readonly BlueprintBuff GatherPowerBuffIII = Resources.GetBlueprint<BlueprintBuff>("82eb0c274eddd8849bb89a8e6dbc65f8");
        private static readonly BlueprintBuff KineticBladeEnableBuff = Resources.GetBlueprint<BlueprintBuff>("426a9c079ee7ac34aa8e0054f2218074");
        private static readonly BlueprintBuff ElementalBastionBuff = Resources.GetBlueprint<BlueprintBuff>("99953956704788444964899b5b8e96ab");
        private static readonly BlueprintAbility AirBlastBase = Resources.GetBlueprint<BlueprintAbility>("0ab1552e2ebdacf44bb7b20f5393366d");
        private static readonly BlueprintAbility BlizzardBlastBase = Resources.GetBlueprint<BlueprintAbility>("16617b8c20688e4438a803effeeee8a6");
        private static readonly BlueprintAbility BlueFlameBlastBase = Resources.GetBlueprint<BlueprintAbility>("d29186edb20be6449b23660b39435398");
        private static readonly BlueprintAbility ChargedWaterBlastBase = Resources.GetBlueprint<BlueprintAbility>("4e2e066dd4dc8de4d8281ed5b3f4acb6");
        private static readonly BlueprintAbility ColdBlastBase = Resources.GetBlueprint<BlueprintAbility>("7980e876b0749fc47ac49b9552e259c1");
        private static readonly BlueprintAbility EarthBlastBase = Resources.GetBlueprint<BlueprintAbility>("e53f34fb268a7964caf1566afb82dadd");
        private static readonly BlueprintAbility ElectricBlastBase = Resources.GetBlueprint<BlueprintAbility>("45eb571be891c4c4581b6fcddda72bcd");
        private static readonly BlueprintAbility FireBlastBase = Resources.GetBlueprint<BlueprintAbility>("83d5873f306ac954cad95b6aeeeb2d8c");
        private static readonly BlueprintAbility IceBlastBase = Resources.GetBlueprint<BlueprintAbility>("403bcf42f08ca70498432cf62abee434");
        private static readonly BlueprintAbility MagmaBlastBase = Resources.GetBlueprint<BlueprintAbility>("8c25f52fce5113a4491229fd1265fc3c");
        private static readonly BlueprintAbility MetalBlastBase = Resources.GetBlueprint<BlueprintAbility>("6276881783962284ea93298c1fe54c48");
        private static readonly BlueprintAbility MudBlastBase = Resources.GetBlueprint<BlueprintAbility>("e2610c88664e07343b4f3fb6336f210c");
        private static readonly BlueprintAbility PlasmaBlastBase = Resources.GetBlueprint<BlueprintAbility>("9afdc3eeca49c594aa7bf00e8e9803ac");
        private static readonly BlueprintAbility SandstormBlastBase = Resources.GetBlueprint<BlueprintAbility>("b93e1f0540a4fa3478a6b47ae3816f32");
        private static readonly BlueprintAbility SteamBlastBase = Resources.GetBlueprint<BlueprintAbility>("3baf01649a92ae640927b0f633db7c11");
        private static readonly BlueprintAbility ThunderstormBlastBase = Resources.GetBlueprint<BlueprintAbility>("b813ceb82d97eed4486ddd86d3f7771b");
        private static readonly BlueprintAbility WaterBlastBase = Resources.GetBlueprint<BlueprintAbility>("d663a8d40be1e57478f34d6477a67270");

        // Gather Power Buffs
        private static readonly BlueprintBuff GatherPowerAirBuff = Resources.GetBlueprint<BlueprintBuff>("633f147eb1567274e9ed4d4150d79d78");
        private static readonly BlueprintBuff GatherPowerEarthBuff = Resources.GetBlueprint<BlueprintBuff>("28a39fc406a974748bd70ce3908efe61");
        private static readonly BlueprintBuff GatherPowerFireBuff = Resources.GetBlueprint<BlueprintBuff>("3bcf793f91cbd104280efe590d6e4d0c");
        private static readonly BlueprintBuff GatherPowerWaterBuff = Resources.GetBlueprint<BlueprintBuff>("8a59a1b6f3db18e4d831623718706a03");
        private static readonly BlueprintBuff GatherPowerAirBuffEmpowered = Resources.GetBlueprint<BlueprintBuff>("0ddc64a1dc3bbf84c8d6aa33cf2b8607");
        private static readonly BlueprintBuff GatherPowerEarthBuffEmpowered = Resources.GetBlueprint<BlueprintBuff>("82e8e3115e95d064685acc3c75053174");
        private static readonly BlueprintBuff GatherPowerFireBuffEmpowered = Resources.GetBlueprint<BlueprintBuff>("63b8e8e8a453d874aa379428a089fc1f");
        private static readonly BlueprintBuff GatherPowerWaterBuffEmpowered = Resources.GetBlueprint<BlueprintBuff>("68c1e339205d6c14e902aeb4c7ee2d2c");

        // Kinetic Power Progression
        private static readonly BlueprintFeature SuperCharge = Resources.GetBlueprint<BlueprintFeature>("5a13756fb4be25f46951bc3f16448276");
        private static readonly BlueprintFeature DismissInfusionFeature = Resources.GetBlueprint<BlueprintFeature>("48bbbb16189443049663ca161bb3e338");
        private static readonly BlueprintFeature MetakinesisEmpowerFeature = Resources.GetBlueprint<BlueprintFeature>("70322f5a2a294e54a9552f77ee85b0a7");
        private static readonly BlueprintFeature MetakinesisMaximizedFeature = Resources.GetBlueprint<BlueprintFeature>("0306bc7c6930a5c4b879c7dea78208c2");
        private static readonly BlueprintFeature MetakinesisQuickenFeature = Resources.GetBlueprint<BlueprintFeature>("4bb9d2328a3fdca419243d6116b337ac");
        private static readonly BlueprintFeature GatherPowerAbilitiesFeature = Resources.GetBlueprint<BlueprintFeature>("71f526b1d4b50b94582b0b9cbe12b0e0");
        private static readonly BlueprintFeature ElementalOverflowBonusFeature = Resources.GetBlueprint<BlueprintFeature>("2496916d8465dbb4b9ddeafdf28c67d8");
        private static readonly BlueprintFeature CompositeBlastSpecialisation = Resources.GetBlueprint<BlueprintFeature>("df8897708983d4846871ca72c4cbfc52");
        private static readonly BlueprintFeatureSelection SecondaryElementalFocusSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("4204bc10b3d5db440b1f52f0c375848b");
        private static readonly BlueprintFeatureSelection ThirdElementalFocusSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("e2c1718828fc843479f18ab4d75ded86");
        private static readonly BlueprintFeatureSelection MetakinesisMaster = Resources.GetBlueprint<BlueprintFeatureSelection>("8c33002186eb2fd45a140eed1301e207");
        private static readonly BlueprintFeatureSelection ElementalFocusSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("1f3a15a3ae8a5524ab8b97f469bf4e3d");
        private static readonly BlueprintFeatureSelection WildTalentSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("5c883ae0cd6d7d5448b7a420f51f8459");
        private static readonly BlueprintProgression KineticBlastProgression = Resources.GetBlueprint<BlueprintProgression>("30a5b8cf728bd4a4d8d90fc4953e322e");
        private static readonly BlueprintProgression ElementalOverflowProgression = Resources.GetBlueprint<BlueprintProgression>("86beb0391653faf43aec60d5ec05b538");
        private static readonly BlueprintProgression InfusionSpecializationProgression = Resources.GetBlueprint<BlueprintProgression>("1f86ce843fbd2d548a8d88ea1b652452");


        // Kineticist Class
        private static readonly BlueprintCharacterClass KineticistClass = Resources.GetBlueprint<BlueprintCharacterClass>("42a455d9ec1ad924d889272429eb8391");

        // Kinetic Blasts
        private static readonly BlueprintAbility AirBlastAbility = Resources.GetBlueprint<BlueprintAbility>("31f668b12011e344aa542aa07ab6c8d9");
        private static readonly BlueprintAbility CycloneAirBlastAbility = Resources.GetBlueprint<BlueprintAbility>("9fbc4fe045472984aa4a2d15d88bdaf9");
        private static readonly BlueprintAbility ExtendRangeAirBlastAbility = Resources.GetBlueprint<BlueprintAbility>("cae4cb39eb87a5d47b8ff35fd948dc4f");
        private static readonly BlueprintAbility SpindleAirBlastAbility = Resources.GetBlueprint<BlueprintAbility>("a28e54e4e5fafd1449dd9e926be85160");
        private static readonly BlueprintAbility TorrentAirBlastAbility = Resources.GetBlueprint<BlueprintAbility>("51ede1faa3cdb3b47a46f7579ca02b0a");
        private static readonly BlueprintAbility WallAirBlastAbility = Resources.GetBlueprint<BlueprintAbility>("d0390bd9ff12cd242a40c384445546cd");

        private static readonly BlueprintAbility EarthBlastAbility = Resources.GetBlueprint<BlueprintAbility>("b28c336c10eb51c4a8ded0258d5742e1");
        private static readonly BlueprintAbility DeadlyEarthEarthBlastAbility = Resources.GetBlueprint<BlueprintAbility>("e29cf5372f89c40489227edc9ffc52be");
        private static readonly BlueprintAbility ExtendedRangeEarthBlastAbility = Resources.GetBlueprint<BlueprintAbility>("7d4712812818f094297f7d7920d130b1");
        private static readonly BlueprintAbility FragmentationEarthBlastAbility = Resources.GetBlueprint<BlueprintAbility>("d859e796f6177cf449679c677076c577");
        private static readonly BlueprintAbility SpindleEarthBlastAbility = Resources.GetBlueprint<BlueprintAbility>("44d37b2230390b24e8060fe821068984");
        private static readonly BlueprintAbility WallEarthBlastAbility = Resources.GetBlueprint<BlueprintAbility>("f493e7b18b2a22c438df7ced760dd5b0");

        private static readonly BlueprintAbility FireBlastAbility = Resources.GetBlueprint<BlueprintAbility>("7b4f0c9a06db79345b55c39b2d5fb510");
        private static readonly BlueprintAbility DetonationFireBlastAbility = Resources.GetBlueprint<BlueprintAbility>("d651db4ffb7441548a06b11de5f163a1");
        private static readonly BlueprintAbility EruptionFireBlastAbility = Resources.GetBlueprint<BlueprintAbility>("5b69fce8b7890de4b8b9ab973158fed8");
        private static readonly BlueprintAbility ExtendedRangeFireBlastAbility = Resources.GetBlueprint<BlueprintAbility>("7bc1270b5bb78834192215bc03f161cc");
        private static readonly BlueprintAbility FanOfFlamesFireBlastAbility = Resources.GetBlueprint<BlueprintAbility>("a240a6d61e1aee040bf7d132bfe1dc07");
        private static readonly BlueprintAbility SpindleFireBlastAbility = Resources.GetBlueprint<BlueprintAbility>("6f299bc4320299c49a291f43a667496d");
        private static readonly BlueprintAbility TorrentFireBlastAbility = Resources.GetBlueprint<BlueprintAbility>("5e4c7cb990de4034bbee9fb99be2e15d");
        private static readonly BlueprintAbility WallFireBlastAbility = Resources.GetBlueprint<BlueprintAbility>("19309b5551a28d74288f4b6f7d8d838d");


        private static readonly BlueprintAbility WaterBlastAbility = Resources.GetBlueprint<BlueprintAbility>("e3f41966c2d662a4e9582a0497621c46");

        // Projectiles
        private static readonly BlueprintProjectile WindProjectile00 = Resources.GetBlueprint<BlueprintProjectile>("e093b08cd4cafe946962b339faf2310a");
        private static readonly BlueprintProjectile Kinetic_AirBlastLine00 = Resources.GetBlueprint<BlueprintProjectile>("03689858955c6bf409be06f35f09946a");
        private static readonly BlueprintProjectile Kinetic_EarthBlast00_Projectile = Resources.GetBlueprint<BlueprintProjectile>("c28e153e8c212c1458ec2ee4092a794f");
        private static readonly BlueprintProjectile Kinetic_EarthSphere00_Projectile = Resources.GetBlueprint<BlueprintProjectile>("3751a263d0386ef45807e0111de1a5de");
        private static readonly BlueprintProjectile FireCommonProjectile00 = Resources.GetBlueprint<BlueprintProjectile>("30a5f408ea9d163418c86a7107fc4326");
        private static readonly BlueprintProjectile ArrowFire00 = Resources.GetBlueprint<BlueprintProjectile>("cd6fbf24b5f625245960c4b8e6f58292");
        private static readonly BlueprintProjectile FireLine00_Head = Resources.GetBlueprint<BlueprintProjectile>("7172842b720c3534897ebda2e0624c2d");
        private static readonly BlueprintProjectile FireCone15Feet00 = Resources.GetBlueprint<BlueprintProjectile>("6dfc5e4c7d9ae3048984744222dbd0fa");

        // Buffs
        private static readonly BlueprintBuff VolcanicStormDifficultTerrainBuff = Resources.GetBlueprint<BlueprintBuff>("fe21bf21c3182f743a964de5bcd2033e");

        // Weapon
        private static readonly BlueprintItemWeapon KineticBlastPhysicalWeapon = Resources.GetBlueprint<BlueprintItemWeapon>("65951e1195848844b8ab8f46d942f6e8");
        private static readonly BlueprintItemWeapon KineticBlastEnergyWeapon = Resources.GetBlueprint<BlueprintItemWeapon>("4d3265a5b9302ee4cab9c07adddb253f");

        // DLC3 Ricochet
        private static readonly BlueprintBuff DLC3_KineticRicochetBuff = Resources.GetBlueprint<BlueprintBuff>("5f7d567ae4054cc291e42fc43ef5a046");
        private static readonly BlueprintUnitProperty DLC3_KineticRicochetProperty = Resources.GetBlueprint<BlueprintUnitProperty>("4a18040254d040f78c298f10649eab71");

        private static readonly DamageTypeDescription AirDamage = new()
        {
            Type = DamageType.Physical,
            Common = new DamageTypeDescription.CommomData(),
            Physical = new DamageTypeDescription.PhysicalData() { Form = PhysicalDamageForm.Bludgeoning }
        };
        private static readonly DamageTypeDescription EarthDamage = new()
        {
            Type = DamageType.Physical,
            Common = new DamageTypeDescription.CommomData(),
            Physical = new DamageTypeDescription.PhysicalData()
            {
                Form = PhysicalDamageForm.Bludgeoning | PhysicalDamageForm.Piercing | PhysicalDamageForm.Slashing
            }
        };
        private static readonly DamageTypeDescription FireDamage = new()
        {
            Type = DamageType.Energy,
            Common = new DamageTypeDescription.CommomData(),
            Physical = new DamageTypeDescription.PhysicalData(),
            Energy = DamageEnergyType.Fire
        };
        private static readonly ContextDiceValue KineticBlastDamage = new()
        {
            DiceType = DiceType.D6,
            DiceCountValue = new ContextValue()
            {
                ValueType = ContextValueType.Rank,
                ValueRank = AbilityRankType.DamageDice
            },
            BonusValue = new ContextValue()
            {
                ValueType = ContextValueType.Shared,
                ValueRank = AbilityRankType.DamageBonus
            }
        };
        private static readonly ContextDurationValue KineticAreaDuration = new()
        {
            Rate = DurationRate.Rounds,
            DiceType = DiceType.Zero,
            DiceCountValue = 0,
            BonusValue = new ContextValue()
            {
                ValueType = ContextValueType.Rank,
                ValueRank = AbilityRankType.DamageBonus
            },
            m_IsExtendable = true
        };

        public static void Add()
        {
            // Air Blast
            var IsekaiAirBlastBase = CreateKineticBlastAbility("IsekaiAirBlastBase", bp => {
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
                        c.IfTrue = DealKineticBlastDamage(c => {
                            c.DamageType = AirDamage;
                        });
                        c.IfFalse = DealKineticBlastDamage(c => {
                            c.DamageType = AirDamage;
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
                    c.CachedDamageInfo = InfusionDamageCache(AirDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<AbilityDeliverRicochet>(c => {
                    c.m_Layer = 1;
                    c.m_BeforeCondition = ActionFlow.IfSingle<ContextConditionHasBuff>(c => {
                        c.m_Buff = DLC3_KineticRicochetBuff.ToReference<BlueprintBuffReference>();
                    });
                    c.m_Projectile = WindProjectile00.ToReference<BlueprintProjectileReference>();
                    c.TargetsCount = new ContextValue()
                    {
                        ValueType = ContextValueType.CasterCustomProperty,
                        m_CustomProperty = DLC3_KineticRicochetProperty.ToReference<BlueprintUnitPropertyReference>()
                    };
                    c.Radius = new Feet(10);
                    c.m_TargetCondition = ActionFlow.EmptyCondition();
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
                    c.Actions = DealKineticBlastDamage(c => {
                        c.DamageType = AirDamage;
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
                    c.CachedDamageInfo = InfusionDamageCache(AirDamage, true);
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
                        c.IfTrue = DealKineticBlastDamage(c => {
                            c.DamageType = AirDamage;
                        });
                        c.IfFalse = DealKineticBlastDamage(c => {
                            c.DamageType = AirDamage;
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
                    c.CachedDamageInfo = InfusionDamageCache(AirDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<AbilityDeliverRicochet>(c => {
                    c.m_Layer = 1;
                    c.m_BeforeCondition = ActionFlow.IfSingle<ContextConditionHasBuff>(c => {
                        c.m_Buff = DLC3_KineticRicochetBuff.ToReference<BlueprintBuffReference>();
                    });
                    c.m_Projectile = WindProjectile00.ToReference<BlueprintProjectileReference>();
                    c.TargetsCount = new ContextValue()
                    {
                        ValueType = ContextValueType.CasterCustomProperty,
                        m_CustomProperty = DLC3_KineticRicochetProperty.ToReference<BlueprintUnitPropertyReference>()
                    };
                    c.Radius = new Feet(10);
                    c.m_TargetCondition = ActionFlow.EmptyCondition();
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
                        c.Failed = DealKineticBlastDamage(c => {
                            c.DamageType = AirDamage;
                            c.Half = true;
                        });
                    });
                });
                bp.AddComponent<AbilityDeliverChain>(c => {
                    c.m_ProjectileFirst = WindProjectile00.ToReference<BlueprintProjectileReference>();
                    c.m_Projectile = WindProjectile00.ToReference<BlueprintProjectileReference>();
                    c.TargetsCount = new ContextValue()
                    {
                        Value = 70,
                        ValueRank = AbilityRankType.ProjectilesCount
                    };
                    c.Radius = new Feet(5);
                    c.m_Condition = ActionFlow.EmptyCondition();
                    c.m_TargetType = TargetType.Any;
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 2;
                    c.CachedDamageInfo = InfusionDamageCache(AirDamage, true);
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
                    c.Actions = DealKineticBlastDamage(c => {
                        c.DamageType = AirDamage;
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
                    c.CachedDamageInfo = InfusionDamageCache(AirDamage, true);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiAirBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = TorrentAirBlastAbility.AvailableMetamagic;
            });
            var IsekaiAirBlastWallArea = CreateKineticAreaEffect("IsekaiAirBlastWallArea", bp => {
                bp.AddComponent<AbilityAreaEffectRunAction>(c => {
                    c.UnitEnter = DealKineticBlastDamage(c => {
                        c.DamageType = AirDamage;
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
                    c.CachedDamageInfo = InfusionDamageCache(AirDamage, true);
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
            var IsekaiAirBlastFeature = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiAirBlastFeature", bp => {
                bp.SetName("Air Avatar");
                bp.SetDescription("You gain the ability to use air blast and all its associated form infusions. "
                    + "Your air blast deals bludgeoning damage equal to 1d6+1 + your Constitution modifier, increasing by 1d6+1 for every 2 character levels beyond 1st. "
                    + "The DC of your blast is 10 + 1/2 your character level + your Dexterity modifier.");
                bp.m_Icon = AirBlastAbility.m_Icon;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
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
            var IsekaiEarthBlastBase = CreateKineticBlastAbility("IsekaiEarthBlastBase", bp => {
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
                        c.IfTrue = DealKineticBlastDamage(c => {
                            c.DamageType = EarthDamage;
                        });
                        c.IfFalse = DealKineticBlastDamage(c => {
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
                    c.CachedDamageInfo = InfusionDamageCache(EarthDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<AbilityDeliverRicochet>(c => {
                    c.m_Layer = 1;
                    c.m_BeforeCondition = ActionFlow.IfSingle<ContextConditionHasBuff>(c => {
                        c.m_Buff = DLC3_KineticRicochetBuff.ToReference<BlueprintBuffReference>();
                    });
                    c.m_Projectile = Kinetic_EarthBlast00_Projectile.ToReference<BlueprintProjectileReference>();
                    c.TargetsCount = new ContextValue()
                    {
                        ValueType = ContextValueType.CasterCustomProperty,
                        m_CustomProperty = DLC3_KineticRicochetProperty.ToReference<BlueprintUnitPropertyReference>()
                    };
                    c.Radius = new Feet(10);
                    c.m_TargetCondition = ActionFlow.EmptyCondition();
                });
                bp.CanTargetEnemies = true;
                bp.ShouldTurnToTarget = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiEarthBlastBase.ToReference<BlueprintAbilityReference>();
                bp.m_TargetMapObjects = true;
                bp.AvailableMetamagic = EarthBlastAbility.AvailableMetamagic;
            });
            var IsekaiEarthBlastDeadlyEarthArea = CreateKineticAreaEffect("IsekaiEarthBlastDeadlyEarthArea", bp => {
                bp.AddComponent<AbilityAreaEffectRunAction>(c => {
                    c.UnitEnter = DealKineticBlastDamage(c => {
                        c.DamageType = EarthDamage;
                        c.Half = true;
                    });
                    c.UnitExit = ActionFlow.DoNothing();
                    c.UnitMove = ActionFlow.DoNothing();
                    c.Round = DealKineticBlastDamage(c => {
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
                            Value = KineticBlastDamage,
                            Type = EarthDamage,
                            Half = true
                        },
                        new AbilityKineticist.DamageInfo()
                        {
                            Value = KineticBlastDamage,
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
                        c.IfTrue = DealKineticBlastDamage(c => {
                            c.DamageType = EarthDamage;
                        });
                        c.IfFalse = DealKineticBlastDamage(c => {
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
                    c.CachedDamageInfo = InfusionDamageCache(EarthDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<AbilityDeliverRicochet>(c => {
                    c.m_Layer = 1;
                    c.m_BeforeCondition = ActionFlow.IfSingle<ContextConditionHasBuff>(c => {
                        c.m_Buff = DLC3_KineticRicochetBuff.ToReference<BlueprintBuffReference>();
                    });
                    c.m_Projectile = Kinetic_EarthBlast00_Projectile.ToReference<BlueprintProjectileReference>();
                    c.TargetsCount = new ContextValue()
                    {
                        ValueType = ContextValueType.CasterCustomProperty,
                        m_CustomProperty = DLC3_KineticRicochetProperty.ToReference<BlueprintUnitPropertyReference>()
                    };
                    c.Radius = new Feet(10);
                    c.m_TargetCondition = ActionFlow.EmptyCondition();
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
                        c.IfTrue = DealKineticBlastDamage(c => {
                            c.DamageType = EarthDamage;
                        });
                        c.IfFalse = ActionFlow.DoSingle<ContextActionSavingThrow>(c => {
                            c.Type = SavingThrowType.Reflex;
                            c.m_ConditionalDCIncrease = new ContextActionSavingThrow.ConditionalDCIncrease[0];
                            c.CustomDC = 0;
                            c.Actions = DealKineticBlastDamage(c => {
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
                            Value = KineticBlastDamage,
                            Type = EarthDamage,
                        },
                        new AbilityKineticist.DamageInfo()
                        {
                            Value = KineticBlastDamage,
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
                        c.Failed = DealKineticBlastDamage(c => {
                            c.DamageType = EarthDamage;
                            c.Half = true;
                        });
                    });
                });
                bp.AddComponent<AbilityDeliverChain>(c => {
                    c.m_ProjectileFirst = Kinetic_EarthBlast00_Projectile.ToReference<BlueprintProjectileReference>();
                    c.m_Projectile = Kinetic_EarthBlast00_Projectile.ToReference<BlueprintProjectileReference>();
                    c.TargetsCount = new ContextValue()
                    {
                        Value = 70,
                        ValueRank = AbilityRankType.ProjectilesCount
                    };
                    c.Radius = new Feet(5);
                    c.m_Condition = ActionFlow.EmptyCondition();
                    c.m_TargetType = TargetType.Any;
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 2;
                    c.CachedDamageInfo = InfusionDamageCache(EarthDamage, true);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiEarthBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = SpindleEarthBlastAbility.AvailableMetamagic;
            });
            var IsekaiEarthBlastWallArea = CreateKineticAreaEffect("IsekaiEarthBlastWallArea", bp => {
                bp.AddComponent<AbilityAreaEffectRunAction>(c => {
                    c.UnitEnter = DealKineticBlastDamage(c => {
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
                    c.CachedDamageInfo = InfusionDamageCache(EarthDamage, true);
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
            var IsekaiEarthBlastFeature = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiEarthBlastFeature", bp => {
                bp.SetName("Earth Avatar");
                bp.SetDescription("You gain the ability to use earth blast and all its associated form infusions. "
                    + "Your earth blast deals physical damage equal to 1d6+1 + your Constitution modifier, increasing by 1d6+1 for every 2 character levels beyond 1st. "
                    + "The DC of your blast is 10 + 1/2 your character level + your Dexterity modifier.");
                bp.m_Icon = EarthBlastAbility.m_Icon;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
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
            var IsekaiFireBlastBase = CreateKineticBlastAbility("IsekaiFireBlastBase", bp => {
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
                        c.IfTrue = DealKineticBlastDamage(c => {
                            c.DamageType = FireDamage;
                        });
                        c.IfFalse = DealKineticBlastDamage(c => {
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
                    c.CachedDamageInfo = InfusionDamageCache(FireDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<AbilityDeliverRicochet>(c => {
                    c.m_Layer = 1;
                    c.m_BeforeCondition = ActionFlow.IfSingle<ContextConditionHasBuff>(c => {
                        c.m_Buff = DLC3_KineticRicochetBuff.ToReference<BlueprintBuffReference>();
                    });
                    c.m_Projectile = ArrowFire00.ToReference<BlueprintProjectileReference>();
                    c.TargetsCount = new ContextValue()
                    {
                        ValueType = ContextValueType.CasterCustomProperty,
                        m_CustomProperty = DLC3_KineticRicochetProperty.ToReference<BlueprintUnitPropertyReference>()
                    };
                    c.Radius = new Feet(10);
                    c.m_TargetCondition = ActionFlow.EmptyCondition();
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
                        c.IfFalse = DealKineticBlastDamage(c => {
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
                    c.CachedDamageInfo = InfusionDamageCache(FireDamage, false);
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
                    c.Actions = DealKineticBlastDamage(c => {
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
                    c.PrefabLink = new PrefabLink() { AssetId = "a4464254a634f9f41a91a37cb8ef48fd" };
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 2;
                    c.CachedDamageInfo = InfusionDamageCache(FireDamage, false);
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
                        c.IfTrue = DealKineticBlastDamage(c => {
                            c.DamageType = FireDamage;
                        });
                        c.IfFalse = DealKineticBlastDamage(c => {
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
                    c.CachedDamageInfo = InfusionDamageCache(FireDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<AbilityDeliverRicochet>(c => {
                    c.m_Layer = 1;
                    c.m_BeforeCondition = ActionFlow.IfSingle<ContextConditionHasBuff>(c => {
                        c.m_Buff = DLC3_KineticRicochetBuff.ToReference<BlueprintBuffReference>();
                    });
                    c.m_Projectile = ArrowFire00.ToReference<BlueprintProjectileReference>();
                    c.TargetsCount = new ContextValue()
                    {
                        ValueType = ContextValueType.CasterCustomProperty,
                        m_CustomProperty = DLC3_KineticRicochetProperty.ToReference<BlueprintUnitPropertyReference>()
                    };
                    c.Radius = new Feet(10);
                    c.m_TargetCondition = ActionFlow.EmptyCondition();
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
                    c.Actions = DealKineticBlastDamage(c => {
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
                    c.CachedDamageInfo = InfusionDamageCache(FireDamage, false);
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
                        c.Failed = DealKineticBlastDamage(c => {
                            c.DamageType = FireDamage;
                        });
                    });
                });
                bp.AddComponent<AbilityDeliverChain>(c => {
                    c.m_ProjectileFirst = FireCommonProjectile00.ToReference<BlueprintProjectileReference>();
                    c.m_Projectile = FireCommonProjectile00.ToReference<BlueprintProjectileReference>();
                    c.TargetsCount = new ContextValue()
                    {
                        Value = 70,
                        ValueRank = AbilityRankType.ProjectilesCount
                    };
                    c.Radius = new Feet(5);
                    c.m_Condition = ActionFlow.EmptyCondition();
                    c.m_TargetType = TargetType.Any;
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 2;
                    c.CachedDamageInfo = InfusionDamageCache(FireDamage, false);
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
                    c.Actions = DealKineticBlastDamage(c => {
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
                    c.CachedDamageInfo = InfusionDamageCache(FireDamage, false);
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiFireBlastBase.ToReference<BlueprintAbilityReference>();
                bp.AvailableMetamagic = TorrentFireBlastAbility.AvailableMetamagic;
            });
            var IsekaiFireBlastWallArea = CreateKineticAreaEffect("IsekaiFireBlastWallArea", bp => {
                bp.AddComponent<AbilityAreaEffectRunAction>(c => {
                    c.UnitEnter = DealKineticBlastDamage(c => {
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
                    c.CachedDamageInfo = InfusionDamageCache(FireDamage, false);
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
            var IsekaiFireBlastFeature = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiFireBlastFeature", bp => {
                bp.SetName("Fire Avatar");
                bp.SetDescription("You gain the ability to use fire blast and all its associated form infusions. "
                    + "Your fire blast deals fire damage equal to 1d6+1 + your Constitution modifier, increasing by 1d6+1 for every 2 character levels beyond 1st. "
                    + "The DC of your blast is 10 + 1/2 your character level + your Dexterity modifier.");
                bp.m_Icon = FireBlastAbility.m_Icon;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
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


            var IsekaiWaterBlastFeature = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiWaterBlastFeature", bp => {
                bp.SetName("Water Avatar");
                bp.SetDescription("You gain the ability to use water blast and all its associated form infusions.");
                bp.m_Icon = WaterBlastAbility.m_Icon;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { IsekaiAirBlastBase.ToReference<BlueprintUnitFactReference>() }; // TODO: change to Water
                });
            });

            var KineticBlastProficiency = Helpers.CreateBlueprint<BlueprintFeature>("KineticBlastProficiency", bp => {
                bp.SetName("Kinetic Blast Proficiency");
                bp.SetDescription("You gain the proficiency with kinetic blasts.");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddProficiencies>(c => {
                    c.ArmorProficiencies = new ArmorProficiencyGroup[0];
                    c.WeaponProficiencies = new WeaponCategory[] { WeaponCategory.KineticBlast };
                });
            });
            var KineticPowerBurnPerRoundResource = Helpers.CreateBlueprint<BlueprintAbilityResource>("KineticPowerBurnPerRoundResource", bp => {
                    bp.m_MaxAmount = new BlueprintAbilityResource.Amount
                    {
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
            var KineticPowerBurn = Helpers.CreateBlueprint<BlueprintFeature>("KineticPowerBurn", bp => {
                bp.m_DisplayName = BurnFeature.m_DisplayName;
                bp.m_Description = BurnFeature.m_Description;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
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
                        IsekaiAirBlastBase.ToReference<BlueprintAbilityReference>(), // TODO: add other elements later
                        IsekaiEarthBlastBase.ToReference<BlueprintAbilityReference>(),
                        IsekaiFireBlastBase.ToReference<BlueprintAbilityReference>(),
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
                        c.DurationValue = Constants.ZeroDuration;
                        c.AsChild = true;
                    });
                });
            });
            var KineticPowerSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("KineticPowerSelection", bp => {
                bp.SetName("Kinetic Power");
                bp.SetDescription("You gain the ability to use a kinetic blast.");
                bp.m_Icon = Icon_InfusionSelection;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<ClassLevelsForPrerequisites>(c => {
                    c.m_FakeClass = KineticistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_ActualClass = IsekaiProtagonistClass.GetReference();
                    c.Modifier = 1.0;
                    c.Summand = 0;
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
                    IsekaiAirBlastFeature.ToReference<BlueprintFeatureReference>(), // TODO: add other elements
                    IsekaiEarthBlastFeature.ToReference<BlueprintFeatureReference>(),
                    IsekaiFireBlastFeature.ToReference<BlueprintFeatureReference>(),
                };
            });

            PatchGatherPowerBuffs(IsekaiAirBlastFeature, IsekaiEarthBlastFeature, IsekaiFireBlastFeature);

            CharacterDevelopmentSelection.AddToSelection(KineticPowerSelection);
        }
        private static void PatchGatherPowerBuffs(BlueprintFeature airBlastFeature, BlueprintFeature earthBlastFeature, BlueprintFeature fireBlastFeature)
        {
            BlueprintBuff[] buffs = new BlueprintBuff[] { GatherPowerBuffI, GatherPowerBuffII, GatherPowerBuffIII }; // TODO: patch other elements
            foreach(BlueprintBuff buff in buffs)
            {
                var airConditional = (Conditional)buff.GetComponent<AddFactContextActions>().Activated.Actions[0];
                var airCondition = new ContextConditionHasFact() { m_Fact = airBlastFeature.ToReference<BlueprintUnitFactReference>() };
                airConditional.ConditionsChecker.Conditions = airConditional.ConditionsChecker.Conditions.AddToArray(airCondition);
                var earthConditional = (Conditional)buff.GetComponent<AddFactContextActions>().Activated.Actions[1];
                var earthCondition = new ContextConditionHasFact() { m_Fact = earthBlastFeature.ToReference<BlueprintUnitFactReference>() };
                earthConditional.ConditionsChecker.Conditions = earthConditional.ConditionsChecker.Conditions.AddToArray(earthCondition);
                var fireConditional = (Conditional)buff.GetComponent<AddFactContextActions>().Activated.Actions[2];
                var fireCondition = new ContextConditionHasFact() { m_Fact = fireBlastFeature.ToReference<BlueprintUnitFactReference>() };
                fireConditional.ConditionsChecker.Conditions = fireConditional.ConditionsChecker.Conditions.AddToArray(fireCondition);
            }
        }
        private static BlueprintAbility CreateKineticBlastAbility(string name, Action<BlueprintAbility> init = null)
        {
            var result = Helpers.CreateBlueprint<BlueprintAbility>(name, bp => {
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
                    c.Value = new ContextDiceValue()
                    {
                        DiceType = DiceType.One,
                        DiceCountValue = new ContextValue()
                        {
                            ValueType = ContextValueType.Rank,
                            ValueRank = AbilityRankType.DamageDice
                        },
                        BonusValue = new ContextValue()
                        {
                            ValueType = ContextValueType.Rank,
                            ValueRank = AbilityRankType.DamageBonus
                        }
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
        private static BlueprintAbility CreateAirBlastAbility(string name, Action<BlueprintAbility> init = null)
        {
            var result = CreateKineticBlastAbility(name, bp => {
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
        private static BlueprintAbility CreateEarthBlastAbility(string name, Action<BlueprintAbility> init = null)
        {
            var result = CreateKineticBlastAbility(name, bp => {
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
        private static BlueprintAbility CreateFireBlastAbility(string name, Action<BlueprintAbility> init = null)
        {
            var result = CreateKineticBlastAbility(name, bp => {
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
                bp.SpellResistance = true;
            });
            init?.Invoke(result);
            return result;
        }
        private static BlueprintAbilityAreaEffect CreateKineticAreaEffect(string name, Action<BlueprintAbilityAreaEffect> init = null)
        {
            var t = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(name, bp => {
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
                    c.Value = new ContextDiceValue()
                    {
                        DiceType = DiceType.One,
                        DiceCountValue = new ContextValue()
                        {
                            ValueType = ContextValueType.Rank,
                            ValueRank = AbilityRankType.DamageDice
                        },
                        BonusValue = new ContextValue()
                        {
                            ValueType = ContextValueType.Rank,
                            ValueRank = AbilityRankType.DamageBonus
                        }
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
        private static List<AbilityKineticist.DamageInfo> InfusionDamageCache(DamageTypeDescription damageType, bool half)
        {
            return new List<AbilityKineticist.DamageInfo>()
            {
                new AbilityKineticist.DamageInfo()
                {
                    Value = KineticBlastDamage,
                    Type = damageType,
                    Half = half
                }
            };
        }
        private static ActionList DealKineticBlastDamage(Action<ContextActionDealDamage> init = null)
        {
            var t = new ContextActionDealDamage()
            {
                m_Type = ContextActionDealDamage.Type.Damage,
                Duration = Constants.ZeroDuration,
                Value = KineticBlastDamage,
                UseWeaponDamageModifiers = true
            };
            init?.Invoke(t);
            return Helpers.CreateActionList(t);
        }
    }
}
