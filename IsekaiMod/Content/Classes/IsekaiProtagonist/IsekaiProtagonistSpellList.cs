using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist
{
    class IsekaiProtagonistSpellList
    {
        // Spells - 0
        public static readonly BlueprintAbility MageLightAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("95f206566c5261c42aa5b3e7e0d1e36c");
        public static readonly BlueprintAbility JoltAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("16e23c7a8ae53cc42a93066d19766404");
        public static readonly BlueprintAbility DisruptUndeadAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("652739779aa05504a9ad5db1db6d02ae");
        public static readonly BlueprintAbility AcidSplashAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("0c852a2405dd9f14a8bbcfaf245ff823");
        public static readonly BlueprintAbility DismissAreaEffectAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("97a23111df7547fd8f6417f9ba9b9775");
        public static readonly BlueprintAbility DazeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("55f14bc84d7c85446b07a1b5dd6b2b4c");
        public static readonly BlueprintAbility TouchOfFatigueAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5bf3315ce1ed4d94e8805706820ef64d");
        public static readonly BlueprintAbility FlareAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f0f8e5b9808f44e4eadd22b138131d52");
        public static readonly BlueprintAbility RayOfFrostAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("9af2ab69df6538f4793b2f9c3cc85603");
        public static readonly BlueprintAbility ResistanceAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7bc8e27cba24f0e43ae64ed201ad5785");
        public static readonly BlueprintAbility DivineZapAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("8a1992f59e06dd64ab9ba52337bf8cb5");
        public static readonly BlueprintAbility GuidanceAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c3a8f31778c3980498d8f00c980be5f5");
        public static readonly BlueprintAbility VirtueAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d3a852385ba4cd740992d1970170301a");

        // Spells - 1
        public static readonly BlueprintAbility SnowBallAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("9f10909f0be1f5141bf1c102041f93d9");
        public static readonly BlueprintAbility VanishAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f001c73999fb5a543a199f890108d936");
        public static readonly BlueprintAbility ColorSprayAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("91da41b9793a4624797921f221db653c");
        public static readonly BlueprintAbility ShockingGraspAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ab395d2335d3f384e99dddee8562978f");
        public static readonly BlueprintAbility MagicWeaponAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d7fdd79f0f6b6a2418298e936bb68e40");
        public static readonly BlueprintAbility EarPiercingScreamAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("8e7cfa5f213a90549aadd18f8f6f4664");
        public static readonly BlueprintAbility StunningBarrierAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a5ec7892fb1c2f74598b3a82f3fd679f");
        public static readonly BlueprintAbility MageShieldAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ef768022b0785eb43a18969903c537c4");
        public static readonly BlueprintAbility CorrosiveTouchAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("95810d2829895724f950c8c4086056e7");
        public static readonly BlueprintAbility ExpeditiousRetreatAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4f8181e7a7f1d904fbaea64220e83379");
        public static readonly BlueprintAbility TouchOfGracelessnessAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ad10bfec6d7ae8b47870e3a545cc8900");
        public static readonly BlueprintAbility MagicMissileAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
        public static readonly BlueprintAbility ProtectionFromAlignmentAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("433b1faf4d02cc34abb0ade5ceda47c4");
        public static readonly BlueprintAbility BurningHandsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4783c3709a74a794dbe7c8e7e0b1b038");
        public static readonly BlueprintAbility CauseFearAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("bd81a3931aa285a4f9844585b5d97e51");
        public static readonly BlueprintAbility TrueStrikeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("2c38da66e5a599347ac95b3294acbe00");
        public static readonly BlueprintAbility FlareBurstAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("39a602aa80cc96f4597778b6d4d49c0a");
        public static readonly BlueprintAbility HurricaneBowAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("3e9d1119d43d07c4c8ba9ebfd1671952");
        public static readonly BlueprintAbility MageArmorAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("9e1ad5d6f87d19e4d8883d63a6e35568");
        public static readonly BlueprintAbility GreaseAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("95851f6e85fe87d4190675db0419d112");
        public static readonly BlueprintAbility SleepAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("bb7ecad2d3d2c8247a38f44855c99061");
        public static readonly BlueprintAbility ReducePersonAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4e0e9aba6447d514f88eff1464cc4763");
        public static readonly BlueprintAbility RayOfSickeningAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("fa3078b9976a5b24caf92e20ee9c0f54");
        public static readonly BlueprintAbility StoneFistAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("85067a04a97416949b5d1dbf986d93f3");
        public static readonly BlueprintAbility RayOfEnfeeblementAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("450af0402422b0b4980d9c2175869612");
        public static readonly BlueprintAbility SummonMonsterIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("8fd74eddd9b6c224693d9ab241f25e84");
        public static readonly BlueprintAbility EnlargePersonAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c60969e7f264e6d4b84a1499fdcf9039");
        public static readonly BlueprintAbility HypnotismAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("88367310478c10b47903463c5d0152b0");
        public static readonly BlueprintAbility BaneAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("8bc64d869456b004b9db255cdd1ea734");
        public static readonly BlueprintAbility BlessAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("90e59f4a4ada87243b7b3535a06d0638");
        public static readonly BlueprintAbility CureLightWoundsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5590652e1c2225c4ca30c4a699ab3649");
        public static readonly BlueprintAbility DivineFavorAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("9d5d2d3ffdd73c648af3eb3e585b1113");
        public static readonly BlueprintAbility DoomAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("fbdd8c455ac4cde4a9a3e18c84af9485");
        public static readonly BlueprintAbility FirebellyAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("b065231094a21d14dbf1c3832f776871");
        public static readonly BlueprintAbility InflictLightWoundsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e5af3674bb241f14b9a9f6b0c7dc3d27");
        public static readonly BlueprintAbility RemoveFearAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("55a037e514c0ee14a8e3ed14b47061de");
        public static readonly BlueprintAbility RemoveSicknessAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f6f95242abdfac346befd6f4f6222140");
        public static readonly BlueprintAbility ShieldOfFaithAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("183d5bb91dea3a1489a6db6c9cb64445");
        public static readonly BlueprintAbility UnbreakableHeartAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("dd38f33c56ad00a4da386c1afaa49967");
        public static readonly BlueprintAbility HazeOfDreamsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("40ec382849b60504d88946df46a10f2d");
        public static readonly BlueprintAbility CommandAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("feb70aab86cc17f4bb64432c83737ac2");
        public static readonly BlueprintAbility SummonNaturesAllyIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c6147854641924442a3bb736080cfeb6");
        public static readonly BlueprintAbility AcidMawAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("75de4ded3e731dc4f84d978fe947dc67");
        public static readonly BlueprintAbility MagicFangAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("403cf599412299a4f9d5d925c7b9fb33");
        public static readonly BlueprintAbility AspectOfTheFalconAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7bdb6a9fb6b37614e96f155748ae50c6");
        public static readonly BlueprintAbility FeatherStepAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f3c0b267dd17a2a45a40805e31fe3cd1");
        public static readonly BlueprintAbility EntangleAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("0fd00984a2c0e0a429cf1a911b4ec5ca");
        public static readonly BlueprintAbility FaerieFireAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4d9bf81b7939b304185d58a09960f589");
        public static readonly BlueprintAbility LongstriderAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("14c90900b690cac429b229efdf416127");
        public static readonly BlueprintAbility LeadBladesAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("779179912e6c6fe458fa4cfb90d96e10");
        public static readonly BlueprintAbility ChallengeEvilAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("57aae1aa36b8022479e1cd39f3a85ef9");
        public static readonly BlueprintAbility VeilOfHeavenAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("72d9f5adda6387a40a63c49d7781bbbf");
        public static readonly BlueprintAbility VeilOfPositiveEnergyAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("6bb0533cd457d1f4eaccc73ab7680fb2");

        // Spells - 2
        public static readonly BlueprintAbility OwlsWisdomAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f0455c9295b53904f9e02fc571dd2ce1");
        public static readonly BlueprintAbility BurningArcAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("eaac3d36e0336cb479209a6f65e25e7c");
        public static readonly BlueprintAbility FalseLifeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7a5b5bf845779a941a67251539545762");
        public static readonly BlueprintAbility AnimalAspectAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d4b28341acdfa9443a3a779acb58be51");
        public static readonly BlueprintAbility SummonElementalSmallAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("970c6db48ff0c6f43afc9dbb48780d03");
        public static readonly BlueprintAbility BoneShakerAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("b7731c2b4fa1c9844a092329177be4c3");
        public static readonly BlueprintAbility StoneCallAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5181c2ed0190fc34b8a1162783af5bf4");
        public static readonly BlueprintAbility HideousLaughterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("fd4d9fd7f87575d47aafe2a64a6e2d8d");
        public static readonly BlueprintAbility MoltenOrbAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("42a65895ba0cb3a42b6019039dd2bff1");
        public static readonly BlueprintAbility ProtectionFromAlignmentCommunalAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("2cadf6c6350e4684baa109d067277a45");
        public static readonly BlueprintAbility AcidArrowAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("9a46dfd390f943647ab4395fc997936d");
        public static readonly BlueprintAbility SeeInvisibilityAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("30e5dc243f937fc4b95d2f8f4e1b7ff3");
        public static readonly BlueprintAbility ScorchingRayAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("cdb106d53c65bbc4086183d54c3b97c7");
        public static readonly BlueprintAbility ScareAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("08cb5f4c3b2695e44971bf5c45205df0");
        public static readonly BlueprintAbility BullsStrengthAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4c3d08935262b6544ae97599b3a9556d");
        public static readonly BlueprintAbility GlitterdustAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ce7dad2b25acf85429b6c9550787b2d9");
        public static readonly BlueprintAbility CreatePitAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("29ccc62632178d344ad0be0865fd3113");
        public static readonly BlueprintAbility BearsEnduranceAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a900628aea19aa74aad0ece0e65d091a");
        public static readonly BlueprintAbility SenseVitalsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("82962a820ebc0e7408b8582fdc3f4c0c");
        public static readonly BlueprintAbility EaglesSplendorAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("446f7bf201dc1934f96ac0a26e324803");
        public static readonly BlueprintAbility ResisEnergyAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("21ffef7791ce73f468b6fca4d9371e8b");
        public static readonly BlueprintAbility CommandUndeadAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("0b101dd5618591e478f825f0eef155b4");
        public static readonly BlueprintAbility BlurAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("14ec7a4e52e90fa47a4c8d63c69fd5c1");
        public static readonly BlueprintAbility ProtectionFromArrowsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c28de1f98a3f432448e52e5d47c73208");
        public static readonly BlueprintAbility PerniciousPoisonAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("dee3074b2fbfb064b80b973f9b56319e");
        public static readonly BlueprintAbility MirrorImageAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
        public static readonly BlueprintAbility WebAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("134cb6d492269aa4f8662700ef57449f");
        public static readonly BlueprintAbility InvisibilityAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("89940cde01689fb46946b2f8cd7b66b7");
        public static readonly BlueprintAbility BlindnessAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("46fd02ad56c35224c9c91c88cd457791");
        public static readonly BlueprintAbility FrigidTouchAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("b6010dda6333bcf4093ce20f0063cd41");
        public static readonly BlueprintAbility CatsGraceAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("de7a025d48ad5da4991e7d3c682cf69d");
        public static readonly BlueprintAbility SummonMonsterIIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1724061e89c667045a6891179ee2e8e7");
        public static readonly BlueprintAbility FoxsCunningAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ae4d3ad6a8fda1542acf2e9bbc13d113");
        public static readonly BlueprintAbility ArrowOfLawAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("dd2a5a6e76611c04e9eac6254fcf8c6b");
        public static readonly BlueprintAbility AidAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("03a9630394d10164a9410882d31572f0");
        public static readonly BlueprintAbility BlessingOfCourageAndLifeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c36c1d11771b0584f8e100b92ee5475b");
        public static readonly BlueprintAbility BlessingOfLuckAndResolveAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("9a7e3cd1323dfe347a6dcce357844769");
        public static readonly BlueprintAbility CureModerateWoundsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("6b90c773a6543dc49b2505858ce33db5");
        public static readonly BlueprintAbility DelayPoisonAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("b48b4c5ffb4eab0469feba27fc86a023");
        public static readonly BlueprintAbility EffortlessArmorAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e1291272c8f48c14ab212a599ad17aac");
        public static readonly BlueprintAbility FindTrapsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4709274b2080b6444a3c11c6ebbe2404");
        public static readonly BlueprintAbility GraceAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("464a7193519429f48b4d190acb753cf0");
        public static readonly BlueprintAbility InflictModerateWoundsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("65f0b63c45ea82a4f8b8325768a3832d");
        public static readonly BlueprintAbility RemoveParalysisAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f8bce986adfc88544a42bf4ab7ae75b2");
        public static readonly BlueprintAbility RestorationLesserAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e84fc922ccf952943b5240293669b171");
        public static readonly BlueprintAbility SoundBurstAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c3893092a333b93499fd0a21845aa265");
        public static readonly BlueprintAbility HoldPersonAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c7104f7526c4c524f91474614054547e");
        public static readonly BlueprintAbility AlignWeaponAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d026d5c80dbb9224f9a97fec83f5644a");
        public static readonly BlueprintAbility PoxPustulesAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("bc153808ef4884a4594bc9bec2299b69");
        public static readonly BlueprintAbility NaturalRythmAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("dde924776bd7ad247928b5efbfacfbdd");
        public static readonly BlueprintAbility SummonNaturesAllyIIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("298148133cdc3fd42889b99c82711986");
        public static readonly BlueprintAbility BarkskinAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5b77d7cc65b8ab74688e74a37fc2f553");
        public static readonly BlueprintAbility HoldAnimalAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("41bab342089c0254ca222eb918e98cd4");
        public static readonly BlueprintAbility AspectOfTheBearAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a4ad1b8fa11e7c347a608c004efce9d5");
        public static readonly BlueprintAbility SickeningEntanglementAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("6c7467f0344004d48848a43d8c078bf8");
        public static readonly BlueprintAbility ChameleonStrideAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("27bf851c585817c4fbd079c970a162fa");
        public static readonly BlueprintAbility CastigateAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ce4c4e52c53473549ae033e2bb44b51a");
        public static readonly BlueprintAbility CacophonousCallAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e6048d85fc3294f4c92b21c8d7526b1f");
        public static readonly BlueprintAbility BestowGraceAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("042aaa117e89c4d4b8cb41478dd3fca3");

        // Spells - 3
        public static readonly BlueprintAbility VampiricTouchAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("8a28a811ca5d20d49a863e832c31cce1");
        public static readonly BlueprintAbility MagicWeaponGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("0f92caa35619f234298d95a4b6dda90d");
        public static readonly BlueprintAbility ProtectionFromArrowsCommunalAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("96c9d98b6a9a7c249b6c4572e4977157");
        public static readonly BlueprintAbility ProtectionFromEnergyAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d2f116cfe05fcdd4a94e80143b67046f");
        public static readonly BlueprintAbility SeeInvisibilityCommunalAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1a045f845778dc54db1c2be33a8c3c0a");
        public static readonly BlueprintAbility RageAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("97b991256e43bb140b263c326f690ce2");
        public static readonly BlueprintAbility HasteAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
        public static readonly BlueprintAbility LightningBoltAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73");
        public static readonly BlueprintAbility DisplacementAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
        public static readonly BlueprintAbility SummonMonsterIIIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5d61dde0020bbf54ba1521f7ca0229dc");
        public static readonly BlueprintAbility BatteringBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("0a2f7c6aa81bc6548ac7780d8b70bcbc");
        public static readonly BlueprintAbility ForcePunchAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("fc58ddcff6ab1394eb6c18e9126bb990");
        public static readonly BlueprintAbility SlowAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f492622e473d34747806bdb39356eb89");
        public static readonly BlueprintAbility SpikedPitAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("46097f610219ac445b4d6403fc596b9f");
        public static readonly BlueprintAbility StinkingCloudAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("68a9e6d7256f1354289a39003a46d826");
        public static readonly BlueprintAbility BlinkAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("045351f1421ee3f449a9143db701d192");
        public static readonly BlueprintAbility HeroismAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5ab0d42fb68c9e34abae4921822b9d63");
        public static readonly BlueprintAbility DeepSlumberAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7658b74f626c56a49939d9c20580885e");
        public static readonly BlueprintAbility FireballAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("2d81362af43aeac4387a3d4fced489c3");
        public static readonly BlueprintAbility BeastShapeIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("61a7ed778dd93f344a5dacdbad324cc9");
        public static readonly BlueprintAbility ResistEnergyCommunalAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7bb0c402f7f789d4d9fae8ca87b4c7e2");
        public static readonly BlueprintAbility DispelMagicAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("92681f181b507b34ea87018e8f7a528a");
        public static readonly BlueprintAbility RayOfExhaustionAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("8eead52509987034ea9025d60cc05985");
        public static readonly BlueprintAbility ArchonsAuraAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e67efd8c84f69d24ab472c9f546fff7e");
        public static readonly BlueprintAbility BestowCurseAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("989ab5c44240907489aba0a8568d0603");
        public static readonly BlueprintAbility ContagionAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("48e2744846ed04b4580be1a3343a5d3d");
        public static readonly BlueprintAbility CureSeriousWoundsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("3361c5df793b4c8448756146a88026ad");
        public static readonly BlueprintAbility DelayPoisonCommunalAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("04e820e1ce3a66f47a50ad5074d3ae40");
        public static readonly BlueprintAbility InflictSeriousWoundsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("bd5da98859cf2b3418f6d68ea66cabbe");
        public static readonly BlueprintAbility MagicalVestmentAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("2d4263d80f5136b4296d6eb43a221d7d");
        public static readonly BlueprintAbility PrayerAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("faabd2cc67efa4646ac58c7bb3e40fcc");
        public static readonly BlueprintAbility RemoveBlindnessAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c927a8b0cd3f5174f8c0b67cdbfde539");
        public static readonly BlueprintAbility RemoveCurseAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("b48674cef2bff5e478a007cf57d8345b");
        public static readonly BlueprintAbility RemoveDiseaseAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4093d5a0eb5cae94e909eb1e0e1a6b36");
        public static readonly BlueprintAbility SearingLightAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("bf0accce250381a44b857d4af6c8e10d");
        public static readonly BlueprintAbility AnimateDeadAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4b76d32feb089ad4499c3a1ce8e1ac27");
        public static readonly BlueprintAbility FeatherStepMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d219494150ac1f24f9ce14a3d4f66d26");
        public static readonly BlueprintAbility CallLightningAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("2a9ef0e0b5822a24d88b16673a267456");
        public static readonly BlueprintAbility PoisonAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("2a6eda8ef30379142a4b75448fb214a3");
        public static readonly BlueprintAbility SpitVenomAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("9779c8578acd919419f563c33d7b2af5");
        public static readonly BlueprintAbility MagicFangGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f1100650705a69c4384d3edd88ba0f52");
        public static readonly BlueprintAbility LongstriderGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e80a4d6c0efa5774cbd515e3e37095b0");
        public static readonly BlueprintAbility NeutralizePoisonAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e7240516af4241b42b2cd819929ea9da");
        public static readonly BlueprintAbility DominateAnimalAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("754c478a2aa9bb54d809e648c3f7ac0e");
        public static readonly BlueprintAbility SummonNaturesAllyIIIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("fdcf7e57ec44f704591f11b45f4acf61");
        public static readonly BlueprintAbility SoothingMudAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1a36c8b9ed655c249a9f9e8d4731f001");
        public static readonly BlueprintAbility SpikeGrowthAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("29b0f9026ad05e14789d84e867cc6dff");
        public static readonly BlueprintAbility AnimalAspectGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c9c56af3b25be3942aa0ffd12f11cf35");
        public static readonly BlueprintAbility ChameleonStrideGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7ec0ffdd8779c344f85337109af0c6c5");
        public static readonly BlueprintAbility InstantEnemyAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("42c78009dd5cb8e429b27c13d92152b7");
        public static readonly BlueprintAbility FesterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("2dbe271c979d9104c8e2e6b42e208e32");
        public static readonly BlueprintAbility LitanyOfEloquenceAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c9198d9dfd2515d4ba98335b57bb66c7");
        public static readonly BlueprintAbility LitanyOfEntanglementAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("16f7754287811724abe1e0ead88f74ca");
        public static readonly BlueprintAbility GoodHopeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a5e23522eda32dc45801e32c05dc9f96");
        public static readonly BlueprintAbility ThunderingDrumsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c26eeeeabf732914ba723f2b67fe9b9d");
        public static readonly BlueprintAbility HolyWhisperAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5f1ca17be3ba44949be427f18e696d9b");

        // Spells - 4
        public static readonly BlueprintAbility OverwhelmingGriefAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("dd2918e4a77c50044acba1ac93494c36");
        public static readonly BlueprintAbility CrushingDespairAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4baf4109145de4345861fe0f2209d903");
        public static readonly BlueprintAbility ObsidianFlowAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e48638596c955a74c8a32dbc90b518c1");
        public static readonly BlueprintAbility RainbowPatternAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4b8265132f9c8174f87ce7fa6d0fe47b");
        public static readonly BlueprintAbility BoneshatterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f2f1efac32ea2884e84ecaf14657298b");
        public static readonly BlueprintAbility SummonMonsterIVAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7ed74a3ec8c458d4fb50b192fd7be6ef");
        public static readonly BlueprintAbility VolcanicStormAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("16ce660837fb2544e96c3b7eaad73c63");
        public static readonly BlueprintAbility ControlledFireballAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f72f8f03bf0136c4180cd1d70eb773a5");
        public static readonly BlueprintAbility ProtectionFromEnergyCommunalAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("76a629d019275b94184a1a8733cac45e");
        public static readonly BlueprintAbility ConfusionAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("cf6c901fb7acc904e85c63b342e9c949");
        public static readonly BlueprintAbility FalseLifeGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("dc6af3b4fd149f841912d8a3ce0983de");
        public static readonly BlueprintAbility FearAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d2aeac47450c76347aebbc02e4f463e0");
        public static readonly BlueprintAbility DragonsBreathAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5e826bcdfde7f82468776b55315b2403");
        public static readonly BlueprintAbility BeastShapeIIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5d4028eb28a106d4691ed1b92bbb1915");
        public static readonly BlueprintAbility ShoutAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f09453607e683784c8fca646eec49162");
        public static readonly BlueprintAbility TouchOfSlimeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("84ccca10da2a4484c89a837fbea2a829");
        public static readonly BlueprintAbility SymbolOfRevelationAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("48a555180a109e545a6e367b1bd3f535");
        public static readonly BlueprintAbility IceStormAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("fcb028205a71ee64d98175ff39a0abf9");
        public static readonly BlueprintAbility DimensionDoorAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4a648b57935a59547b7a2ee86fb4f26a");
        public static readonly BlueprintAbility EnervationAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f34fb78eaaec141469079af124bcfa0f");
        public static readonly BlueprintAbility StoneskinAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c66e86905f7606c4eaa5c774f0357b2b");
        public static readonly BlueprintAbility PhantasmalKillerAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("6717dbaef00c0eb4897a1c908a75dfe5");
        public static readonly BlueprintAbility SummonElementalMediumAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e42b1dbff4262c6469a9ff0a6ce730e3");
        public static readonly BlueprintAbility ShadowConjurationAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("caac251ca7601324bbe000372a0a1005");
        public static readonly BlueprintAbility AcidPitAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1407fb5054d087d47a4c40134c809f12");
        public static readonly BlueprintAbility ReducePersonMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("2427f2e3ca22ae54ea7337bbab555b16");
        public static readonly BlueprintAbility ElementalBodyIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("690c90a82bf2e58449c6b541cb8ea004");
        public static readonly BlueprintAbility EnlargePersonMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("66dc49bf154863148bd217287079245e");
        public static readonly BlueprintAbility InvisibilityGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ecaa0def35b38f949bd1976a6c9539e0");
        public static readonly BlueprintAbility ChaosHammerAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c42ac3feb96d1e54e9bc77c84082f05f");
        public static readonly BlueprintAbility CrusaderEdgeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("be5452c422a6ea744bf1037b0a443bb1");
        public static readonly BlueprintAbility CureCriticalWoundsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("41c9016596fe1de4faf67425ed691203");
        public static readonly BlueprintAbility DeathWardAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e9cc9378fd6841f48ad59384e79e9953");
        public static readonly BlueprintAbility DivinePowerAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ef16771cb05d1344989519e87f25b3c5");
        public static readonly BlueprintAbility FreedomOfMovementAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("0087fc2d64b6095478bc7b8d7d512caf");
        public static readonly BlueprintAbility HolySmiteAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ad5ed5ea4ec52334a94e975a64dad336");
        public static readonly BlueprintAbility InflictCriticalWoundsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("651110ed4f117a948b41c05c5c7624c0");
        public static readonly BlueprintAbility OrdersWrathAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1ec8f035d8329134d96cdc7b90fdc2e1");
        public static readonly BlueprintAbility RestorationAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f2115ac1148256b4ba20788f7e966830");
        public static readonly BlueprintAbility ShieldOfDawnAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("62888999171921e4dafb46de83f4d67d");
        public static readonly BlueprintAbility UnholyBlightAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a02cf51787df937489ef5d4cf5970335");
        public static readonly BlueprintAbility DismissalAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("95f7cdcec94e293489a85afdf5af1fd7");
        public static readonly BlueprintAbility LifeBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a8666d26bbbd9b640958284e0eee3602");
        public static readonly BlueprintAbility EcholocationAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("20b548bf09bb3ea4bafea78dcb4f3db6");
        public static readonly BlueprintAbility SlowMudAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("6b30813c3709fc44b92dc8fd8191f345");
        public static readonly BlueprintAbility ThornBodyAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("2daf9c5112f16d54ab3cd6904c705c59");
        public static readonly BlueprintAbility CapeOfWaspsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e418c20c8ce362943a8025d82c865c1c");
        public static readonly BlueprintAbility SpikeStonesAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d1afa8bc28c99104da7d784115552de5");
        public static readonly BlueprintAbility SummonNaturesAllyIVAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c83db50513abdf74ca103651931fac4b");
        public static readonly BlueprintAbility FlameStrikeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f9910c76efc34af41b6e43d5d8752f0f");
        public static readonly BlueprintAbility LifeBubbleAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("265582bc494c4b12b5860b508a2f89a2");
        public static readonly BlueprintAbility ForcedRepentanceAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("cc0aeb74b35cb7147bff6c53538bbc76");
        public static readonly BlueprintAbility ResoundingBlowAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("9047cb1797639924487ec0ad566a3fea");
        public static readonly BlueprintAbility OathOfPeaceAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("cb3d70cc98b5f1540bddfff6f9667f73");

        // Spells - 5
        public static readonly BlueprintAbility AngelicAspectAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("75a10d5a635986641bfbcceceec87217");
        public static readonly BlueprintAbility AcidicSprayAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c543eef6d725b184ea8669dd09b3894c");
        public static readonly BlueprintAbility HoldMonsterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("41e8a952da7a5c247b3ec1c2dbb73018");
        public static readonly BlueprintAbility ConstrictingCoilsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("3fce8e988a51a2a4ea366324d6153001");
        public static readonly BlueprintAbility ElementalBodyIIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("6d437be73b459594ab103acdcae5b9e2");
        public static readonly BlueprintAbility StoneskinCommunalAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7c5d556b9a5883048bf030e20daebe31");
        public static readonly BlueprintAbility SummonElementalLargeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("89404dd71edc1aa42962824b44156fe5");
        public static readonly BlueprintAbility ConeOfColdAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e7c530f8137630f4d9d7ee1aa7b1edc0");
        public static readonly BlueprintAbility IcyPrisonAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("65e8d23aef5e7784dbeb27b1fca40931");
        public static readonly BlueprintAbility PolymorphAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("93d9d74dac46b9b458d4d2ea7f4b1911");
        public static readonly BlueprintAbility DominatePersonAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d7cbd2004ce66a042aeab2e95a3c5c61");
        public static readonly BlueprintAbility MindFogAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("eabf94e4edc6e714cabd96aa69f8b207");
        public static readonly BlueprintAbility WavesOfFatigueAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("8878d0c46dfbd564e9d5756349d5e439");
        public static readonly BlueprintAbility FeeblemindAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("444eed6e26f773a40ab6e4d160c67faa");
        public static readonly BlueprintAbility FireSnakeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ebade19998e1f8542a1b55bd4da766b3");
        public static readonly BlueprintAbility VampiricShadowShieldAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a34921035f2a6714e9be5ca76c5e34b5");
        public static readonly BlueprintAbility BreakEnchantmentAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7792da00c85b9e042a0fdfc2b66ec9a8");
        public static readonly BlueprintAbility HungryPitAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f63f4d1806b78604a952b3958892ce1c");
        public static readonly BlueprintAbility BalefulPolymorphAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("3105d6e9febdc3f41a08d2b7dda1fe74");
        public static readonly BlueprintAbility AnimalGrowthAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("56923211d2ac95e43b8ac5031bab74d8");
        public static readonly BlueprintAbility GeniekindAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("07b608fab304f894880898dc0764e6e5");
        public static readonly BlueprintAbility ShadowEvocationAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("237427308e48c3341b3d532b9d3a001f");
        public static readonly BlueprintAbility SummonMonsterVAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("630c8b85d9f07a64f917d79cb5905741");
        public static readonly BlueprintAbility BeastShapeIIIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("9b93040dad242eb43ac7de6bb6547030");
        public static readonly BlueprintAbility PhantasmalWebAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("12fb4a4c22549c74d949e2916a2f0b6a");
        public static readonly BlueprintAbility WrackingRayAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1cde0691195feae45bab5b83ea3f221e");
        public static readonly BlueprintAbility ThoughtsenseAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("8fb1a1670b6e1f84b89ea846f589b627");
        public static readonly BlueprintAbility CloudkillAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("548d339ba87ee56459c98e80167bdf10");
        public static readonly BlueprintAbility SerenityAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d316d3d94d20c674db2c24d7de96f6a7");
        public static readonly BlueprintAbility BreathOfLifeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d5847cad0b0e54c4d82d6c59a3cda6b0");
        public static readonly BlueprintAbility BurstOfGloryAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1bc83efec9f8c4b42a46162d72cbf494");
        public static readonly BlueprintAbility ClenseAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("be2062d6d85f4634ea4f26e9e858c3b8");
        public static readonly BlueprintAbility CureLightWoundsMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5d3d689392e4ff740a761ef346815074");
        public static readonly BlueprintAbility DisruptingWeaponAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("46c96cc3a3ef35243915ff3452dfacf5");
        public static readonly BlueprintAbility InflictLightWoundsMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("9da37873d79ef0a468f969e4e5116ad2");
        public static readonly BlueprintAbility PillarOfLifeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("aca83c764d751594287f18b817814bce");
        public static readonly BlueprintAbility ProfaneNimbusAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("b56521d58f996cd4299dab3f38d5fe31");
        public static readonly BlueprintAbility RaiseDeadAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a0fc99f0933d01643b2b8fe570caa4c5");
        public static readonly BlueprintAbility RighteousMightAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("90810e5cf53bf854293cbd5ea1066252");
        public static readonly BlueprintAbility SacredNimbusAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("bf74b3b54c21a9344afe9947546e036f");
        public static readonly BlueprintAbility SlayLivingAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4fbd47525382517419c66fb548fe9a67");
        public static readonly BlueprintAbility SpellResistanceAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("0a5ddfbcfb3989543ac7c936fc256889");
        public static readonly BlueprintAbility TrueSeeingAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4cf3d0fae3239ec478f51e86f49161cb");
        public static readonly BlueprintAbility VinetrapAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("6d1d48a939ce475409f06e1b376bc386");
        public static readonly BlueprintAbility CommandGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("cb15cc8d7a5480648855a23b3ba3f93d");
        public static readonly BlueprintAbility CallLightningStormAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d5a36a7ee8177be4f848b953d1c53c84");
        public static readonly BlueprintAbility AspectOfTheWolfAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("6126b36fe22291543ad72f8b9f0d53a7");
        public static readonly BlueprintAbility SummonNaturesAllyVAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("8f98a22f35ca6684a983363d32e51bfe");
        public static readonly BlueprintAbility CaveFangsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("bacba2ff48d498b46b86384053945e83");
        public static readonly BlueprintAbility BlessingOfTheSalamanderAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("9256a86aec14ad14e9497f6b60e26f3f");
        public static readonly BlueprintAbility CastigateMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("41236cf0e476d7043bc16a33a9f449bd");
        public static readonly BlueprintAbility CacophonousCallMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1262284b6fa45b9458b8c3693edbd676");
        public static readonly BlueprintAbility SongOfDiscordAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d38aaf487e29c3d43a3bffa4a4a55f8f");

        // Spells - 6
        public static readonly BlueprintAbility ChainsOfLightAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f8cea58227f59c64399044a82c9735c4");
        public static readonly BlueprintAbility ElementalAssessorAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("6303b404df12b0f4793fa0763b21dd2c");
        public static readonly BlueprintAbility StoneToFleshAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e243740dfdb17a246b116b334ed0b165");
        public static readonly BlueprintAbility SummonMonsterVIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e740afbab0147944dab35d83faa0ae1c");
        public static readonly BlueprintAbility DispelMagicGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f0f761b808dc4b149b08eaf44b99f633");
        public static readonly BlueprintAbility FormOfTheDragonIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f767399367df54645ac620ef7b2062bb");
        public static readonly BlueprintAbility UndeathToDeathAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a9a52760290591844a96d0109e30e04d");
        public static readonly BlueprintAbility CatsGraceMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1f6c94d56f178b84ead4c02f1b1e1c48");
        public static readonly BlueprintAbility BullsStrengthMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("6a234c6dcde7ae94e94e9c36fd1163a7");
        public static readonly BlueprintAbility CircleOfDeathAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a89dcbbab8f40e44e920cc60636097cf");
        public static readonly BlueprintAbility HeroismGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e15e5e7045fda2244b98c8f010adfe31");
        public static readonly BlueprintAbility DisintegrateAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4aa7942c3e62a164387a73184bca3fc1");
        public static readonly BlueprintAbility ChainLightningAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("645558d63604747428d55f0dd3a4cb58");
        public static readonly BlueprintAbility OwlsWisdomMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("9f5ada581af3db4419b54db77f44e430");
        public static readonly BlueprintAbility AcidFogAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("dbf99b00cd35d0a4491c6cc9e771b487");
        public static readonly BlueprintAbility BearsEnduranceMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f6bcea6db14f0814d99b54856e918b92");
        public static readonly BlueprintAbility HellfireRayAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("700cfcbd0cb2975419bcab7dbb8c6210");
        public static readonly BlueprintAbility CloakofDreamsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7f71a70d822af94458dc1a235507e972");
        public static readonly BlueprintAbility FoxsCunningMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("2b24159ad9907a8499c2313ba9c0f615");
        public static readonly BlueprintAbility EaglesSplendorMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("2caa607eadda4ab44934c5c9875e01bc");
        public static readonly BlueprintAbility BeastShapeIVAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("940a545a665194b48b722c1f9dd78d53");
        public static readonly BlueprintAbility TransformationAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("27203d62eb3d4184c9aced94f22e1806");
        public static readonly BlueprintAbility SiroccoAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("093ed1d67a539ad4c939d9d05cfe192c");
        public static readonly BlueprintAbility ElementalBodyIIIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("459e6d5aab080a14499e13b407eb3b85");
        public static readonly BlueprintAbility TarPoolAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7d700cdf260d36e48bb7af3a8ca5031f");
        public static readonly BlueprintAbility ColdIceStrikeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5ef85d426783a5347b420546f91a677b");
        public static readonly BlueprintAbility BansheeBlastAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d42c6d3f29e07b6409d670792d72bc82");
        public static readonly BlueprintAbility SummonElementalHugeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("766ec978fa993034f86a372c8eb1fc10");
        public static readonly BlueprintAbility PhantasmalPutrefactionAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1f2e6019ece86d64baa5effa15e81ecc");
        public static readonly BlueprintAbility EyebiteAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("3167d30dd3c622c46b0c0cb242061642");
        public static readonly BlueprintAbility CreateUndeadAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("76a11b460be25e44ca85904d6806e5a3");
        public static readonly BlueprintAbility BlessingOfLuckAndResolveMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("462c21cebf7820c40a87f5e4d03e17cf");
        public static readonly BlueprintAbility EaglesoulAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("332ad68273db9704ab0e92518f2efd1c");
        public static readonly BlueprintAbility TrueSeeingCommunalAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("fa08cb49ade3eee42b5fd42bd33cb407");
        public static readonly BlueprintAbility BladeBarrierAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("36c8971e91f1745418cc3ffdfac17b74");
        public static readonly BlueprintAbility CureModerateWoundsMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("571221cc141bc21449ae96b3944652aa");
        public static readonly BlueprintAbility HarmAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("cc09224ecc9af79449816c45bc5be218");
        public static readonly BlueprintAbility HealAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5da172c4c89f9eb4cbb614f3a67357d3");
        public static readonly BlueprintAbility InflictModerateWoundsMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("03944622fbe04824684ec29ff2cec6a7");
        public static readonly BlueprintAbility InspiringRecoveryAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("788d72e7713cf90418ee1f38449416dc");
        public static readonly BlueprintAbility PlagueStormAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("82a5b848c05e3f342b893dedb1f9b446");
        public static readonly BlueprintAbility BanishmentAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d361391f645db984bbf58907711a146a");
        public static readonly BlueprintAbility JoyfulRaptureAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("15a04c40f84545949abeedef7279751a");
        public static readonly BlueprintAbility PrimalRegressionAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("07d577a74441a3a44890e3006efcf604");
        public static readonly BlueprintAbility SummonNaturesAllyVIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("55bbce9b3e76d4a4a8c8e0698d29002c");
        public static readonly BlueprintAbility PoisonBreathAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("b5be90707c17a9643b90d90b7c4096e2");
        public static readonly BlueprintAbility FesterMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("52b8b14360a87104482b2735c7fc8606");
        public static readonly BlueprintAbility LitanyOfMadnessAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("435e73bcff18f304293484f9511b4672");
        public static readonly BlueprintAbility BrilliantInspirationAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a5c56f0f699daec44b7aedd8b273b08a");

        // Spells - 7
        public static readonly BlueprintAbility UmbralStrikeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("474ed0aa656cc38499cc9a073d113716");
        public static readonly BlueprintAbility InsanityAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("2b044152b3620c841badb090e01ed9de");
        public static readonly BlueprintAbility PolymorphGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a9fc28e147dbb364ea4a3c1831e7e55f");
        public static readonly BlueprintAbility PowerWordBlindAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("261e1788bfc5ac1419eec68b1d485dbc");
        public static readonly BlueprintAbility ElementalBodyIVAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("376db0590f3ca4945a8b6dc16ed14975");
        public static readonly BlueprintAbility FingerOfDeathAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("6f1dcf6cfa92d1948a740195707c0dbe");
        public static readonly BlueprintAbility WalkThroughSpaceAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("368d7cf2fb69d8a46be5a650f5a5a173");
        public static readonly BlueprintAbility SummonMonsterVIIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ab167fd8203c1314bac6568932f1752f");
        public static readonly BlueprintAbility FormOfTheDragonIIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("666556ded3a32f34885e8c318c3a0ced");
        public static readonly BlueprintAbility CircleOfClarityAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f333185ae986b2a45823cce86535a122");
        public static readonly BlueprintAbility KiShoutAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5c8cde7f0dcec4e49bfa2632dfe2ecc0");
        public static readonly BlueprintAbility ResonatingWordAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("df7d13c967bce6a40bec3ba7c9f0e64c");
        public static readonly BlueprintAbility PrismaticSprayAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("b22fd434bdb60fb4ba1068206402c4cf");
        public static readonly BlueprintAbility InvisibilityMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("98310a099009bbd4dbdf66bcef58b4cd");
        public static readonly BlueprintAbility IceBodyAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("89778dc261fe6094bb2445cb389842d2");
        public static readonly BlueprintAbility WavesOfEcstasyAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1e2d1489781b10a45a3b70192bba9be3");
        public static readonly BlueprintAbility HoldPersonMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("defbbeaef79eda64abc645036228a31b");
        public static readonly BlueprintAbility SummonElementalGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("8eb769e3b583f594faabe1cfdb0bb696");
        public static readonly BlueprintAbility CausticEruptionAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("8c29e953190cc67429dc9c701b16b7c2");
        public static readonly BlueprintAbility WavesOfExhaustionAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("3e4d3b9a5bd03734d9b053b9067c2f38");
        public static readonly BlueprintAbility LegendaryProportionsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("da1b292d91ba37948893cdbe9ea89e28");
        public static readonly BlueprintAbility ShadowConjurationGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("08255ea4cdd812341af93f9cd113acb9");
        public static readonly BlueprintAbility FirebrandAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("98734a2665c18cd4db71878b0532024a");
        public static readonly BlueprintAbility BestowGraceOfTheChampionAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("199d585bff173c74b86387856919242c");
        public static readonly BlueprintAbility ArbitramentAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("0f5bd128c76dd374b8cb9111e3b5186b");
        public static readonly BlueprintAbility BlasphemyAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("bd10c534a09f44f4ea632c8b8ae97145");
        public static readonly BlueprintAbility DictumAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("302ab5e241931a94881d323a7844ae8f");
        public static readonly BlueprintAbility HolyWordAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4737294a66c91b844842caee8cf505c8");
        public static readonly BlueprintAbility WordOfChaosAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("69f2e7aff2d1cd148b8075ee476515b1");
        public static readonly BlueprintAbility CureSeriousWoundsMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("0cea35de4d553cc439ae80b3a8724397");
        public static readonly BlueprintAbility DestructionAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("3b646e1db3403b940bf620e01d2ce0c7");
        public static readonly BlueprintAbility InflictSeriousWoundsMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("820170444d4d2a14abc480fcbdb49535");
        public static readonly BlueprintAbility JoltingPortentAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("0dd638688edf68a4da865752d7b9ee82");
        public static readonly BlueprintAbility RestorationGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("fafd77c6bfa85c04ba31fdc1c962c914");
        public static readonly BlueprintAbility ResurrectionAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("80a1a388ee938aa4e90d427ce9a7a3e9");
        public static readonly BlueprintAbility BestowCurseGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("6101d0f0720927e4ca413de7b3c4b7e5");
        public static readonly BlueprintAbility SummonNaturesAllyVIIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("051b979e7d7f8ec41b9fa35d04746b33");
        public static readonly BlueprintAbility CreepingDoomAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("b974af13e45639a41a04843ce1c9aa12");
        public static readonly BlueprintAbility SunbeamAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1fca0ba2fdfe2994a8c8bc1f0f2fc5b1");
        public static readonly BlueprintAbility FireStormAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e3d0dfe1c8527934294f241e0ae96a8d");
        public static readonly BlueprintAbility ChangestaffAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("26be70c4664d07446bdfe83504c1d757");

        // Spells - 8
        public static readonly BlueprintAbility AngelicAspectGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("b1c7576bd06812b42bda3f09ab202f14");
        public static readonly BlueprintAbility ShoutGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("fd0d3840c48cafb44bb29e8eb74df204");
        public static readonly BlueprintAbility ProtectionFromSpellsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("42aa71adc7343714fa92e471baa98d42");
        public static readonly BlueprintAbility SummonMonsterVIIIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d3ac756a229830243a72e84f3ab050d0");
        public static readonly BlueprintAbility ScintillatingPatternAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4dc60d08c6c4d3c47b413904e4de5ff0");
        public static readonly BlueprintAbility SummonElementalElderAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("8a7f8c1223bda1541b42fd0320cdbe2b");
        public static readonly BlueprintAbility HoridWiltingAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("08323922485f7e246acb3d2276515526");
        public static readonly BlueprintAbility SunburstAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e96424f70ff884947b06f41a765b7658");
        public static readonly BlueprintAbility DeathClutchAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c3d2294a6740bc147870fff652f3ced5");
        public static readonly BlueprintAbility PolarRayAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("17696c144a0194c478cbe402b496cb23");
        public static readonly BlueprintAbility FrightfulAspectAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e788b02f8d21014488067bdd3ba7b325");
        public static readonly BlueprintAbility SeamantleAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7ef49f184922063499b8f1346fb7f521");
        public static readonly BlueprintAbility FormOfTheDragonIIIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1cdc4ad4c208246419b98a35539eafa6");
        public static readonly BlueprintAbility IronBodyAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("198fcc43490993f49899ed086fe723c1");
        public static readonly BlueprintAbility RiftOfRuinAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("dd3dacafcf40a0145a5824c838e2698d");
        public static readonly BlueprintAbility PredictionOfFailureAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("0e67fa8f011662c43934d486acc50253");
        public static readonly BlueprintAbility PowerWordStunAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("f958ef62eea5050418fb92dfa944c631");
        public static readonly BlueprintAbility ShadowEvocationGreaterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("3c4a2d4181482e84d9cd752ef8edc3b6");
        public static readonly BlueprintAbility StormboltsAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7cfbefe0931257344b2cb7ddc4cdff6f");
        public static readonly BlueprintAbility MindBlankAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("df2a0ba6b6dcecf429cbb80a56fee5cf");
        public static readonly BlueprintAbility EuphoricTranquilityAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("740d943e42b60f64a8de74926ba6ddf7");
        public static readonly BlueprintAbility SouldreaverAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("b4afacd337dac4a40a769a567c038ab7");
        public static readonly BlueprintAbility CloakOfChaosAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("9155dbc8268da1c49a7fc4834fa1a4b1");
        public static readonly BlueprintAbility CureCriticalWoundsMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1f173a16120359e41a20fc75bb53d449");
        public static readonly BlueprintAbility HolyAuraAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("808ab74c12df8784ab4eeaf6a107dbea");
        public static readonly BlueprintAbility InflictCriticalWoundsMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5ee395a2423808c4baf342a4f8395b19");
        public static readonly BlueprintAbility ShieldOfLawAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("73e7728808865094b8892613ddfaf7f5");
        public static readonly BlueprintAbility UnholyAuraAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("47f9cb1c367a5e4489cfa32fce290f86");
        public static readonly BlueprintAbility AnimalShapesAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("cf689244b2c7e904eb85f26fd6e81552");
        public static readonly BlueprintAbility SummonNaturesAllyVIIIAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ea78c04f0bd13d049a1cce5daf8d83e0");

        // Spells - 9
        public static readonly BlueprintAbility OverwhelmingPresenceAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("41cf93453b027b94886901dbfc680cb9");
        public static readonly BlueprintAbility IcyPrisonMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1852a9393a23d5741b650a1ea7078abc");
        public static readonly BlueprintAbility ShadesAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("70e12191790f69a439ea0132c75f83aa");
        public static readonly BlueprintAbility TsunamiAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d8144161e352ca846a73cf90e85bf9ac");
        public static readonly BlueprintAbility PowerWordKillAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("2f8a67c483dfa0f439b293e094ca9e3c");
        public static readonly BlueprintAbility WailOfBansheeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("b24583190f36a8442b212e45226c54fc");
        public static readonly BlueprintAbility ClashingRocksAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("01300baad090d634cb1a1b2defe068d6");
        public static readonly BlueprintAbility ShapechangeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("22b9044aa229815429d57d0a30e4b739");
        public static readonly BlueprintAbility HeroicInvocationAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("43740dab07286fe4aa00a6ee104ce7c1");
        public static readonly BlueprintAbility EnergyDrainAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("37302f72b06ced1408bf5bb965766d46");
        public static readonly BlueprintAbility WeirdAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("870af83be6572594d84d276d7fc583e0");
        public static readonly BlueprintAbility SummonMonsterIXAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("52b5df2a97df18242aec67610616ded0");
        public static readonly BlueprintAbility FieryBodyAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("08ccad78cac525040919d51963f9ac39");
        public static readonly BlueprintAbility DominateMonsterAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("3c17035ec4717674cae2e841a190e757");
        public static readonly BlueprintAbility HoldMonsterMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7f4b66a2b1fdab142904a263c7866d46");
        public static readonly BlueprintAbility ForesightAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1f01a098d737ec6419aedc4e7ad61fdd");
        public static readonly BlueprintAbility MindBlankCommunalAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("87a29febd010993419f2a4a9bee11cfc");
        public static readonly BlueprintAbility HealMassAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("867524328b54f25488d371214eea0d90");
        public static readonly BlueprintAbility PolarMidnightAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ba48abb52b142164eba309fd09898856");
        public static readonly BlueprintAbility WindsOfVengeanceAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5d8f1da2fdc0b9242af9f326f9e507be");
        public static readonly BlueprintAbility SummonNaturesAllyIXAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a7469ef84ba50ac4cbf3d145e3173f8e");
        public static readonly BlueprintAbility ElementalSwarmAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("0340fe43f35e7a448981b646c638c83d");
        public static readonly BlueprintAbility SummonElderWormAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("954f1469ed62843409783c9fa7472998");

        public static void Add()
        {
            Helpers.CreateBlueprint<BlueprintSpellList>(IsekaiContext, "IsekaiProtagonistSpellList", bp => {
                bp.SpellsByLevel = new SpellLevelList[] {
                    new SpellLevelList(0) {
                        m_Spells = new List<BlueprintAbilityReference> {
                            MageLightAbility.ToReference<BlueprintAbilityReference>(),
                            JoltAbility.ToReference<BlueprintAbilityReference>(),
                            DisruptUndeadAbility.ToReference<BlueprintAbilityReference>(),
                            AcidSplashAbility.ToReference<BlueprintAbilityReference>(),
                            DismissAreaEffectAbility.ToReference<BlueprintAbilityReference>(),
                            DazeAbility.ToReference<BlueprintAbilityReference>(),
                            TouchOfFatigueAbility.ToReference<BlueprintAbilityReference>(),
                            FlareAbility.ToReference<BlueprintAbilityReference>(),
                            RayOfFrostAbility.ToReference<BlueprintAbilityReference>(),
                            ResistanceAbility.ToReference<BlueprintAbilityReference>(),
                            DivineZapAbility.ToReference<BlueprintAbilityReference>(),
                            GuidanceAbility.ToReference<BlueprintAbilityReference>(),
                            VirtueAbility.ToReference<BlueprintAbilityReference>(),
                        }
                    },
                    new SpellLevelList(1) {
                        m_Spells = new List<BlueprintAbilityReference> {
                            SnowBallAbility.ToReference<BlueprintAbilityReference>(),
                            VanishAbility.ToReference<BlueprintAbilityReference>(),
                            ColorSprayAbility.ToReference<BlueprintAbilityReference>(),
                            ShockingGraspAbility.ToReference<BlueprintAbilityReference>(),
                            MagicWeaponAbility.ToReference<BlueprintAbilityReference>(),
                            EarPiercingScreamAbility.ToReference<BlueprintAbilityReference>(),
                            StunningBarrierAbility.ToReference<BlueprintAbilityReference>(),
                            MageShieldAbility.ToReference<BlueprintAbilityReference>(),
                            CorrosiveTouchAbility.ToReference<BlueprintAbilityReference>(),
                            ExpeditiousRetreatAbility.ToReference<BlueprintAbilityReference>(),
                            TouchOfGracelessnessAbility.ToReference<BlueprintAbilityReference>(),
                            MagicMissileAbility.ToReference<BlueprintAbilityReference>(),
                            ProtectionFromAlignmentAbility.ToReference<BlueprintAbilityReference>(),
                            BurningHandsAbility.ToReference<BlueprintAbilityReference>(),
                            CauseFearAbility.ToReference<BlueprintAbilityReference>(),
                            TrueStrikeAbility.ToReference<BlueprintAbilityReference>(),
                            FlareBurstAbility.ToReference<BlueprintAbilityReference>(),
                            HurricaneBowAbility.ToReference<BlueprintAbilityReference>(),
                            MageArmorAbility.ToReference<BlueprintAbilityReference>(),
                            GreaseAbility.ToReference<BlueprintAbilityReference>(),
                            SleepAbility.ToReference<BlueprintAbilityReference>(),
                            ReducePersonAbility.ToReference<BlueprintAbilityReference>(),
                            RayOfSickeningAbility.ToReference<BlueprintAbilityReference>(),
                            StoneFistAbility.ToReference<BlueprintAbilityReference>(),
                            RayOfEnfeeblementAbility.ToReference<BlueprintAbilityReference>(),
                            SummonMonsterIAbility.ToReference<BlueprintAbilityReference>(),
                            EnlargePersonAbility.ToReference<BlueprintAbilityReference>(),
                            HypnotismAbility.ToReference<BlueprintAbilityReference>(),
                            BaneAbility.ToReference<BlueprintAbilityReference>(),
                            BlessAbility.ToReference<BlueprintAbilityReference>(),
                            CureLightWoundsAbility.ToReference<BlueprintAbilityReference>(),
                            DivineFavorAbility.ToReference<BlueprintAbilityReference>(),
                            DoomAbility.ToReference<BlueprintAbilityReference>(),
                            FirebellyAbility.ToReference<BlueprintAbilityReference>(),
                            InflictLightWoundsAbility.ToReference<BlueprintAbilityReference>(),
                            RemoveFearAbility.ToReference<BlueprintAbilityReference>(),
                            RemoveSicknessAbility.ToReference<BlueprintAbilityReference>(),
                            ShieldOfFaithAbility.ToReference<BlueprintAbilityReference>(),
                            UnbreakableHeartAbility.ToReference<BlueprintAbilityReference>(),
                            HazeOfDreamsAbility.ToReference<BlueprintAbilityReference>(),
                            CommandAbility.ToReference<BlueprintAbilityReference>(),
                            SummonNaturesAllyIAbility.ToReference<BlueprintAbilityReference>(),
                            AcidMawAbility.ToReference<BlueprintAbilityReference>(),
                            MagicFangAbility.ToReference<BlueprintAbilityReference>(),
                            AspectOfTheFalconAbility.ToReference<BlueprintAbilityReference>(),
                            FeatherStepAbility.ToReference<BlueprintAbilityReference>(),
                            EntangleAbility.ToReference<BlueprintAbilityReference>(),
                            FaerieFireAbility.ToReference<BlueprintAbilityReference>(),
                            LongstriderAbility.ToReference<BlueprintAbilityReference>(),
                            LeadBladesAbility.ToReference<BlueprintAbilityReference>(),
                            ChallengeEvilAbility.ToReference<BlueprintAbilityReference>(),
                            VeilOfHeavenAbility.ToReference<BlueprintAbilityReference>(),
                            VeilOfPositiveEnergyAbility.ToReference<BlueprintAbilityReference>(),
                        }
                    },
                    new SpellLevelList(2) {
                        m_Spells = new List<BlueprintAbilityReference> {
                            OwlsWisdomAbility.ToReference<BlueprintAbilityReference>(),
                            BurningArcAbility.ToReference<BlueprintAbilityReference>(),
                            FalseLifeAbility.ToReference<BlueprintAbilityReference>(),
                            AnimalAspectAbility.ToReference<BlueprintAbilityReference>(),
                            SummonElementalSmallAbility.ToReference<BlueprintAbilityReference>(),
                            BoneShakerAbility.ToReference<BlueprintAbilityReference>(),
                            StoneCallAbility.ToReference<BlueprintAbilityReference>(),
                            HideousLaughterAbility.ToReference<BlueprintAbilityReference>(),
                            MoltenOrbAbility.ToReference<BlueprintAbilityReference>(),
                            ProtectionFromAlignmentCommunalAbility.ToReference<BlueprintAbilityReference>(),
                            AcidArrowAbility.ToReference<BlueprintAbilityReference>(),
                            SeeInvisibilityAbility.ToReference<BlueprintAbilityReference>(),
                            ScorchingRayAbility.ToReference<BlueprintAbilityReference>(),
                            ScareAbility.ToReference<BlueprintAbilityReference>(),
                            BullsStrengthAbility.ToReference<BlueprintAbilityReference>(),
                            GlitterdustAbility.ToReference<BlueprintAbilityReference>(),
                            CreatePitAbility.ToReference<BlueprintAbilityReference>(),
                            BearsEnduranceAbility.ToReference<BlueprintAbilityReference>(),
                            SenseVitalsAbility.ToReference<BlueprintAbilityReference>(),
                            EaglesSplendorAbility.ToReference<BlueprintAbilityReference>(),
                            ResisEnergyAbility.ToReference<BlueprintAbilityReference>(),
                            CommandUndeadAbility.ToReference<BlueprintAbilityReference>(),
                            BlurAbility.ToReference<BlueprintAbilityReference>(),
                            ProtectionFromArrowsAbility.ToReference<BlueprintAbilityReference>(),
                            PerniciousPoisonAbility.ToReference<BlueprintAbilityReference>(),
                            MirrorImageAbility.ToReference<BlueprintAbilityReference>(),
                            WebAbility.ToReference<BlueprintAbilityReference>(),
                            InvisibilityAbility.ToReference<BlueprintAbilityReference>(),
                            BlindnessAbility.ToReference<BlueprintAbilityReference>(),
                            FrigidTouchAbility.ToReference<BlueprintAbilityReference>(),
                            CatsGraceAbility.ToReference<BlueprintAbilityReference>(),
                            SummonMonsterIIAbility.ToReference<BlueprintAbilityReference>(),
                            FoxsCunningAbility.ToReference<BlueprintAbilityReference>(),
                            ArrowOfLawAbility.ToReference<BlueprintAbilityReference>(),
                            AidAbility.ToReference<BlueprintAbilityReference>(),
                            BlessingOfCourageAndLifeAbility.ToReference<BlueprintAbilityReference>(),
                            BlessingOfLuckAndResolveAbility.ToReference<BlueprintAbilityReference>(),
                            CureModerateWoundsAbility.ToReference<BlueprintAbilityReference>(),
                            DelayPoisonAbility.ToReference<BlueprintAbilityReference>(),
                            EffortlessArmorAbility.ToReference<BlueprintAbilityReference>(),
                            FindTrapsAbility.ToReference<BlueprintAbilityReference>(),
                            GraceAbility.ToReference<BlueprintAbilityReference>(),
                            InflictModerateWoundsAbility.ToReference<BlueprintAbilityReference>(),
                            RemoveParalysisAbility.ToReference<BlueprintAbilityReference>(),
                            RestorationLesserAbility.ToReference<BlueprintAbilityReference>(),
                            SoundBurstAbility.ToReference<BlueprintAbilityReference>(),
                            HoldPersonAbility.ToReference<BlueprintAbilityReference>(),
                            AlignWeaponAbility.ToReference<BlueprintAbilityReference>(),
                            PoxPustulesAbility.ToReference<BlueprintAbilityReference>(),
                            NaturalRythmAbility.ToReference<BlueprintAbilityReference>(),
                            SummonNaturesAllyIIAbility.ToReference<BlueprintAbilityReference>(),
                            BarkskinAbility.ToReference<BlueprintAbilityReference>(),
                            HoldAnimalAbility.ToReference<BlueprintAbilityReference>(),
                            AspectOfTheBearAbility.ToReference<BlueprintAbilityReference>(),
                            SickeningEntanglementAbility.ToReference<BlueprintAbilityReference>(),
                            ChameleonStrideAbility.ToReference<BlueprintAbilityReference>(),
                            CastigateAbility.ToReference<BlueprintAbilityReference>(),
                            CacophonousCallAbility.ToReference<BlueprintAbilityReference>(),
                            BestowGraceAbility.ToReference<BlueprintAbilityReference>(),
                        }
                    },
                    new SpellLevelList(3) {
                        m_Spells = new List<BlueprintAbilityReference> {
                            VampiricTouchAbility.ToReference<BlueprintAbilityReference>(),
                            MagicWeaponGreaterAbility.ToReference<BlueprintAbilityReference>(),
                            ProtectionFromArrowsCommunalAbility.ToReference<BlueprintAbilityReference>(),
                            ProtectionFromEnergyAbility.ToReference<BlueprintAbilityReference>(),
                            SeeInvisibilityCommunalAbility.ToReference<BlueprintAbilityReference>(),
                            RageAbility.ToReference<BlueprintAbilityReference>(),
                            HasteAbility.ToReference<BlueprintAbilityReference>(),
                            LightningBoltAbility.ToReference<BlueprintAbilityReference>(),
                            DisplacementAbility.ToReference<BlueprintAbilityReference>(),
                            SummonMonsterIIIAbility.ToReference<BlueprintAbilityReference>(),
                            BatteringBlastAbility.ToReference<BlueprintAbilityReference>(),
                            ForcePunchAbility.ToReference<BlueprintAbilityReference>(),
                            SlowAbility.ToReference<BlueprintAbilityReference>(),
                            SpikedPitAbility.ToReference<BlueprintAbilityReference>(),
                            StinkingCloudAbility.ToReference<BlueprintAbilityReference>(),
                            BlinkAbility.ToReference<BlueprintAbilityReference>(),
                            HeroismAbility.ToReference<BlueprintAbilityReference>(),
                            DeepSlumberAbility.ToReference<BlueprintAbilityReference>(),
                            FireballAbility.ToReference<BlueprintAbilityReference>(),
                            BeastShapeIAbility.ToReference<BlueprintAbilityReference>(),
                            ResistEnergyCommunalAbility.ToReference<BlueprintAbilityReference>(),
                            DispelMagicAbility.ToReference<BlueprintAbilityReference>(),
                            RayOfExhaustionAbility.ToReference<BlueprintAbilityReference>(),
                            ArchonsAuraAbility.ToReference<BlueprintAbilityReference>(),
                            BestowCurseAbility.ToReference<BlueprintAbilityReference>(),
                            ContagionAbility.ToReference<BlueprintAbilityReference>(),
                            CureSeriousWoundsAbility.ToReference<BlueprintAbilityReference>(),
                            DelayPoisonCommunalAbility .ToReference<BlueprintAbilityReference>(),
                            InflictSeriousWoundsAbility.ToReference<BlueprintAbilityReference>(),
                            MagicalVestmentAbility.ToReference<BlueprintAbilityReference>(),
                            PrayerAbility.ToReference<BlueprintAbilityReference>(),
                            RemoveBlindnessAbility.ToReference<BlueprintAbilityReference>(),
                            RemoveCurseAbility.ToReference<BlueprintAbilityReference>(),
                            RemoveDiseaseAbility.ToReference<BlueprintAbilityReference>(),
                            SearingLightAbility.ToReference<BlueprintAbilityReference>(),
                            AnimateDeadAbility.ToReference<BlueprintAbilityReference>(),
                            FeatherStepMassAbility.ToReference<BlueprintAbilityReference>(),
                            CallLightningAbility.ToReference<BlueprintAbilityReference>(),
                            PoisonAbility.ToReference<BlueprintAbilityReference>(),
                            SpitVenomAbility.ToReference<BlueprintAbilityReference>(),
                            MagicFangGreaterAbility.ToReference<BlueprintAbilityReference>(),
                            LongstriderGreaterAbility.ToReference<BlueprintAbilityReference>(),
                            NeutralizePoisonAbility.ToReference<BlueprintAbilityReference>(),
                            DominateAnimalAbility.ToReference<BlueprintAbilityReference>(),
                            SummonNaturesAllyIIIAbility.ToReference<BlueprintAbilityReference>(),
                            SoothingMudAbility.ToReference<BlueprintAbilityReference>(),
                            SpikeGrowthAbility.ToReference<BlueprintAbilityReference>(),
                            AnimalAspectGreaterAbility.ToReference<BlueprintAbilityReference>(),
                            ChameleonStrideGreaterAbility.ToReference<BlueprintAbilityReference>(),
                            InstantEnemyAbility.ToReference<BlueprintAbilityReference>(),
                            FesterAbility.ToReference<BlueprintAbilityReference>(),
                            LitanyOfEloquenceAbility.ToReference<BlueprintAbilityReference>(),
                            LitanyOfEntanglementAbility.ToReference<BlueprintAbilityReference>(),
                            GoodHopeAbility.ToReference<BlueprintAbilityReference>(),
                            ThunderingDrumsAbility.ToReference<BlueprintAbilityReference>(),
                            HolyWhisperAbility.ToReference<BlueprintAbilityReference>(),
                        }
                    },
                    new SpellLevelList(4) {
                        m_Spells = new List<BlueprintAbilityReference> {
                            OverwhelmingGriefAbility.ToReference<BlueprintAbilityReference>(),
                            CrushingDespairAbility.ToReference<BlueprintAbilityReference>(),
                            ObsidianFlowAbility.ToReference<BlueprintAbilityReference>(),
                            RainbowPatternAbility.ToReference<BlueprintAbilityReference>(),
                            BoneshatterAbility.ToReference<BlueprintAbilityReference>(),
                            SummonMonsterIVAbility.ToReference<BlueprintAbilityReference>(),
                            VolcanicStormAbility.ToReference<BlueprintAbilityReference>(),
                            ControlledFireballAbility.ToReference<BlueprintAbilityReference>(),
                            ProtectionFromEnergyCommunalAbility.ToReference<BlueprintAbilityReference>(),
                            ConfusionAbility.ToReference<BlueprintAbilityReference>(),
                            FalseLifeGreaterAbility.ToReference<BlueprintAbilityReference>(),
                            FearAbility.ToReference<BlueprintAbilityReference>(),
                            DragonsBreathAbility.ToReference<BlueprintAbilityReference>(),
                            BeastShapeIIAbility.ToReference<BlueprintAbilityReference>(),
                            ShoutAbility.ToReference<BlueprintAbilityReference>(),
                            TouchOfSlimeAbility.ToReference<BlueprintAbilityReference>(),
                            SymbolOfRevelationAbility.ToReference<BlueprintAbilityReference>(),
                            IceStormAbility.ToReference<BlueprintAbilityReference>(),
                            DimensionDoorAbility.ToReference<BlueprintAbilityReference>(),
                            EnervationAbility.ToReference<BlueprintAbilityReference>(),
                            StoneskinAbility.ToReference<BlueprintAbilityReference>(),
                            PhantasmalKillerAbility.ToReference<BlueprintAbilityReference>(),
                            SummonElementalMediumAbility.ToReference<BlueprintAbilityReference>(),
                            ShadowConjurationAbility.ToReference<BlueprintAbilityReference>(),
                            AcidPitAbility.ToReference<BlueprintAbilityReference>(),
                            ReducePersonMassAbility.ToReference<BlueprintAbilityReference>(),
                            ElementalBodyIAbility.ToReference<BlueprintAbilityReference>(),
                            EnlargePersonMassAbility.ToReference<BlueprintAbilityReference>(),
                            InvisibilityGreaterAbility.ToReference<BlueprintAbilityReference>(),
                            ChaosHammerAbility.ToReference<BlueprintAbilityReference>(),
                            CrusaderEdgeAbility.ToReference<BlueprintAbilityReference>(),
                            CureCriticalWoundsAbility.ToReference<BlueprintAbilityReference>(),
                            DeathWardAbility.ToReference<BlueprintAbilityReference>(),
                            DivinePowerAbility.ToReference<BlueprintAbilityReference>(),
                            FreedomOfMovementAbility .ToReference<BlueprintAbilityReference>(),
                            HolySmiteAbility.ToReference<BlueprintAbilityReference>(),
                            InflictCriticalWoundsAbility.ToReference<BlueprintAbilityReference>(),
                            OrdersWrathAbility.ToReference<BlueprintAbilityReference>(),
                            RestorationAbility.ToReference<BlueprintAbilityReference>(),
                            ShieldOfDawnAbility.ToReference<BlueprintAbilityReference>(),
                            UnholyBlightAbility.ToReference<BlueprintAbilityReference>(),
                            DismissalAbility.ToReference<BlueprintAbilityReference>(),
                            LifeBlastAbility.ToReference<BlueprintAbilityReference>(),
                            EcholocationAbility.ToReference<BlueprintAbilityReference>(),
                            SlowMudAbility.ToReference<BlueprintAbilityReference>(),
                            ThornBodyAbility.ToReference<BlueprintAbilityReference>(),
                            CapeOfWaspsAbility.ToReference<BlueprintAbilityReference>(),
                            SpikeStonesAbility.ToReference<BlueprintAbilityReference>(),
                            SummonNaturesAllyIVAbility.ToReference<BlueprintAbilityReference>(),
                            FlameStrikeAbility.ToReference<BlueprintAbilityReference>(),
                            LifeBubbleAbility.ToReference<BlueprintAbilityReference>(),
                            ForcedRepentanceAbility.ToReference<BlueprintAbilityReference>(),
                            ResoundingBlowAbility.ToReference<BlueprintAbilityReference>(),
                            OathOfPeaceAbility.ToReference<BlueprintAbilityReference>(),
                        }
                    },
                    new SpellLevelList(5) {
                        m_Spells = new List<BlueprintAbilityReference> {
                            AngelicAspectAbility.ToReference<BlueprintAbilityReference>(),
                            AcidicSprayAbility.ToReference<BlueprintAbilityReference>(),
                            HoldMonsterAbility.ToReference<BlueprintAbilityReference>(),
                            ConstrictingCoilsAbility.ToReference<BlueprintAbilityReference>(),
                            ElementalBodyIIAbility.ToReference<BlueprintAbilityReference>(),
                            StoneskinCommunalAbility.ToReference<BlueprintAbilityReference>(),
                            SummonElementalLargeAbility.ToReference<BlueprintAbilityReference>(),
                            ConeOfColdAbility.ToReference<BlueprintAbilityReference>(),
                            IcyPrisonAbility.ToReference<BlueprintAbilityReference>(),
                            PolymorphAbility.ToReference<BlueprintAbilityReference>(),
                            DominatePersonAbility.ToReference<BlueprintAbilityReference>(),
                            MindFogAbility.ToReference<BlueprintAbilityReference>(),
                            WavesOfFatigueAbility.ToReference<BlueprintAbilityReference>(),
                            FeeblemindAbility.ToReference<BlueprintAbilityReference>(),
                            FireSnakeAbility.ToReference<BlueprintAbilityReference>(),
                            VampiricShadowShieldAbility.ToReference<BlueprintAbilityReference>(),
                            BreakEnchantmentAbility.ToReference<BlueprintAbilityReference>(),
                            HungryPitAbility.ToReference<BlueprintAbilityReference>(),
                            BalefulPolymorphAbility.ToReference<BlueprintAbilityReference>(),
                            AnimalGrowthAbility.ToReference<BlueprintAbilityReference>(),
                            GeniekindAbility.ToReference<BlueprintAbilityReference>(),
                            ShadowEvocationAbility.ToReference<BlueprintAbilityReference>(),
                            SummonMonsterVAbility.ToReference<BlueprintAbilityReference>(),
                            BeastShapeIIIAbility.ToReference<BlueprintAbilityReference>(),
                            PhantasmalWebAbility.ToReference<BlueprintAbilityReference>(),
                            WrackingRayAbility.ToReference<BlueprintAbilityReference>(),
                            ThoughtsenseAbility.ToReference<BlueprintAbilityReference>(),
                            CloudkillAbility.ToReference<BlueprintAbilityReference>(),
                            SerenityAbility.ToReference<BlueprintAbilityReference>(),
                            BreathOfLifeAbility.ToReference<BlueprintAbilityReference>(),
                            BurstOfGloryAbility.ToReference<BlueprintAbilityReference>(),
                            ClenseAbility.ToReference<BlueprintAbilityReference>(),
                            CureLightWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                            DisruptingWeaponAbility.ToReference<BlueprintAbilityReference>(),
                            InflictLightWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                            PillarOfLifeAbility.ToReference<BlueprintAbilityReference>(),
                            ProfaneNimbusAbility.ToReference<BlueprintAbilityReference>(),
                            RaiseDeadAbility.ToReference<BlueprintAbilityReference>(),
                            RighteousMightAbility.ToReference<BlueprintAbilityReference>(),
                            SacredNimbusAbility.ToReference<BlueprintAbilityReference>(),
                            SlayLivingAbility.ToReference<BlueprintAbilityReference>(),
                            SpellResistanceAbility.ToReference<BlueprintAbilityReference>(),
                            TrueSeeingAbility.ToReference<BlueprintAbilityReference>(),
                            VinetrapAbility.ToReference<BlueprintAbilityReference>(),
                            CommandGreaterAbility.ToReference<BlueprintAbilityReference>(),
                            CallLightningStormAbility.ToReference<BlueprintAbilityReference>(),
                            AspectOfTheWolfAbility.ToReference<BlueprintAbilityReference>(),
                            SummonNaturesAllyVAbility.ToReference<BlueprintAbilityReference>(),
                            CaveFangsAbility.ToReference<BlueprintAbilityReference>(),
                            BlessingOfTheSalamanderAbility.ToReference<BlueprintAbilityReference>(),
                            CastigateMassAbility.ToReference<BlueprintAbilityReference>(),
                            CacophonousCallMassAbility.ToReference<BlueprintAbilityReference>(),
                            SongOfDiscordAbility.ToReference<BlueprintAbilityReference>(),
                        }
                    },
                    new SpellLevelList(6) {
                        m_Spells = new List<BlueprintAbilityReference> {
                            ChainsOfLightAbility.ToReference<BlueprintAbilityReference>(),
                            ElementalAssessorAbility.ToReference<BlueprintAbilityReference>(),
                            StoneToFleshAbility.ToReference<BlueprintAbilityReference>(),
                            SummonMonsterVIAbility.ToReference<BlueprintAbilityReference>(),
                            DispelMagicGreaterAbility.ToReference<BlueprintAbilityReference>(),
                            FormOfTheDragonIAbility.ToReference<BlueprintAbilityReference>(),
                            UndeathToDeathAbility.ToReference<BlueprintAbilityReference>(),
                            CatsGraceMassAbility.ToReference<BlueprintAbilityReference>(),
                            BullsStrengthMassAbility.ToReference<BlueprintAbilityReference>(),
                            CircleOfDeathAbility.ToReference<BlueprintAbilityReference>(),
                            HeroismGreaterAbility.ToReference<BlueprintAbilityReference>(),
                            DisintegrateAbility.ToReference<BlueprintAbilityReference>(),
                            ChainLightningAbility.ToReference<BlueprintAbilityReference>(),
                            OwlsWisdomMassAbility.ToReference<BlueprintAbilityReference>(),
                            AcidFogAbility.ToReference<BlueprintAbilityReference>(),
                            BearsEnduranceMassAbility.ToReference<BlueprintAbilityReference>(),
                            HellfireRayAbility.ToReference<BlueprintAbilityReference>(),
                            CloakofDreamsAbility.ToReference<BlueprintAbilityReference>(),
                            FoxsCunningMassAbility.ToReference<BlueprintAbilityReference>(),
                            EaglesSplendorMassAbility.ToReference<BlueprintAbilityReference>(),
                            BeastShapeIVAbility.ToReference<BlueprintAbilityReference>(),
                            TransformationAbility.ToReference<BlueprintAbilityReference>(),
                            SiroccoAbility.ToReference<BlueprintAbilityReference>(),
                            ElementalBodyIIIAbility.ToReference<BlueprintAbilityReference>(),
                            TarPoolAbility.ToReference<BlueprintAbilityReference>(),
                            ColdIceStrikeAbility.ToReference<BlueprintAbilityReference>(),
                            BansheeBlastAbility.ToReference<BlueprintAbilityReference>(),
                            SummonElementalHugeAbility.ToReference<BlueprintAbilityReference>(),
                            PhantasmalPutrefactionAbility.ToReference<BlueprintAbilityReference>(),
                            EyebiteAbility.ToReference<BlueprintAbilityReference>(),
                            CreateUndeadAbility.ToReference<BlueprintAbilityReference>(),
                            BlessingOfLuckAndResolveMassAbility.ToReference<BlueprintAbilityReference>(),
                            EaglesoulAbility.ToReference<BlueprintAbilityReference>(),
                            TrueSeeingCommunalAbility.ToReference<BlueprintAbilityReference>(),
                            BladeBarrierAbility.ToReference<BlueprintAbilityReference>(),
                            CureModerateWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                            HarmAbility.ToReference<BlueprintAbilityReference>(),
                            HealAbility.ToReference<BlueprintAbilityReference>(),
                            InflictModerateWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                            InspiringRecoveryAbility.ToReference<BlueprintAbilityReference>(),
                            PlagueStormAbility.ToReference<BlueprintAbilityReference>(),
                            BanishmentAbility.ToReference<BlueprintAbilityReference>(),
                            JoyfulRaptureAbility.ToReference<BlueprintAbilityReference>(),
                            PrimalRegressionAbility.ToReference<BlueprintAbilityReference>(),
                            SummonNaturesAllyVIAbility.ToReference<BlueprintAbilityReference>(),
                            PoisonBreathAbility.ToReference<BlueprintAbilityReference>(),
                            FesterMassAbility.ToReference<BlueprintAbilityReference>(),
                            LitanyOfMadnessAbility.ToReference<BlueprintAbilityReference>(),
                            BrilliantInspirationAbility.ToReference<BlueprintAbilityReference>(),
                        }
                    },
                    new SpellLevelList(7) {
                        m_Spells = new List<BlueprintAbilityReference> {
                            UmbralStrikeAbility.ToReference<BlueprintAbilityReference>(),
                            InsanityAbility.ToReference<BlueprintAbilityReference>(),
                            PolymorphGreaterAbility.ToReference<BlueprintAbilityReference>(),
                            PowerWordBlindAbility.ToReference<BlueprintAbilityReference>(),
                            ElementalBodyIVAbility.ToReference<BlueprintAbilityReference>(),
                            FingerOfDeathAbility.ToReference<BlueprintAbilityReference>(),
                            WalkThroughSpaceAbility.ToReference<BlueprintAbilityReference>(),
                            SummonMonsterVIIAbility.ToReference<BlueprintAbilityReference>(),
                            FormOfTheDragonIIAbility.ToReference<BlueprintAbilityReference>(),
                            CircleOfClarityAbility.ToReference<BlueprintAbilityReference>(),
                            KiShoutAbility.ToReference<BlueprintAbilityReference>(),
                            ResonatingWordAbility.ToReference<BlueprintAbilityReference>(),
                            PrismaticSprayAbility.ToReference<BlueprintAbilityReference>(),
                            InvisibilityMassAbility.ToReference<BlueprintAbilityReference>(),
                            IceBodyAbility.ToReference<BlueprintAbilityReference>(),
                            WavesOfEcstasyAbility.ToReference<BlueprintAbilityReference>(),
                            HoldPersonMassAbility.ToReference<BlueprintAbilityReference>(),
                            SummonElementalGreaterAbility.ToReference<BlueprintAbilityReference>(),
                            CausticEruptionAbility.ToReference<BlueprintAbilityReference>(),
                            WavesOfExhaustionAbility.ToReference<BlueprintAbilityReference>(),
                            LegendaryProportionsAbility.ToReference<BlueprintAbilityReference>(),
                            ShadowConjurationGreaterAbility.ToReference<BlueprintAbilityReference>(),
                            FirebrandAbility.ToReference<BlueprintAbilityReference>(),
                            BestowGraceOfTheChampionAbility.ToReference<BlueprintAbilityReference>(),
                            ArbitramentAbility.ToReference<BlueprintAbilityReference>(),
                            BlasphemyAbility.ToReference<BlueprintAbilityReference>(),
                            DictumAbility.ToReference<BlueprintAbilityReference>(),
                            HolyWordAbility.ToReference<BlueprintAbilityReference>(),
                            WordOfChaosAbility.ToReference<BlueprintAbilityReference>(),
                            CureSeriousWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                            DestructionAbility.ToReference<BlueprintAbilityReference>(),
                            InflictSeriousWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                            JoltingPortentAbility.ToReference<BlueprintAbilityReference>(),
                            RestorationGreaterAbility.ToReference<BlueprintAbilityReference>(),
                            ResurrectionAbility.ToReference<BlueprintAbilityReference>(),
                            BestowCurseGreaterAbility.ToReference<BlueprintAbilityReference>(),
                            SummonNaturesAllyVIIAbility.ToReference<BlueprintAbilityReference>(),
                            CreepingDoomAbility.ToReference<BlueprintAbilityReference>(),
                            SunbeamAbility.ToReference<BlueprintAbilityReference>(),
                            FireStormAbility.ToReference<BlueprintAbilityReference>(),
                            ChangestaffAbility.ToReference<BlueprintAbilityReference>()
                        }
                    },
                    new SpellLevelList(8) {
                        m_Spells = new List<BlueprintAbilityReference> {
                            AngelicAspectGreaterAbility.ToReference<BlueprintAbilityReference>(),
                            ShoutGreaterAbility.ToReference<BlueprintAbilityReference>(),
                            ProtectionFromSpellsAbility.ToReference<BlueprintAbilityReference>(),
                            SummonMonsterVIIIAbility.ToReference<BlueprintAbilityReference>(),
                            ScintillatingPatternAbility.ToReference<BlueprintAbilityReference>(),
                            SummonElementalElderAbility.ToReference<BlueprintAbilityReference>(),
                            HoridWiltingAbility.ToReference<BlueprintAbilityReference>(),
                            SunburstAbility.ToReference<BlueprintAbilityReference>(),
                            DeathClutchAbility.ToReference<BlueprintAbilityReference>(),
                            PolarRayAbility.ToReference<BlueprintAbilityReference>(),
                            FrightfulAspectAbility.ToReference<BlueprintAbilityReference>(),
                            SeamantleAbility.ToReference<BlueprintAbilityReference>(),
                            FormOfTheDragonIIIAbility.ToReference<BlueprintAbilityReference>(),
                            IronBodyAbility.ToReference<BlueprintAbilityReference>(),
                            RiftOfRuinAbility.ToReference<BlueprintAbilityReference>(),
                            PredictionOfFailureAbility.ToReference<BlueprintAbilityReference>(),
                            PowerWordStunAbility.ToReference<BlueprintAbilityReference>(),
                            ShadowEvocationGreaterAbility.ToReference<BlueprintAbilityReference>(),
                            StormboltsAbility.ToReference<BlueprintAbilityReference>(),
                            MindBlankAbility.ToReference<BlueprintAbilityReference>(),
                            EuphoricTranquilityAbility.ToReference<BlueprintAbilityReference>(),
                            SouldreaverAbility.ToReference<BlueprintAbilityReference>(),
                            CloakOfChaosAbility.ToReference<BlueprintAbilityReference>(),
                            CureCriticalWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                            HolyAuraAbility.ToReference<BlueprintAbilityReference>(),
                            InflictCriticalWoundsMassAbility.ToReference<BlueprintAbilityReference>(),
                            ShieldOfLawAbility.ToReference<BlueprintAbilityReference>(),
                            UnholyAuraAbility.ToReference<BlueprintAbilityReference>(),
                            AnimalShapesAbility.ToReference<BlueprintAbilityReference>(),
                            SummonNaturesAllyVIIIAbility.ToReference<BlueprintAbilityReference>()
                        }
                    },
                    new SpellLevelList(9) {
                        m_Spells = new List<BlueprintAbilityReference> {
                            OverwhelmingPresenceAbility.ToReference<BlueprintAbilityReference>(),
                            IcyPrisonMassAbility.ToReference<BlueprintAbilityReference>(),
                            ShadesAbility.ToReference<BlueprintAbilityReference>(),
                            TsunamiAbility.ToReference<BlueprintAbilityReference>(),
                            PowerWordKillAbility.ToReference<BlueprintAbilityReference>(),
                            WailOfBansheeAbility.ToReference<BlueprintAbilityReference>(),
                            ClashingRocksAbility.ToReference<BlueprintAbilityReference>(),
                            ShapechangeAbility.ToReference<BlueprintAbilityReference>(),
                            HeroicInvocationAbility.ToReference<BlueprintAbilityReference>(),
                            EnergyDrainAbility.ToReference<BlueprintAbilityReference>(),
                            WeirdAbility.ToReference<BlueprintAbilityReference>(),
                            SummonMonsterIXAbility.ToReference<BlueprintAbilityReference>(),
                            FieryBodyAbility.ToReference<BlueprintAbilityReference>(),
                            DominateMonsterAbility.ToReference<BlueprintAbilityReference>(),
                            HoldMonsterMassAbility.ToReference<BlueprintAbilityReference>(),
                            ForesightAbility.ToReference<BlueprintAbilityReference>(),
                            MindBlankCommunalAbility.ToReference<BlueprintAbilityReference>(),
                            HealMassAbility.ToReference<BlueprintAbilityReference>(),
                            PolarMidnightAbility.ToReference<BlueprintAbilityReference>(),
                            WindsOfVengeanceAbility.ToReference<BlueprintAbilityReference>(),
                            SummonNaturesAllyIXAbility.ToReference<BlueprintAbilityReference>(),
                            ElementalSwarmAbility.ToReference<BlueprintAbilityReference>(),
                            SummonElderWormAbility.ToReference<BlueprintAbilityReference>()
                        }
                    },
                    new SpellLevelList(10) { m_Spells = new List<BlueprintAbilityReference> { } }
                };
            });
        }
        public static BlueprintSpellList Get()
        {
            return BlueprintTools.GetModBlueprint<BlueprintSpellList>(IsekaiContext, "IsekaiProtagonistSpellList");
        }
        // spells that are technically their own spell but should be excluded because they are things like Protection From Chaos or Protection From Evil that are also covered by a more general spell that is a feature Selection
        private static Boolean excludeSpell(BlueprintAbility spell) {
            var GUIId = spell.AssetGuid.m_Guid.ToString("N");
            if ("0ec75ec95d9e39d47a23610123ba1bad".Equals(GUIId)) return true;
            if ("b6da529f710491b4fa789a5838c1ae8f".Equals(GUIId)) return true;
            if ("3026de673d4d8fe45baf40e0b5edd718".Equals(GUIId)) return true;
            if ("93f391b0c5a99e04e83bbfbe3bb6db64".Equals(GUIId)) return true;
            if ("224f03e74d1dd4648a81242c01e65f41".Equals(GUIId)) return true;
            if ("5bfd4cce1557d5744914f8f6d85959a4".Equals(GUIId)) return true;
            if ("8b8ccc9763e3cc74bbf5acc9c98557b9".Equals(GUIId)) return true;
            if ("1eaf1020e82028d4db55e6e464269e00".Equals(GUIId)) return true;
            if ("b70104f09b3da794da923fbf248befc5".Equals(GUIId)) return true;
            if ("c28f7234f5fb8c943a77621ad96ad8f9".Equals(GUIId)) return true;
            if ("eee384c813b6d74498d1b9cc720d61f4".Equals(GUIId)) return true;
            if ("07dccc8e4c4489c4d9de721dddaf12cc".Equals(GUIId)) return true;
            if ("2ac7637daeb2aa143a3bae860095b63e".Equals(GUIId)) return true;
            if ("c3aafbbb6e8fc754fb8c82ede3280051".Equals(GUIId)) return true;
            //elemental swarms
            if ("07e8f6479cbcc3f46a12696784805305".Equals(GUIId)) return true;
            if ("a6c41f10be92dec488276ab079a296c8".Equals(GUIId)) return true;
            if ("1c509c6f186528b49a291ab77f7f997d".Equals(GUIId)) return true;
            if ("a0df3fc5fda5c7b4bbec8443e5bb315a".Equals(GUIId)) return true;
            //elder fire
            if ("e4926aa766a1cc048835237b3a97597d".Equals(GUIId)) return true;
            //greater air
            if ("a4849d6bd536ade48a3839a4ad960a8b".Equals(GUIId)) return true;
            //elemental body
            if ("ee63301f83c76694692d4704d8a05bdc".Equals(GUIId)) return true;
            if ("facdc8851a0b3f44a8bed50f0199b83c".Equals(GUIId)) return true;
            if ("c281eeecc554b72449fef43924e522ce".Equals(GUIId)) return true;
            if ("96d2ab91f2d2329459a8dab496c5bede".Equals(GUIId)) return true;
            //level 6 beast shape, body air, summon fire
            if ("b140c323981ba0a45a3bee5a1a57f493".Equals(GUIId)) return true;
            if ("cd4b858611f11ec44861f02505f9261d".Equals(GUIId)) return true;
            if ("4814f8645d1d77447a70479c0be51c72".Equals(GUIId)) return true;
            //dim door mass
            if ("5bdc37e4acfa209408334326076a43bc".Equals(GUIId)) return true;
            return false;
        }

        public static void MergeSpellLists() {
            var IsekaiSpellList = Get();
            /* merge the three major first then everything else after*/
            foreach (var spellLevel in SpellTools.SpellList.ClericSpellList.SpellsByLevel) {
                foreach (var spell in spellLevel.Spells) {
                    if (!excludeSpell(spell)) {
                        ThingsNotHandledByTTTCore.RegisterSpell(IsekaiSpellList, spell, spellLevel.SpellLevel);
                    }
                }
            }
            foreach (var spellLevel in SpellTools.SpellList.WizardSpellList.SpellsByLevel) {
                foreach (var spell in spellLevel.Spells) {
                    if (!excludeSpell(spell)) {
                        ThingsNotHandledByTTTCore.RegisterSpell(IsekaiSpellList, spell, spellLevel.SpellLevel);
                    }
                }
            }
            foreach (var spellLevel in SpellTools.SpellList.DruidSpellList.SpellsByLevel) {
                foreach (var spell in spellLevel.Spells) {
                    if (!excludeSpell(spell)) {
                        ThingsNotHandledByTTTCore.RegisterSpell(IsekaiSpellList, spell, spellLevel.SpellLevel);
                    }
                }
            }
            /* mostly redundant list as I think that all domain spells appear on at least one other spellist and the specialist wizard lists should be sub lists of the wizard, but it can't really hurt and someone might release a spell only available to necromancers*/
            var mergeSpellLists = new BlueprintSpellList[70]
            {
                SpellTools.SpellList.AirDomainSpellList, SpellTools.SpellList.AnimalDomainSpellList, SpellTools.SpellList.ArmagsBladeSpellList, SpellTools.SpellList.ArtificeDomainSpellList, SpellTools.SpellList.BattleSpiritSpellList, 
                SpellTools.SpellList.BloodragerSpellList, SpellTools.SpellList.BonesSpiritSpellList, SpellTools.SpellList.ChaosDomainSpellList, SpellTools.SpellList.CharmDomainSpellList, SpellTools.SpellList.CommunityDomainSpellList, 
                SpellTools.SpellList.DarknessDomainSpellList, SpellTools.SpellList.DeathDomainSpellList,  SpellTools.SpellList.DestructionDomainSpellList, SpellTools.SpellList.EarthDomainSpellList, SpellTools.SpellList.EvilDomainSpellList, 
                SpellTools.SpellList.FeyspeakerSpelllist, SpellTools.SpellList.FireDomainSpellList, SpellTools.SpellList.FlamesSpiritSpellList,  SpellTools.SpellList.FrostSpiritSpellList,
                SpellTools.SpellList.GloryDomainSpellList, SpellTools.SpellList.GoodDomainSpellList, SpellTools.SpellList.HealingDomainSpellList,
                SpellTools.SpellList.KnowledgeDomainSpellList, SpellTools.SpellList.LawDomainSpellList, SpellTools.SpellList.LiberationDomainSpellList, SpellTools.SpellList.LifeSpiritSpellList, SpellTools.SpellList.LuckDomainSpellList,
                SpellTools.SpellList.MadnessDomainSpellList, SpellTools.SpellList.MagicDomainSpellList, SpellTools.SpellList.NatureSpiritSpellList, SpellTools.SpellList.NobilityDomainSpellList,
                SpellTools.SpellList.PlantDomainSpellList, SpellTools.SpellList.ProtectionDomainSpellList, SpellTools.SpellList.RangerSpellList, SpellTools.SpellList.ReposeDomainSpellList,
                SpellTools.SpellList.RuneDomainSpellList,  SpellTools.SpellList.ShamanSpelllist, SpellTools.SpellList.SpiritWardenSpellList, SpellTools.SpellList.StoneSpiritSpellList, SpellTools.SpellList.StrengthDomainSpellList,
                SpellTools.SpellList.SunDomainSpellList, SpellTools.SpellList.ThassilonianAbjurationSpellList, SpellTools.SpellList.ThassilonianConjurationSpellList, SpellTools.SpellList.ThassilonianEnchantmentSpellList, SpellTools.SpellList.ThassilonianEvocationSpellList,
                SpellTools.SpellList.ThassilonianIllusionSpellList, SpellTools.SpellList.ThassilonianNecromancySpellList, SpellTools.SpellList.ThassilonianTransmutationSpellList, SpellTools.SpellList.TravelDomainSpellList, SpellTools.SpellList.TrickeryDomainSpellList,
                SpellTools.SpellList.WarDomainSpellList, SpellTools.SpellList.WarpriestSpelllist, SpellTools.SpellList.WaterDomainSpellList,
                SpellTools.SpellList.WavesSpiritSpellList, SpellTools.SpellList.WeatherDomainSpellList, SpellTools.SpellList.WindSpiritSpellList, SpellTools.SpellList.WitchSpellList, SpellTools.SpellList.WizardAbjurationSpellList,
                SpellTools.SpellList.WizardConjurationSpellList, SpellTools.SpellList.WizardDivinationSpellList, SpellTools.SpellList.WizardEnchantmentSpellList, SpellTools.SpellList.WizardEvocationSpellList, SpellTools.SpellList.WizardIllusionSpellList,
                SpellTools.SpellList.WizardNecromancySpellList, SpellTools.SpellList.WizardTransmutationSpellList,
                SpellTools.SpellList.BardSpellList, SpellTools.SpellList.PaladinSpellList, SpellTools.SpellList.HunterSpelllist, SpellTools.SpellList.InquisitorSpellList, SpellTools.SpellList.MagusSpellList
            };
            foreach (var spellList in mergeSpellLists) {
                foreach (var spellLevel in spellList.SpellsByLevel) {
                    foreach (var spell in spellLevel.Spells) {
                        if (!excludeSpell(spell)) {
                            ThingsNotHandledByTTTCore.RegisterSpell(IsekaiSpellList, spell, spellLevel.SpellLevel);
                        }
                    }
                }
            }
            var cantrips = IsekaiSpellList.GetSpells(0);
            var IsekaiCantrips = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProtagonistCantripsFeature");
            IsekaiCantrips.AddComponent<AddFacts>(c => {
                c.m_Facts = new BlueprintUnitFactReference[0];
                foreach (var spell in cantrips) {
                    c.m_Facts = c.m_Facts.AppendToArray(spell.ToReference<BlueprintUnitFactReference>());
                }
            });


        }
    }
}
