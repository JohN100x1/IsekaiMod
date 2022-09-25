using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System.Collections.Generic;

namespace IsekaiMod.Changes.Classes.IsekaiProtagonist
{
    class IsekaiProtagonistSpellList
    {
        // Spells - 0
        public static readonly BlueprintAbility MageLightAbility = Resources.GetBlueprint<BlueprintAbility>("95f206566c5261c42aa5b3e7e0d1e36c");
        public static readonly BlueprintAbility JoltAbility = Resources.GetBlueprint<BlueprintAbility>("16e23c7a8ae53cc42a93066d19766404");
        public static readonly BlueprintAbility DisruptUndeadAbility = Resources.GetBlueprint<BlueprintAbility>("652739779aa05504a9ad5db1db6d02ae");
        public static readonly BlueprintAbility AcidSplashAbility = Resources.GetBlueprint<BlueprintAbility>("0c852a2405dd9f14a8bbcfaf245ff823");
        public static readonly BlueprintAbility DismissAreaEffectAbility = Resources.GetBlueprint<BlueprintAbility>("97a23111df7547fd8f6417f9ba9b9775");
        public static readonly BlueprintAbility DazeAbility = Resources.GetBlueprint<BlueprintAbility>("55f14bc84d7c85446b07a1b5dd6b2b4c");
        public static readonly BlueprintAbility TouchOfFatigueAbility = Resources.GetBlueprint<BlueprintAbility>("5bf3315ce1ed4d94e8805706820ef64d");
        public static readonly BlueprintAbility FlareAbility = Resources.GetBlueprint<BlueprintAbility>("f0f8e5b9808f44e4eadd22b138131d52");
        public static readonly BlueprintAbility RayOfFrostAbility = Resources.GetBlueprint<BlueprintAbility>("9af2ab69df6538f4793b2f9c3cc85603");
        public static readonly BlueprintAbility ResistanceAbility = Resources.GetBlueprint<BlueprintAbility>("7bc8e27cba24f0e43ae64ed201ad5785");
        public static readonly BlueprintAbility DivineZapAbility = Resources.GetBlueprint<BlueprintAbility>("8a1992f59e06dd64ab9ba52337bf8cb5");
        public static readonly BlueprintAbility GuidanceAbility = Resources.GetBlueprint<BlueprintAbility>("c3a8f31778c3980498d8f00c980be5f5");
        public static readonly BlueprintAbility VirtueAbility = Resources.GetBlueprint<BlueprintAbility>("d3a852385ba4cd740992d1970170301a");

        // Spells - 1
        private static readonly BlueprintAbility SnowBallAbility = Resources.GetBlueprint<BlueprintAbility>("9f10909f0be1f5141bf1c102041f93d9");
        private static readonly BlueprintAbility VanishAbility = Resources.GetBlueprint<BlueprintAbility>("f001c73999fb5a543a199f890108d936");
        private static readonly BlueprintAbility ColorSprayAbility = Resources.GetBlueprint<BlueprintAbility>("91da41b9793a4624797921f221db653c");
        private static readonly BlueprintAbility ShockingGraspAbility = Resources.GetBlueprint<BlueprintAbility>("ab395d2335d3f384e99dddee8562978f");
        private static readonly BlueprintAbility MagicWeaponAbility = Resources.GetBlueprint<BlueprintAbility>("d7fdd79f0f6b6a2418298e936bb68e40");
        private static readonly BlueprintAbility EarPiercingScreamAbility = Resources.GetBlueprint<BlueprintAbility>("8e7cfa5f213a90549aadd18f8f6f4664");
        private static readonly BlueprintAbility StunningBarrierAbility = Resources.GetBlueprint<BlueprintAbility>("a5ec7892fb1c2f74598b3a82f3fd679f");
        private static readonly BlueprintAbility MageShieldAbility = Resources.GetBlueprint<BlueprintAbility>("ef768022b0785eb43a18969903c537c4");
        private static readonly BlueprintAbility CorrosiveTouchAbility = Resources.GetBlueprint<BlueprintAbility>("95810d2829895724f950c8c4086056e7");
        private static readonly BlueprintAbility ExpeditiousRetreatAbility = Resources.GetBlueprint<BlueprintAbility>("4f8181e7a7f1d904fbaea64220e83379");
        private static readonly BlueprintAbility TouchOfGracelessnessAbility = Resources.GetBlueprint<BlueprintAbility>("ad10bfec6d7ae8b47870e3a545cc8900");
        private static readonly BlueprintAbility MagicMissileAbility = Resources.GetBlueprint<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
        private static readonly BlueprintAbility ProtectionFromAlignmentAbility = Resources.GetBlueprint<BlueprintAbility>("433b1faf4d02cc34abb0ade5ceda47c4");
        private static readonly BlueprintAbility BurningHandsAbility = Resources.GetBlueprint<BlueprintAbility>("4783c3709a74a794dbe7c8e7e0b1b038");
        private static readonly BlueprintAbility CauseFearAbility = Resources.GetBlueprint<BlueprintAbility>("bd81a3931aa285a4f9844585b5d97e51");
        private static readonly BlueprintAbility TrueStrikeAbility = Resources.GetBlueprint<BlueprintAbility>("2c38da66e5a599347ac95b3294acbe00");
        private static readonly BlueprintAbility FlareBurstAbility = Resources.GetBlueprint<BlueprintAbility>("39a602aa80cc96f4597778b6d4d49c0a");
        private static readonly BlueprintAbility HurricaneBowAbility = Resources.GetBlueprint<BlueprintAbility>("3e9d1119d43d07c4c8ba9ebfd1671952");
        private static readonly BlueprintAbility MageArmorAbility = Resources.GetBlueprint<BlueprintAbility>("9e1ad5d6f87d19e4d8883d63a6e35568");
        private static readonly BlueprintAbility GreaseAbility = Resources.GetBlueprint<BlueprintAbility>("95851f6e85fe87d4190675db0419d112");
        private static readonly BlueprintAbility SleepAbility = Resources.GetBlueprint<BlueprintAbility>("bb7ecad2d3d2c8247a38f44855c99061");
        private static readonly BlueprintAbility ReducePersonAbility = Resources.GetBlueprint<BlueprintAbility>("4e0e9aba6447d514f88eff1464cc4763");
        private static readonly BlueprintAbility RayOfSickeningAbility = Resources.GetBlueprint<BlueprintAbility>("fa3078b9976a5b24caf92e20ee9c0f54");
        private static readonly BlueprintAbility StoneFistAbility = Resources.GetBlueprint<BlueprintAbility>("85067a04a97416949b5d1dbf986d93f3");
        private static readonly BlueprintAbility RayOfEnfeeblementAbility = Resources.GetBlueprint<BlueprintAbility>("450af0402422b0b4980d9c2175869612");
        private static readonly BlueprintAbility SummonMonsterIAbility = Resources.GetBlueprint<BlueprintAbility>("8fd74eddd9b6c224693d9ab241f25e84");
        private static readonly BlueprintAbility EnlargePersonAbility = Resources.GetBlueprint<BlueprintAbility>("c60969e7f264e6d4b84a1499fdcf9039");
        private static readonly BlueprintAbility HypnotismAbility = Resources.GetBlueprint<BlueprintAbility>("88367310478c10b47903463c5d0152b0");
        private static readonly BlueprintAbility BaneAbility = Resources.GetBlueprint<BlueprintAbility>("8bc64d869456b004b9db255cdd1ea734");
        private static readonly BlueprintAbility BlessAbility = Resources.GetBlueprint<BlueprintAbility>("90e59f4a4ada87243b7b3535a06d0638");
        private static readonly BlueprintAbility CureLightWoundsAbility = Resources.GetBlueprint<BlueprintAbility>("5590652e1c2225c4ca30c4a699ab3649");
        private static readonly BlueprintAbility DivineFavorAbility = Resources.GetBlueprint<BlueprintAbility>("9d5d2d3ffdd73c648af3eb3e585b1113");
        private static readonly BlueprintAbility DoomAbility = Resources.GetBlueprint<BlueprintAbility>("fbdd8c455ac4cde4a9a3e18c84af9485");
        private static readonly BlueprintAbility FirebellyAbility = Resources.GetBlueprint<BlueprintAbility>("b065231094a21d14dbf1c3832f776871");
        private static readonly BlueprintAbility InflictLightWoundsAbility = Resources.GetBlueprint<BlueprintAbility>("e5af3674bb241f14b9a9f6b0c7dc3d27");
        private static readonly BlueprintAbility RemoveFearAbility = Resources.GetBlueprint<BlueprintAbility>("55a037e514c0ee14a8e3ed14b47061de");
        private static readonly BlueprintAbility RemoveSicknessAbility = Resources.GetBlueprint<BlueprintAbility>("f6f95242abdfac346befd6f4f6222140");
        private static readonly BlueprintAbility ShieldOfFaithAbility = Resources.GetBlueprint<BlueprintAbility>("183d5bb91dea3a1489a6db6c9cb64445");
        private static readonly BlueprintAbility UnbreakableHeartAbility = Resources.GetBlueprint<BlueprintAbility>("dd38f33c56ad00a4da386c1afaa49967");
        private static readonly BlueprintAbility HazeOfDreamsAbility = Resources.GetBlueprint<BlueprintAbility>("40ec382849b60504d88946df46a10f2d");
        private static readonly BlueprintAbility CommandAbility = Resources.GetBlueprint<BlueprintAbility>("feb70aab86cc17f4bb64432c83737ac2");
        private static readonly BlueprintAbility SummonNaturesAllyIAbility = Resources.GetBlueprint<BlueprintAbility>("c6147854641924442a3bb736080cfeb6");
        private static readonly BlueprintAbility AcidMawAbility = Resources.GetBlueprint<BlueprintAbility>("75de4ded3e731dc4f84d978fe947dc67");
        private static readonly BlueprintAbility MagicFangAbility = Resources.GetBlueprint<BlueprintAbility>("403cf599412299a4f9d5d925c7b9fb33");
        private static readonly BlueprintAbility AspectOfTheFalconAbility = Resources.GetBlueprint<BlueprintAbility>("7bdb6a9fb6b37614e96f155748ae50c6");
        private static readonly BlueprintAbility FeatherStepAbility = Resources.GetBlueprint<BlueprintAbility>("f3c0b267dd17a2a45a40805e31fe3cd1");
        private static readonly BlueprintAbility EntangleAbility = Resources.GetBlueprint<BlueprintAbility>("0fd00984a2c0e0a429cf1a911b4ec5ca");
        private static readonly BlueprintAbility FaerieFireAbility = Resources.GetBlueprint<BlueprintAbility>("4d9bf81b7939b304185d58a09960f589");
        private static readonly BlueprintAbility LongstriderAbility = Resources.GetBlueprint<BlueprintAbility>("14c90900b690cac429b229efdf416127");

