# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

# [5.0.3] - 2023-04-19
# Fixed
- Fixed spells not being added for legacy bloodlines.
- Fixed crash when using Dark Codex mod.

# [5.0.2] - 2023-04-18
# Fixed
- Fixed "Arcanist 0" showing in spellbook list.

# [5.0.1] - 2023-04-17
# Fixed
- Fixed missing legacies for base `Isekai Protagonist` class.

# [5.0.0] - 2023-04-17
### Added
- Added `Mastermind` archetype (Isekai Protagonist).
- Added `Overlord` archetype (Isekai Protagonist).
- Added `Demonic Cultivator` Isekai background.
- Added `Enlightened Sage` Isekai background.
- Added `Musician` Isekai background.
- Added `Rationalist` Isekai background.
- Added `Supermassive` Special Power.
- Added `Sigma Strike` Special Power.
- Added `Power Leveling` Overpowered ability.
- Added features to `Isekai Protagonist` progression: `Gifted`, `Release Energy`, `Afterimage`, `Secret Power`, `Hax`.
- Added features to `Edge Lord` progression: `Chuunibyou Actualisation`, `Extra Special Power`.
- Added features to `God Emperor` progression: `Energy Condensation`, `Energy Barrier`, `Alteration of body and mind`, `Chosen Path`, `Transcendental Realm`.
- Added features to `Hero` progression: `Hands of Salvation`, `Gold Barrier`, `Improved Gold Barrier`, `Greater Gold Barrier`, `Grand Gold Barrier`, `Deus Ex Machina`.
- Added `Divine Aura` feature to `Otherwordly Aura` selection.
- Added `Sneak attack Immunity` to `Effect Immunity` selection.
- Added `Critical hit Immunity` to `Effect Immunity` selection.
- Added `Signature Strike` to `Signature Move` selection.
### Changed
- Buffed `Friendly Aura` to also affect damage rolls.
- Buffed `Siphoning Aura` to scale 1/2 character level.
- Buffed `Extreme Speed` Special Power range from 40 -> 120.
- Buffed `Gamer` background skill bonus from 4 -> 8.
- Nerfed `Beta Tester` background initiative bonus from 10 -> 4.
- Nerfed `Magical Amplification` spell dice from d12 -> d10.
- Nerfed `Exceptional Weapon` feats to only affect primary and secondary hand weapon.
- Changes for `Isekai Protagonist`:
	- `Fast Movement` replaced with `Afterimage`.
	- `Friendly Aura` replaced with `Otherwordly Aura`.
	- Can now choose two `Signature Move` features.
	- Can now choose two `Beach Episode` features.
	- Moved `Second Reincarnation` feature from level 20 -> 15.
	- Moved `Otherworldly Stamina` feature from level 15 -> 13.
	- Moved `Quick-Footed` feature from level 16 -> 15.
	- Updated description for `Fighter Training`.
	- Updated icon for `Starting Weapon` feature.
- Changes for `Edge Lord`:
	- Now has Exotic Weapon Proficiency at 1st level.
	- Added `Extra Special Power` at 3rd level.
	- Added OP ability at 5th, 10th, and 15th level.
	- Added `Otherwordly Aura` at 10th level.
	- Removed Special Power at 5th and 15th level.
- Changes for `God Emperor`:
	- `Divine Array` replaced with `Energy Condensation`.
	- `Celestial Realm` replaced with `Transcendental Realm`.
	- `Dark Aura` replaced with `Regal Aura`.
	- Moved all effect immunities from `Godly Vessel` to `Nascent Apotheosis`.
	- Moved elemental immunities from `Godhood` to `Godly Vessel`.
	- Added another OP ability at 5th and 15th level.
	- Replaced casting stat to WIS.
	- Moved `Channel Energy` feature from level 5 -> 3.
	- Moved `Armor Saint` feature from level 4 -> 3.
	- Moved `Godly Vessel` feature from level 15 -> 17.
- Changed for `Hero`:
	- Now has Tower shield and exotic weapon proficiency at 1st level.
	- `Friendly Aura` replaced with `Heroic Aura`.
	- `Hero's Presence` replaced with `Deus Ex Machina`.
	- Added another OP Ability at 10th level.
	- Added another Special Power at 3rd and 17th level.
	- Removed Special Power at 9th and 11th level.
	- Updated icon for `Graceful Combat` feature.
