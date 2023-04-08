using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
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

        private static readonly Sprite Icon_StartWeapon = AssetLoader.LoadInternal(IsekaiContext, "Features", "ICON_START_WEAPON.png");

        public static void Add() {
            var StartingWeaponDagger = CreateStartingWeaponFeature("StartingWeaponDagger", "You start with a cold iron dagger.", Dagger);
            var StartingWeaponLightMace = CreateStartingWeaponFeature("StartingWeaponLightMace", "You start with a cold iron light mace.", LightMace);
            var StartingWeaponPunchingDagger = CreateStartingWeaponFeature("StartingWeaponPunchingDagger", "You start with a cold iron punching dagger.", PunchingDagger);
            var StartingWeaponSickle = CreateStartingWeaponFeature("StartingWeaponSickle", "You start with a cold iron sickle.", Sickle);
            var StartingWeaponClub = CreateStartingWeaponFeature("StartingWeaponClub", "You start with a cold iron club.", Club);
            var StartingWeaponHeavyMace = CreateStartingWeaponFeature("StartingWeaponHeavyMace", "You start with a cold iron heavy mace.", HeavyMace);
            var StartingWeaponShortspear = CreateStartingWeaponFeature("StartingWeaponShortspear", "You start with a cold iron shortspear.", Shortspear);
            var StartingWeaponGreatclub = CreateStartingWeaponFeature("StartingWeaponGreatclub", "You start with a cold iron greatclub.", Greatclub);
            var StartingWeaponLongspear = CreateStartingWeaponFeature("StartingWeaponLongspear", "You start with a cold iron longspear.", Longspear);
            var StartingWeaponQuarterstaff = CreateStartingWeaponFeature("StartingWeaponQuarterstaff", "You start with a quarterstaff.", Quarterstaff);
            var StartingWeaponSpear = CreateStartingWeaponFeature("StartingWeaponSpear", "You start with a cold iron spear.", Spear);
            var StartingWeaponTrident = CreateStartingWeaponFeature("StartingWeaponTrident", "You start with a cold iron trident.", Trident);
            var StartingWeaponDart = CreateStartingWeaponFeature("StartingWeaponDart", "You start with a cold iron dart.", Dart);
            var StartingWeaponLightCrossbow = CreateStartingWeaponFeature("StartingWeaponLightCrossbow", "You start with a light crossbow.", LightCrossbow);
            var StartingWeaponHeavyCrossbow = CreateStartingWeaponFeature("StartingWeaponHeavyCrossbow", "You start with a heavy crossbow.", HeavyCrossbow);
            var StartingWeaponJavelin = CreateStartingWeaponFeature("StartingWeaponJavelin", "You start with a cold iron javelin.", Javelin);
            var StartingWeaponHandaxe = CreateStartingWeaponFeature("StartingWeaponHandaxe", "You start with a cold iron handaxe.", Handaxe);
            var StartingWeaponKukri = CreateStartingWeaponFeature("StartingWeaponKukri", "You start with a cold iron kukri.", Kukri);
            var StartingWeaponLightHammer = CreateStartingWeaponFeature("StartingWeaponLightHammer", "You start with a cold iron light hammer.", LightHammer);
            var StartingWeaponShortsword = CreateStartingWeaponFeature("StartingWeaponShortsword", "You start with a cold iron shortsword.", Shortsword);
            var StartingWeaponLightPick = CreateStartingWeaponFeature("StartingWeaponLightPick", "You start with a cold iron light pick.", LightPick);
            var StartingWeaponStarknife = CreateStartingWeaponFeature("StartingWeaponStarknife", "You start with a cold iron starknife.", Starknife);
            var StartingWeaponBattleaxe = CreateStartingWeaponFeature("StartingWeaponBattleaxe", "You start with a cold iron battleaxe.", Battleaxe);
            var StartingWeaponFlail = CreateStartingWeaponFeature("StartingWeaponFlail", "You start with a cold iron flail.", Flail);
            var StartingWeaponHeavyPick = CreateStartingWeaponFeature("StartingWeaponHeavyPick", "You start with a cold iron heavy pick.", HeavyPick);
            var StartingWeaponLongsword = CreateStartingWeaponFeature("StartingWeaponLongsword", "You start with a cold iron longsword.", Longsword);
            var StartingWeaponRapier = CreateStartingWeaponFeature("StartingWeaponRapier", "You start with a cold iron rapier.", Rapier);
            var StartingWeaponScimitar = CreateStartingWeaponFeature("StartingWeaponScimitar", "You start with a cold iron scimitar.", Scimitar);
            var StartingWeaponWarhammer = CreateStartingWeaponFeature("StartingWeaponWarhammer", "You start with a cold iron warhammer.", Warhammer);
            var StartingWeaponEarthbreaker = CreateStartingWeaponFeature("StartingWeaponEarthbreaker", "You start with a cold iron earthbreaker.", Earthbreaker);
            var StartingWeaponFalchion = CreateStartingWeaponFeature("StartingWeaponFalchion", "You start with a cold iron falchion.", Falchion);
            var StartingWeaponGlaive = CreateStartingWeaponFeature("StartingWeaponGlaive", "You start with a cold iron glaive.", Glaive);
            var StartingWeaponGreataxe = CreateStartingWeaponFeature("StartingWeaponGreataxe", "You start with a cold iron greataxe.", Greataxe);
            var StartingWeaponGreatsword = CreateStartingWeaponFeature("StartingWeaponGreatsword", "You start with a cold iron greatsword.", Greatsword);
            var StartingWeaponHeavyFlail = CreateStartingWeaponFeature("StartingWeaponHeavyFlail", "You start with a cold iron heavy flail.", HeavyFlail);
            var StartingWeaponScythe = CreateStartingWeaponFeature("StartingWeaponScythe", "You start with a cold iron scythe.", Scythe);
            var StartingWeaponShortbow = CreateStartingWeaponFeature("StartingWeaponShortbow", "You start with a shortbow.", Shortbow);
            var StartingWeaponLongbow = CreateStartingWeaponFeature("StartingWeaponLongbow", "You start with a longbow.", Longbow);
            var StartingWeaponKama = CreateStartingWeaponFeature("StartingWeaponKama", "You start with a cold iron kama.", Kama);
            var StartingWeaponNunchaku = CreateStartingWeaponFeature("StartingWeaponNunchaku", "You start with a cold iron nunchaku.", Nunchaku);
            var StartingWeaponSai = CreateStartingWeaponFeature("StartingWeaponSai", "You start with a cold iron sai.", Sai);
            var StartingWeaponBastardSword = CreateStartingWeaponFeature("StartingWeaponBastardSword", "You start with a cold iron bastard sword.", BastardSword);
            var StartingWeaponDuelingSword = CreateStartingWeaponFeature("StartingWeaponDuelingSword", "You start with a cold iron dueling sword.", DuelingSword);
            var StartingWeaponDwarvenWaraxe = CreateStartingWeaponFeature("StartingWeaponDwarvenWaraxe", "You start with a cold iron dwarven waraxe.", DwarvenWaraxe);
            var StartingWeaponEstoc = CreateStartingWeaponFeature("StartingWeaponEstoc", "You start with a cold iron estoc.", Estoc);
            var StartingWeaponFalcata = CreateStartingWeaponFeature("StartingWeaponFalcata", "You start with a cold iron falcata.", Falcata);
            var StartingWeaponTongi = CreateStartingWeaponFeature("StartingWeaponTongi", "You start with a cold iron tongi.", Tongi);
            var StartingWeaponElvenCurvedBlade = CreateStartingWeaponFeature("StartingWeaponElvenCurvedBlade", "You start with a cold iron elven curved blade.", ElvenCurvedBlade);
            var StartingWeaponFauchard = CreateStartingWeaponFeature("StartingWeaponFauchard", "You start with a cold iron fauchard.", Fauchard);
            var StartingWeaponBardiche = CreateStartingWeaponFeature("StartingWeaponBardiche", "You start with a cold iron bardiche.", Bardiche);
            var StartingWeaponDoubleSword = CreateStartingWeaponFeature("StartingWeaponDoubleSword", "You start with a cold iron double sword.", DoubleSword);
            var StartingWeaponDoubleAxe = CreateStartingWeaponFeature("StartingWeaponDoubleAxe", "You start with a cold iron double axe.", DoubleAxe);
            var StartingWeaponUrgrosh = CreateStartingWeaponFeature("StartingWeaponUrgrosh", "You start with a cold iron urgrosh.", Urgrosh);
            var StartingWeaponHookedHammer = CreateStartingWeaponFeature("StartingWeaponHookedHammer", "You start with a cold iron hooked hammer.", HookedHammer);
            var StartingWeaponThrowingAxe = CreateStartingWeaponFeature("StartingWeaponThrowingAxe", "You start with a cold iron throwing axe.", ThrowingAxe);

            var StartingWeaponSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "StartingWeaponSelection", bp => {
                bp.SetName(IsekaiContext, "Starting Weapon");
                bp.SetDescription(IsekaiContext, "At 1st level, you get to select a starting weapon. The weapon can be found in the Kenarbes festival chest.");
                bp.IgnorePrerequisites = true;
                bp.m_Icon = Icon_StartWeapon;
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
        private static BlueprintFeature CreateStartingWeaponFeature(string name, string description, BlueprintItemWeapon weapon) {
            return Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, name, bp => {
                bp.SetName(weapon.m_Type.Get().m_DefaultNameText);
                bp.SetDescription(IsekaiContext, description);
                bp.m_Icon = Icon_StartWeapon;
                bp.AddComponent<AddStartingEquipment>(c => {
                    c.m_BasicItems = new BlueprintItemReference[1] { weapon.ToReference<BlueprintItemReference>() };
                });
            });
        }
    }
}