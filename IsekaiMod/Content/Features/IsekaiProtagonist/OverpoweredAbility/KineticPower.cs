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
using System.Collections.Generic;
using UnityEngine;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class KineticPower
    {
        // TODO: Fix gather power fx (replace gatherpowerbuff 1 2 and 3)
        // TODO: Fix DC of kineticist blasts/infusions
        // TODO: Fix ability parameters calculated based on kineticist class.
        // TODO: rework progression into archetype. progression is broken if not taken at level 1

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


        private static readonly BlueprintFeature WallInfusion = Resources.GetBlueprint<BlueprintFeature>("c684335918896ce4ab13e96cec929796");

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
        private static readonly BlueprintAbility FireBlastAbility = Resources.GetBlueprint<BlueprintAbility>("7b4f0c9a06db79345b55c39b2d5fb510");
        private static readonly BlueprintAbility WaterBlastAbility = Resources.GetBlueprint<BlueprintAbility>("e3f41966c2d662a4e9582a0497621c46");

        // Projectiles
        private static readonly BlueprintProjectile WindProjectile00 = Resources.GetBlueprint<BlueprintProjectile>("e093b08cd4cafe946962b339faf2310a");
        private static readonly BlueprintProjectile Kinetic_AirBlastLine00 = Resources.GetBlueprint<BlueprintProjectile>("03689858955c6bf409be06f35f09946a");

        // Area Effects
        private static readonly BlueprintAbilityAreaEffect WallAirBlastArea = Resources.GetBlueprint<BlueprintAbilityAreaEffect>("2a90aa7f771677b4e9624fa77697fdc6");

        // Weapon
        private static readonly BlueprintItemWeapon KineticBlastPhysicalWeapon = Resources.GetBlueprint<BlueprintItemWeapon>("65951e1195848844b8ab8f46d942f6e8");

        // DLC3 Ricochet
        private static readonly BlueprintBuff DLC3_KineticRicochetBuff = Resources.GetBlueprint<BlueprintBuff>("5f7d567ae4054cc291e42fc43ef5a046");
        private static readonly BlueprintUnitProperty DLC3_KineticRicochetProperty = Resources.GetBlueprint<BlueprintUnitProperty>("4a18040254d040f78c298f10649eab71");

        public static void Add()
        {
            // Air Blast
            var IsekaiAirBlastBase = Helpers.CreateBlueprint<BlueprintAbility>("IsekaiAirBlastBase", bp => {
                bp.m_DisplayName = AirBlastAbility.m_DisplayName;
                bp.m_Description = AirBlastAbility.m_Description;
                bp.m_Icon = AirBlastAbility.m_Icon;
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
                    c.StatType = StatType.Constitution;
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.CachedDamageInfo = new List<AbilityKineticist.DamageInfo>();
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.Type = AbilityType.Special;
                bp.Range = AbilityRange.Close;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Kineticist;
                bp.AvailableMetamagic = AirBlastAbility.AvailableMetamagic;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.LocalizedDuration = new LocalizedString();
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            var IsekaiAirBlastAbility = Helpers.CreateBlueprint<BlueprintAbility>("IsekaiAirBlastAbility", bp => {
                bp.m_DisplayName = AirBlastAbility.m_DisplayName;
                bp.m_Description = AirBlastAbility.m_Description;
                bp.m_Icon = AirBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfSingle<IsEqual>(c => {
                            c.FirstValue = new DeliverEffectLayer();
                            c.SecondValue = new IntConstant();
                        });
                        c.IfTrue = ActionFlow.DoSingle<ContextActionDealDamage>(c => {
                            c.m_Type = ContextActionDealDamage.Type.Damage;
                            c.DamageType = new DamageTypeDescription()
                            {
                                Type = DamageType.Physical,
                                Common = new DamageTypeDescription.CommomData(),
                                Physical = new DamageTypeDescription.PhysicalData() { Form = PhysicalDamageForm.Bludgeoning }
                            };
                            c.Duration = new ContextDurationValue()
                            {
                                DiceType = DiceType.Zero,
                                DiceCountValue = 0,
                                BonusValue = 0,
                                m_IsExtendable = true,
                            };
                            c.Value = new ContextDiceValue()
                            {
                                DiceType = DiceType.D6,
                                DiceCountValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Rank,
                                    ValueRank = AbilityRankType.DamageDice
                                },
                                BonusValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Shared
                                }
                            };
                            c.UseWeaponDamageModifiers = true;
                        });
                        c.IfFalse = ActionFlow.DoSingle<ContextActionDealDamage>(c => {
                            c.m_Type = ContextActionDealDamage.Type.Damage;
                            c.DamageType = new DamageTypeDescription()
                            {
                                Type = DamageType.Physical,
                                Common = new DamageTypeDescription.CommomData(),
                                Physical = new DamageTypeDescription.PhysicalData() { Form = PhysicalDamageForm.Bludgeoning }
                            };
                            c.Duration = new ContextDurationValue()
                            {
                                DiceType = DiceType.Zero,
                                DiceCountValue = 0,
                                BonusValue = 0,
                                m_IsExtendable = true,
                            };
                            c.Value = new ContextDiceValue()
                            {
                                DiceType = DiceType.D6,
                                DiceCountValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Rank,
                                    ValueRank = AbilityRankType.DamageDice
                                },
                                BonusValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Shared
                                }
                            };
                            c.Half = true;
                            c.UseWeaponDamageModifiers = true;
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
                    c.StatType = StatType.Constitution;
                });
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.CachedDamageInfo = new List<AbilityKineticist.DamageInfo>() {
                        new AbilityKineticist.DamageInfo()
                        {
                            Value = new ContextDiceValue()
                            {
                                DiceType = DiceType.D6,
                                DiceCountValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Rank,
                                    ValueRank = AbilityRankType.DamageDice
                                },
                                BonusValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Shared
                                }
                            },
                            Type = new DamageTypeDescription()
                            {
                                Type = DamageType.Physical,
                                Common = new DamageTypeDescription.CommomData(),
                                Physical = new DamageTypeDescription.PhysicalData() { Form = PhysicalDamageForm.Bludgeoning }
                            }
                        }
                    };
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "a0b5b95a9a139944c965c593a0a77ff7" };
                    c.Time = AbilitySpawnFxTime.OnPrecastStart;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "4daa50efa21f9564fb3c5cd35d022cbf" };
                    c.Time = AbilitySpawnFxTime.OnStart;
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
                bp.Type = AbilityType.Special;
                bp.Range = AbilityRange.Close;
                bp.CanTargetEnemies = true;
                bp.ShouldTurnToTarget = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiAirBlastBase.ToReference<BlueprintAbilityReference>();
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Kineticist;
                bp.m_TargetMapObjects = true;
                bp.AvailableMetamagic = AirBlastAbility.AvailableMetamagic;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.LocalizedDuration = new LocalizedString();
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            var IsekaiAirBlastCyclone = Helpers.CreateBlueprint<BlueprintAbility>("IsekaiAirBlastCyclone", bp => {
                bp.m_DisplayName = CycloneAirBlastAbility.m_DisplayName;
                bp.m_Description = CycloneAirBlastAbility.m_Description;
                bp.m_Icon = CycloneAirBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Reflex;
                    c.Actions = ActionFlow.DoSingle<ContextActionDealDamage>(c => {
                        c.m_Type = ContextActionDealDamage.Type.Damage;
                        c.DamageType = new DamageTypeDescription()
                        {
                            Type = DamageType.Physical,
                            Common = new DamageTypeDescription.CommomData(),
                            Physical = new DamageTypeDescription.PhysicalData() { Form = PhysicalDamageForm.Bludgeoning }
                        };
                        c.Duration = new ContextDurationValue()
                        {
                            DiceType = DiceType.Zero,
                            DiceCountValue = 0,
                            BonusValue = 0,
                            m_IsExtendable = true,
                        };
                        c.Value = new ContextDiceValue()
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
                        c.Half = true;
                        c.IsAoE = true;
                        c.HalfIfSaved = true;
                        c.UseWeaponDamageModifiers = true;
                    });
                });
                bp.AddComponent<AbilityTargetsAround>(c => {
                    c.m_Radius = new Feet(20);
                    c.m_Condition = ActionFlow.EmptyCondition();
                    c.m_SpreadSpeed = new Feet(0);
                });
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
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 3;
                    c.CachedDamageInfo = new List<AbilityKineticist.DamageInfo>() {
                        new AbilityKineticist.DamageInfo()
                        {
                            Value = new ContextDiceValue()
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
                            },
                            Type = new DamageTypeDescription()
                            {
                                Type = DamageType.Physical,
                                Common = new DamageTypeDescription.CommomData(),
                                Physical = new DamageTypeDescription.PhysicalData() { Form = PhysicalDamageForm.Bludgeoning }
                            },
                            Half = true
                        }
                    };
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "2483780330931b64f97cbb6bb7cbd352" };
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "a0b5b95a9a139944c965c593a0a77ff7" };
                    c.Time = AbilitySpawnFxTime.OnPrecastStart;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "4daa50efa21f9564fb3c5cd35d022cbf" };
                    c.Time = AbilitySpawnFxTime.OnStart;
                });
                bp.Type = AbilityType.Special;
                bp.Range = AbilityRange.Personal;
                bp.CanTargetSelf = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiAirBlastBase.ToReference<BlueprintAbilityReference>();
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Kineticist;
                bp.AvailableMetamagic = CycloneAirBlastAbility.AvailableMetamagic;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.LocalizedDuration = new LocalizedString();
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            var IsekaiAirBlastExtendRange = Helpers.CreateBlueprint<BlueprintAbility>("IsekaiAirBlastExtendRange", bp => {
                bp.m_DisplayName = ExtendRangeAirBlastAbility.m_DisplayName;
                bp.m_Description = ExtendRangeAirBlastAbility.m_Description;
                bp.m_Icon = ExtendRangeAirBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.Actions = ActionFlow.DoSingle<Conditional>(c => {
                        c.ConditionsChecker = ActionFlow.IfSingle<IsEqual>(c => {
                            c.FirstValue = new DeliverEffectLayer();
                            c.SecondValue = new IntConstant();
                        });
                        c.IfTrue = ActionFlow.DoSingle<ContextActionDealDamage>(c => {
                            c.m_Type = ContextActionDealDamage.Type.Damage;
                            c.DamageType = new DamageTypeDescription()
                            {
                                Type = DamageType.Physical,
                                Common = new DamageTypeDescription.CommomData(),
                                Physical = new DamageTypeDescription.PhysicalData() { Form = PhysicalDamageForm.Bludgeoning }
                            };
                            c.Duration = new ContextDurationValue()
                            {
                                DiceType = DiceType.Zero,
                                DiceCountValue = 0,
                                BonusValue = 0,
                                m_IsExtendable = true,
                            };
                            c.Value = new ContextDiceValue()
                            {
                                DiceType = DiceType.D6,
                                DiceCountValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Rank,
                                    ValueRank = AbilityRankType.DamageDice
                                },
                                BonusValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Shared
                                }
                            };
                            c.UseWeaponDamageModifiers = true;
                        });
                        c.IfFalse = ActionFlow.DoSingle<ContextActionDealDamage>(c => {
                            c.m_Type = ContextActionDealDamage.Type.Damage;
                            c.DamageType = new DamageTypeDescription()
                            {
                                Type = DamageType.Physical,
                                Common = new DamageTypeDescription.CommomData(),
                                Physical = new DamageTypeDescription.PhysicalData() { Form = PhysicalDamageForm.Bludgeoning }
                            };
                            c.Duration = new ContextDurationValue()
                            {
                                DiceType = DiceType.Zero,
                                DiceCountValue = 0,
                                BonusValue = 0,
                                m_IsExtendable = true,
                            };
                            c.Value = new ContextDiceValue()
                            {
                                DiceType = DiceType.D6,
                                DiceCountValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Rank,
                                    ValueRank = AbilityRankType.DamageDice
                                },
                                BonusValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Shared
                                }
                            };
                            c.Half = true;
                            c.UseWeaponDamageModifiers = true;
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
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 1;
                    c.CachedDamageInfo = new List<AbilityKineticist.DamageInfo>() {
                        new AbilityKineticist.DamageInfo()
                        {
                            Value = new ContextDiceValue()
                            {
                                DiceType = DiceType.D6,
                                DiceCountValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Rank,
                                    ValueRank = AbilityRankType.DamageDice
                                },
                                BonusValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Shared
                                }
                            },
                            Type = new DamageTypeDescription()
                            {
                                Type = DamageType.Physical,
                                Common = new DamageTypeDescription.CommomData(),
                                Physical = new DamageTypeDescription.PhysicalData() { Form = PhysicalDamageForm.Bludgeoning }
                            }
                        }
                    };
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "a0b5b95a9a139944c965c593a0a77ff7" };
                    c.Time = AbilitySpawnFxTime.OnPrecastStart;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "4daa50efa21f9564fb3c5cd35d022cbf" };
                    c.Time = AbilitySpawnFxTime.OnStart;
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
                bp.Type = AbilityType.Special;
                bp.Range = AbilityRange.Long;
                bp.CanTargetEnemies = true;
                bp.ShouldTurnToTarget = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiAirBlastBase.ToReference<BlueprintAbilityReference>();
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Kineticist;
                bp.m_TargetMapObjects = true;
                bp.AvailableMetamagic = ExtendRangeAirBlastAbility.AvailableMetamagic;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.LocalizedDuration = new LocalizedString();
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            var IsekaiAirBlastSpindle = Helpers.CreateBlueprint<BlueprintAbility>("IsekaiAirBlastSpindle", bp => {
                bp.m_DisplayName = SpindleAirBlastAbility.m_DisplayName;
                bp.m_Description = SpindleAirBlastAbility.m_Description;
                bp.m_Icon = SpindleAirBlastAbility.m_Icon;
                bp.AddComponent<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Electricity;
                });
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Reflex;
                    c.Actions = ActionFlow.DoSingle<ContextActionConditionalSaved>(c => {
                        c.Succeed = ActionFlow.DoNothing();
                        c.Failed = ActionFlow.DoSingle<ContextActionDealDamage>(c => {
                            c.m_Type = ContextActionDealDamage.Type.Damage;
                            c.DamageType = new DamageTypeDescription()
                            {
                                Type = DamageType.Physical,
                                Common = new DamageTypeDescription.CommomData(),
                                Physical = new DamageTypeDescription.PhysicalData() { Form = PhysicalDamageForm.Bludgeoning }
                            };
                            c.Duration = new ContextDurationValue()
                            {
                                DiceType = DiceType.Zero,
                                DiceCountValue = 0,
                                BonusValue = 0,
                                m_IsExtendable = true,
                            };
                            c.Value = new ContextDiceValue()
                            {
                                DiceType = DiceType.D6,
                                DiceCountValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Rank,
                                    ValueRank = AbilityRankType.DamageDice
                                },
                                BonusValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Shared
                                }
                            };
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
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 2;
                    c.CachedDamageInfo = new List<AbilityKineticist.DamageInfo>() {
                        new AbilityKineticist.DamageInfo()
                        {
                            Value = new ContextDiceValue()
                            {
                                DiceType = DiceType.D6,
                                DiceCountValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Rank,
                                    ValueRank = AbilityRankType.DamageDice
                                },
                                BonusValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Shared
                                }
                            },
                            Type = new DamageTypeDescription()
                            {
                                Type = DamageType.Physical,
                                Common = new DamageTypeDescription.CommomData(),
                                Physical = new DamageTypeDescription.PhysicalData() { Form = PhysicalDamageForm.Bludgeoning }
                            },
                            Half = true
                        }
                    };
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "a0b5b95a9a139944c965c593a0a77ff7" };
                    c.Time = AbilitySpawnFxTime.OnPrecastStart;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "4daa50efa21f9564fb3c5cd35d022cbf" };
                    c.Time = AbilitySpawnFxTime.OnStart;
                });
                bp.Type = AbilityType.Special;
                bp.Range = AbilityRange.Close;
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiAirBlastBase.ToReference<BlueprintAbilityReference>();
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Kineticist;
                bp.AvailableMetamagic = SpindleAirBlastAbility.AvailableMetamagic;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.LocalizedDuration = new LocalizedString();
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            var IsekaiAirBlastTorrent = Helpers.CreateBlueprint<BlueprintAbility>("IsekaiAirBlastTorrent", bp => {
                bp.m_DisplayName = TorrentAirBlastAbility.m_DisplayName;
                bp.m_Description = TorrentAirBlastAbility.m_Description;
                bp.m_Icon = TorrentAirBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Reflex;
                    c.Actions = ActionFlow.DoSingle<ContextActionDealDamage>(c => {
                        c.m_Type = ContextActionDealDamage.Type.Damage;
                        c.DamageType = new DamageTypeDescription()
                        {
                            Type = DamageType.Physical,
                            Common = new DamageTypeDescription.CommomData(),
                            Physical = new DamageTypeDescription.PhysicalData() { Form = PhysicalDamageForm.Bludgeoning }
                        };
                        c.Duration = new ContextDurationValue()
                        {
                            DiceType = DiceType.Zero,
                            DiceCountValue = 0,
                            BonusValue = 0,
                            m_IsExtendable = true,
                        };
                        c.Value = new ContextDiceValue()
                        {
                            DiceType = DiceType.D6,
                            DiceCountValue = new ContextValue()
                            {
                                ValueType = ContextValueType.Rank,
                                ValueRank = AbilityRankType.DamageDice
                            },
                            BonusValue = new ContextValue()
                            {
                                ValueType = ContextValueType.Shared
                            }
                        };
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
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 2;
                    c.CachedDamageInfo = new List<AbilityKineticist.DamageInfo>() {
                        new AbilityKineticist.DamageInfo()
                        {
                            Value = new ContextDiceValue()
                            {
                                DiceType = DiceType.D6,
                                DiceCountValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Rank,
                                    ValueRank = AbilityRankType.DamageDice
                                },
                                BonusValue = new ContextValue()
                                {
                                    ValueType = ContextValueType.Shared
                                }
                            },
                            Type = new DamageTypeDescription()
                            {
                                Type = DamageType.Physical,
                                Common = new DamageTypeDescription.CommomData(),
                                Physical = new DamageTypeDescription.PhysicalData() { Form = PhysicalDamageForm.Bludgeoning }
                            },
                            Half = true
                        }
                    };
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "a0b5b95a9a139944c965c593a0a77ff7" };
                    c.Time = AbilitySpawnFxTime.OnPrecastStart;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "4daa50efa21f9564fb3c5cd35d022cbf" };
                    c.Time = AbilitySpawnFxTime.OnStart;
                });
                bp.Type = AbilityType.Special;
                bp.Range = AbilityRange.Close;
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiAirBlastBase.ToReference<BlueprintAbilityReference>();
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Kineticist;
                bp.AvailableMetamagic = TorrentAirBlastAbility.AvailableMetamagic;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.LocalizedDuration = new LocalizedString();
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            var IsekaiAirBlastWallArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("IsekaiAirBlastWallArea", bp => {
                bp.AddComponent<AbilityAreaEffectRunAction>(c => {
                    c.UnitEnter = ActionFlow.DoSingle<ContextActionDealDamage>(c => {
                        c.m_Type = ContextActionDealDamage.Type.Damage;
                        c.DamageType = new DamageTypeDescription()
                        {
                            Type = DamageType.Physical,
                            Common = new DamageTypeDescription.CommomData(),
                            Physical = new DamageTypeDescription.PhysicalData() { Form = PhysicalDamageForm.Bludgeoning }
                        };
                        c.Duration = new ContextDurationValue()
                        {
                            DiceType = DiceType.Zero,
                            DiceCountValue = 0,
                            BonusValue = 0,
                            m_IsExtendable = true,
                        };
                        c.Value = new ContextDiceValue()
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
                        c.Half = true;
                    });
                    c.UnitExit = ActionFlow.DoNothing();
                    c.UnitMove = ActionFlow.DoNothing();
                    c.Round = ActionFlow.DoNothing();
                });
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
                bp.Shape = AreaEffectShape.Wall;
                bp.Size = new Feet(60);
                bp.Fx = new PrefabLink() { AssetId = "4ffc8d2162a215e44a1a728752b762eb" };
            });
            var IsekaiAirBlastWall = Helpers.CreateBlueprint<BlueprintAbility>("IsekaiAirBlastWall", bp => {
                bp.m_DisplayName = WallAirBlastAbility.m_DisplayName;
                bp.m_Description = WallAirBlastAbility.m_Description;
                bp.m_Icon = WallAirBlastAbility.m_Icon;
                bp.AddComponent<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Unknown;
                    c.Actions = ActionFlow.DoSingle<ContextActionSpawnAreaEffect>(c => {
                        c.m_AreaEffect = IsekaiAirBlastWallArea.ToReference<BlueprintAbilityAreaEffectReference>();
                        c.DurationValue = new ContextDurationValue()
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
                    });
                });
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
                bp.AddComponent<AbilityKineticist>(c => {
                    c.Amount = 1;
                    c.InfusionBurnCost = 3;
                    c.CachedDamageInfo = new List<AbilityKineticist.DamageInfo>() {
                        new AbilityKineticist.DamageInfo()
                        {
                            Value = new ContextDiceValue()
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
                            },
                            Type = new DamageTypeDescription()
                            {
                                Type = DamageType.Physical,
                                Common = new DamageTypeDescription.CommomData(),
                                Physical = new DamageTypeDescription.PhysicalData() { Form = PhysicalDamageForm.Bludgeoning }
                            },
                            Half = true
                        }
                    };
                    c.CachedDamageSource = IsekaiAirBlastWallArea.ToReference<AnyBlueprintReference>();
                    c.ResourceCostIncreasingFacts = new List<BlueprintUnitFactReference>();
                    c.ResourceCostDecreasingFacts = new List<BlueprintUnitFactReference>();
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "a0b5b95a9a139944c965c593a0a77ff7" };
                    c.Time = AbilitySpawnFxTime.OnPrecastStart;
                });
                bp.AddComponent<AbilitySpawnFx>(c => {
                    c.PrefabLink = new PrefabLink() { AssetId = "4daa50efa21f9564fb3c5cd35d022cbf" };
                    c.Time = AbilitySpawnFxTime.OnStart;
                });
                bp.Type = AbilityType.Special;
                bp.Range = AbilityRange.Close;
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.m_Parent = IsekaiAirBlastBase.ToReference<BlueprintAbilityReference>();
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Kineticist;
                bp.AvailableMetamagic = WallAirBlastAbility.AvailableMetamagic;
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.LocalizedDuration = new LocalizedString();
                bp.LocalizedSavingThrow = new LocalizedString();
            });
            var IsekaiAirBlastFeature = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiAirBlastFeature", bp => {
                bp.SetName("Overpowered Ability — Air Avatar");
                bp.SetDescription("You gain the ability to use the Air Kinetic blast and all its associated form infusions.");
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

            var IsekaiEarthBlastFeature = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiEarthBlastFeature", bp => {
                bp.m_DisplayName = EarthBlastAbility.m_DisplayName;
                bp.m_Description = EarthBlastAbility.m_Description;
                bp.m_Icon = EarthBlastAbility.m_Icon;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { IsekaiAirBlastBase.ToReference<BlueprintUnitFactReference>() }; // TODO: change to earth
                });
            });
            var IsekaiFireBlastFeature = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiFireBlastFeature", bp => {
                bp.m_DisplayName = FireBlastAbility.m_DisplayName;
                bp.m_Description = FireBlastAbility.m_Description;
                bp.m_Icon = FireBlastAbility.m_Icon;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { IsekaiAirBlastBase.ToReference<BlueprintUnitFactReference>() }; // TODO: change to Fire
                });
            });
            var IsekaiWaterBlastFeature = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiWaterBlastFeature", bp => {
                bp.m_DisplayName = WaterBlastAbility.m_DisplayName;
                bp.m_Description = WaterBlastAbility.m_Description;
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
                bp.SetDescription("At 1st level, a kineticist can overexert herself to channel more power than normal, pushing past the limit of what is safe for her body by accepting burn. "
                    + "Some of her wild talents allow her to accept burn in exchange for a greater effect, while others require her to accept a certain amount of burn to use that talent at "
                    + "all. For each point of burn she accepts, a kineticist takes (1 per {g|Encyclopedia:Character_Level}character level{/g}) points of nonlethal "
                    + "{g|Encyclopedia:Damage}damage{/g}. This damage can't be {g|Encyclopedia:Healing}healed{/g} by any means other than getting a full night's "
                    + "{g|Encyclopedia:Rest}rest{/g}, which removes all burn and associated nonlethal damage. Nonlethal damage from burn can't be reduced or redirected, and a kineticist "
                    + "incapable of taking nonlethal damage can't accept burn. A kineticist can accept only 1 point of burn per {g|Encyclopedia:Combat_Round}round{/g}. This limit rises to "
                    + "2 points of burn at 6th level, and rises by 1 additional point every 3 levels thereafter. A kineticist can't choose to accept burn if it would put her total number "
                    + "of points of burn higher than (3 + her {g|Encyclopedia:Constitution}Constitution{/g} modifier), though she can be forced to accept more burn from a source outside "
                    + "her control. A kineticist who has accepted burn never benefits from abilities that allow her to ignore or alter the effects she receives from nonlethal damage.");
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
                        c.DurationValue = new ContextDurationValue()
                        {
                            Rate = DurationRate.Rounds,
                            DiceType = DiceType.Zero,
                            DiceCountValue = 0,
                            BonusValue = 0,
                            m_IsExtendable = true,
                        };
                        c.AsChild = true;
                    });
                });
            });
            var KineticPowerSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("KineticPowerSelection", bp => {
                bp.SetName("Overpowered Ability — Kinetic Power");
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
                        WallInfusion.ToReference<BlueprintUnitFactReference>(),
                    };
                });

                // Add features later
                bp.m_Features = new BlueprintFeatureReference[0];
                bp.m_AllFeatures = new BlueprintFeatureReference[] { IsekaiAirBlastFeature.ToReference<BlueprintFeatureReference>() }; // TODO: add other elements
            });

            PatchGatherPowerBuffs(IsekaiAirBlastFeature);

            OverpoweredAbilitySelection.AddToSelection(KineticPowerSelection);
        }
        private static void PatchGatherPowerBuffs(BlueprintFeature airBlastFeature)
        {
            BlueprintBuff[] buffs = new BlueprintBuff[] { GatherPowerBuffI, GatherPowerBuffII, GatherPowerBuffIII }; // TODO: patch other elements
            foreach(BlueprintBuff buff in buffs)
            {
                var airConditional = (Conditional)buff.GetComponent<AddFactContextActions>().Activated.Actions[0];
                var airCondition = new ContextConditionHasFact() { m_Fact = airBlastFeature.ToReference<BlueprintUnitFactReference>() };
                airConditional.ConditionsChecker.Conditions = airConditional.ConditionsChecker.Conditions.AddToArray(airCondition);
            }
        }
    }
}