- Changed `Dark Aura` debuff from -2 -> -4 but no longer affects attack rolls.
- Replaced `Aura of Righteous Wrath` with 4 different alignment based variants.
- Removed alignment restrictions for `Isekai Channel Positive Energy` and `Isekai Channel Negative Energy`.
- Renamed `Energy Immunity Selection` to `Energy Immunity`.
- Renamed `Aura of Golden Protection` to `Gold Barrier`.
- Updated description for `Dupe Gold` OP ability.
- Updated icon for `Exceptional Feats`.
- Updated icon for `Siphoning Aura`.
- Updated icon for `Dark Aura`.
### Fixed
- Fixed `Graceful Combat` not applying the 1.5x damage bonus to two-handed weapons.
- Fixed `Reflect` to not affect attacks from the owner.
- Fixed `Monk Legacy` fast movement not being applied correctly.
- Fixed `Bloodrager Legacy - Chimeric Rager` bloodlines not being shown.
### Removed
- Removed `Villain` archetype (Isekai Protagonist).
- Removed `Aura of Divine Fury` feature from `God Emperor` and `Hero` progression.
- Removed `True Smite` and `True Mark` from `Paladin Legacy - Hero of Light` legacy.
- Removed `Kinetic Power` Special Power.

# [4.3.0] - 2023-03-28
### Added
- Added `Meta Luck` OP ability.
- Added Isekai Protagonist dialogue with Horgus when asking for help escaping the Kenabres caves.
- Added Isekai Protagonist dialogue to insult Minagho during first encounter in Gray Garrison.
- Added Isekai Protagonist dialogue with Anevia in the Bad Luck Tavern.
- Added UMM option to change the default clothes on the Isekai Protagonist Class.
- Added new legacies:
	1. `Druid Legacy - Nature Mage`
	2. `Fighter Legacy - Two Handed Fighter`
	3. `Fighter Legacy - Guardian Shield`
	4. `Inquisitor Legacy - Domain Lord`
	5. `Inquisitor Legacy - Judge`
	6. `Inquisitor Legacy - Tactician` (replaces `Tactician Legacy - Isekai Tactician`)
	7. `Paladin Legacy - Hero of Light` (replaces a legacy of the same name, see Fixed below for more details)
	8. `Witch Legacy - Pactmaker`
	9. `Bloodrager Legacy - Chimeric Rager`
	10. `Player Legacy - Computer Nerd`
	11. `Player Legacy - Part Timer`
- Added legacy selection for `God Emperor`
### Changed
- Changed `Dual Legacy` restriction to require IP as a class so people that jsut use the OP feats through mythic feats don't accidentally pick it
- Changed `Dual Legacy` to now require at least level 5
- Changed `Dual Legacy` to be removed from special powers selection, now can only be gained through `Overpowered Ability`.
- Changed `Mythic Class Feature` to appear in Mythic selection directly when choosing a mythic ability.
- added more restrictions on what is available for each archetype as a legacy and added a toggle so people can choose if they actually want to enforce that restriction on the dual legacy
- properly added restrictions on overlapping archetypes(bard with skald, skald with bard and barbarian, fighter subtypes, etc.)
- old versions of `Paladin Legacy - Hero of Light` and `Tactician Legacy - Isekai Tactician` removed from the selection so people don't accidentally pick them instead of the new buffed versions replacing them, the progressions themself are still there to ensure downwards compatibility for people already using them
- Changed `Channel Positive Energy` Special Power to allow neutral users.
- Changed `Channel Negative Energy` Special Power to allow neutral users.
- Changed `Reflect` Special Power to be a toggle ability.
- Changed `Isekai Protagonist`'s `Friendly Aura` obtained from level 9 -> 10.
- Changed `Isekai Protagonist` and `Villain`'s '`Quicked-Footed` obtained from level 15 -> 16.
- Changed `Edge Lord`'s `Fast Movement` obtained from level 7 -> 8.
- Changed `God Emperor`'s `Aura Of Divine Fury` obtained from level 15 -> 14.
- Changed `God Emperor`'s `Armor Saint` obtained from level 5 -> 4.
- Replaced feature name/descriptions with existing base game localisaed strings to reduce mod localisation.
- Updated description for `Infinite Space` OP ability.
- Updated description for `Instakill` OP ability.
- Updated description for `Mind Control` OP ability.
- Updated description for `Dupe Gold` OP ability.
- Updated description for `Perfect Roll` OP ability.
- Updated description for `Summon Calamity` OP ability.
- Updated description for `Supreme Being` OP ability.
- Updated description for `Unlimited Power` OP ability.
- Updated description for `Kinetic Power` Special Power with deprecation message.
### Fixed
- Fixed white background for `Deathsnatcher` small portrait.
- Fixed `True Smite` damage bonus applies correctly on allies.
- Fixed `Paladin Legacy - Hero of Light` legacy bug fixed as much as possible so people should be able to use it without having to use a respec mod on it
- Fixed shaman legacy capstone is part of the legacy again if TabletopTweaks-Base is installed and the feature is enabled
- Fixed `Mythic Overpowered Ability` and `Mythic Special Power` to be included in `Extra Mythic Ability` mythic feat.
- Fixed `Mythic Class Feature` and appear properly in `Extra Mythic Ability` mythic feat.