        // Spells - 2
        private static readonly BlueprintAbility OwlsWisdomAbility = Resources.GetBlueprint<BlueprintAbility>("f0455c9295b53904f9e02fc571dd2ce1");
        private static readonly BlueprintAbility BurningArcAbility = Resources.GetBlueprint<BlueprintAbility>("eaac3d36e0336cb479209a6f65e25e7c");
        private static readonly BlueprintAbility FalseLifeAbility = Resources.GetBlueprint<BlueprintAbility>("7a5b5bf845779a941a67251539545762");
        private static readonly BlueprintAbility AnimalAspectAbility = Resources.GetBlueprint<BlueprintAbility>("d4b28341acdfa9443a3a779acb58be51");
        private static readonly BlueprintAbility SummonElementalSmallAbility = Resources.GetBlueprint<BlueprintAbility>("970c6db48ff0c6f43afc9dbb48780d03");
        private static readonly BlueprintAbility BoneShakerAbility = Resources.GetBlueprint<BlueprintAbility>("b7731c2b4fa1c9844a092329177be4c3");
        private static readonly BlueprintAbility StoneCallAbility = Resources.GetBlueprint<BlueprintAbility>("5181c2ed0190fc34b8a1162783af5bf4");
        private static readonly BlueprintAbility HideousLaughterAbility = Resources.GetBlueprint<BlueprintAbility>("fd4d9fd7f87575d47aafe2a64a6e2d8d");
        private static readonly BlueprintAbility MoltenOrbAbility = Resources.GetBlueprint<BlueprintAbility>("42a65895ba0cb3a42b6019039dd2bff1");
        private static readonly BlueprintAbility ProtectionFromAlignmentCommunalAbility = Resources.GetBlueprint<BlueprintAbility>("2cadf6c6350e4684baa109d067277a45");
        private static readonly BlueprintAbility AcidArrowAbility = Resources.GetBlueprint<BlueprintAbility>("9a46dfd390f943647ab4395fc997936d");
        private static readonly BlueprintAbility SeeInvisibilityAbility = Resources.GetBlueprint<BlueprintAbility>("30e5dc243f937fc4b95d2f8f4e1b7ff3");
        private static readonly BlueprintAbility ScorchingRayAbility = Resources.GetBlueprint<BlueprintAbility>("cdb106d53c65bbc4086183d54c3b97c7");
        private static readonly BlueprintAbility ScareAbility = Resources.GetBlueprint<BlueprintAbility>("08cb5f4c3b2695e44971bf5c45205df0");
        private static readonly BlueprintAbility BullsStrengthAbility = Resources.GetBlueprint<BlueprintAbility>("4c3d08935262b6544ae97599b3a9556d");
        private static readonly BlueprintAbility GlitterdustAbility = Resources.GetBlueprint<BlueprintAbility>("ce7dad2b25acf85429b6c9550787b2d9");
        private static readonly BlueprintAbility CreatePitAbility = Resources.GetBlueprint<BlueprintAbility>("29ccc62632178d344ad0be0865fd3113");
        private static readonly BlueprintAbility BearsEnduranceAbility = Resources.GetBlueprint<BlueprintAbility>("a900628aea19aa74aad0ece0e65d091a");
        private static readonly BlueprintAbility SenseVitalsAbility = Resources.GetBlueprint<BlueprintAbility>("82962a820ebc0e7408b8582fdc3f4c0c");
        private static readonly BlueprintAbility EaglesSplendorAbility = Resources.GetBlueprint<BlueprintAbility>("446f7bf201dc1934f96ac0a26e324803");
        private static readonly BlueprintAbility ResisEnergyAbility = Resources.GetBlueprint<BlueprintAbility>("21ffef7791ce73f468b6fca4d9371e8b");
        private static readonly BlueprintAbility CommandUndeadAbility = Resources.GetBlueprint<BlueprintAbility>("0b101dd5618591e478f825f0eef155b4");
        private static readonly BlueprintAbility BlurAbility = Resources.GetBlueprint<BlueprintAbility>("14ec7a4e52e90fa47a4c8d63c69fd5c1");
        private static readonly BlueprintAbility ProtectionFromArrowsAbility = Resources.GetBlueprint<BlueprintAbility>("c28de1f98a3f432448e52e5d47c73208");
        private static readonly BlueprintAbility PerniciousPoisonAbility = Resources.GetBlueprint<BlueprintAbility>("dee3074b2fbfb064b80b973f9b56319e");
        private static readonly BlueprintAbility MirrorImageAbility = Resources.GetBlueprint<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
        private static readonly BlueprintAbility WebAbility = Resources.GetBlueprint<BlueprintAbility>("134cb6d492269aa4f8662700ef57449f");
        private static readonly BlueprintAbility InvisibilityAbility = Resources.GetBlueprint<BlueprintAbility>("89940cde01689fb46946b2f8cd7b66b7");
        private static readonly BlueprintAbility BlindnessAbility = Resources.GetBlueprint<BlueprintAbility>("46fd02ad56c35224c9c91c88cd457791");
        private static readonly BlueprintAbility FrigidTouchAbility = Resources.GetBlueprint<BlueprintAbility>("b6010dda6333bcf4093ce20f0063cd41");
        private static readonly BlueprintAbility CatsGraceAbility = Resources.GetBlueprint<BlueprintAbility>("de7a025d48ad5da4991e7d3c682cf69d");
        private static readonly BlueprintAbility SummonMonsterIIAbility = Resources.GetBlueprint<BlueprintAbility>("1724061e89c667045a6891179ee2e8e7");
        private static readonly BlueprintAbility FoxsCunningAbility = Resources.GetBlueprint<BlueprintAbility>("ae4d3ad6a8fda1542acf2e9bbc13d113");
        private static readonly BlueprintAbility ArrowOfLawAbility = Resources.GetBlueprint<BlueprintAbility>("dd2a5a6e76611c04e9eac6254fcf8c6b");
        private static readonly BlueprintAbility AidAbility = Resources.GetBlueprint<BlueprintAbility>("03a9630394d10164a9410882d31572f0");
        private static readonly BlueprintAbility BlessingOfCourageAndLifeAbility = Resources.GetBlueprint<BlueprintAbility>("c36c1d11771b0584f8e100b92ee5475b");
        private static readonly BlueprintAbility BlessingOfLuckAndResolveAbility = Resources.GetBlueprint<BlueprintAbility>("9a7e3cd1323dfe347a6dcce357844769");
        private static readonly BlueprintAbility CureModerateWoundsAbility = Resources.GetBlueprint<BlueprintAbility>("6b90c773a6543dc49b2505858ce33db5");
        private static readonly BlueprintAbility DelayPoisonAbility = Resources.GetBlueprint<BlueprintAbility>("b48b4c5ffb4eab0469feba27fc86a023");
        private static readonly BlueprintAbility EffortlessArmorAbility = Resources.GetBlueprint<BlueprintAbility>("e1291272c8f48c14ab212a599ad17aac");
        private static readonly BlueprintAbility FindTrapsAbility = Resources.GetBlueprint<BlueprintAbility>("4709274b2080b6444a3c11c6ebbe2404");
        private static readonly BlueprintAbility GraceAbility = Resources.GetBlueprint<BlueprintAbility>("464a7193519429f48b4d190acb753cf0");
        private static readonly BlueprintAbility InflictModerateWoundsAbility = Resources.GetBlueprint<BlueprintAbility>("65f0b63c45ea82a4f8b8325768a3832d");
        private static readonly BlueprintAbility RemoveParalysisAbility = Resources.GetBlueprint<BlueprintAbility>("f8bce986adfc88544a42bf4ab7ae75b2");
        private static readonly BlueprintAbility RestorationLesserAbility = Resources.GetBlueprint<BlueprintAbility>("e84fc922ccf952943b5240293669b171");
        private static readonly BlueprintAbility SoundBurstAbility = Resources.GetBlueprint<BlueprintAbility>("c3893092a333b93499fd0a21845aa265");
        private static readonly BlueprintAbility HoldPersonAbility = Resources.GetBlueprint<BlueprintAbility>("c7104f7526c4c524f91474614054547e");
        private static readonly BlueprintAbility AlignWeaponAbility = Resources.GetBlueprint<BlueprintAbility>("d026d5c80dbb9224f9a97fec83f5644a");
        private static readonly BlueprintAbility PoxPustulesAbility = Resources.GetBlueprint<BlueprintAbility>("bc153808ef4884a4594bc9bec2299b69");
        private static readonly BlueprintAbility NaturalRythmAbility = Resources.GetBlueprint<BlueprintAbility>("dde924776bd7ad247928b5efbfacfbdd");
        private static readonly BlueprintAbility SummonNaturesAllyIIAbility = Resources.GetBlueprint<BlueprintAbility>("298148133cdc3fd42889b99c82711986");
        private static readonly BlueprintAbility BarkskinAbility = Resources.GetBlueprint<BlueprintAbility>("5b77d7cc65b8ab74688e74a37fc2f553");
        private static readonly BlueprintAbility HoldAnimalAbility = Resources.GetBlueprint<BlueprintAbility>("41bab342089c0254ca222eb918e98cd4");
        private static readonly BlueprintAbility AspectOfTheBearAbility = Resources.GetBlueprint<BlueprintAbility>("a4ad1b8fa11e7c347a608c004efce9d5");
        private static readonly BlueprintAbility SickeningEntanglementAbility = Resources.GetBlueprint<BlueprintAbility>("6c7467f0344004d48848a43d8c078bf8");

