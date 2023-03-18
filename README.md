# Isekai Mod
This is a content mod for `Pathfinder: Wrath of the Righteous` that adds an `Isekai Protagonist` Class into the game.
## Development Guide
### Requirements
- Visual Studio 2019 (You can use the latest version if you know what you're doing)
### Setup
- Add `WrathPath` as an environment variable with the value `C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure` or wherever your game directory is.
- Open Visual Studio and [publicize your assemblies](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Publicize-Assemblies).
### Testing
- Create a folder called `IsekaiMod` in `C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure\Mods`.
- After building your solution in Visual Studio, go to your project directory -> `bin` -> `Release` or `Debug` -> `IsekaiMod` -> `net472`.
- Copy the files and folders from the diagram below and place them in the `IsekaiMod` folder you created.
- You'll need to create the `UserSettings` folder. Copy the `AddedContent.json` and the `Blueprints.json` files from the project and place them inside.
```
C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure\Mods\IsekaiMod

IsekaiMod/
├── Assets/
│   └── ...
├── Localization/
│   └── LocalizationPack.json
├── UserSettings/
│   ├── AddedContent.json
│   └── Blueprints.json
├── Info.json
├── IsekaiMod.dll
└── ModKit.dll
```
- For the Assets make sure you have the Portraits. Copy them from a [Release](https://github.com/JohN100x1/WOTR_IsekaiMod/releases).
- Now you can start your game and test.

On subsequent tests you'll only need to copy the `IsekaiMod.dll`.
- If you edited the blueprint names, copy `Blueprints.json` as well.
- If you added new assets, copy those as well.
## Mod Information
### Requirements
- [Unity Mod Manager](https://www.nexusmods.com/site/mods/21).
- [TabletopTweaks-Core](https://github.com/Vek17/TabletopTweaks-Core/releases).
### Installation
- Open Unity Mod Manager and go to the 'Mods' tab.
- Drag and Drop the IsekaiMod.zip file into Unity Mod Manager.
If you use ModFinder rather than Unity Mod Manager just replace the name mentally in your head, instructions are otherwise identical.

### Downward Compatibility Warning for version 4.0.0
The rogue abilities the protagonist, villain, and edge lord got and the paladin abilities the hero got were moved into progression features with plenty of additional options added (see below).
This means a rather heavy change in the classes progression trees for all four of those options, if you are updating with an existing savegame using something like [barleyFlours Respec Mod](https://github.com/BarleyFlour/RespecMod) is highly advisable.
Otherwise you will miss out on things when leveling up.
Exception to this is the God Emperor as all options that were changed were not part of its original definition so you are only missing out on some additional options for overwhelming abilities you could have picked at level one.


### New Content
- New Classes & Archetypes
	- `Isekai Protagonist`
		- Spontaneous caster that uses Charisma.
		- Has a really powerful spellbook that has spells from all other classes.
		- Has extra feats like the fighter but not limited to combat feats.
		- Starts of with the `Plot Armor` feature which make them hard to kill.
		- Has Overpowered Abilities.
		- Can merge their spellbook with angel or lich.
		- Can choose a familiar or animal companion... or a deathsnatcher.
		- Has a legacy class feature from the list below.
	- `God Emperor` (Isekai Protagonist Archetype)
		- Has powerful auras that buff allies and debuff enemies.
		- Has powerful immunities in the late game.
	- `Edge Lord` (Isekai Protagonist Archetype)
		- Has alot of extra attacks.
		- Uses dexterity for damage and attack rolls.
		- Can pick a melee focused legacy class feature.
	- `Hero` (Isekai Protagonist Archetype)
		- Has the `True Smite` ability (smite any alignment).
		- Uses charisma for damage and attack rolls.
	- `Villain` (Isekai Protagonist Archetype)
		- Has Study target.
		- Has Much more Overpowered Abilities.
		- Intelligence based caster that memorizes spells like an arcanist.
		- Can pick a non-heroic, non-disney, non-Barbarian legacy class feature.
- New Features
	- `Exceptional feats`: Strong feats that can be chosen in place of a feat/bonus feat.
		- `Mythic feat`: You can choose a mythic feat instead of a normal/bonus feat.
		- `Effect Immunity`: You become immune to a specific effect. (e.g. poison, bleed, charm etc.)
		- `Mighty Summoning`: Your summons get +5 HP, +1 attack, and +1 AC per character level.
		- `Magical Summoning`: Your summons get +5 HP, +1 spell penetration, +1 spell DC, +1 spell damage, and +1 to saving throws per character level.
		- `Forbidden Summoning`: Your summons get +10 HP, and +1 to all attributes per character level. (requires Mighty and Magical Summoning).
		- `Ferocious Summoning`: Your summons have 2 more attacks and +10 speed. They also get +1 sneak attack per character level. (requires Forbidden Summoning).
		- `Exceptional Weapon`: Your attacks get an additional enchantment. (e.g. Corrosive, Flaming, Frost, etc.)
	- `Plot Armor`: Get bonus on AC and Saving throws based on character level.
	- `Special Power Feats`: A selection of bonus feats which have very good effects.
		- `Alpha Strike`: Automatically confirm crits.
		- `Beta Strike`: Get an extra attack with a -4 damage penalty.
		- `Gamma Strike`: Ignore concealment and your attacks count as adamantine.
		- `Omega Strike`: Increase your damage multipler by 1.
		- `Mundane Aura`: Get immunity to sneak attack and critical hits.
		- `Regeneration`: Get regeneration 10/acid or fire (requires character level 10).
		- `Training Montage`: Get a +8 bonus to all attributes.
		- `Body Strengthening`: Get a DR/— equal to character level.
		- `Spell Negation`: Get Spell resistance equal to 10 + twice character level.
		- `Extreme Speed`: Allies within 40 feet of you get a speed bonus equal to 5 times your character level.
		- `Channel Positive Energy`: You can channel positive energy (requires good alignment).
		- `Channel Negative Energy`: You can channel negative energy (requires evil alignment).
		- `Kinetic Power`: You can select a kinetic blast (air, earth, fire, water).
		- `Sneaky Magic`: You can add your sneak attack damage to spells against flat-footed.
		- `Spell Master`: Increase your spell DC by 4.
		- `Magical Amplification`: Your spell damage dice become d12.
		- `Armor Saint`: You can move at normal speed while wearing armor, reduce your armor check penalty to zero, and increase your max dexterity bonus by 20.
		- `Armor of Strength`: Get a natural armor bonus to AC equal to Strength modifier.
		- `Summon Beast`: Summon a hydra, owlbear, roc, or minotaur.
		- `Aura of Divine Fury`: Allies within 40 feet of you has a +10 sacred bonus to attack damage and hit point damage from spells (requires character level 15).
		- `Killing Intent`: Enemies within 40 feet who fail a will save become shaken, frightened, and cowering.
		- `Reflect`: Deal damage to enemies equal to damage you receive.
		- `Mythic Class Feature`: see below
		- `Dual Legacy`: Pick a second base class to get abilities from, or in the case of the God Emperor your first.
	- `Overpowered Ability`: Powerful gamebreaking abilities.
		- `AutoBolster`: Bolsters every spell you cast.
		- `AutoEmpower`: Empowers every spell you cast.
		- `AutoExtend`: Extends every spell you cast.
		- `AutoMaximize`: Maximizes every spell you cast.
		- `AutoQuicken`: Quickens every spell you cast.
		- `AutoReach`: Gives more range on every spell you cast.
		- `AutoSelective`: Exclude selected targets on every spell you cast.
		- `Instakill`: Kills target creature (no HP limit).
		- `Dupe Gold`: Get infinite gold.
		- `Perfect Roll`: Roll 20 on every d20 roll.
		- `Super Buff`: Apply many powerful buffs on you and your allies.
		- `Infinite Inventory`: Get infinite carry capacity.
		- `Unlimited Power`: Restore all ability and spell slots at will.
		- `Mind Control`: Make an enemy creature fight for you.
		- `Summon Calamity`: Summon a Devastator, Baphomet, Deskari, Nocticula, or Mephistopheles.
		- `True Resurrection`: Resurrect a dead companion (no diamond cost).
		- `Supreme Being`: All your attributes have a base value of 30.
		- `Mythic Class Feature`: see below
		- `Dual Legacy`: Pick a second base class to get abilities from, or in the case of the God Emperor your first.
		- Requires TabletopTweaks-Base
			- `Auto Rime`: Cold spells entangle the target for a number of rounds.
			- `Auto Burning`: Acid and fire spells cause acid or fire damage on the next round.
			- `Auto Flaring`: Light, fire, and electricity spells cause the dazzled condition.
			- `Auto Piercing`: Spells treat target's SR as 5 lower than actual SR.
			- `Auto Solid Shadows`: Shadow spells are 20% more real.
			- `Auto Encouraging`: Increase spells' morale bonus by 1.
			- `Auto Intensified`: Increase spells' max damage dice by 5.
	- `Mythic Class Feature`: Access to a mythic class feature not your own
		- `Angel Mythic Class Feature`: possible selections include the angelic halo and sword of heaven and their buffs
		- `Azata Mythic Class Feature`: the superpowers
		- `Lich Mythic Class Feature` : the lich powers
		- `Trickster Mythic Class Feature`: the trickster skill specializations
		- `Mythic Aeon Spells`: Aeon Spells in Protagonist Spellbook
		- `Mythic Angel Spells`: as above but for Angel
		- `Mythic Azata Spells`: as above but for Azata
		- `Mythic Demon Spells`: as above but for Demon
		- `Mythic Lich Spells`: as above but for Lich
		- `Mythic Trickster Spells`: as above but for Trickster
	- `Legacy`: if the gods had not interfered and made you into an overpowered spellcasting hero you would have been:
		- `Barbarian Legacy - Ball of Rage`
		- `Bard Legacy - Musical Prodige`
		- `Dread Knight Legacy - Dread Lord`
		- `Paladin Legacy - Hero of Light`
		- `Kineticist Legacy - Kinetic Knight`
		- `Kineticist Legacy - Kinetic Lord`
		- `Magus Legacy - Spellblade`: Still requires testing, so only use it if you are willing to essentially be the betatester for the Legacy at the moment
		- `Oracle Legacy - Seeker of Truth`: does not grant its selections retroactivly, so best picked early.
		- `Rogue Legacy - Supernatural Thief`
		- `Shaman Legacy - Spirit Beacons`: Also still a Beta release
		- `Sorcerer Legacy - Chimera`: does not grant its selections retroactivly, so best picked early.
		- `Tactician Legacy - Isekai Tactician`: A mixture from several classes like hunter and Monster Tactician to create a path focused around tactical feats
- New Animal Companion
	- `Deathsnatcher`: A chaotic evil monstrous humanoid companion that can cast the animate dead spell. (Warning: very unbalanced)
- New Mythic abilities
	- `Mythic Overpowered Ability`: Gives you another Overpowered Ability.
	- `Mythic Special Power`: Gives you another Special Power.
- New Backgrounds
	- `Tabletop RPG Player`: Adds all Lore and Knowledge skills as class skills. Lore and Knowledge skills use CHA instead of WIS/INT.
	- `Martial Artist`: Get proficiency in all exotic weapons.
	- `Salaryman`: Adds perception as a class skill. Perception uses CHA instead of WIS.
	- `Highschool Student`: Get a +1 trait bonus to all attributes.
	- `Reborn Demon Lord`: Get a +2 trait bonus to Strength and Electricity resistance 20.
	- `Otaku`: Adds all skills as class skills except Persuasion.
	- `Gamer`: Get a +4 competence bonus to all knowledge, lore, and perception checks.
	- `Beta Tester`: Get +10 Initiative and adds lore, knowledge and perceptions skills as class skills.
- New Heritages
	- `Isekai Angel` (Aasimar Heritage): A powerful heritage for Aasimar that gives you wings and a powerful holy damage ability.
	- `Isekai Succubus` (Tiefling Heritage): A powerful heritage for Tiefling that gives you wings and a powerful charm ability.
	- `Isekai Vampire` (Dhampir Heritage): A powerful heritage for Dhampir that has fast healing and many immunities.
	- `Isekai Dark Elf` (Elf Heritage): A powerful heritage for Elf that gives you the Drow Poison ability.
	- `Isekai High Elf` (Elf Heritage): A powerful heritage for Elf that increases the number of spells you can cast per day.
	- `Isekai Wood Elf` (Elf Heritage): A powerful heritage for Elf that have extra speed.
	- `Isekai Spriggan` (Gnome Heritage): A powerful heritage for Gnome that gives you a size alteration ability.
	- `Isekai Furry` (Kitsune Heritage): A powerful heritage for Kitsune that has fast healing and extra speed.
- New Deities
	- `Truck-kun`: A god of transportation.
	- `Aqua`: A goddess of water.
	- `Ristarte`: A goddess of healing.
	- `Administrator D`: An ultimate god of evil.
- New Dialogue
	- Prologue, speaking with Hulrun at Kenabres Festival.
	- Act 1, Shield Maze after finding Radiance.
	- Random encounter, during drow ambush.

### Isekai Protagonist Spell progression
#### Spells per Day table
| Level | 1st | 2nd | 3rd | 4th | 5th | 6th | 7th | 8th | 9th |
|-------|-----|-----|-----|-----|-----|-----|-----|-----|-----|
| 1     | 3   |     |     |     |     |     |     |     |     |
| 2     | 6   |     |     |     |     |     |     |     |     |
| 3     | 9   | 3   |     |     |     |     |     |     |     |
| 4     | 12  | 6   |     |     |     |     |     |     |     |
| 5     | 12  | 9   | 3   |     |     |     |     |     |     |
| 6     | 12  | 12  | 6   |     |     |     |     |     |     |
| 7     | 12  | 12  | 9   | 3   |     |     |     |     |     |
| 8     | 12  | 12  | 12  | 6   |     |     |     |     |     |
| 9     | 12  | 12  | 12  | 9   | 3   |     |     |     |     |
| 10    | 12  | 12  | 12  | 12  | 6   |     |     |     |     |
| 11    | 12  | 12  | 12  | 12  | 9   | 3   |     |     |     |
| 12    | 12  | 12  | 12  | 12  | 12  | 6   |     |     |     |
| 13    | 12  | 12  | 12  | 12  | 12  | 9   | 3   |     |     |
| 14    | 12  | 12  | 12  | 12  | 12  | 12  | 6   |     |     |
| 15    | 12  | 12  | 12  | 12  | 12  | 12  | 9   | 3   |     |
| 16    | 12  | 12  | 12  | 12  | 12  | 12  | 12  | 6   |     |
| 17    | 12  | 12  | 12  | 12  | 12  | 12  | 12  | 9   | 3   |
| 18    | 12  | 12  | 12  | 12  | 12  | 12  | 12  | 12  | 6   |
| 19    | 12  | 12  | 12  | 12  | 12  | 12  | 12  | 12  | 9   |
| 20    | 12  | 12  | 12  | 12  | 12  | 12  | 12  | 12  | 12  |
#### Spells Known table
| Level | 1st | 2nd | 3rd | 4th | 5th | 6th | 7th | 8th | 9th |
|-------|-----|-----|-----|-----|-----|-----|-----|-----|-----|
| 1     | 6   |     |     |     |     |     |     |     |     |
| 2     | 12  |     |     |     |     |     |     |     |     |
| 3     | 18  | 6   |     |     |     |     |     |     |     |
| 4     | 24  | 12  |     |     |     |     |     |     |     |
| 5     | 24  | 18  | 6   |     |     |     |     |     |     |
| 6     | 30  | 24  | 6   |     |     |     |     |     |     |
| 7     | 30  | 24  | 12  | 6   |     |     |     |     |     |
| 8     | 30  | 30  | 18  | 6   |     |     |     |     |     |
| 9     | 30  | 30  | 18  | 12  | 6   |     |     |     |     |
| 10    | 30  | 30  | 24  | 18  | 6   |     |     |     |     |
| 11    | 30  | 30  | 24  | 18  | 12  | 6   |     |     |     |
| 12    | 30  | 30  | 24  | 24  | 18  | 6   |     |     |     |
| 13    | 30  | 30  | 24  | 24  | 18  | 12  | 6   |     |     |
| 14    | 30  | 30  | 24  | 24  | 24  | 18  | 6   |     |     |
| 15    | 30  | 30  | 24  | 24  | 24  | 18  | 12  | 6   |     |
| 16    | 30  | 30  | 24  | 24  | 24  | 24  | 18  | 6   |     |
| 17    | 30  | 30  | 24  | 24  | 24  | 24  | 18  | 12  | 6   |
| 18    | 30  | 30  | 24  | 24  | 24  | 24  | 24  | 18  | 6   |
| 19    | 30  | 30  | 24  | 24  | 24  | 24  | 24  | 24  | 12  |
| 20    | 30  | 30  | 24  | 24  | 24  | 24  | 24  | 24  | 20  |

## Mod Support
This mod has support for the following mods.
### TabletopTweaks-Base (2.5.2)
If you have the `TabletopTweaks-Base` mod, the `Isekai Protagonist` will have `Auto Rime`, `Auto Burning`, `Auto Flaring`,
`Auto Piercing`, `Auto Solid Shadows`, `Auto Encouraging`, `Auto Intensified` as OP ability options.
### MysticalMayhem (0.1.5)
If you have the `MysticalMayhem` mod, the `Isekai Protagonist` will have the 9th level `Meteor Swarm` spell added to its spellbook.
### ExpandedContent (0.5.2)
If you have the `ExpandedContent` mod, the `Isekai Protagonist` will have all the new spells add to its spellbook.
### SpellbookMerge (1.7.1)
If you have the `SpellbookMerge` mod, the `Isekai Protagonist` will be able to merge its spellbook with Aeon, Azata, Demon, and Trickster.

### Any Mod adding spells to the base classes
As of version 4.0.0 there is an option to create the Isekai spell list by merging most of the non mythic ingame spell lists. That means that as long as the mod loads in before this one and adds the spell to at least one of those lists the Isekai Protagonist gets it too.
The list of spell lists we merge for this is fairly comprehensive, Cleric, Wizard, Druid,all the base game domains, all the different wizard specialisation lists, Witch, ...
As such almost no spell should need work on our part to add support for it, if you find one please let us know.

## Credits
Thanks to kjk001 for contributing alot to this repository, improving the code to use TabletopTweaks-Core as well as adding lots of content.
Thanks to WittleWolfie for creating this modding guide that helped me get started:
- https://github.com/WittleWolfie/OwlcatModdingWiki/wiki