# [4.2.0] - 2023-03-20
### Added
- Added `Auto Rime` OP ability (requires TabletopTweaks-Base).
- Added `Auto Burning` OP ability (requires TabletopTweaks-Base).
- Added `Auto Flaring` OP ability (requires TabletopTweaks-Base).
- Added `Auto Piercing` OP ability (requires TabletopTweaks-Base).
- Added `Auto Solid Shadows` OP ability (requires TabletopTweaks-Base).
- Added `Auto Encouraging` OP ability (requires TabletopTweaks-Base).
- Added `Auto Intensified` OP ability (requires TabletopTweaks-Base).
- Added `Auto Elemental` OP abilities (requires TabletopTweaks-Base).
- Added UMM option to allow for multiple Mythic OP abilities and Mythic special powers.
- Added UMM option to restrict Exceptional Feats to the Isekai Protagonist Class.
- Added UMM option to restrict Mythic Overpowered Abilities to the Isekai Protagonist Class.
- Added UMM option to restrict Mythic Special Powers to the Isekai Protagonist Class.
- Added new legacies:
	1. Kinetic Legacy - Soulbinder
	2. Kinetic Legacy - Noble Soul
	3. Fighter Legacy - Basic Fighter
	4. Monk Legacy - Daoist Martial Artist
	5. Monk Legacy - Fist of a Dragon
	6. Skald Legacy - Metal Singer
	7. Skald Legacy - Silver Tongue
	8. Skald Legacy - The Voice
	9. Shifter Legacy - Ditto
	10. Shifter Legacy - Stinger
	11. Shifter Legacy - Shapeshifted Baby Dragon
- Updated mod support for ExpandedContent.
### Changed
- Reworked UMM settings.
### Fixed
- Fixed typos and grammar in multiple legacy descriptions.
- Fixed missing dialogue for drow ambush encounter.
- Fixed `Martial Artist` Nunchaku weapon proficiency.
- Fixed `Kinetic Power` fire avatar eruption ability animation.
- Fixed `Channel Energy` and other features class level scaling in legacy progressions.
- Fixed `Channel Positive Energy` Special Power to apply selectively with the selective channel feat.

## [4.1.1] - 2023-03-17
### Fixed
- Fixed `Supreme Being` to allow base stat increases (for real this time).

## [4.1.0] - 2023-03-15
### Added
- Added `Isekai Furry` heritage (kitsune heritage).
- Added `Areshkagal` to `Summon Calamity` ability.
- Added `None` option for Isekai Protagonist pet selection.
- Added `Legacy` as a listed Isekai Protagonist signature class feature.
- Added icons for `Legacy` and `Dual Legacy` selections.
### Changed
- Buffed `Killing Intent` Special power fear duration from 1 round to 1d4 rounds.
- Changed `Dual Legacy` so that it can only be selected once.
- Renamed `Legacy Class Feature` to `Legacy`.
- Renamed `Dual Class - Legacy Class` Feature to `Dual Legacy`.
### Fixed
- Fixed Deathsnatcher default name.
- Fixed `Supreme Being` to allow base stat increases.
- Fixed `Instakill` Spell penetration modifier.
- Fixed `Dread Knight Legacy - Dread Lord` not appearing in selection.
### Removed
- Removed `Sneak Attack` as a listed Isekai Protagonist signature class feature.