        // Spells - 3
        private static readonly BlueprintAbility VampiricTouchAbility = Resources.GetBlueprint<BlueprintAbility>("8a28a811ca5d20d49a863e832c31cce1");
        private static readonly BlueprintAbility MagicWeaponGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("0f92caa35619f234298d95a4b6dda90d");
        private static readonly BlueprintAbility ProtectionFromArrowsCommunalAbility = Resources.GetBlueprint<BlueprintAbility>("96c9d98b6a9a7c249b6c4572e4977157");
        private static readonly BlueprintAbility ProtectionFromEnergyAbility = Resources.GetBlueprint<BlueprintAbility>("d2f116cfe05fcdd4a94e80143b67046f");
        private static readonly BlueprintAbility SeeInvisibilityCommunalAbility = Resources.GetBlueprint<BlueprintAbility>("1a045f845778dc54db1c2be33a8c3c0a");
        private static readonly BlueprintAbility RageAbility = Resources.GetBlueprint<BlueprintAbility>("97b991256e43bb140b263c326f690ce2");
        private static readonly BlueprintAbility HasteAbility = Resources.GetBlueprint<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
        private static readonly BlueprintAbility LightningBoltAbility = Resources.GetBlueprint<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73");
        private static readonly BlueprintAbility DisplacementAbility = Resources.GetBlueprint<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
        private static readonly BlueprintAbility SummonMonsterIIIAbility = Resources.GetBlueprint<BlueprintAbility>("5d61dde0020bbf54ba1521f7ca0229dc");
        private static readonly BlueprintAbility BatteringBlastAbility = Resources.GetBlueprint<BlueprintAbility>("0a2f7c6aa81bc6548ac7780d8b70bcbc");
        private static readonly BlueprintAbility ForcePunchAbility = Resources.GetBlueprint<BlueprintAbility>("fc58ddcff6ab1394eb6c18e9126bb990");
        private static readonly BlueprintAbility SlowAbility = Resources.GetBlueprint<BlueprintAbility>("f492622e473d34747806bdb39356eb89");
        private static readonly BlueprintAbility SpikedPitAbility = Resources.GetBlueprint<BlueprintAbility>("46097f610219ac445b4d6403fc596b9f");
        private static readonly BlueprintAbility StinkingCloudAbility = Resources.GetBlueprint<BlueprintAbility>("68a9e6d7256f1354289a39003a46d826");
        private static readonly BlueprintAbility BlinkAbility = Resources.GetBlueprint<BlueprintAbility>("045351f1421ee3f449a9143db701d192");
        private static readonly BlueprintAbility HeroismAbility = Resources.GetBlueprint<BlueprintAbility>("5ab0d42fb68c9e34abae4921822b9d63");
        private static readonly BlueprintAbility DeepSlumberAbility = Resources.GetBlueprint<BlueprintAbility>("7658b74f626c56a49939d9c20580885e");
        private static readonly BlueprintAbility FireballAbility = Resources.GetBlueprint<BlueprintAbility>("2d81362af43aeac4387a3d4fced489c3");
        private static readonly BlueprintAbility BeastShapeIAbility = Resources.GetBlueprint<BlueprintAbility>("61a7ed778dd93f344a5dacdbad324cc9");
        private static readonly BlueprintAbility ResistEnergyCommunalAbility = Resources.GetBlueprint<BlueprintAbility>("7bb0c402f7f789d4d9fae8ca87b4c7e2");
        private static readonly BlueprintAbility DispelMagicAbility = Resources.GetBlueprint<BlueprintAbility>("92681f181b507b34ea87018e8f7a528a");
        private static readonly BlueprintAbility RayOfExhaustionAbility = Resources.GetBlueprint<BlueprintAbility>("8eead52509987034ea9025d60cc05985");
        private static readonly BlueprintAbility ArchonsAuraAbility = Resources.GetBlueprint<BlueprintAbility>("e67efd8c84f69d24ab472c9f546fff7e");
        private static readonly BlueprintAbility BestowCurseAbility = Resources.GetBlueprint<BlueprintAbility>("989ab5c44240907489aba0a8568d0603");
        private static readonly BlueprintAbility ContagionAbility = Resources.GetBlueprint<BlueprintAbility>("48e2744846ed04b4580be1a3343a5d3d");
        private static readonly BlueprintAbility CureSeriousWoundsAbility = Resources.GetBlueprint<BlueprintAbility>("3361c5df793b4c8448756146a88026ad");
        private static readonly BlueprintAbility DelayPoisonCommunalAbility = Resources.GetBlueprint<BlueprintAbility>("04e820e1ce3a66f47a50ad5074d3ae40");
        private static readonly BlueprintAbility InflictSeriousWoundsAbility = Resources.GetBlueprint<BlueprintAbility>("bd5da98859cf2b3418f6d68ea66cabbe");
        private static readonly BlueprintAbility MagicalVestmentAbility = Resources.GetBlueprint<BlueprintAbility>("2d4263d80f5136b4296d6eb43a221d7d");
        private static readonly BlueprintAbility PrayerAbility = Resources.GetBlueprint<BlueprintAbility>("faabd2cc67efa4646ac58c7bb3e40fcc");
        private static readonly BlueprintAbility RemoveBlindnessAbility = Resources.GetBlueprint<BlueprintAbility>("c927a8b0cd3f5174f8c0b67cdbfde539");
        private static readonly BlueprintAbility RemoveCurseAbility = Resources.GetBlueprint<BlueprintAbility>("b48674cef2bff5e478a007cf57d8345b");
        private static readonly BlueprintAbility RemoveDiseaseAbility = Resources.GetBlueprint<BlueprintAbility>("4093d5a0eb5cae94e909eb1e0e1a6b36");
        private static readonly BlueprintAbility SearingLightAbility = Resources.GetBlueprint<BlueprintAbility>("bf0accce250381a44b857d4af6c8e10d");
        private static readonly BlueprintAbility AnimateDeadAbility = Resources.GetBlueprint<BlueprintAbility>("4b76d32feb089ad4499c3a1ce8e1ac27");
        private static readonly BlueprintAbility FeatherStepMassAbility = Resources.GetBlueprint<BlueprintAbility>("d219494150ac1f24f9ce14a3d4f66d26");
        private static readonly BlueprintAbility CallLightningAbility = Resources.GetBlueprint<BlueprintAbility>("2a9ef0e0b5822a24d88b16673a267456");
        private static readonly BlueprintAbility PoisonAbility = Resources.GetBlueprint<BlueprintAbility>("2a6eda8ef30379142a4b75448fb214a3");
        private static readonly BlueprintAbility SpitVenomAbility = Resources.GetBlueprint<BlueprintAbility>("9779c8578acd919419f563c33d7b2af5");
        private static readonly BlueprintAbility MagicFangGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("f1100650705a69c4384d3edd88ba0f52");
        private static readonly BlueprintAbility LongstriderGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("e80a4d6c0efa5774cbd515e3e37095b0");
        private static readonly BlueprintAbility NeutralizePoisonAbility = Resources.GetBlueprint<BlueprintAbility>("e7240516af4241b42b2cd819929ea9da");
        private static readonly BlueprintAbility DominateAnimalAbility = Resources.GetBlueprint<BlueprintAbility>("754c478a2aa9bb54d809e648c3f7ac0e");
        private static readonly BlueprintAbility SummonNaturesAllyIIIAbility = Resources.GetBlueprint<BlueprintAbility>("fdcf7e57ec44f704591f11b45f4acf61");
        private static readonly BlueprintAbility SoothingMudAbility = Resources.GetBlueprint<BlueprintAbility>("1a36c8b9ed655c249a9f9e8d4731f001");
        private static readonly BlueprintAbility SpikeGrowthAbility = Resources.GetBlueprint<BlueprintAbility>("29b0f9026ad05e14789d84e867cc6dff");
        private static readonly BlueprintAbility AnimalAspectGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("c9c56af3b25be3942aa0ffd12f11cf35");

