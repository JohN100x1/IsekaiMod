using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Localization;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Utilities {

    public class StaticReferences {
        // Base Classes
        public static readonly BlueprintCharacterClass[] BaseClasses = new BlueprintCharacterClass[25] {
            ClassTools.Classes.AlchemistClass,
            ClassTools.Classes.ArcanistClass,
            ClassTools.Classes.BarbarianClass,
            ClassTools.Classes.BardClass,
            ClassTools.Classes.BloodragerClass,
            ClassTools.Classes.CavalierClass,
            ClassTools.Classes.ClericClass,
            ClassTools.Classes.DruidClass,
            ClassTools.Classes.FighterClass,
            ClassTools.Classes.HunterClass,
            ClassTools.Classes.InquisitorClass,
            ClassTools.Classes.KineticistClass,
            ClassTools.Classes.MagusClass,
            ClassTools.Classes.MonkClass,
            ClassTools.Classes.OracleClass,
            ClassTools.Classes.PaladinClass,
            ClassTools.Classes.RangerClass,
            ClassTools.Classes.RogueClass,
            ClassTools.Classes.ShamanClass,
            ClassTools.Classes.SkaldClass,
            ClassTools.Classes.SlayerClass,
            ClassTools.Classes.SorcererClass,
            ClassTools.Classes.WarpriestClass,
            ClassTools.Classes.WitchClass,
            ClassTools.Classes.WizardClass
        };

        // Sorcerer
        public static readonly BlueprintParametrizedFeature BloodlineArcaneNewArcanaFeature = BlueprintTools.GetBlueprint<BlueprintParametrizedFeature>("4a2e8388c2f0dd3478811d9c947bebfb");

        internal static class Strings {
            public static readonly LocalizedString Null = new();

            public static class Duration {
                public static readonly LocalizedString OneDay = new() { m_Key = "b2581d37-9b43-4473-a755-f675929feaa2" };
                public static readonly LocalizedString OneMinute = new() { m_Key = "70e2c2f0-b2c6-423a-b6ec-c05084530366" };
                public static readonly LocalizedString OneMinutePerLevel = new() { m_Key = "00b2e4c2-aafe-487b-b890-d57473373da7" };
                public static readonly LocalizedString OneRoundPerLevel = new() { m_Key = "6250ccf0-1ed0-460f-8ce7-094c2da7e198" };
                public static readonly LocalizedString UntilTargetOfSmiteIsDead = new() { m_Key = "cd623bdb-7aa6-43d2-afdc-865357596efb" };
            }

            public static class SavingThrow {
                public static readonly LocalizedString FortitudeNegates = new() { m_Key = "c8ec9dfb-37ba-485d-8c08-c45a6bfc88f3" };
                public static readonly LocalizedString FortitudePartial = new() { m_Key = "af1a01bb-3924-4663-94e8-79e080287aaa" };
                public static readonly LocalizedString WillNegates = new() { m_Key = "7ac9f1bb-ab14-4d64-8543-4c97a64a71bd" };
                public static readonly LocalizedString WillNegatesSaveEachRound = new() { m_Key = "50f1639f-a789-4939-bab6-557375828c4d" };
            }

            public static class ReplaceSpellbookDescription {
                public static readonly LocalizedString Loremaster = new() { m_Key = "c213f6d4-9760-4939-a9fe-9d34f9747240" };
                public static readonly LocalizedString HellknightSignifier = new() { m_Key = "eb71d1c5-c890-4c44-8790-2fb8c3621e55" };
                public static readonly LocalizedString ArcaneTrickster = new() { m_Key = "bf9c1e4a-5753-4705-9617-1a54ac291dfc" };
                public static readonly LocalizedString MysticTheurgeArcane = new() { m_Key = "296a19d9-bc24-47fd-a608-ba1aad556b9c" };
                public static readonly LocalizedString MysticTheurgeDivine = new() { m_Key = "801d1633-efa1-4ed2-83d1-337231705ae7" };
                public static readonly LocalizedString DragonDisciple = new() { m_Key = "9a186e08-9d9e-4dfb-98b9-d35127bad905" };
                public static readonly LocalizedString EldritchKnight = new() { m_Key = "cf828ba6-8a11-48b0-aa36-2d7972b51a5f" };
                public static readonly LocalizedString WinterWitch = new() { m_Key = "591fbec8-dac1-4198-9a1b-ae7921635af0" };
            }
        }

        internal static class Proficiencies {
            public static readonly BlueprintFeature LightArmorProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("6d3728d4e9c9898458fe5e9532951132");
            public static readonly BlueprintFeature MediumArmorProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("46f4fb320f35704488ba3d513397789d");
            public static readonly BlueprintFeature HeavyArmorProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("1b0f68188dcc435429fb87a022239681");
            public static readonly BlueprintFeature SimpleWeaponProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("e70ecf1ed95ca2f40b754f1adb22bbdd");
            public static readonly BlueprintFeature MartialWeaponProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("203992ef5b35c864390b4e4a1e200629");
            public static readonly BlueprintFeature ShieldsProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("cb8686e7357a68c42bdd9d4e65334633");
            public static readonly BlueprintFeature TowerShieldProficiency = BlueprintTools.GetBlueprint<BlueprintFeature>("6105f450bb2acbd458d277e71e19d835");
            public static BlueprintFeature ExoticWeaponProficiency => BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ExoticWeaponProficiency");
        }
    }
}