## [4.0.0] - 2023-03-12
### Added
- merge spellbook logic to merge the spellbooks of the major classes into the isekai book rather than add each spell manually, this automatically adds support for any spell added by a mod loaded before this mod is loaded (optional toggle)
- patch for some other mod that turned deity selection into a recursive selection call onto itself which made it hard to select deities
- BlessingOfTheMythic: Mythic Class Feature, adds an option to OverpoweredAbilities and Special Powers to select a mytchic class feature despie not being a member of this mythic class, limited selection options so far
- Heroic Legacies, please refer to github page for more details:
	1.  Barbarian Legacy 	- Ball of Rage
	2.  Bard Legacy 		- Musical Prodige
	3.  Dread Knight Legacy - Dread Lord, only available with Expanded Content installed, the anti paladin
	4.  Paladin Legacy 		- Hero of Light
	5.  Kineticist Legacy 	- Kinetic Knight, melee fighter Kineticist (while not required I advice installing Expandended Element as their energize weapon feat is what really makes this archetype even work)
	6.  Kineticist Legacy 	- Kinetic Lord
	7.  Magus Legacy 		- Spellblade, Attention Still requires any form of descent testing, so only use it if you are willing to essentially be the betatester for the Legacy at the moment
	8.  Oracle Legacy 		- Seeker of Truth
	9.  Rogue Legacy 		- Supernatural Thief
	10. Shaman Legacy 		- Spirit Beacons
	11. Sorcerer Legacy 	- Chimera, grants
	12. Tactician Legacy 	- Isekai Tactician
### Changed
- Major Class Progression rework, thief feats removed from all archetypes that had them, instead players can now select a base class from which their Isekai Hero Class descends
- internal logic switch to directly use TTCCore where possible rather than code "inspired" from them (this adds a TTCCore dependency)
### Fixed
- Fixed `Omega Strike` to apply to touch attacks.

## [3.2.2] - 2023-03-10
### Fixed
- Fixed non-loading issue due to outdated blueprint core.

## [3.2.1] - 2023-03-09
### Fixed
- Fixed infinite loading for game version 2.1.0u

## [3.2.0] - 2022-12-24
### Added
- Added `Reflect` Special power.
- Added option to disable `Isekai Protagonist` class for companions and mercenaries.
### Changed
- Buffed `Extreme Speed` to work on allies within 40 feet.
- Changed `Grasp Heart` to `Instakill`. This is a buffed version that ignores death immunity.
- Changed `Mythic Overpowered Ability` and `Mythic Special Power` to be selected without non-mythic prerequisites.
### Fixed
- Fixed `Nascent Apotheosis` DR per level.
- Fixed `Second Reincarnation` missing buff.
- Fixed `Kinetic Power` abilities breaking mod if missing DLC3.

## [3.1.0] - 2022-12-16
### Added
- Added `Aura of Righteous Wrath` Overpowered ability.
- Added `Magical Summoning` Exceptional summoning feat.
- Added `Dismiss Super Buff` ability for `Super Buff` Overpowered ability.
### Changed
- Patched Prestige classes to allow `Isekai Protagonist` spellbook to be selected.
- Nerfed `Exceptional Summoning` to `Mighty Summoning`. Lowered HP buff to summons from +10 to +5, no saving throw bonus.
- Changed `Isekai Protagonist` to count as both an arcane and divine caster.
- Changed Isekai Protagonist spellbook spells to be counted as arcane spells rather than divine spells.
- Changed `Supersonic Combat` and `Graceful Combat` to affect damage for ranged attacks.
- Changed `Forbidden Summoning` to require Mighty and Magical Summoning.
- Renamed `Infinite Inventory` to `Infinite Space`.