        // Spells - 4
        private static readonly BlueprintAbility OverwhelmingGriefAbility = Resources.GetBlueprint<BlueprintAbility>("dd2918e4a77c50044acba1ac93494c36");
        private static readonly BlueprintAbility CrushingDespairAbility = Resources.GetBlueprint<BlueprintAbility>("4baf4109145de4345861fe0f2209d903");
        private static readonly BlueprintAbility ObsidianFlowAbility = Resources.GetBlueprint<BlueprintAbility>("e48638596c955a74c8a32dbc90b518c1");
        private static readonly BlueprintAbility RainbowPatternAbility = Resources.GetBlueprint<BlueprintAbility>("4b8265132f9c8174f87ce7fa6d0fe47b");
        private static readonly BlueprintAbility BoneshatterAbility = Resources.GetBlueprint<BlueprintAbility>("f2f1efac32ea2884e84ecaf14657298b");
        private static readonly BlueprintAbility SummonMonsterIVAbility = Resources.GetBlueprint<BlueprintAbility>("7ed74a3ec8c458d4fb50b192fd7be6ef");
        private static readonly BlueprintAbility VolcanicStormAbility = Resources.GetBlueprint<BlueprintAbility>("16ce660837fb2544e96c3b7eaad73c63");
        private static readonly BlueprintAbility ControlledFireballAbility = Resources.GetBlueprint<BlueprintAbility>("f72f8f03bf0136c4180cd1d70eb773a5");
        private static readonly BlueprintAbility ProtectionFromEnergyCommunalAbility = Resources.GetBlueprint<BlueprintAbility>("76a629d019275b94184a1a8733cac45e");
        private static readonly BlueprintAbility ConfusionAbility = Resources.GetBlueprint<BlueprintAbility>("cf6c901fb7acc904e85c63b342e9c949");
        private static readonly BlueprintAbility FalseLifeGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("dc6af3b4fd149f841912d8a3ce0983de");
        private static readonly BlueprintAbility FearAbility = Resources.GetBlueprint<BlueprintAbility>("d2aeac47450c76347aebbc02e4f463e0");
        private static readonly BlueprintAbility DragonsBreathAbility = Resources.GetBlueprint<BlueprintAbility>("5e826bcdfde7f82468776b55315b2403");
        private static readonly BlueprintAbility BeastShapeIIAbility = Resources.GetBlueprint<BlueprintAbility>("5d4028eb28a106d4691ed1b92bbb1915");
        private static readonly BlueprintAbility ShoutAbility = Resources.GetBlueprint<BlueprintAbility>("f09453607e683784c8fca646eec49162");
        private static readonly BlueprintAbility TouchOfSlimeAbility = Resources.GetBlueprint<BlueprintAbility>("84ccca10da2a4484c89a837fbea2a829");
        private static readonly BlueprintAbility SymbolOfRevelationAbility = Resources.GetBlueprint<BlueprintAbility>("48a555180a109e545a6e367b1bd3f535");
        private static readonly BlueprintAbility IceStormAbility = Resources.GetBlueprint<BlueprintAbility>("fcb028205a71ee64d98175ff39a0abf9");
        private static readonly BlueprintAbility DimensionDoorAbility = Resources.GetBlueprint<BlueprintAbility>("4a648b57935a59547b7a2ee86fb4f26a");
        private static readonly BlueprintAbility EnervationAbility = Resources.GetBlueprint<BlueprintAbility>("f34fb78eaaec141469079af124bcfa0f");
        private static readonly BlueprintAbility StoneskinAbility = Resources.GetBlueprint<BlueprintAbility>("c66e86905f7606c4eaa5c774f0357b2b");
        private static readonly BlueprintAbility PhantasmalKillerAbility = Resources.GetBlueprint<BlueprintAbility>("6717dbaef00c0eb4897a1c908a75dfe5");
        private static readonly BlueprintAbility SummonElementalMediumAbility = Resources.GetBlueprint<BlueprintAbility>("e42b1dbff4262c6469a9ff0a6ce730e3");
        private static readonly BlueprintAbility ShadowConjurationAbility = Resources.GetBlueprint<BlueprintAbility>("caac251ca7601324bbe000372a0a1005");
        private static readonly BlueprintAbility AcidPitAbility = Resources.GetBlueprint<BlueprintAbility>("1407fb5054d087d47a4c40134c809f12");
        private static readonly BlueprintAbility ReducePersonMassAbility = Resources.GetBlueprint<BlueprintAbility>("2427f2e3ca22ae54ea7337bbab555b16");
        private static readonly BlueprintAbility ElementalBodyIAbility = Resources.GetBlueprint<BlueprintAbility>("690c90a82bf2e58449c6b541cb8ea004");
        private static readonly BlueprintAbility EnlargePersonMassAbility = Resources.GetBlueprint<BlueprintAbility>("66dc49bf154863148bd217287079245e");
        private static readonly BlueprintAbility InvisibilityGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("ecaa0def35b38f949bd1976a6c9539e0");
        private static readonly BlueprintAbility ChaosHammerAbility = Resources.GetBlueprint<BlueprintAbility>("c42ac3feb96d1e54e9bc77c84082f05f");
        private static readonly BlueprintAbility CrusaderEdgeAbility = Resources.GetBlueprint<BlueprintAbility>("be5452c422a6ea744bf1037b0a443bb1");
        private static readonly BlueprintAbility CureCriticalWoundsAbility = Resources.GetBlueprint<BlueprintAbility>("41c9016596fe1de4faf67425ed691203");
        private static readonly BlueprintAbility DeathWardAbility = Resources.GetBlueprint<BlueprintAbility>("e9cc9378fd6841f48ad59384e79e9953");
        private static readonly BlueprintAbility DivinePowerAbility = Resources.GetBlueprint<BlueprintAbility>("ef16771cb05d1344989519e87f25b3c5");
        private static readonly BlueprintAbility FreedomOfMovementAbility = Resources.GetBlueprint<BlueprintAbility>("0087fc2d64b6095478bc7b8d7d512caf");
        private static readonly BlueprintAbility HolySmiteAbility = Resources.GetBlueprint<BlueprintAbility>("ad5ed5ea4ec52334a94e975a64dad336");
        private static readonly BlueprintAbility InflictCriticalWoundsAbility = Resources.GetBlueprint<BlueprintAbility>("651110ed4f117a948b41c05c5c7624c0");
        private static readonly BlueprintAbility OrdersWrathAbility = Resources.GetBlueprint<BlueprintAbility>("1ec8f035d8329134d96cdc7b90fdc2e1");
        private static readonly BlueprintAbility RestorationAbility = Resources.GetBlueprint<BlueprintAbility>("f2115ac1148256b4ba20788f7e966830");
        private static readonly BlueprintAbility ShieldOfDawnAbility = Resources.GetBlueprint<BlueprintAbility>("62888999171921e4dafb46de83f4d67d");
        private static readonly BlueprintAbility UnholyBlightAbility = Resources.GetBlueprint<BlueprintAbility>("a02cf51787df937489ef5d4cf5970335");
        private static readonly BlueprintAbility DismissalAbility = Resources.GetBlueprint<BlueprintAbility>("95f7cdcec94e293489a85afdf5af1fd7");
        private static readonly BlueprintAbility LifeBlastAbility = Resources.GetBlueprint<BlueprintAbility>("a8666d26bbbd9b640958284e0eee3602");
        private static readonly BlueprintAbility EcholocationAbility = Resources.GetBlueprint<BlueprintAbility>("20b548bf09bb3ea4bafea78dcb4f3db6");
        private static readonly BlueprintAbility SlowMudAbility = Resources.GetBlueprint<BlueprintAbility>("6b30813c3709fc44b92dc8fd8191f345");
        private static readonly BlueprintAbility ThornBodyAbility = Resources.GetBlueprint<BlueprintAbility>("2daf9c5112f16d54ab3cd6904c705c59");
        private static readonly BlueprintAbility CapeOfWaspsAbility = Resources.GetBlueprint<BlueprintAbility>("e418c20c8ce362943a8025d82c865c1c");
        private static readonly BlueprintAbility SpikeStonesAbility = Resources.GetBlueprint<BlueprintAbility>("d1afa8bc28c99104da7d784115552de5");
        private static readonly BlueprintAbility SummonNaturesAllyIVAbility = Resources.GetBlueprint<BlueprintAbility>("c83db50513abdf74ca103651931fac4b");
        private static readonly BlueprintAbility FlameStrikeAbility = Resources.GetBlueprint<BlueprintAbility>("f9910c76efc34af41b6e43d5d8752f0f");
        private static readonly BlueprintAbility LifeBubbleAbility = Resources.GetBlueprint<BlueprintAbility>("265582bc494c4b12b5860b508a2f89a2");

