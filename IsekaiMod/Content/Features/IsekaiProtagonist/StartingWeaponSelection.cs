using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {

    internal class StartingWeaponSelection {
        private static readonly BlueprintItemWeapon Dagger = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("b103b6468f2eff042903377b6ed940b2");
        private static readonly BlueprintItemWeapon LightMace = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("9d5b3d28fe5399f4ba4a82419f80cda3");
        private static readonly BlueprintItemWeapon PunchingDagger = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("3d168a6320ac93849b7b31c0c41f65c0");
        private static readonly BlueprintItemWeapon Sickle = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("abe43edfbd081854fa3657f854988446");
        private static readonly BlueprintItemWeapon Club = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("bba26f42561554b40be64f058eab152f");
        private static readonly BlueprintItemWeapon HeavyMace = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("4499f1b1dfc7a3d4ab1b95a13580e2e4");
        private static readonly BlueprintItemWeapon Shortspear = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("f713232cb92bde747aa32dc6b45f1ca7");
        private static readonly BlueprintItemWeapon Greatclub = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("34e7453f0e8403544b30bf593e03ebc8");
        private static readonly BlueprintItemWeapon Longspear = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("db54c32926dc3814685a6da455abbf84");
        private static readonly BlueprintItemWeapon Quarterstaff = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("ada85dae8d12eda4bbe6747bb8b5883c");
        private static readonly BlueprintItemWeapon Spear = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("f18a9ed7bcba738479b97162b9c77f46");
        private static readonly BlueprintItemWeapon Trident = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("fed59d344fe866d42a51c128dc1cc86b");
        private static readonly BlueprintItemWeapon Dart = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("aec0204879d450444b6a074b4bb3232d");
        private static readonly BlueprintItemWeapon LightCrossbow = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("511c97c1ea111444aa186b1a58496664");
        private static readonly BlueprintItemWeapon HeavyCrossbow = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("19a5092244dcf99478dcd73c974828b1");
        private static readonly BlueprintItemWeapon Javelin = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("df1b5a8490e8f9c4fbedad8f23a984b5");
        private static readonly BlueprintItemWeapon Handaxe = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("4759e289840c1c5439c5e5846109af9d");
        private static readonly BlueprintItemWeapon Kukri = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("d29f4f3f854fb8e43983e0983f2698fa");
        private static readonly BlueprintItemWeapon LightHammer = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("0d63566868570f04b9dd69398b7ae239");
        private static readonly BlueprintItemWeapon Shortsword = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("08c7987d7320d1645a4a1f005ab2dfcb");
        private static readonly BlueprintItemWeapon LightPick = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("5945fc0f6d86888418b9be7eefc09d98");
        private static readonly BlueprintItemWeapon Starknife = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("f01006f4204dc7a429997714196defe7");
        private static readonly BlueprintItemWeapon Battleaxe = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("2ae9c318e571f7d47b75f528606f0243");
        private static readonly BlueprintItemWeapon Flail = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("28c5eaa3604027941a9399433411f888");
        private static readonly BlueprintItemWeapon HeavyPick = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("fe703cbf712954d4c870ab0d35d7d7d5");
        private static readonly BlueprintItemWeapon Longsword = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("533e10c8b4c6a4940a3767d096f4f05d");
        private static readonly BlueprintItemWeapon Rapier = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("ec731c55e657cf0408fd89c648ccc536");
        private static readonly BlueprintItemWeapon Scimitar = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("ed7e22f153240d645af7a56c5bcf7faf");
        private static readonly BlueprintItemWeapon Warhammer = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("7590319dcdc11c9418d629ea37fbc68c");
        private static readonly BlueprintItemWeapon Earthbreaker = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("b7a78df8b24b8fb41823628caad28a0a");
        private static readonly BlueprintItemWeapon Falchion = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("a7b6e91cb2cd19846b360444e9645041");
        private static readonly BlueprintItemWeapon Glaive = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("af8d3a366d7874648a8a26ded274b1fd");
        private static readonly BlueprintItemWeapon Greataxe = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("d3e0da47c5aa08a468a09f295c2e69af");
        private static readonly BlueprintItemWeapon Greatsword = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("d48ee6124ad593f429e2e618726f2ef7");
        private static readonly BlueprintItemWeapon HeavyFlail = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("cfc52eb282dfe64459ef3e804bd265ec");
        private static readonly BlueprintItemWeapon Scythe = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("446a31d5375f43f45bf5fea69405120c");
        private static readonly BlueprintItemWeapon Shortbow = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("6d40d84e239bdf345b349ff52e3c00a9");
        private static readonly BlueprintItemWeapon Longbow = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("201f6150321e09048bd59e9b7f558cb0");
        private static readonly BlueprintItemWeapon Kama = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("1000fb244ea388c49978151cbddc0080");
        private static readonly BlueprintItemWeapon Nunchaku = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("3239a085ec94fb545ade6a41607c3049");
        private static readonly BlueprintItemWeapon Sai = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("9c7881ebbb9c96944ad18adca92fdb4c");
        private static readonly BlueprintItemWeapon BastardSword = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("200baf16628d3ab4b993094b51df5891");
        private static readonly BlueprintItemWeapon DuelingSword = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("7f2fa59c5b05df849a33e8a49e658137");
        private static readonly BlueprintItemWeapon DwarvenWaraxe = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("2c1665f62069e7f4581599cb04ba440e");
        private static readonly BlueprintItemWeapon Estoc = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("638db1905268b3845825ffa194b7415f");
        private static readonly BlueprintItemWeapon Falcata = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("413c2458f8e7a2c48a47723271a1fbb1");
        private static readonly BlueprintItemWeapon Tongi = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("4152f08d9f58b664d972349af8be70a5");
        private static readonly BlueprintItemWeapon ElvenCurvedBlade = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("a5cc3a9960e4105458366783d6f703d2");
        private static readonly BlueprintItemWeapon Fauchard = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("c4aa7ad69a9908740a8d6994f1cc8f54");
        private static readonly BlueprintItemWeapon Bardiche = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("d53aec4a36f36e44f84005441056bfd6");
        private static readonly BlueprintItemWeapon DoubleSword = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("93b62f230b22101419e7e7b0c2c12733");
        private static readonly BlueprintItemWeapon DoubleAxe = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("25e6b7c3685d14645bbd99dc19fba40b");
        private static readonly BlueprintItemWeapon Urgrosh = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("ecfaa8983906848479648ab0659d98f7");
        private static readonly BlueprintItemWeapon HookedHammer = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("3fb96c96ac146294ba1e92fdb9509a5d");
        private static readonly BlueprintItemWeapon ThrowingAxe = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("a29eacae30ee2f04398c3b2784861109");

        public static void Add() {
            var StartingWeaponDagger = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponDagger", bp => {
                bp.SetName(Dagger.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron dagger.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Dagger.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponLightMace = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponLightMace", bp => {
                bp.SetName(LightMace.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron light mace.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { LightMace.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponPunchingDagger = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponPunchingDagger", bp => {
                bp.SetName(PunchingDagger.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron punching dagger.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { PunchingDagger.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponSickle = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponSickle", bp => {
                bp.SetName(Sickle.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron sickle.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Sickle.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponClub = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponClub", bp => {
                bp.SetName(Club.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron club.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Club.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponHeavyMace = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponHeavyMace", bp => {
                bp.SetName(HeavyMace.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron heavy mace.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { HeavyMace.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponShortspear = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponShortspear", bp => {
                bp.SetName(Shortspear.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron shortspear.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Shortspear.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponGreatclub = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponGreatclub", bp => {
                bp.SetName(Greatclub.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron greatclub.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Greatclub.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponLongspear = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponLongspear", bp => {
                bp.SetName(Longspear.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron longspear.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Longspear.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponQuarterstaff = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponQuarterstaff", bp => {
                bp.SetName(Quarterstaff.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a quarterstaff.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Quarterstaff.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponSpear = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponSpear", bp => {
                bp.SetName(Spear.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron spear.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Spear.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponTrident = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponTrident", bp => {
                bp.SetName(Trident.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron trident.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Trident.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponDart = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponDart", bp => {
                bp.SetName(Dart.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron dart.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Dart.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponLightCrossbow = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponLightCrossbow", bp => {
                bp.SetName(LightCrossbow.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a light crossbow.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { LightCrossbow.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponHeavyCrossbow = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponHeavyCrossbow", bp => {
                bp.SetName(HeavyCrossbow.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a heavy crossbow.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { HeavyCrossbow.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponJavelin = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponJavelin", bp => {
                bp.SetName(Javelin.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron javelin.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Javelin.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponHandaxe = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponHandaxe", bp => {
                bp.SetName(Handaxe.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron handaxe.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Handaxe.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponKukri = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponKukri", bp => {
                bp.SetName(Kukri.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron kukri.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Kukri.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponLightHammer = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponLightHammer", bp => {
                bp.SetName(LightHammer.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron light hammer.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { LightHammer.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponShortsword = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponShortsword", bp => {
                bp.SetName(Shortsword.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron shortsword.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Shortsword.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponLightPick = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponLightPick", bp => {
                bp.SetName(LightPick.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron light pick.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { LightPick.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponStarknife = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponStarknife", bp => {
                bp.SetName(Starknife.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron starknife.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Starknife.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponBattleaxe = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponBattleaxe", bp => {
                bp.SetName(Battleaxe.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron battleaxe.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Battleaxe.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponFlail = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponFlail", bp => {
                bp.SetName(Flail.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron flail.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Flail.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponHeavyPick = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponHeavyPick", bp => {
                bp.SetName(HeavyPick.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron heavy pick.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { HeavyPick.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponLongsword = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponLongsword", bp => {
                bp.SetName(Longsword.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron longsword.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Longsword.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponRapier = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponRapier", bp => {
                bp.SetName(Rapier.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron rapier.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Rapier.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponScimitar = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponScimitar", bp => {
                bp.SetName(Scimitar.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron scimitar.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Scimitar.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponWarhammer = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponWarhammer", bp => {
                bp.SetName(Warhammer.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron warhammer.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Warhammer.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponEarthbreaker = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponEarthbreaker", bp => {
                bp.SetName(Earthbreaker.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron earthbreaker.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Earthbreaker.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponFalchion = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponFalchion", bp => {
                bp.SetName(Falchion.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron falchion.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Falchion.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponGlaive = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponGlaive", bp => {
                bp.SetName(Glaive.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron glaive.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Glaive.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponGreataxe = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponGreataxe", bp => {
                bp.SetName(Greataxe.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron greataxe.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Greataxe.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponGreatsword = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponGreatsword", bp => {
                bp.SetName(Greatsword.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron greatsword.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Greatsword.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponHeavyFlail = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponHeavyFlail", bp => {
                bp.SetName(HeavyFlail.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron heavy flail.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { HeavyFlail.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponScythe = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponScythe", bp => {
                bp.SetName(Scythe.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron scythe.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Scythe.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponShortbow = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponShortbow", bp => {
                bp.SetName(Shortbow.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a shortbow.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Shortbow.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponLongbow = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponLongbow", bp => {
                bp.SetName(Longbow.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a longbow.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Longbow.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponKama = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponKama", bp => {
                bp.SetName(Kama.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron kama.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Kama.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponNunchaku = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponNunchaku", bp => {
                bp.SetName(Nunchaku.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron nunchaku.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Nunchaku.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponSai = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponSai", bp => {
                bp.SetName(Sai.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron sai.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Sai.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponBastardSword = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponBastardSword", bp => {
                bp.SetName(BastardSword.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron bastard sword.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { BastardSword.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponDuelingSword = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponDuelingSword", bp => {
                bp.SetName(DuelingSword.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron dueling sword.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { DuelingSword.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponDwarvenWaraxe = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponDwarvenWaraxe", bp => {
                bp.SetName(DwarvenWaraxe.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron dwarven waraxe.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { DwarvenWaraxe.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponEstoc = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponEstoc", bp => {
                bp.SetName(Estoc.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron estoc.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Estoc.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponFalcata = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponFalcata", bp => {
                bp.SetName(Falcata.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron falcata.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Falcata.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponTongi = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponTongi", bp => {
                bp.SetName(Tongi.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron tongi.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Tongi.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponElvenCurvedBlade = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponElvenCurvedBlade", bp => {
                bp.SetName(ElvenCurvedBlade.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron elven curved blade.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { ElvenCurvedBlade.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponFauchard = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponFauchard", bp => {
                bp.SetName(Fauchard.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron fauchard.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Fauchard.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponBardiche = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponBardiche", bp => {
                bp.SetName(Bardiche.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron bardiche.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Bardiche.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponDoubleSword = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponDoubleSword", bp => {
                bp.SetName(DoubleSword.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron double sword.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { DoubleSword.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponDoubleAxe = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponDoubleAxe", bp => {
                bp.SetName(DoubleAxe.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron double axe.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { DoubleAxe.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponUrgrosh = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponUrgrosh", bp => {
                bp.SetName(Urgrosh.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron urgrosh.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { Urgrosh.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponHookedHammer = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponHookedHammer", bp => {
                bp.SetName(HookedHammer.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron hooked hammer.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { HookedHammer.ToReference<BlueprintItemReference>() };
                });
            });
            var StartingWeaponThrowingAxe = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "StartingWeaponThrowingAxe", bp => {
                bp.SetName(ThrowingAxe.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, "You start with a cold iron throwing axe.");
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { ThrowingAxe.ToReference<BlueprintItemReference>() };
                });
            });

            var StartingWeaponSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "StartingWeaponSelection", bp => {
                bp.SetName(IsekaiContext, "Starting Weapon");
                bp.SetDescription(IsekaiContext, "At 1st level, you get to select a starting weapon. The weapon can be found in the Kenarbes festival chest.");
                bp.IgnorePrerequisites = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[55] {
                    StartingWeaponDagger.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponLightMace.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponPunchingDagger.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponSickle.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponClub.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponHeavyMace.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponShortspear.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponGreatclub.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponLongspear.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponQuarterstaff.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponSpear.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponTrident.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponDart.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponLightCrossbow.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponHeavyCrossbow.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponJavelin.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponHandaxe.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponKukri.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponLightHammer.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponShortsword.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponLightPick.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponStarknife.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponBattleaxe.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponFlail.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponHeavyPick.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponLongsword.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponRapier.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponScimitar.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponWarhammer.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponEarthbreaker.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponFalchion.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponGlaive.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponGreataxe.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponGreatsword.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponHeavyFlail.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponScythe.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponShortbow.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponLongbow.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponKama.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponNunchaku.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponSai.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponBastardSword.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponDuelingSword.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponDwarvenWaraxe.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponEstoc.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponFalcata.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponTongi.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponElvenCurvedBlade.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponFauchard.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponBardiche.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponDoubleSword.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponDoubleAxe.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponUrgrosh.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponHookedHammer.ToReference<BlueprintFeatureReference>(),
                    StartingWeaponThrowingAxe.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}