## [3.0.1] - 2022-12-12
### Changed
- Changed `Second Reincarnation` and `Godhood` to ignore spell immunity.
### Fixed
- Fixed description for `Celestial Realm` feature.

## [3.0.0] - 2022-12-11
### Added
- Added `Magical Amplification` Special power.
- Added `Killing Intent` Special power.
- Added `Aura of Divine Fury` Special power.
- Added `Armor of Strength` Special power.
- Added `Omega Strike` Special power.
- Added `Summon Beast` Special power.
- Added `Armor Saint` Special power.
- Added `Supreme Being` Overpowered ability.
- Added `True Resurrection` Overpowered ability.
- Added `Playful Darkness` to `Summon Calamity` Overpowered ability.
- Added bard, ranger, paladin, and inquisitor spells into the `Isekai Protagonist` spellbook.
- Added `Mythic Special Power` to mythic ability selection.
- Added `Starting Weapon` to `Isekai Protagonist` progression.
- Added `Signature Ability` to `Isekai Protagonist` progression. This can be chosen instead of `Signature Attack`.
- Added `Second Reincarnation` to `Isekai Protagonist` progression. This feature replaces `True Main Character`.
- Added `Summon Harem` ability to `Isekai Protagonist` progression. This ability replaces `Harem Magnet`.
- Added `Channel Energy` selection to `God Emperor` progression.
- Added `Divine Array` feature to `God Emperor` progression.
- Added `Celestial Realm` feature to `God Emperor` and `Hero` progression.
- Added `True Mark` ability to `Hero` progression.
### Changed
- Reworked `Isekai Protagonist` class and all archetypes.
- Buffed `Extra Strike` to apply to off-hand aswell if duel-wielding.
- Buffed `Nascent Apotheosis` to also give spell penetration and spell resistance.
- Changed `Godhood` to have spell immunity instead of 100 spell resistance. Removed "ignore spell immunity" and "auto confirm critical hits".
- Changed `Villain` Archetype to memorise spells like an Arcanist instead of Wizard. The Spell slots progression is the same as the spells per day progression.
- Changed `Body Strengthening` to give DR/— per level.
- Changed `Exceptional Weapon` exceptional feats into activatable abilities.
- Renamed `Protective Aura` to `Aura of Golden Protection`.
- Renamed `Glorious Aura` to `Aura of Majesty`.
- Renamed `Interdimensional Bag` to `Infinite Inventory` and updated icon.
- Update `Graceful Combat` icon.
### Removed
- Removed `Harem Magnet` ability.
- Removed `True Main Character` feature.
### Fixed
- Fixed `Dupe Gold` ability to correctly give 1 million gold instead of 100 thousand gold.
- Fixed `Exceptional Summoning` feats not applying to summoned creatures from spells without the `Summoning` spell descriptor.

## [2.4.0] - 2022-12-04
### Added
- Added new dialogue during drow ambush.
- Added `Special Powers` to show in class signature abilities.
### Changed
- Decreased mod file size significantly.
- Buffed `Grasp Heart` DC from 50 to 99.
- Nerfed `Super Buff` by removing Ice body, fiery body, and firebrand buffs.
- Nerfed `Training Montage` from +10 bonus to +8.
- Changed `Very Fast Movement` feature speed bonus from insight to untyped.
- Changed `Isekai Protagonist` from divine caster to arcane (visual only).
- Changed `Sneaky Magic` to require sneak attack.
- Changed `Character Development` feats to now be called `Special Powers`.
- Updated icon for `Drow Poison` feature.

## [2.3.0] - 2022-12-04
### Added
- Added `Isekai High Elf` heritage (Elf Heritage).
- Added `Isekai Wood Elf` heritage (Elf Heritage).
- Added `Exceptional weapon` exceptional feats.
- Added `Spell Master` character development feat.
- Added `Sneaky Magic` character development feat.
- Added `Auto Selective` Overpowered ability.
### Changed
- Reworked `Isekai Drow` into `Isekai Dark Elf` which focuses on Intelligence.
- Buffed `Nascent Apotheosis` feature to also give DR/— per level.
- Buffed `Training Montage` to no longer require character level 10.
- Nerfed `Body Strengthening` to give DR 20/— and requires level 10.
- Nerfed `Regeneration` hitpoint restoration from 20 to 10.
- Changed `Exceptional feats` to now always be recommended.
- Changed exceptional summoning feats to be in a selection group.
### Fixed
- Fixed `Deathsnatcher` default name.
- Fixed UI bug when selecting multiple exceptional feats.