        // Spells - 5
        private static readonly BlueprintAbility AngelicAspectAbility = Resources.GetBlueprint<BlueprintAbility>("75a10d5a635986641bfbcceceec87217");
        private static readonly BlueprintAbility AcidicSprayAbility = Resources.GetBlueprint<BlueprintAbility>("c543eef6d725b184ea8669dd09b3894c");
        private static readonly BlueprintAbility HoldMonsterAbility = Resources.GetBlueprint<BlueprintAbility>("41e8a952da7a5c247b3ec1c2dbb73018");
        private static readonly BlueprintAbility ConstrictingCoilsAbility = Resources.GetBlueprint<BlueprintAbility>("3fce8e988a51a2a4ea366324d6153001");
        private static readonly BlueprintAbility ElementalBodyIIAbility = Resources.GetBlueprint<BlueprintAbility>("6d437be73b459594ab103acdcae5b9e2");
        private static readonly BlueprintAbility StoneskinCommunalAbility = Resources.GetBlueprint<BlueprintAbility>("7c5d556b9a5883048bf030e20daebe31");
        private static readonly BlueprintAbility SummonElementalLargeAbility = Resources.GetBlueprint<BlueprintAbility>("89404dd71edc1aa42962824b44156fe5");
        private static readonly BlueprintAbility ConeOfColdAbility = Resources.GetBlueprint<BlueprintAbility>("e7c530f8137630f4d9d7ee1aa7b1edc0");
        private static readonly BlueprintAbility IcyPrisonAbility = Resources.GetBlueprint<BlueprintAbility>("65e8d23aef5e7784dbeb27b1fca40931");
        private static readonly BlueprintAbility PolymorphAbility = Resources.GetBlueprint<BlueprintAbility>("93d9d74dac46b9b458d4d2ea7f4b1911");
        private static readonly BlueprintAbility DominatePersonAbility = Resources.GetBlueprint<BlueprintAbility>("d7cbd2004ce66a042aeab2e95a3c5c61");
        private static readonly BlueprintAbility MindFogAbility = Resources.GetBlueprint<BlueprintAbility>("eabf94e4edc6e714cabd96aa69f8b207");
        private static readonly BlueprintAbility WavesOfFatigueAbility = Resources.GetBlueprint<BlueprintAbility>("8878d0c46dfbd564e9d5756349d5e439");
        private static readonly BlueprintAbility FeeblemindAbility = Resources.GetBlueprint<BlueprintAbility>("444eed6e26f773a40ab6e4d160c67faa");
        private static readonly BlueprintAbility FireSnakeAbility = Resources.GetBlueprint<BlueprintAbility>("ebade19998e1f8542a1b55bd4da766b3");
        private static readonly BlueprintAbility VampiricShadowShieldAbility = Resources.GetBlueprint<BlueprintAbility>("a34921035f2a6714e9be5ca76c5e34b5");
        private static readonly BlueprintAbility BreakEnchantmentAbility = Resources.GetBlueprint<BlueprintAbility>("7792da00c85b9e042a0fdfc2b66ec9a8");
        private static readonly BlueprintAbility HungryPitAbility = Resources.GetBlueprint<BlueprintAbility>("f63f4d1806b78604a952b3958892ce1c");
        private static readonly BlueprintAbility BalefulPolymorphAbility = Resources.GetBlueprint<BlueprintAbility>("3105d6e9febdc3f41a08d2b7dda1fe74");
        private static readonly BlueprintAbility AnimalGrowthAbility = Resources.GetBlueprint<BlueprintAbility>("56923211d2ac95e43b8ac5031bab74d8");
        private static readonly BlueprintAbility GeniekindAbility = Resources.GetBlueprint<BlueprintAbility>("07b608fab304f894880898dc0764e6e5");
        private static readonly BlueprintAbility ShadowEvocationAbility = Resources.GetBlueprint<BlueprintAbility>("237427308e48c3341b3d532b9d3a001f");
        private static readonly BlueprintAbility SummonMonsterVAbility = Resources.GetBlueprint<BlueprintAbility>("630c8b85d9f07a64f917d79cb5905741");
        private static readonly BlueprintAbility BeastShapeIIIAbility = Resources.GetBlueprint<BlueprintAbility>("9b93040dad242eb43ac7de6bb6547030");
        private static readonly BlueprintAbility PhantasmalWebAbility = Resources.GetBlueprint<BlueprintAbility>("12fb4a4c22549c74d949e2916a2f0b6a");
        private static readonly BlueprintAbility WrackingRayAbility = Resources.GetBlueprint<BlueprintAbility>("1cde0691195feae45bab5b83ea3f221e");
        private static readonly BlueprintAbility ThoughtsenseAbility = Resources.GetBlueprint<BlueprintAbility>("8fb1a1670b6e1f84b89ea846f589b627");
        private static readonly BlueprintAbility CloudkillAbility = Resources.GetBlueprint<BlueprintAbility>("548d339ba87ee56459c98e80167bdf10");
        private static readonly BlueprintAbility SerenityAbility = Resources.GetBlueprint<BlueprintAbility>("d316d3d94d20c674db2c24d7de96f6a7");
        private static readonly BlueprintAbility BreathOfLifeAbility = Resources.GetBlueprint<BlueprintAbility>("d5847cad0b0e54c4d82d6c59a3cda6b0");
        private static readonly BlueprintAbility BurstOfGloryAbility = Resources.GetBlueprint<BlueprintAbility>("1bc83efec9f8c4b42a46162d72cbf494");
        private static readonly BlueprintAbility ClenseAbility = Resources.GetBlueprint<BlueprintAbility>("be2062d6d85f4634ea4f26e9e858c3b8");
        private static readonly BlueprintAbility CureLightWoundsMassAbility = Resources.GetBlueprint<BlueprintAbility>("5d3d689392e4ff740a761ef346815074");
        private static readonly BlueprintAbility DisruptingWeaponAbility = Resources.GetBlueprint<BlueprintAbility>("46c96cc3a3ef35243915ff3452dfacf5");
        private static readonly BlueprintAbility InflictLightWoundsMassAbility = Resources.GetBlueprint<BlueprintAbility>("9da37873d79ef0a468f969e4e5116ad2");
        private static readonly BlueprintAbility PillarOfLifeAbility = Resources.GetBlueprint<BlueprintAbility>("aca83c764d751594287f18b817814bce");
        private static readonly BlueprintAbility ProfaneNimbusAbility = Resources.GetBlueprint<BlueprintAbility>("b56521d58f996cd4299dab3f38d5fe31");
        private static readonly BlueprintAbility RaiseDeadAbility = Resources.GetBlueprint<BlueprintAbility>("a0fc99f0933d01643b2b8fe570caa4c5");
        private static readonly BlueprintAbility RighteousMightAbility = Resources.GetBlueprint<BlueprintAbility>("90810e5cf53bf854293cbd5ea1066252");
        private static readonly BlueprintAbility SacredNimbusAbility = Resources.GetBlueprint<BlueprintAbility>("bf74b3b54c21a9344afe9947546e036f");
        private static readonly BlueprintAbility SlayLivingAbility = Resources.GetBlueprint<BlueprintAbility>("4fbd47525382517419c66fb548fe9a67");
        private static readonly BlueprintAbility SpellResistanceAbility = Resources.GetBlueprint<BlueprintAbility>("0a5ddfbcfb3989543ac7c936fc256889");
        private static readonly BlueprintAbility TrueSeeingAbility = Resources.GetBlueprint<BlueprintAbility>("4cf3d0fae3239ec478f51e86f49161cb");
        private static readonly BlueprintAbility VinetrapAbility = Resources.GetBlueprint<BlueprintAbility>("6d1d48a939ce475409f06e1b376bc386");
        private static readonly BlueprintAbility CommandGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("cb15cc8d7a5480648855a23b3ba3f93d");
        private static readonly BlueprintAbility CallLightningStormAbility = Resources.GetBlueprint<BlueprintAbility>("d5a36a7ee8177be4f848b953d1c53c84");
        private static readonly BlueprintAbility AspectOfTheWolfAbility = Resources.GetBlueprint<BlueprintAbility>("6126b36fe22291543ad72f8b9f0d53a7");
        private static readonly BlueprintAbility SummonNaturesAllyVAbility = Resources.GetBlueprint<BlueprintAbility>("8f98a22f35ca6684a983363d32e51bfe");
        private static readonly BlueprintAbility CaveFangsAbility = Resources.GetBlueprint<BlueprintAbility>("bacba2ff48d498b46b86384053945e83");
        private static readonly BlueprintAbility BlessingOfTheSalamanderAbility = Resources.GetBlueprint<BlueprintAbility>("9256a86aec14ad14e9497f6b60e26f3f");

