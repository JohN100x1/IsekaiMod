using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using System.Collections.Generic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility
{
    class KineticPower
    {
        // TODO: Fix DC of kineticist blasts/infusions
        // TODO: Fix ability parameters calculated based on kineticist class.
        // TODO: rework progression into archetype. progression is broken if not taken at level 1

        // Kinetic Power Burn
        private static readonly BlueprintAbilityResource BurnResource = Resources.GetBlueprint<BlueprintAbilityResource>("066ac4b762e32be4b953703174ed925c");
        private static readonly BlueprintBuff BurnEffectBuff = Resources.GetBlueprint<BlueprintBuff>("95b1c0d55f30996429a3a4eba4d2b4a6");
        private static readonly BlueprintAbility GatherPower = Resources.GetBlueprint<BlueprintAbility>("6dcbffb8012ba2a4cb4ac374a33e2d9a");
        private static readonly BlueprintFeature GatherPowerFeature = Resources.GetBlueprint<BlueprintFeature>("0601925a028b788469365d5f8f39e14a");
        private static readonly BlueprintBuff GatherPowerBuffI = Resources.GetBlueprint<BlueprintBuff>("e6b8b31e1f8c524458dc62e8a763cfb1");
        private static readonly BlueprintBuff GatherPowerBuffII = Resources.GetBlueprint<BlueprintBuff>("3a2bfdc8bf74c5c4aafb97591f6e4282");
        private static readonly BlueprintBuff GatherPowerBuffIII = Resources.GetBlueprint<BlueprintBuff>("82eb0c274eddd8849bb89a8e6dbc65f8");
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
        private static readonly BlueprintBuff KineticBladeEnableBuff = Resources.GetBlueprint<BlueprintBuff>("426a9c079ee7ac34aa8e0054f2218074");
        private static readonly BlueprintBuff ElementalBastionBuff = Resources.GetBlueprint<BlueprintBuff>("99953956704788444964899b5b8e96ab");

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
        private static readonly BlueprintFeatureSelection InfusionSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("58d6f8e9eea63f6418b107ce64f315ea");
        private static readonly BlueprintFeatureSelection WildTalentSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("5c883ae0cd6d7d5448b7a420f51f8459");
        private static readonly BlueprintProgression KineticBlastProgression = Resources.GetBlueprint<BlueprintProgression>("30a5b8cf728bd4a4d8d90fc4953e322e");
        private static readonly BlueprintProgression ElementalOverflowProgression = Resources.GetBlueprint<BlueprintProgression>("86beb0391653faf43aec60d5ec05b538");
        private static readonly BlueprintProgression InfusionSpecializationProgression = Resources.GetBlueprint<BlueprintProgression>("1f86ce843fbd2d548a8d88ea1b652452");

        // Kineticist Class
        private static readonly BlueprintCharacterClass KineticistClass = Resources.GetBlueprint<BlueprintCharacterClass>("42a455d9ec1ad924d889272429eb8391");
        private static readonly BlueprintFeature RayCalculateFeature = Resources.GetBlueprint<BlueprintFeature>("d3e6275cfa6e7a04b9213b7b292a011c");

        public static void Add()
        {
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
                bp.SetName("Burn");
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
                    c.m_Blasts = new BlueprintAbilityReference[17] {
                        AirBlastBase.ToReference<BlueprintAbilityReference>(),
                        BlizzardBlastBase.ToReference<BlueprintAbilityReference>(),
                        BlueFlameBlastBase.ToReference<BlueprintAbilityReference>(),
                        ChargedWaterBlastBase.ToReference<BlueprintAbilityReference>(),
                        ColdBlastBase.ToReference<BlueprintAbilityReference>(),
                        EarthBlastBase.ToReference<BlueprintAbilityReference>(),
                        ElectricBlastBase.ToReference<BlueprintAbilityReference>(),
                        FireBlastBase.ToReference<BlueprintAbilityReference>(),
                        IceBlastBase.ToReference<BlueprintAbilityReference>(),
                        MagmaBlastBase.ToReference<BlueprintAbilityReference>(),
                        MetalBlastBase.ToReference<BlueprintAbilityReference>(),
                        MudBlastBase.ToReference<BlueprintAbilityReference>(),
                        PlasmaBlastBase.ToReference<BlueprintAbilityReference>(),
                        SandstormBlastBase.ToReference<BlueprintAbilityReference>(),
                        SteamBlastBase.ToReference<BlueprintAbilityReference>(),
                        ThunderstormBlastBase.ToReference<BlueprintAbilityReference>(),
                        WaterBlastBase.ToReference<BlueprintAbilityReference>(),
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
            var KineticPowerProgression = Helpers.CreateBlueprint<BlueprintProgression>("KineticPowerProgression", bp => {
                bp.SetName("Overpowered Ability — Kinetic Power");
                bp.SetDescription("You gain the ability to use kinetic blasts.");
                bp.m_Icon = InfusionSelection.m_Icon;
                bp.Ranks = 1;
                bp.m_AllowNonContextActions = false;
                bp.IsClassFeature = true;
                bp.m_FeaturesRankIncrease = new List<BlueprintFeatureReference>();
                bp.AddComponent<ClassLevelsForPrerequisites>(c => {
                    c.m_FakeClass = KineticistClass.ToReference<BlueprintCharacterClassReference>();
                    c.m_ActualClass = IsekaiProtagonistClass.GetReference();
                    c.Modifier = 1.0;
                    c.Summand = 0;
                });
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { RayCalculateFeature.ToReference<BlueprintUnitFactReference>() };
                });
                bp.AddComponent<AddProficiencies>(c => {
                    c.ArmorProficiencies = new ArmorProficiencyGroup[0];
                    c.WeaponProficiencies = new WeaponCategory[] { WeaponCategory.KineticBlast };
                });
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }
                };
                bp.LevelEntries = new LevelEntry[] {
                    Helpers.LevelEntry(1, KineticPowerBurn, GatherPowerAbilitiesFeature, ElementalFocusSelection, InfusionSelection, KineticBlastProgression, ElementalOverflowProgression, InfusionSpecializationProgression, DismissInfusionFeature),
                    Helpers.LevelEntry(2, WildTalentSelection),
                    Helpers.LevelEntry(3, InfusionSelection, ElementalOverflowBonusFeature),
                    Helpers.LevelEntry(4, WildTalentSelection),
                    Helpers.LevelEntry(5, InfusionSelection, MetakinesisEmpowerFeature),
                    Helpers.LevelEntry(6, WildTalentSelection),
                    Helpers.LevelEntry(7, SecondaryElementalFocusSelection),
                    Helpers.LevelEntry(8, WildTalentSelection),
                    Helpers.LevelEntry(9, InfusionSelection, MetakinesisMaximizedFeature),
                    Helpers.LevelEntry(10, WildTalentSelection),
                    Helpers.LevelEntry(11, InfusionSelection, SuperCharge),
                    Helpers.LevelEntry(12, WildTalentSelection),
                    Helpers.LevelEntry(13, InfusionSelection, MetakinesisQuickenFeature),
                    Helpers.LevelEntry(14, WildTalentSelection),
                    Helpers.LevelEntry(15, ThirdElementalFocusSelection),
                    Helpers.LevelEntry(16, WildTalentSelection, CompositeBlastSpecialisation),
                    Helpers.LevelEntry(17, InfusionSelection),
                    Helpers.LevelEntry(18, WildTalentSelection),
                    Helpers.LevelEntry(19, InfusionSelection, MetakinesisMaster),
                    Helpers.LevelEntry(20, WildTalentSelection),
                };
                bp.UIGroups = new UIGroup[] {
                    Helpers.CreateUIGroup(ElementalFocusSelection, SecondaryElementalFocusSelection, ThirdElementalFocusSelection, CompositeBlastSpecialisation),
                    Helpers.CreateUIGroup(MetakinesisEmpowerFeature, MetakinesisMaximizedFeature, MetakinesisQuickenFeature, MetakinesisMaster),
                    Helpers.CreateUIGroup(GatherPowerFeature, SuperCharge, ElementalOverflowBonusFeature),
                };
                bp.m_UIDeterminatorsGroup = new BlueprintFeatureBaseReference[] {
                    KineticPowerBurn.ToReference<BlueprintFeatureBaseReference>(),
                    KineticBlastProgression.ToReference<BlueprintFeatureBaseReference>(),
                };
            });

            // Patch Progressions and Class dependent features
            PatchProgressions();
            PatchContextRankConfigs();
            PatchResources();
            PatchContextCalculateAbilityParamsBasedOnClass();

            OverpoweredAbilitySelection.AddToSelection(KineticPowerProgression);
        }
        public static void PatchProgressions()
        {
            var progressions = new BlueprintProgression[]
            {
                Resources.GetBlueprint<BlueprintProgression>("2bd0d44953a536f489082534c48f8e31"), // ElementalFocusAir
                Resources.GetBlueprint<BlueprintProgression>("c6816ad80a3df9c4ea7d3b012b06bacd"), // ElementalFocusEarth
                Resources.GetBlueprint<BlueprintProgression>("3d8d3d6678b901444a07984294a1bc24"), // ElementalFocusFire
                Resources.GetBlueprint<BlueprintProgression>("7ab8947ce2e19c44a9edcf5fd1466686"), // ElementalFocusWater
                Resources.GetBlueprint<BlueprintProgression>("659c39542b728c04b83e969c834782a9"), // SecondaryElementAir
                Resources.GetBlueprint<BlueprintProgression>("956b65effbf37e5419c13100ab4385a3"), // SecondaryElementEarth
                Resources.GetBlueprint<BlueprintProgression>("caa7edca64af1914d9e14785beb6a143"), // SecondaryElementFire
                Resources.GetBlueprint<BlueprintProgression>("faa5f1233600d864fa998bc0afe351ab"), // SecondaryElementWater
                Resources.GetBlueprint<BlueprintProgression>("651570c873e22b84f893f146ce2de502"), // ThirdElementAir
                Resources.GetBlueprint<BlueprintProgression>("c43d9c2d23e56fb428a4eb60da9ba1cb"), // ThirdElementEarth
                Resources.GetBlueprint<BlueprintProgression>("56e2fc3abed8f2247a621ac37e75f303"), // ThirdElementFire
                Resources.GetBlueprint<BlueprintProgression>("86eff374d040404438ad97fedd7218bc"), // ThirdElementWater
                Resources.GetBlueprint<BlueprintProgression>("6f1d86ae43adf1049834457ce5264003"), // AirBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("ba7767cb03f7f3949ad08bd3ff8a646f"), // ElecticBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("747a1f33ed0a17442b3273adc7797661"), // BlizzardBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("535a9c4dbe912924396ae50cc7fba8c4"), // BloodBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("cdf2a117e8a2ccc4ebabd2fcee1e4d09"), // BlueFlameBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("e717ae6647573bf4195ea168693c7be0"), // ChargedWaterBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("d6375ba9b52eca04a805a54765310976"), // IceBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("cb19d1cbf6daf7a46bf38c05af1c2fb0"), // MagmaBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("ccd26825e04f8044c881cfcef49f1872"), // MetalBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("648d3c01bcab7614595facd302e88184"), // MudBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("953fe61325983f244adbd7384903393d"), // PlasmaBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("f05a7bde1b2bf9e4e927b3b1aeca8bfb"), // SandstormBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("985fa6f168ea663488956713bc44a1e8"), // SteamBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("33217c1678c30bd4ea2748decaced223"), // ThunderstormBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("d945ac76fc6a06e44b890252824db30a"), // EarthBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("fbed3ca8c0d89124ebb3299ccf68c439"), // FireBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("dbb1159b0e8137c4ea20434a854ae6a8"), // ColdBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("e4027e0fec48e8048a172c6627d4eba9"), // WaterBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("30a5b8cf728bd4a4d8d90fc4953e322e"), // KineticBlastProgression
                Resources.GetBlueprint<BlueprintProgression>("86beb0391653faf43aec60d5ec05b538"), // ElementalOverflowProgression
                Resources.GetBlueprint<BlueprintProgression>("908286aeefa6be54e8c39e144cb87fdd"), // InfusionProgression
                Resources.GetBlueprint<BlueprintProgression>("1f86ce843fbd2d548a8d88ea1b652452"), // InfusionSpecializationProgression
            };

            foreach (BlueprintProgression progression in progressions)
            {
                progression.m_Classes = progression.m_Classes.AddToArray(
                    new BlueprintProgression.ClassWithLevel
                    {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    });
            }
        }
        public static void PatchContextRankConfigs()
        {
            var blueprintsToPatch = new BlueprintUnitFact[] { 
                Resources.GetBlueprint<BlueprintBuff>("b803fcd9da7b1564fb52978f08372767"),    // EnvelopingWindsBuff
                Resources.GetBlueprint<BlueprintFeature>("a942347023fedb2419f8bdbb4450e528"), // FleshOfStoneEffectFeature
                Resources.GetBlueprint<BlueprintFeature>("642bb6097c37b3b4b8be1f46d2d9296e"), // SearingFleshEffectFeature
                Resources.GetBlueprint<BlueprintFeature>("1ff803cb49f63ea4185490fae2c43ca7"), // ShroudOfWaterArmorEffectFeature
                Resources.GetBlueprint<BlueprintFeature>("4d8feca11d6e29a499ae761b90eacdba"), // ShroudOfWaterShieldEffectFeature
                Resources.GetBlueprint<BlueprintFeature>("2496916d8465dbb4b9ddeafdf28c67d8"), // ElementalOverflowBonusFeature
                Resources.GetBlueprint<BlueprintBuff>("61201f3a439781a4db776747043f4bee"),    // ElementalOverflowEffectFeatureBuff
                Resources.GetBlueprint<BlueprintAbility>("80e7e30cdf96be0418a615ebb38ea4b9"), // Celerity
                Resources.GetBlueprint<BlueprintBuff>("23c0f0417981608479131d25d4349f7d"),    // FlameShieldBuff
                Resources.GetBlueprint<BlueprintAbility>("27f0127528bd96f44897987f339ae282"), // FoxFireAbility
                Resources.GetBlueprint<BlueprintAbility>("db611ffeefb8f1e4f88e7d5393fc651d"), // HealingBurstAbility
                Resources.GetBlueprint<BlueprintAbility>("eff667a3a43a77d45a193bb7c94b3a6c"), // KineticHealerAbility
                Resources.GetBlueprint<BlueprintAbility>("0e370822d9e0ff54f897e7fdf24cffb8"), // KineticRevificationAbility
                Resources.GetBlueprint<BlueprintBuff>("50d6b5b795c1e59418d3ad720a0e4004"),    // SkilledKineticistAirBuff
                Resources.GetBlueprint<BlueprintBuff>("56b70109d78b0444cb3ad04be3b1ee9e"),    // SkilledKineticistBuff
                Resources.GetBlueprint<BlueprintBuff>("a6a7bba1c2daae8419747c6ac2c2df91"),    // SkilledKineticistEarthBuff
                Resources.GetBlueprint<BlueprintBuff>("984a3194cb267d04da689cb16f952d53"),    // SkilledKineticistFireBuff
                Resources.GetBlueprint<BlueprintBuff>("ca26882a3c263e741a9fd60e7b9f3b19"),    // SkilledKineticistWaterBuff
                Resources.GetBlueprint<BlueprintAbility>("3c030a62a0efa1c419ecf315a9d694ef"), // SlickAbility
                Resources.GetBlueprint<BlueprintAbility>("566e989d7c1d1d14f8371e35f7c5d9b8"), // SlickShortAbility
            };
            foreach(BlueprintUnitFact blueprint in blueprintsToPatch)
            {
                foreach (ContextRankConfig config in blueprint.GetComponents<ContextRankConfig>())
                {
                    config.m_Class = config.m_Class.AddToArray(IsekaiProtagonistClass.GetReference());
                }
            }
        }
        public static void PatchResources()
        {
            var resources = new BlueprintAbilityResource[] {
                Resources.GetBlueprint<BlueprintAbilityResource>("f3ed2974316feb344afacc0d7ada3ace"), // EnvelopingWindsResource
                Resources.GetBlueprint<BlueprintAbilityResource>("7d3a708bc1dc6e345b70a5f66ab80bc3"), // FleshOfStoneResource
                Resources.GetBlueprint<BlueprintAbilityResource>("4d3297d1e4505654c899c00f3eb39373"), // ShroudOfWaterArmorResource
                Resources.GetBlueprint<BlueprintAbilityResource>("1f4eeef738e694c44aad070a0b3d64a2"), // ShroudOfWaterResource
                Resources.GetBlueprint<BlueprintAbilityResource>("53c3fa21e16afe642a3b6f2ba43068fd"), // ShroudOfWaterShieldResource
            };
            foreach (BlueprintAbilityResource resource in resources)
            {
                resource.m_MaxAmount.m_Class = resource.m_MaxAmount.m_Class.AddToArray(IsekaiProtagonistClass.GetReference());
                resource.m_MaxAmount.m_ClassDiv = resource.m_MaxAmount.m_ClassDiv.AddToArray(IsekaiProtagonistClass.GetReference());
            }
        }
        public static void PatchContextCalculateAbilityParamsBasedOnClass()
        {
            var abilities = new BlueprintAbility[] {
                Resources.GetBlueprint<BlueprintAbility>("31f668b12011e344aa542aa07ab6c8d9"), // AirBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("89cc522f2e1444b40ba1757320c58530"), // AirBlastKineticBladeDamage
                Resources.GetBlueprint<BlueprintAbility>("9fbc4fe045472984aa4a2d15d88bdaf9"), // CycloneAirBladtAbility
                Resources.GetBlueprint<BlueprintAbility>("a28e54e4e5fafd1449dd9e926be85160"), // SpindleAirBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("51ede1faa3cdb3b47a46f7579ca02b0a"), // TorrentAirBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("d0390bd9ff12cd242a40c384445546cd"), // WallAirBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("a41b8912878a4a4488084c2efc84f572"), // ChainElectricBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("24f26ac07d21a0e4492899085d1302f6"), // ElectricBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("ca608f545b07ec045954aee5ff94640a"), // ElectricBlastBladeAbility
                Resources.GetBlueprint<BlueprintAbility>("b333573557f496746b754d0af246c0fe"), // SpindleElectricBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("a87fd82362ff7d247b998e68eecc087b"), // TorrentElectricBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("139558a1389f7034e88dca5bfa6d4d3b"), // WallElectricBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("27f582dcef8206142b01e27ad521e6a4"), // BlizzardBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("027ce0b3842170748a63ea04cb02cab7"), // BlizzardBlastBladeDamage
                Resources.GetBlueprint<BlueprintAbility>("cca552f27c6ea4f458858fb857212df7"), // CycloneBlizzardBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("e4624a8398c3bdc44bbcbf2fb20fae47"), // SpindleBlizzardBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("d02fba9ae78f12642b4111a4bbbdc023"), // TorrentBlizzardBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("a34c55992021031438ca3f1a0406a9ef"), // WallBlizzardBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("ab6e3f470fba2d349b7b7ef0990b5476"), // BloodBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("0a386b1c2b4ae9b4f81ddf4557155810"), // BloodBlastBladeDamage
                Resources.GetBlueprint<BlueprintAbility>("ec3741322559fc449ad1ace45d1ec58a"), // SpindleBloodBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("48ae2d5a6105bdb4abb9c23a3809f1c1"), // SprayBloodBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("e5b1f4d8995f3f0489a4fed250a178a0"), // TorrentBloodBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("97e1009a2e708eb4cb8b79bab253d32a"), // WallBloodBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("21ce8eb90232d27489dae1ae895cc3d7"), // WrackBloodBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("322911b79eabdb64f8b079c7a2d95e68"), // BlueFlameBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("a975a40b710833a468476564fa673cee"), // BlueFlameBlastBladeDamage
                Resources.GetBlueprint<BlueprintAbility>("2ca478c57073c9f469beef873b001503"), // DetonationBlueFlameBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("0f70d9349ef23bf4089387edac18317c"), // EruptionBlueFlameBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("e3b3c7747e14f54458d27163f19761ae"), // FanOfFlamesBlueFlameBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("3442485bd9cdfeb4fb7faf1984dec5bb"), // SpindleBlueFlameBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("cc514f4604da850409f1af291e848e3a"), // TorrentBlueFlameBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("40681ea748d98f54ba7f5dc704507f39"), // ChargedWaterBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("ff24a4ac444afeb4bab5699828aa4e77"), // ChargedWaterBlastBladeDamage
                Resources.GetBlueprint<BlueprintAbility>("680fe1162cff5294a8375f6eb32652ce"), // SpindleChargedWaterBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("53b701d71c0cde64e887f3b81a094682"), // SprayChargedWaterBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("3bbc16ca68378af4f88d33dbd364a9d9"), // TorrentChargedWaterBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("d7f06e36bff449d468ce8a1621b494a3"), // WallChargedWaterBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("519e36decde7c964d87c2ffe4d3d8459"), // IceBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("8c8dd4e7c07e468498a6f5ed2c01063f"), // IceBlastBladeDamage
                Resources.GetBlueprint<BlueprintAbility>("415ce928decc2ac4fa551be49de86ceb"), // FragmentationIceBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("49246be3e43efc845a5c7ba5d6d5a353"), // SpindleIceBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("bbe6903c268f1104692c6d62d3e4858e"), // WallIceBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("a0f05637428cbca4bab8bc9122b9e3b9"), // MagmaBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("c49d2ddf72adf85478d6b3e09f52d32e"), // MagmaBlastBladeDamage
                Resources.GetBlueprint<BlueprintAbility>("7cc353f52000d4742a2710fa38de7357"), // EruptionMagmaBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("300bcc4bac44b4a489c919590256b625"), // SpindleMagmaBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("2ae4a1c73e8c6ca4d8b20d0e6eb730bd"), // TorrentMagmaBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("665cfd3718c4f284d80538d85a2791c9"), // MetalBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("9cef404da5745314b88f49c1ee9fbab1"), // MetalBlastBladeDamage
                Resources.GetBlueprint<BlueprintAbility>("44804ca6ba7d495439cc9d5ad6d6cfcf"), // DeadlyEarthMetalBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("3cf0a759bc612264fb9b03aa2f90b24b"), // FragmentationMetalBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("ff829a11544db914d89761c676397ef8"), // SpindleMetalBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("6551795d81a0e744ebc5785c1264b788"), // WallMetalBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("3236a9e26e23b364e8951ee9e92554e8"), // MudBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("f82cfcf11b94bef49bf1a8f57aad5c13"), // MudBlastBladeDamage
                Resources.GetBlueprint<BlueprintAbility>("0be97d0e752060f468bbf62ce032b9f5"), // DeadlyEarthMudBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("bcce0961438aa524ebf0d6992c5bede1"), // SpindleMudBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("32a018b283bc9c3428ec66b745bd0b27"), // TorrentMudBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("c25f56632bd43e240b4349fef841efa2"), // WallMudBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("a5631955254ae5c4d9cc2d16870448a2"), // PlasmaBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("fc22c06d63a95154291272577daa0b4d"), // PlasmaBlastBladeDamage
                Resources.GetBlueprint<BlueprintAbility>("1e2cff4d83b74ca468d4cea21665db2e"), // SpindlePlasmaBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("459dfd4225ac2fe48bdcb401b0f1dcc0"), // TorrentPlasmaBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("7b8a4a256d4f3dc4d99192bbaabcb307"), // SandstormBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("a41bfd708a7677f46aede02715f3100d"), // SandstormBlastBladeDamage
                Resources.GetBlueprint<BlueprintAbility>("251af7913c0a0f442a38bc85ed5737a8"), // CloudSandstormBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("2d1f3ad47ce421745b80495b9ed8ddc9"), // CycloneSandstormBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("ecb202fa5e1d0c84095b6604a62884cb"), // SpindleSandstormBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("82db79a0b4e91dc4ea2938192e6fc7af"), // TorrentSandstormBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("9652dec009183db4d8c29c6a196200e8"), // WallSandstormBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("08eb2ade31670b843879d8841b32d629"), // SteamBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("77dc27ae2f48ffe4a8ab17154145f1d8"), // SteamBlastBladeDamage
                Resources.GetBlueprint<BlueprintAbility>("f42bf8d4379d1b641b6163aa317ec80e"), // EruptionSteamBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("6d91306bce5524c4090c417efe7c538f"), // SpindleSteamBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("4d2e60cfd9902724d999758551020288"), // TorrentSteamBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("fc432e7a63f5a3545a93118af13bcb89"), // ThunderstormBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("833e3c01a1492d74588430249e6431af"), // ThunderstormBlastBladeDamage
                Resources.GetBlueprint<BlueprintAbility>("3e5996148b4ff634ea7033e112710402"), // CycloneThunderstormBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("ad985f8975b9986409eae00ea87225ca"), // SpindleThunderstormBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("c073af2846b8e054fb28e6f72bc02749"), // TorrentThunderstormBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("11cb007605def4546a596bd582f746fc"), // WallThunderstormBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("d859e796f6177cf449679c677076c577"), // FragmentationEarthBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("44d37b2230390b24e8060fe821068984"), // SpindleEarthBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("f493e7b18b2a22c438df7ced760dd5b0"), // WallEarthBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("d651db4ffb7441548a06b11de5f163a1"), // DetontationFireBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("5b69fce8b7890de4b8b9ab973158fed8"), // EruptionFireBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("a240a6d61e1aee040bf7d132bfe1dc07"), // FanOfFlamesFireBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("6f299bc4320299c49a291f43a667496d"), // SpindleFireBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("5e4c7cb990de4034bbee9fb99be2e15d"), // TorrentFireBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("f6d32ecd20ebacb4e964e2ece1c70826"), // ColdBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("cb20c297b1db1cd4ea9430578c90246d"), // ColdBlastBladeDamage
                Resources.GetBlueprint<BlueprintAbility>("920e4edc2df510444b016dd18038f2b7"), // SpindleColdBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("c8dda5accb6354b40aa3618484e91029"), // WallColdBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("e3f41966c2d662a4e9582a0497621c46"), // WaterBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("92724a6d6a6225d4895b41e35e973599"), // WaterBlastBladeDamage
                Resources.GetBlueprint<BlueprintAbility>("7021bbe4dca437440a41da4552dce28e"), // SpindleWaterBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("963da934d652bdc41900ed68f63ca1fa"), // SprayWaterBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("93cc42235edc6824fa7d54b83ed4e1fe"), // TorrentWaterBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("1ab8c76ac4983174dbffa35e2a87e582"), // WallWaterBlastAbility
                Resources.GetBlueprint<BlueprintAbility>("3c030a62a0efa1c419ecf315a9d694ef"), // SlickAbility
                Resources.GetBlueprint<BlueprintAbility>("566e989d7c1d1d14f8371e35f7c5d9b8"), // SlickShortAbility
                Resources.GetBlueprint<BlueprintAbility>("d8d451ed3c919a4438cde74cd145b981"), // TidalWaveAbility
            };
            foreach (BlueprintAbility ability in abilities)
            {
                ability.AddComponent<ContextCalculateAbilityParamsBasedOnClass>(c => {
                    c.StatType = StatType.Dexterity;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                });
            }
            var infusions = new BlueprintBuff[] {
                Resources.GetBlueprint<BlueprintBuff>("492a8156ecede6345a8e82475eed85ac"), // BleedingInfusionBuff
                Resources.GetBlueprint<BlueprintBuff>("918b2524af5c3f647b5daa4f4e985411"), // BowlingInfusionBuff
                Resources.GetBlueprint<BlueprintBuff>("74f5184d9bf809c419d040a1639cbe1b"), // BurningInfusionBuff
                Resources.GetBlueprint<BlueprintBuff>("49fc69c05ff7c5d46b61745d361a72fb"), // ChillingInfusionBuff
                Resources.GetBlueprint<BlueprintBuff>("ee8d9f5631c53684d8d627d715eb635c"), // DazzlingInfusionBuff
                Resources.GetBlueprint<BlueprintBuff>("738120aad01eedb4f891eca5b784646a"), // EntanglingInfusionBuff
                Resources.GetBlueprint<BlueprintBuff>("5d4db592f0fde214991ed27752cfce16"), // EntanglingInfusionSecondEffectBuff
                Resources.GetBlueprint<BlueprintBuff>("50cf40b1cb3115546a3e9b44d7687384"), // FlashInfusionBuff
                Resources.GetBlueprint<BlueprintBuff>("e671f173fcb75bf4aa78a4078d075792"), // FoxfireInfusionBuff
                Resources.GetBlueprint<BlueprintBuff>("f69a66c0feaa4374b8ca2732ee91a373"), // GrapplingInfusionBuff
                Resources.GetBlueprint<BlueprintBuff>("6d1b4436e500a4c4182dd5bc1ba6b208"), // GutWrenchingInfusionBuff
                Resources.GetBlueprint<BlueprintBuff>("f795bede8baefaf4d9d7f404ede960ba"), // PushingInfusionBuff
                Resources.GetBlueprint<BlueprintBuff>("67fc7492f198c8d4aace14d28e0ad438"), // SynapticInfusionBuff
                Resources.GetBlueprint<BlueprintBuff>("cebd08ab72f1baa4eaacdd836207873a"), // UnravelingInfusionBuff
                Resources.GetBlueprint<BlueprintBuff>("e50e653cff511cd49a55b979346699f1"), // VampiricInfusionBuff
            };
            foreach (BlueprintBuff infusion in infusions)
            {
                infusion.AddComponent<ContextCalculateAbilityParamsBasedOnClass>(c => {
                    c.UseKineticistMainStat = true;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                });
            }
            var areas = new BlueprintAbilityAreaEffect[] {
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("2a90aa7f771677b4e9624fa77697fdc6"), // WallAirBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("740b3ba212b5bb448becf202a97cdbf4"), // WallElectricBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("6ea87a0ff5df41c459d641326f9973d5"), // CloudBlizzardBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("d12f759590ac61b40870a0725b92a985"), // WallBlizzardBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("b35085bcd37e8e14eb7cb6e36d57f99e"), // WallBloodBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("f3b3f32b7f9f35b4cb4114d633b6de6d"), // WallBlueFlameBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("a4d33389f2b7b824889169d227cab729"), // WallBlueFlameBlastAreaPure
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("724d174829a1c1949a4a7ba99cfb06a0"), // WallChargedWaterBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("3b65f77ec33ab764592803685fe6891e"), // WallIceBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("c26aa67475bdb64449b0e0be6a9ea823"), // DeadlyEarthMagmaBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("f92cdd3b43a744f4f8abeacb913c92fb"), // WallMagmaBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("38a2979db34ad0f45a449e5eb174729f"), // DeadlyEarthMetalBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("267f19ba174b21e4d9baf30afd589068"), // DeadlyEarthMetalBlastAreaRare
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("c6b4fc6e73c25de4f83378c959144dc8"), // WallMetalBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("9a9895cbb91a15d48a0368ee8d0f650e"), // WallMetalBlastAreaRare
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("0af604484b5fcbb41b328750797e3948"), // DeadlyEarthMudBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("2cad16fcffefe3240b2d6dc3d33ff580"), // WallMudBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("182de1c07ecb56d448cd6d3237ae4b81"), // WallPlasmaBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("48aa66d1a15515e40b07bc1f5fb80f64"), // CloudSandstormBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("2eef9ca9e79968547a01d06d3828e17f"), // WallSandstormBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("35a62ad81dd5ae3478956c61d6cd2d2e"), // CloudSteamBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("6a64cc20d5820dc4cb3907b36ce6ac13"), // WallSteamBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("3659ce23ae102ca47a7bf3a30dd98609"), // CloudThunderstormBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("757b40456bbe27a46bbf18a57d64f31b"), // WallThunderstormBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("4b19dd893a4b80a49905903bcd56b9e2"), // DeadlyEarthEarthBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("af830491079fea141ad5f46e2dcf93cf"), // WallEarthBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("edb2896d49015434bbbe401ee27338c3"), // WallFireBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("2414e5c126976604584ebcee90395eee"), // WallColdBlastArea
                Resources.GetBlueprint<BlueprintAbilityAreaEffect>("bb4ddd5e7d64a4a49ba71fe8275d1552"), // WallWaterBlastArea
            };
            foreach (BlueprintAbilityAreaEffect area in areas)
            {
                area.AddComponent<ContextCalculateAbilityParamsBasedOnClass>(c => {
                    c.UseKineticistMainStat = true;
                    c.m_CharacterClass = IsekaiProtagonistClass.GetReference();
                });
            }
        }
    }
}
