using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist
{
    class PrebuildIsekaiProtagonistFeatureList
    {
        public static void Add()
        {
            // Prebuild Features
            var PowerAttack = Resources.GetBlueprint<BlueprintFeature>("9972f33f977fc724c838e59641b2fca5");
            var CombatReflexes = Resources.GetBlueprint<BlueprintFeature>("0f8939ae6f220984e8fb568abbdfba95");
            var ImprovedInitiative = Resources.GetBlueprint<BlueprintFeature>("797f25d709f559546b29e7bcb181cc74");
            var IronWill = Resources.GetBlueprint<BlueprintFeature>("175d1577bb6c9a04baf88eec99c66334");
            var Outflank = Resources.GetBlueprint<BlueprintFeature>("422dab7309e1ad343935f33a4d6e9f11");
            var IronWillImproved = Resources.GetBlueprint<BlueprintFeature>("3ea2215150a1c8a4a9bfed9d9023903e");
            var Dodge = Resources.GetBlueprint<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");
            var Toughness = Resources.GetBlueprint<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var SpellPenetration = Resources.GetBlueprint<BlueprintFeature>("ee7dc126939e4d9438357fbd5980d459");
            var GreaterSpellPenetration = Resources.GetBlueprint<BlueprintFeature>("1978c3f91cfbbc24b9c9b0d017f4beec");

            var Cleave = Resources.GetBlueprint<BlueprintFeature>("d809b6c4ff2aaff4fa70d712a70f7d7b");
            var CleavingFinish = Resources.GetBlueprint<BlueprintFeature>("59bd93899149fa44687ff4121389b3a9");
            var PointBlankShot = Resources.GetBlueprint<BlueprintFeature>("0da0c194d6e1d43419eb8d990b28e0ab");
            var PreciseShot = Resources.GetBlueprint<BlueprintFeature>("8f3d1e6b4be006f4d896081f2f889665");
            var DeadlyAim = Resources.GetBlueprint<BlueprintFeature>("f47df34d53f8c904f9981a3ee8e84892");
            var GreatFortitude = Resources.GetBlueprint<BlueprintFeature>("79042cb55f030614ea29956177977c52");
            var GreatFortitudeImproved = Resources.GetBlueprint<BlueprintFeature>("f5db1cc7ad48d794f85252fa4a64157b");
            var LightningReflexes = Resources.GetBlueprint<BlueprintFeature>("15e7da6645a7f3d41bdad7c8c4b9de1e");
            var LightningReflexesImproved = Resources.GetBlueprint<BlueprintFeature>("1e813eb8159b67a459b1c975027866e5");
            var MaximizeSpellFeat = Resources.GetBlueprint<BlueprintFeature>("7f2b282626862e345935bbea5e66424b");
            var EmpowerSpellFeat = Resources.GetBlueprint<BlueprintFeature>("a1de1e4f92195b442adb946f0e2b9d4e");

            // Prebuild Selections
            var BackgroundNone = Resources.GetBlueprint<BlueprintFeature>("7d300f497584d9245ac24c062dce0bd6");
            var BackgroundBaseSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("f926dabeee7f8a54db8f2010b323383c");
            var PitbornHeritage = Resources.GetBlueprint<BlueprintFeature>("c09ffb2657f6c2b41b5ed0ed607b362a");
            var TieflingHeritageSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("c862fd0e4046d2d4d9702dd60474a181");
            var AngelHeritage = Resources.GetBlueprint<BlueprintFeature>("ceedc840b113c3348a2f32b434df5fef");
            var AasimarHeritageSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("67aabcbce8f8ae643a9d08a6ca67cabd");
            var SkillFocusPhysique = Resources.GetBlueprint<BlueprintFeature>("9db907332bdaec1468cff3a99efef5b4");
            var Adaptibility = Resources.GetBlueprint<BlueprintFeatureSelection>("26a668c5a8c22354bac67bcd42e09a3f");
            var BasicFeatSelection = Resources.GetBlueprint<BlueprintFeatureSelection>("247a4068296e8be42890143f451b4b45");

            var IsekaiProtagonistBonusFeatSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("IsekaiProtagonistBonusFeatSelection");
            var CheatSkillSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("CheatSkillSelection");
            var TrainingArcSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("TrainingArcSelection");
            var BeachEpisodeSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("BeachEpisodeSelection");
            var CharacterDevelopmentSelection1 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection1");
            var CharacterDevelopmentSelection2 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection2");
            var CharacterDevelopmentSelection3 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection3");
            var CharacterDevelopmentSelection4 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection4");
            var CharacterDevelopmentSelection5 = Resources.GetModBlueprint<BlueprintFeatureSelection>("CharacterDevelopmentSelection5");

            var AutoQuickenFeature = Resources.GetModBlueprint<BlueprintFeature>("AutoQuickenFeature");
            var TrainingMontage = Resources.GetModBlueprint<BlueprintFeature>("TrainingMontage");
            var BodyStrengthening = Resources.GetModBlueprint<BlueprintFeature>("BodyStrengthening");
            var SpellNegation = Resources.GetModBlueprint<BlueprintFeature>("SpellNegation");
            var MasterSelf = Resources.GetModBlueprint<BlueprintFeature>("MasterSelf");
            var AlphaStrike = Resources.GetModBlueprint<BlueprintFeature>("AlphaStrike");
            var BetaStrike = Resources.GetModBlueprint<BlueprintFeature>("BetaStrike");
            var GammaStrike = Resources.GetModBlueprint<BlueprintFeature>("GammaStrike");
            var MundaneAura = Resources.GetModBlueprint<BlueprintFeature>("MundaneAura");
            var FireImmunity = Resources.GetModBlueprint<BlueprintFeature>("FireImmunity");

            var IsekaiProtagonistClass = Resources.GetModBlueprint<BlueprintCharacterClass>("IsekaiProtagonistClass");
            var PrebuildIsekaiProtagonistFeatureList = Helpers.CreateBlueprint<BlueprintFeature>("PrebuildIsekaiProtagonistFeatureList", bp => {
                bp.Ranks = 1;
                bp.HideInUI = true;
                bp.AddComponent<AddClassLevels>(c => {
                    c.DoNotApplyAutomatically = false;
                    c.m_CharacterClass = IsekaiProtagonistClass.ToReference<BlueprintCharacterClassReference>();
                    c.Levels = 20;
                    c.RaceStat = StatType.Strength;
                    c.LevelsStat = StatType.Charisma;
                    c.Skills = new StatType[11] {
                    StatType.SkillAthletics,
                    StatType.SkillMobility,
                    StatType.SkillThievery,
                    StatType.SkillStealth,
                    StatType.SkillKnowledgeArcana,
                    StatType.SkillKnowledgeWorld,
                    StatType.SkillLoreNature,
                    StatType.SkillLoreReligion,
                    StatType.SkillPerception,
                    StatType.SkillPersuasion,
                    StatType.SkillUseMagicDevice
                };
                    c.Selections = new SelectionEntry[] {
                    new SelectionEntry()
                    {
                        m_Selection = BasicFeatSelection.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            PowerAttack.ToReference<BlueprintFeatureReference>(),
                            CombatReflexes.ToReference<BlueprintFeatureReference>(),
                            ImprovedInitiative.ToReference<BlueprintFeatureReference>(),
                            Outflank.ToReference<BlueprintFeatureReference>(),
                            IronWill.ToReference<BlueprintFeatureReference>(),
                            IronWillImproved.ToReference<BlueprintFeatureReference>(),
                            Dodge.ToReference<BlueprintFeatureReference>(),
                            Toughness.ToReference<BlueprintFeatureReference>(),
                            SpellPenetration.ToReference<BlueprintFeatureReference>(),
                            GreaterSpellPenetration.ToReference<BlueprintFeatureReference>(),
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = IsekaiProtagonistBonusFeatSelection.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            Cleave.ToReference<BlueprintFeatureReference>(),
                            CleavingFinish.ToReference<BlueprintFeatureReference>(),
                            PointBlankShot.ToReference<BlueprintFeatureReference>(),
                            PreciseShot.ToReference<BlueprintFeatureReference>(),
                            DeadlyAim.ToReference<BlueprintFeatureReference>(),
                            GreatFortitude.ToReference<BlueprintFeatureReference>(),
                            GreatFortitudeImproved.ToReference<BlueprintFeatureReference>(),
                            LightningReflexes.ToReference<BlueprintFeatureReference>(),
                            LightningReflexesImproved.ToReference<BlueprintFeatureReference>(),
                            MaximizeSpellFeat.ToReference<BlueprintFeatureReference>(),
                            EmpowerSpellFeat.ToReference<BlueprintFeatureReference>(),
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = CheatSkillSelection.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            AutoQuickenFeature.ToReference<BlueprintFeatureReference>()
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = TrainingArcSelection.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            TrainingMontage.ToReference<BlueprintFeatureReference>(),
                            BodyStrengthening.ToReference<BlueprintFeatureReference>(),
                            SpellNegation.ToReference<BlueprintFeatureReference>(),
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = CharacterDevelopmentSelection1.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            BetaStrike.ToReference<BlueprintFeatureReference>(),
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = CharacterDevelopmentSelection2.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            AlphaStrike.ToReference<BlueprintFeatureReference>(),
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = CharacterDevelopmentSelection3.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            GammaStrike.ToReference<BlueprintFeatureReference>()
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = CharacterDevelopmentSelection4.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            MundaneAura.ToReference<BlueprintFeatureReference>()
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = CharacterDevelopmentSelection5.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            FireImmunity.ToReference<BlueprintFeatureReference>()
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = BeachEpisodeSelection.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            MasterSelf.ToReference<BlueprintFeatureReference>()
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = Adaptibility.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            SkillFocusPhysique.ToReference<BlueprintFeatureReference>()
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = AasimarHeritageSelection.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            AngelHeritage.ToReference<BlueprintFeatureReference>()
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = TieflingHeritageSelection.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            PitbornHeritage.ToReference<BlueprintFeatureReference>()
                        }
                    },
                    new SelectionEntry()
                    {
                        m_Selection = BackgroundBaseSelection.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[]{
                            BackgroundNone.ToReference<BlueprintFeatureReference>()
                        }
                    },
                };
                    c.m_SelectSpells = new BlueprintAbilityReference[]
                    {
                    // Level 1
                    IsekaiProtagonistSpellList.EnlargePersonAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ReducePersonAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.MageArmorAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.MagicWeaponAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.GreaseAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.MagicMissileAbility.ToReference<BlueprintAbilityReference>(),
                    //Level 2
                    IsekaiProtagonistSpellList.MageShieldAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.TrueStrikeAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.BlessAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ShieldOfFaithAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SleepAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.DivineFavorAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 3
                    IsekaiProtagonistSpellList.UnbreakableHeartAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.VanishAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.StunningBarrierAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.FeatherStepAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ExpeditiousRetreatAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.CureLightWoundsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.AidAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.AlignWeaponAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.BarkskinAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.GlitterdustAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.RestorationLesserAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ScorchingRayAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 4
                    IsekaiProtagonistSpellList.EntangleAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.FaerieFireAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.RemoveSicknessAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.RemoveFearAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonMonsterIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonNaturesAllyIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.AnimalAspectAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.FalseLifeAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SenseVitalsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.MirrorImageAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.CureModerateWoundsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.InvisibilityAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 5
                    IsekaiProtagonistSpellList.FoxsCunningAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.BearsEnduranceAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.BullsStrengthAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.EaglesSplendorAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.CatsGraceAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.OwlsWisdomAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.HasteAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.FireballAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.AnimateDeadAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.CureSeriousWoundsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ResistEnergyCommunalAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SlowAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 6
                    IsekaiProtagonistSpellList.HazeOfDreamsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.InflictLightWoundsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.LongstriderAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.RayOfEnfeeblementAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.TouchOfGracelessnessAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.CommandAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ProtectionFromArrowsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.RemoveParalysisAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ResisEnergyAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonElementalSmallAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonMonsterIIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonNaturesAllyIIAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 7
                    IsekaiProtagonistSpellList.AnimalAspectGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.BestowCurseAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.MagicWeaponGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.HeroismAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.MagicalVestmentAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ProtectionFromArrowsCommunalAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.CrusaderEdgeAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.DeathWardAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.FalseLifeGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.FreedomOfMovementAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ProtectionFromEnergyCommunalAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.RestorationAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 8
                    IsekaiProtagonistSpellList.PoxPustulesAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.PerniciousPoisonAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SeeInvisibilityAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.HoldAnimalAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.HoldPersonAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.InflictModerateWoundsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.DispelMagicAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.DisplacementAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.InflictSeriousWoundsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.PrayerAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ProtectionFromEnergyAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SeeInvisibilityCommunalAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 9
                    IsekaiProtagonistSpellList.CureCriticalWoundsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.InvisibilityGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.PhantasmalKillerAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonElementalMediumAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonMonsterIVAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonNaturesAllyIVAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.CureLightWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.InflictLightWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.TrueSeeingAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonElementalLargeAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonMonsterVAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonNaturesAllyVAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 10
                    IsekaiProtagonistSpellList.LightningBoltAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.RemoveBlindnessAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.RemoveCurseAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.RemoveDiseaseAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonMonsterIIIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonNaturesAllyIIIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.BoneshatterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ControlledFireballAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.DimensionDoorAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.DragonsBreathAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ElementalBodyIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.InflictCriticalWoundsAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 11
                    IsekaiProtagonistSpellList.BalefulPolymorphAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.BreathOfLifeAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.CaveFangsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.DominatePersonAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.MindFogAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.StoneskinCommunalAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.BearsEnduranceMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.BullsStrengthMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.EaglesSplendorMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.FoxsCunningMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.OwlsWisdomMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.CatsGraceMassAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 12
                    IsekaiProtagonistSpellList.EnervationAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.EnlargePersonMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.LifeBubbleAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ShadowConjurationAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ShieldOfDawnAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ThornBodyAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.BreakEnchantmentAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.BurstOfGloryAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ElementalBodyIIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.HoldMonsterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ShadowEvocationAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SpellResistanceAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 13
                    IsekaiProtagonistSpellList.CreateUndeadAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.CureModerateWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.FormOfTheDragonIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.EaglesoulAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ElementalBodyIIIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.InflictModerateWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.BestowCurseGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.CreepingDoomAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.FormOfTheDragonIIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ElementalBodyIVAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.LegendaryProportionsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.RestorationGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 14
                    IsekaiProtagonistSpellList.AnimalGrowthAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.HungryPitAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.PolymorphAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.RaiseDeadAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SerenityAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.FeeblemindAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.HarmAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.HealAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.HeroismGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonElementalHugeAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonMonsterVIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonNaturesAllyVIAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 15
                    IsekaiProtagonistSpellList.CureSeriousWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.InflictSeriousWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.InvisibilityMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.PolymorphGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ResurrectionAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.WavesOfExhaustionAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.DeathClutchAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.CureCriticalWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.InflictCriticalWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonElementalElderAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonMonsterVIIIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonNaturesAllyVIIIAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 16
                    IsekaiProtagonistSpellList.DispelMagicGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.EyebiteAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.InspiringRecoveryAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.PrimalRegressionAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SiroccoAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.StoneToFleshAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.FingerOfDeathAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.WalkThroughSpaceAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ShadowConjurationGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonElementalGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonMonsterVIIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonNaturesAllyVIIAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 17
                    IsekaiProtagonistSpellList.AngelicAspectGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.FrightfulAspectAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.HolyAuraAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.FormOfTheDragonIIIAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.IronBodyAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SeamantleAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.DominateMonsterAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.DeathClutchAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ElementalSwarmAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonElderWormAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonMonsterIXAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SummonNaturesAllyIXAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 18
                    IsekaiProtagonistSpellList.DestructionAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.HolyWordAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.FireStormAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.IceBodyAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.KiShoutAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.PrismaticSprayAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.MindBlankAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.PolarRayAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.StormboltsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ShieldOfLawAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.RiftOfRuinAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ShadowEvocationGreaterAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 19
                    IsekaiProtagonistSpellList.EuphoricTranquilityAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ScintillatingPatternAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ProtectionFromSpellsAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SouldreaverAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.SunburstAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.UnholyAuraAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.HealMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.MindBlankCommunalAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.HeroicInvocationAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ShadesAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.WeirdAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ShapechangeAbility.ToReference<BlueprintAbilityReference>(),
                    // Level 20
                    IsekaiProtagonistSpellList.EnergyDrainAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.FieryBodyAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.ForesightAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.HoldMonsterMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.IcyPrisonMassAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.OverwhelmingPresenceAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.PolarMidnightAbility.ToReference<BlueprintAbilityReference>(),
                    IsekaiProtagonistSpellList.WailOfBansheeAbility.ToReference<BlueprintAbilityReference>(),
                    };
                });
                bp.AddComponent<StatsDistributionPreset>(c => {
                    c.TargetPoints = 20;
                    c.Strength = 14;
                    c.Dexterity = 12;
                    c.Constitution = 8;
                    c.Intelligence = 10;
                    c.Wisdom = 12;
                    c.Charisma = 17;
                });
                bp.AddComponent<StatsDistributionPreset>(c => {
                    c.TargetPoints = 25;
                    c.Strength = 14;
                    c.Dexterity = 13;
                    c.Constitution = 8;
                    c.Intelligence = 10;
                    c.Wisdom = 12;
                    c.Charisma = 18;
                });
                bp.AddComponent<BuildBalanceRadarChart>(c => {
                    c.Control = 5;
                    c.Defense = 5;
                    c.Magic = 5;
                    c.Melee = 5;
                    c.Ranged = 5;
                    c.Support = 5;
                });
            });
            IsekaiProtagonistClass.m_DefaultBuild = PrebuildIsekaiProtagonistFeatureList.ToReference<BlueprintUnitFactReference>();
        }
    }
}