        // Spells - 6
        private static readonly BlueprintAbility ChainsOfLightAbility = Resources.GetBlueprint<BlueprintAbility>("f8cea58227f59c64399044a82c9735c4");
        private static readonly BlueprintAbility ElementalAssessorAbility = Resources.GetBlueprint<BlueprintAbility>("6303b404df12b0f4793fa0763b21dd2c");
        private static readonly BlueprintAbility StoneToFleshAbility = Resources.GetBlueprint<BlueprintAbility>("e243740dfdb17a246b116b334ed0b165");
        private static readonly BlueprintAbility SummonMonsterVIAbility = Resources.GetBlueprint<BlueprintAbility>("e740afbab0147944dab35d83faa0ae1c");
        private static readonly BlueprintAbility DispelMagicGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("f0f761b808dc4b149b08eaf44b99f633");
        private static readonly BlueprintAbility FormOfTheDragonIAbility = Resources.GetBlueprint<BlueprintAbility>("f767399367df54645ac620ef7b2062bb");
        private static readonly BlueprintAbility UndeathToDeathAbility = Resources.GetBlueprint<BlueprintAbility>("a9a52760290591844a96d0109e30e04d");
        private static readonly BlueprintAbility CatsGraceMassAbility = Resources.GetBlueprint<BlueprintAbility>("1f6c94d56f178b84ead4c02f1b1e1c48");
        private static readonly BlueprintAbility BullsStrengthMassAbility = Resources.GetBlueprint<BlueprintAbility>("6a234c6dcde7ae94e94e9c36fd1163a7");
        private static readonly BlueprintAbility CircleOfDeathAbility = Resources.GetBlueprint<BlueprintAbility>("a89dcbbab8f40e44e920cc60636097cf");
        private static readonly BlueprintAbility HeroismGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("e15e5e7045fda2244b98c8f010adfe31");
        private static readonly BlueprintAbility DisintegrateAbility = Resources.GetBlueprint<BlueprintAbility>("4aa7942c3e62a164387a73184bca3fc1");
        private static readonly BlueprintAbility ChainLightningAbility = Resources.GetBlueprint<BlueprintAbility>("645558d63604747428d55f0dd3a4cb58");
        private static readonly BlueprintAbility OwlsWisdomMassAbility = Resources.GetBlueprint<BlueprintAbility>("9f5ada581af3db4419b54db77f44e430");
        private static readonly BlueprintAbility AcidFogAbility = Resources.GetBlueprint<BlueprintAbility>("dbf99b00cd35d0a4491c6cc9e771b487");
        private static readonly BlueprintAbility BearsEnduranceMassAbility = Resources.GetBlueprint<BlueprintAbility>("f6bcea6db14f0814d99b54856e918b92");
        private static readonly BlueprintAbility HellfireRayAbility = Resources.GetBlueprint<BlueprintAbility>("700cfcbd0cb2975419bcab7dbb8c6210");
        private static readonly BlueprintAbility CloakofDreamsAbility = Resources.GetBlueprint<BlueprintAbility>("7f71a70d822af94458dc1a235507e972");
        private static readonly BlueprintAbility FoxsCunningMassAbility = Resources.GetBlueprint<BlueprintAbility>("2b24159ad9907a8499c2313ba9c0f615");
        private static readonly BlueprintAbility EaglesSplendorMassAbility = Resources.GetBlueprint<BlueprintAbility>("2caa607eadda4ab44934c5c9875e01bc");
        private static readonly BlueprintAbility BeastShapeIVAbility = Resources.GetBlueprint<BlueprintAbility>("940a545a665194b48b722c1f9dd78d53");
        private static readonly BlueprintAbility TransformationAbility = Resources.GetBlueprint<BlueprintAbility>("27203d62eb3d4184c9aced94f22e1806");
        private static readonly BlueprintAbility SiroccoAbility = Resources.GetBlueprint<BlueprintAbility>("093ed1d67a539ad4c939d9d05cfe192c");
        private static readonly BlueprintAbility ElementalBodyIIIAbility = Resources.GetBlueprint<BlueprintAbility>("459e6d5aab080a14499e13b407eb3b85");
        private static readonly BlueprintAbility TarPoolAbility = Resources.GetBlueprint<BlueprintAbility>("7d700cdf260d36e48bb7af3a8ca5031f");
        private static readonly BlueprintAbility ColdIceStrikeAbility = Resources.GetBlueprint<BlueprintAbility>("5ef85d426783a5347b420546f91a677b");
        private static readonly BlueprintAbility BansheeBlastAbility = Resources.GetBlueprint<BlueprintAbility>("d42c6d3f29e07b6409d670792d72bc82");
        private static readonly BlueprintAbility SummonElementalHugeAbility = Resources.GetBlueprint<BlueprintAbility>("766ec978fa993034f86a372c8eb1fc10");
        private static readonly BlueprintAbility PhantasmalPutrefactionAbility = Resources.GetBlueprint<BlueprintAbility>("1f2e6019ece86d64baa5effa15e81ecc");
        private static readonly BlueprintAbility EyebiteAbility = Resources.GetBlueprint<BlueprintAbility>("3167d30dd3c622c46b0c0cb242061642");
        private static readonly BlueprintAbility CreateUndeadAbility = Resources.GetBlueprint<BlueprintAbility>("76a11b460be25e44ca85904d6806e5a3");
        private static readonly BlueprintAbility BlessingOfLuckAndResolveMassAbility = Resources.GetBlueprint<BlueprintAbility>("462c21cebf7820c40a87f5e4d03e17cf");
        private static readonly BlueprintAbility EaglesoulAbility = Resources.GetBlueprint<BlueprintAbility>("332ad68273db9704ab0e92518f2efd1c");
        private static readonly BlueprintAbility TrueSeeingCommunalAbility = Resources.GetBlueprint<BlueprintAbility>("fa08cb49ade3eee42b5fd42bd33cb407");
        private static readonly BlueprintAbility BladeBarrierAbility = Resources.GetBlueprint<BlueprintAbility>("36c8971e91f1745418cc3ffdfac17b74");
        private static readonly BlueprintAbility CureModerateWoundsMassAbility = Resources.GetBlueprint<BlueprintAbility>("571221cc141bc21449ae96b3944652aa");
        private static readonly BlueprintAbility HarmAbility = Resources.GetBlueprint<BlueprintAbility>("cc09224ecc9af79449816c45bc5be218");
        private static readonly BlueprintAbility HealAbility = Resources.GetBlueprint<BlueprintAbility>("5da172c4c89f9eb4cbb614f3a67357d3");
        private static readonly BlueprintAbility InflictModerateWoundsMassAbility = Resources.GetBlueprint<BlueprintAbility>("03944622fbe04824684ec29ff2cec6a7");
        private static readonly BlueprintAbility InspiringRecoveryAbility = Resources.GetBlueprint<BlueprintAbility>("788d72e7713cf90418ee1f38449416dc");
        private static readonly BlueprintAbility PlagueStormAbility = Resources.GetBlueprint<BlueprintAbility>("82a5b848c05e3f342b893dedb1f9b446");
        private static readonly BlueprintAbility BanishmentAbility = Resources.GetBlueprint<BlueprintAbility>("d361391f645db984bbf58907711a146a");
        private static readonly BlueprintAbility JoyfulRaptureAbility = Resources.GetBlueprint<BlueprintAbility>("15a04c40f84545949abeedef7279751a");
        private static readonly BlueprintAbility PrimalRegressionAbility = Resources.GetBlueprint<BlueprintAbility>("07d577a74441a3a44890e3006efcf604");
        private static readonly BlueprintAbility SummonNaturesAllyVIAbility = Resources.GetBlueprint<BlueprintAbility>("55bbce9b3e76d4a4a8c8e0698d29002c");
        private static readonly BlueprintAbility PoisonBreathAbility = Resources.GetBlueprint<BlueprintAbility>("b5be90707c17a9643b90d90b7c4096e2");