## [2.2.0] - 2022-12-01
### Added
- Added 4 new Kinetic blast character development feats.
- Added Nocticula and Mephistopheles to `Summon Calamity` Overpowered ability.
### Changed
- Buffed `Inner Power` and `Godly Vessel` to protect from ability drain.
### Fixed
- Fixed `Ferocious Summoning` and `Forbidden Summoning` to reapply on level up.

## [2.1.0] - 2022-11-26
### Added
- Added mod support for `Spellbook Merge`.
- Added `Auto Bolster` Overpowered ability.
- Added `Mind Control` Overpowered ability.
- Added `Unlimited Power` Overpowered ability.
- Added `Summon Calamity` Overpowered ability.
- Added `Regeneration` Character Development feat.
- Added `Beta Tester` background.
- Added `Ferocious Summoning` exceptional feat.
- Added `Forbidden Summoning` exceptional feat.
- Added content group in UMM UI for exceptional feats.
### Changed
- Nerfed `Gamer` background to give +4 instead of +10.
- Changed icon for `True Smite`.
- Changed `Exceptional Summoning` to scale +10 hp, +1 attack, +1 AC, +1 saving throws per character level.
### Fixed
- Fixed `Harem Magnet` immunity to be applied after fascinate effect ends.

## [2.0.1] - 2022-11-23
### Changed
- Changed `Isekai Succubus` to give +2 DEX, +2 INT, +4 CHA, -2 STR instead of +4 DEX, +4 CHA, -2 STR.
- Changed `Isekai Drow` to give +2 DEX, +2 INT, +2 WIS, +2 CHA instead of +4 WIS, +4 CHA.
### Fixed
- Fixed missing `Drow Poison` ability use limit.
- Fixed missing speed buff for `Isekai Spriggan` size alteration ability.
- Fixed typo in `Isekai Protagonist` class description.

## [2.0.0] - 2022-11-23
### Added
- Added `Hero` archetype.
- Added `Isekai Drow` heritage (Elf Heritage).
- Added `Isekai Spriggan` heritage (Gnome Heritage).
- Added `Channel Positive Energy` character development feat.
- Added `Channel Negative Energy` character development feat.
- Added `Corrupt Aura` feature for `Villain` archetype.
- Added `Exceptional feats` in feat/bonus feat selection.
- Added `Effect Immunity` feats to exceptional feat selection.
- Added Mythic feats to exceptional feat selection.
- Added dialogue to upgrade radiance as the `Isekai Protagonist`.
### Changed
- Reworked `Character Development` feats to no longer have bonus feats or feats from `Beach Episode` at later levels.
- Reworked `Isekai Protagonist` class progression to have more Overpowered Abilities instead of training arc feats.
- Reworked `Edge Lord` and `God Emperor` archetypes to have more evenly distributed character development feats.
- Reworked `Villain` to have `Channel Negative Energy`.
- Buffed `Godhood` to give energy immunity against acid, cold, electricity, fire, and sonic.
- Nerfed `Grasp Heart` to stun if the creature fails a DC 50 fortitude save.
- Changed `Glorious Aura` to give a +4 sacred bonus to all attributes instead.
- Changed `Training Montage` to give a +10 untyped bonus to all attributes but now requires character level 10.
- Changed `Extreme Speed` to give a +5 untyped speed bonus per character level.
- Changed `Perfect Roll` and Auto metamagic abilities to be turned on by default.
- Changed `Exceptional Summoning` to now be an `Exceptional feat`.
- Updated description for `Super Buff` feature.
- Updated icon for `Siphoning Aura` debuff.
- Updated icon for `Second Form` feature.
- Updated icon for `True Main Character` feature.
### Removed
- Removed `Winner` feature.
- Removed `Training Arc` feature selection. Training Arc feats moved to character development.
### Fixed
- Fixed `Villain` archetype to correctly show source of magic as a divine caster.
- Fixed `Edge Lord` extra attack not stacking at 10th, 15th and 20th level.