        // Spells - 7
        private static readonly BlueprintAbility UmbralStrikeAbility = Resources.GetBlueprint<BlueprintAbility>("474ed0aa656cc38499cc9a073d113716");
        private static readonly BlueprintAbility InsanityAbility = Resources.GetBlueprint<BlueprintAbility>("2b044152b3620c841badb090e01ed9de");
        private static readonly BlueprintAbility PolymorphGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("a9fc28e147dbb364ea4a3c1831e7e55f");
        private static readonly BlueprintAbility PowerWordBlindAbility = Resources.GetBlueprint<BlueprintAbility>("261e1788bfc5ac1419eec68b1d485dbc");
        private static readonly BlueprintAbility ElementalBodyIVAbility = Resources.GetBlueprint<BlueprintAbility>("376db0590f3ca4945a8b6dc16ed14975");
        private static readonly BlueprintAbility FingerOfDeathAbility = Resources.GetBlueprint<BlueprintAbility>("6f1dcf6cfa92d1948a740195707c0dbe");
        private static readonly BlueprintAbility WalkThroughSpaceAbility = Resources.GetBlueprint<BlueprintAbility>("368d7cf2fb69d8a46be5a650f5a5a173");
        private static readonly BlueprintAbility SummonMonsterVIIAbility = Resources.GetBlueprint<BlueprintAbility>("ab167fd8203c1314bac6568932f1752f");
        private static readonly BlueprintAbility FormOfTheDragonIIAbility = Resources.GetBlueprint<BlueprintAbility>("666556ded3a32f34885e8c318c3a0ced");
        private static readonly BlueprintAbility CircleOfClarityAbility = Resources.GetBlueprint<BlueprintAbility>("f333185ae986b2a45823cce86535a122");
        private static readonly BlueprintAbility KiShoutAbility = Resources.GetBlueprint<BlueprintAbility>("5c8cde7f0dcec4e49bfa2632dfe2ecc0");
        private static readonly BlueprintAbility ResonatingWordAbility = Resources.GetBlueprint<BlueprintAbility>("df7d13c967bce6a40bec3ba7c9f0e64c");
        private static readonly BlueprintAbility PrismaticSprayAbility = Resources.GetBlueprint<BlueprintAbility>("b22fd434bdb60fb4ba1068206402c4cf");
        private static readonly BlueprintAbility InvisibilityMassAbility = Resources.GetBlueprint<BlueprintAbility>("98310a099009bbd4dbdf66bcef58b4cd");
        private static readonly BlueprintAbility IceBodyAbility = Resources.GetBlueprint<BlueprintAbility>("89778dc261fe6094bb2445cb389842d2");
        private static readonly BlueprintAbility WavesOfEctasyAbility = Resources.GetBlueprint<BlueprintAbility>("1e2d1489781b10a45a3b70192bba9be3");
        private static readonly BlueprintAbility HoldPersonMassAbility = Resources.GetBlueprint<BlueprintAbility>("defbbeaef79eda64abc645036228a31b");
        private static readonly BlueprintAbility SummonElementalGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("8eb769e3b583f594faabe1cfdb0bb696");
        private static readonly BlueprintAbility CausticEruptionAbility = Resources.GetBlueprint<BlueprintAbility>("8c29e953190cc67429dc9c701b16b7c2");
        private static readonly BlueprintAbility WavesOfExhaustionAbility = Resources.GetBlueprint<BlueprintAbility>("3e4d3b9a5bd03734d9b053b9067c2f38");
        private static readonly BlueprintAbility LegendaryProportionsAbility = Resources.GetBlueprint<BlueprintAbility>("da1b292d91ba37948893cdbe9ea89e28");
        private static readonly BlueprintAbility ShadowConjurationGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("08255ea4cdd812341af93f9cd113acb9");
        private static readonly BlueprintAbility FirebrandAbility = Resources.GetBlueprint<BlueprintAbility>("98734a2665c18cd4db71878b0532024a");
        private static readonly BlueprintAbility BestowGraceOfTheChampionAbility = Resources.GetBlueprint<BlueprintAbility>("199d585bff173c74b86387856919242c");
        private static readonly BlueprintAbility ArbitramentAbility = Resources.GetBlueprint<BlueprintAbility>("0f5bd128c76dd374b8cb9111e3b5186b");
        private static readonly BlueprintAbility BlasphemyAbility = Resources.GetBlueprint<BlueprintAbility>("bd10c534a09f44f4ea632c8b8ae97145");
        private static readonly BlueprintAbility DictumAbility = Resources.GetBlueprint<BlueprintAbility>("302ab5e241931a94881d323a7844ae8f");
        private static readonly BlueprintAbility HolyWordAbility = Resources.GetBlueprint<BlueprintAbility>("4737294a66c91b844842caee8cf505c8");
        private static readonly BlueprintAbility WordOfChaosAbility = Resources.GetBlueprint<BlueprintAbility>("69f2e7aff2d1cd148b8075ee476515b1");
        private static readonly BlueprintAbility CureSeriousWoundsMassAbility = Resources.GetBlueprint<BlueprintAbility>("0cea35de4d553cc439ae80b3a8724397");
        private static readonly BlueprintAbility DestructionAbility = Resources.GetBlueprint<BlueprintAbility>("3b646e1db3403b940bf620e01d2ce0c7");
        private static readonly BlueprintAbility InflictSeriousWoundsMassAbility = Resources.GetBlueprint<BlueprintAbility>("820170444d4d2a14abc480fcbdb49535");
        private static readonly BlueprintAbility JoltingPortentAbility = Resources.GetBlueprint<BlueprintAbility>("0dd638688edf68a4da865752d7b9ee82");
        private static readonly BlueprintAbility RestorationGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("fafd77c6bfa85c04ba31fdc1c962c914");
        private static readonly BlueprintAbility ResurrectionAbility = Resources.GetBlueprint<BlueprintAbility>("80a1a388ee938aa4e90d427ce9a7a3e9");
        private static readonly BlueprintAbility BewstowCurseGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("6101d0f0720927e4ca413de7b3c4b7e5");
        private static readonly BlueprintAbility SummonNaturesAllyVIIAbility = Resources.GetBlueprint<BlueprintAbility>("051b979e7d7f8ec41b9fa35d04746b33");
        private static readonly BlueprintAbility CreepingDoomAbility = Resources.GetBlueprint<BlueprintAbility>("b974af13e45639a41a04843ce1c9aa12");
        private static readonly BlueprintAbility SunbeamAbility = Resources.GetBlueprint<BlueprintAbility>("1fca0ba2fdfe2994a8c8bc1f0f2fc5b1");
        private static readonly BlueprintAbility FireStormAbility = Resources.GetBlueprint<BlueprintAbility>("e3d0dfe1c8527934294f241e0ae96a8d");
        private static readonly BlueprintAbility ChangestaffAbility = Resources.GetBlueprint<BlueprintAbility>("26be70c4664d07446bdfe83504c1d757");