## [1.9.0] - 2022-11-18
### Added
- Added `Deathsnatcher` animal companion.
- Added extra wing options for `Isekai Angel` and `Isekai Succubus` Heritage.
### Changed
- Changed Metamagic abilities to have more than one active at a time.
### Fixed
- Fixed Loremaster to work with Isekai Protagonist and Villain Spellbook.
- Fixed Hellknight Signifier to work with Isekai Protagonist and Villain Spellbook.

## [1.8.0] - 2022-11-13
### Added
- Added `Isekai Protagonist` dialogue when speaking to Hulrun at the Kenabres festival.
- Added `Isekai Vampire` Heritage (Dhampir Heritage).
### Changed
- Buffed `Isekai Succubus` with +4 racial bonus to Dexterity.
- Buffed `God Emperor`'s `Glorious Aura` to give a 1/2 level competence bonus.
- Buffed `God Emperor`'s `Protective Aura` to give a 1/2 level sacred bonus.
- Buffed `God Emperor`'s `Siphoning Aura` to give a -4 penalty.
- Changed `Highschool Student` background to give a trait bonus instead of untyped.
- Changed `Reborn Demon Lord` background to give a trait bonus instead of untyped.
- Updated icon for `Glorious Aura` feature.
- Updated icon for `Siphoning Aura` feature.
- Updated icon for `Dark Aura` feature.
- Updated icon for `Winner` feature.
### Fixed
- Fixed Villain Spellbook merge.

## [1.7.2] - 2022-11-11
### Fixed
- Fixed `AutoEmpower` not working.

## [1.7.1] - 2022-11-11
### Fixed
- Fixed Version number for UMM.

## [1.7.0] - 2022-11-11
### Added
- Added `Otaku` Background.
- Added `Reborn Demon Lord` Background.
- Added `Gamer` Background.
- Added `Aqua` Deity.
- Added `Ristarte` Deity.
- Added `Administrator D` Deity.
### Changed
- Changed `Truck-kun` Deity restriction from `Priest of Balance` to `Angelfire Apostle`.

## [1.6.0] - 2022-11-07
### Added
- Added Overpowered Ability `Interdimensional Bag`.
### Fixed
- Removed critical immunity bypass from `Alpha Strike` and `Godhood` because they don't work.

## [1.5.0] - 2022-11-06
### Added
- Added `Isekai Succubus` Heritage (Tiefling Heritage).
- Added `Isekai Angel` Heritage (Aasimar Heritage).
- Added Overpowered Ability `Super Buff`.
### Changed
- Buffed Edge Lord's "Supersonic Combat" to allow for use in CMB and to qualify for feats that require strength.

## [1.4.1] - 2022-11-05
### Fixed
- Fixed Drake Companion Selection.
- Fixed Drake Mythic ability.

## [1.4.0] - 2022-11-05
### Added
- Added `Villain` archetype.
- Added drake companion support for `ExpandedContent 0.4.40`.

## [1.3.0] - 2022-11-02
### Added
- Added Mod support for `MysticalMayhem 0.1.3`.
- Added Mod support for `ExpandedContent 0.4.40`.

## [1.2.1] - 2022-11-01
### Fixed
- Fixed typo with `Truck-kun` Deity description.

## [1.2.0] - 2022-11-01
### Added
- Added an animal companion or familiar for the `Isekai Protagonist` class.
- Added `Truck-kun` Deity.

## [1.1.1] - 2022-10-31
### Fixed
- Fixed typo with `God Emperor` archetype.
- Fixed error in unity mod manager saying a new update is available.

## [1.1.0] - 2022-10-30
### Added
- Added `Highschool Student` background.
- Added `Exceptional Summoning` feature.
### Fixed
- Fixed `Repository.json` to have the correct release Id.
- Fixed bug with `Martial Artist` background if the `Isekai Protagonist` class is disabled.

## [1.0.0] - 2022-10-28
### Added
- Added `Isekai Protagonist` class
- Added `God Emperor` archetype
- Added `Edge Lord` archetype
- Added 3 Isekai backgrounds
- Added related features and abilities