        // Spells - 8
        private static readonly BlueprintAbility AngelicAspectGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("b1c7576bd06812b42bda3f09ab202f14");
        private static readonly BlueprintAbility ShoutGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("fd0d3840c48cafb44bb29e8eb74df204");
        private static readonly BlueprintAbility ProtectionFromSpellsAbility = Resources.GetBlueprint<BlueprintAbility>("42aa71adc7343714fa92e471baa98d42");
        private static readonly BlueprintAbility SummonMonsterVIIIAbility = Resources.GetBlueprint<BlueprintAbility>("d3ac756a229830243a72e84f3ab050d0");
        private static readonly BlueprintAbility ScintillatingPatternAbility = Resources.GetBlueprint<BlueprintAbility>("4dc60d08c6c4d3c47b413904e4de5ff0");
        private static readonly BlueprintAbility SummonElementalElderAbility = Resources.GetBlueprint<BlueprintAbility>("8a7f8c1223bda1541b42fd0320cdbe2b");
        private static readonly BlueprintAbility HoridWiltingAbility = Resources.GetBlueprint<BlueprintAbility>("08323922485f7e246acb3d2276515526");
        private static readonly BlueprintAbility SunburstAbility = Resources.GetBlueprint<BlueprintAbility>("e96424f70ff884947b06f41a765b7658");
        private static readonly BlueprintAbility DeathClutchAbility = Resources.GetBlueprint<BlueprintAbility>("c3d2294a6740bc147870fff652f3ced5");
        private static readonly BlueprintAbility PolarRayAbility = Resources.GetBlueprint<BlueprintAbility>("17696c144a0194c478cbe402b496cb23");
        private static readonly BlueprintAbility FrightfulAspectAbility = Resources.GetBlueprint<BlueprintAbility>("e788b02f8d21014488067bdd3ba7b325");
        private static readonly BlueprintAbility SeamantleAbility = Resources.GetBlueprint<BlueprintAbility>("7ef49f184922063499b8f1346fb7f521");
        private static readonly BlueprintAbility FormOfTheDragonIIIAbility = Resources.GetBlueprint<BlueprintAbility>("1cdc4ad4c208246419b98a35539eafa6");
        private static readonly BlueprintAbility IronBodyAbility = Resources.GetBlueprint<BlueprintAbility>("198fcc43490993f49899ed086fe723c1");
        private static readonly BlueprintAbility RiftOfRuinAbility = Resources.GetBlueprint<BlueprintAbility>("dd3dacafcf40a0145a5824c838e2698d");
        private static readonly BlueprintAbility PredictionOfFailureAbility = Resources.GetBlueprint<BlueprintAbility>("0e67fa8f011662c43934d486acc50253");
        private static readonly BlueprintAbility PowerWordStunAbility = Resources.GetBlueprint<BlueprintAbility>("f958ef62eea5050418fb92dfa944c631");
        private static readonly BlueprintAbility ShadowEvocationGreaterAbility = Resources.GetBlueprint<BlueprintAbility>("3c4a2d4181482e84d9cd752ef8edc3b6");
        private static readonly BlueprintAbility StormboltsAbility = Resources.GetBlueprint<BlueprintAbility>("7cfbefe0931257344b2cb7ddc4cdff6f");
        private static readonly BlueprintAbility MindBlankAbility = Resources.GetBlueprint<BlueprintAbility>("df2a0ba6b6dcecf429cbb80a56fee5cf");
        private static readonly BlueprintAbility EuphoricTranquilityAbility = Resources.GetBlueprint<BlueprintAbility>("740d943e42b60f64a8de74926ba6ddf7");
        private static readonly BlueprintAbility SouldreaverAbility = Resources.GetBlueprint<BlueprintAbility>("b4afacd337dac4a40a769a567c038ab7");
        private static readonly BlueprintAbility CloakOfChaosAbility = Resources.GetBlueprint<BlueprintAbility>("9155dbc8268da1c49a7fc4834fa1a4b1");
        private static readonly BlueprintAbility CureCriticalWoundsMassAbility = Resources.GetBlueprint<BlueprintAbility>("1f173a16120359e41a20fc75bb53d449");
        private static readonly BlueprintAbility HolyAuraAbility = Resources.GetBlueprint<BlueprintAbility>("808ab74c12df8784ab4eeaf6a107dbea");
        private static readonly BlueprintAbility InflictCriticalWoundsMassAbility = Resources.GetBlueprint<BlueprintAbility>("5ee395a2423808c4baf342a4f8395b19");
        private static readonly BlueprintAbility ShieldOfLawAbility = Resources.GetBlueprint<BlueprintAbility>("73e7728808865094b8892613ddfaf7f5");
        private static readonly BlueprintAbility UnholyAuraAbility = Resources.GetBlueprint<BlueprintAbility>("47f9cb1c367a5e4489cfa32fce290f86");
        private static readonly BlueprintAbility AnimalShapesAbility = Resources.GetBlueprint<BlueprintAbility>("cf689244b2c7e904eb85f26fd6e81552");
        private static readonly BlueprintAbility SummonNaturesAllyVIIIAbility = Resources.GetBlueprint<BlueprintAbility>("ea78c04f0bd13d049a1cce5daf8d83e0");

        // Spells - 9
        private static readonly BlueprintAbility OverwhelmingPresenceAbility = Resources.GetBlueprint<BlueprintAbility>("41cf93453b027b94886901dbfc680cb9");
        private static readonly BlueprintAbility IcyPrisonMassAbility = Resources.GetBlueprint<BlueprintAbility>("1852a9393a23d5741b650a1ea7078abc");
        private static readonly BlueprintAbility ShadesAbility = Resources.GetBlueprint<BlueprintAbility>("70e12191790f69a439ea0132c75f83aa");
        private static readonly BlueprintAbility TsunamiAbility = Resources.GetBlueprint<BlueprintAbility>("d8144161e352ca846a73cf90e85bf9ac");
        private static readonly BlueprintAbility PowerWordKillAbility = Resources.GetBlueprint<BlueprintAbility>("2f8a67c483dfa0f439b293e094ca9e3c");
        private static readonly BlueprintAbility WailOfBansheeAbility = Resources.GetBlueprint<BlueprintAbility>("b24583190f36a8442b212e45226c54fc");
        private static readonly BlueprintAbility ClashingRocksAbility = Resources.GetBlueprint<BlueprintAbility>("01300baad090d634cb1a1b2defe068d6");
        private static readonly BlueprintAbility ShapechangeAbility = Resources.GetBlueprint<BlueprintAbility>("22b9044aa229815429d57d0a30e4b739");
        private static readonly BlueprintAbility HeroicInvocationAbility = Resources.GetBlueprint<BlueprintAbility>("43740dab07286fe4aa00a6ee104ce7c1");
        private static readonly BlueprintAbility EnergyDrainAbility = Resources.GetBlueprint<BlueprintAbility>("37302f72b06ced1408bf5bb965766d46");
        private static readonly BlueprintAbility WerirdAbility = Resources.GetBlueprint<BlueprintAbility>("870af83be6572594d84d276d7fc583e0");
        private static readonly BlueprintAbility SummonMonsterIXAbility = Resources.GetBlueprint<BlueprintAbility>("52b5df2a97df18242aec67610616ded0");
        private static readonly BlueprintAbility FieryBodyAbility = Resources.GetBlueprint<BlueprintAbility>("08ccad78cac525040919d51963f9ac39");
        private static readonly BlueprintAbility DominateMonsterAbility = Resources.GetBlueprint<BlueprintAbility>("3c17035ec4717674cae2e841a190e757");
        private static readonly BlueprintAbility HoldMonsterMassAbility = Resources.GetBlueprint<BlueprintAbility>("7f4b66a2b1fdab142904a263c7866d46");
        private static readonly BlueprintAbility ForesightAbility = Resources.GetBlueprint<BlueprintAbility>("1f01a098d737ec6419aedc4e7ad61fdd");
        private static readonly BlueprintAbility MindBlankCommunalAbility = Resources.GetBlueprint<BlueprintAbility>("87a29febd010993419f2a4a9bee11cfc");
        private static readonly BlueprintAbility HealMassAbility = Resources.GetBlueprint<BlueprintAbility>("867524328b54f25488d371214eea0d90");
        private static readonly BlueprintAbility PolarMidnightAbility = Resources.GetBlueprint<BlueprintAbility>("ba48abb52b142164eba309fd09898856");
        private static readonly BlueprintAbility WindsOfVengeanceAbility = Resources.GetBlueprint<BlueprintAbility>("5d8f1da2fdc0b9242af9f326f9e507be");
        private static readonly BlueprintAbility SummonNaturesAllyIXAbility = Resources.GetBlueprint<BlueprintAbility>("a7469ef84ba50ac4cbf3d145e3173f8e");
        private static readonly BlueprintAbility ElementalSwarmAbility = Resources.GetBlueprint<BlueprintAbility>("0340fe43f35e7a448981b646c638c83d");
        private static readonly BlueprintAbility SummonElderWormAbility = Resources.GetBlueprint<BlueprintAbility>("954f1469ed62843409783c9fa7472998");

        public static void AddIsekaiProtagonistSpellList()
        {
            Helpers.CreateBlueprint<BlueprintSpellList>("IsekaiProtagonistSpellList", bp => {
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
                            SickeningEntanglementAbility.ToReference<BlueprintAbilityReference>()
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
                            AnimalAspectGreaterAbility.ToReference<BlueprintAbilityReference>()
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
                            LifeBubbleAbility.ToReference<BlueprintAbilityReference>()
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
                            BlessingOfTheSalamanderAbility.ToReference<BlueprintAbilityReference>()
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
                            PoisonBreathAbility.ToReference<BlueprintAbilityReference>()
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
                            WavesOfEctasyAbility.ToReference<BlueprintAbilityReference>(),
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
                            BewstowCurseGreaterAbility.ToReference<BlueprintAbilityReference>(),
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
                            WerirdAbility.ToReference<BlueprintAbilityReference>(),
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

    }
}
