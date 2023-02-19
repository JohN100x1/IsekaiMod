using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class BlessingOfTheMythic {

        public static void Configure() {
            var MythicAeonSpellsKnown = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "AeonSpellsKnown", bp => {
                bp.SetName(IsekaiContext, "Mythic Aeon Spells");
                bp.SetDescription(IsekaiContext, "Gain the Spells of an Aeon");
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = false;
                bp.IsClassFeature = true;
                bp.HideInUI = true;
                foreach (var AeonSpellLevel in SpellTools.SpellList.AeonSpellMythicList.SpellsByLevel) {
                    foreach (var spell in AeonSpellLevel.m_Spells) {
                        bp.AddComponent<AddKnownSpell>(cp => {
                            cp.SpellLevel = AeonSpellLevel.SpellLevel;
                            cp.m_Spell = spell;
                            cp.m_CharacterClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("051cef8e29064217a6d5c8011b1d9f60").ToReference<BlueprintCharacterClassReference>();
                        });
                    }
                }
            });
            var MythicAngelSpellsKnown = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "AngelSpellsKnown", bp => {
                bp.SetName(IsekaiContext, "Mythic Angel Spells");
                bp.SetDescription(IsekaiContext, "Gain the Spells of an Angel");
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = false;
                bp.IsClassFeature = true;
                bp.HideInUI = true;
                foreach (var AngelSpellLevel in SpellTools.SpellList.AngelMythicSpelllist.SpellsByLevel) {
                    foreach (var spell in AngelSpellLevel.m_Spells) {
                        bp.AddComponent<AddKnownSpell>(cp => {
                            cp.SpellLevel = AngelSpellLevel.SpellLevel;
                            cp.m_Spell = spell;
                            cp.m_CharacterClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("051cef8e29064217a6d5c8011b1d9f60").ToReference<BlueprintCharacterClassReference>();
                        });
                    }
                }
            });
            var MythicAzataSpellsKnown = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "AzataSpellsKnown", bp => {
                bp.SetName(IsekaiContext, "Mythic Azata Spells");
                bp.SetDescription(IsekaiContext, "Gain the Spells of an Azata");
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = false;
                bp.IsClassFeature = true;
                bp.HideInUI = true;
                foreach (var AzataSpellLevel in SpellTools.SpellList.AzataMythicSpellsSpelllist.SpellsByLevel) {
                    foreach (var spell in AzataSpellLevel.m_Spells) {
                        bp.AddComponent<AddKnownSpell>(cp => {
                            cp.SpellLevel = AzataSpellLevel.SpellLevel;
                            cp.m_Spell = spell;
                            cp.m_CharacterClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("051cef8e29064217a6d5c8011b1d9f60").ToReference<BlueprintCharacterClassReference>();
                        });
                    }
                }
            });
            var MythicDemonSpellsKnown = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "DemonSpellsKnown", bp => {
                bp.SetName(IsekaiContext, "Mythic Demon Spells");
                bp.SetDescription(IsekaiContext, "Gain the Spells of an Demon");
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = false;
                bp.IsClassFeature = true;
                bp.HideInUI = true;
                foreach (var DemonSpellLevel in SpellTools.SpellList.DemonSpelllist.SpellsByLevel) {
                    foreach (var spell in DemonSpellLevel.m_Spells) {
                        bp.AddComponent<AddKnownSpell>(cp => {
                            cp.SpellLevel = DemonSpellLevel.SpellLevel;
                            cp.m_Spell = spell;
                            cp.m_CharacterClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("051cef8e29064217a6d5c8011b1d9f60").ToReference<BlueprintCharacterClassReference>();
                        });
                    }
                }
            });
            var MythicLichSpellsKnown = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "LichSpellsKnown", bp => {
                bp.SetName(IsekaiContext, "Mythic Lich Spells");
                bp.SetDescription(IsekaiContext, "Gain the Spells of an Lich");
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = false;
                bp.IsClassFeature = true;
                bp.HideInUI = true;
                foreach (var LichSpellLevel in SpellTools.SpellList.LichMythicSpelllist.SpellsByLevel) {
                    foreach (var spell in LichSpellLevel.m_Spells) {
                        bp.AddComponent<AddKnownSpell>(cp => {
                            cp.SpellLevel = LichSpellLevel.SpellLevel;
                            cp.m_Spell = spell;
                            cp.m_CharacterClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("051cef8e29064217a6d5c8011b1d9f60").ToReference<BlueprintCharacterClassReference>();
                        });
                    }
                }
            });
            var MythicTricksterSpellsKnown = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "TricksterSpellsKnown", bp => {
                bp.SetName(IsekaiContext, "Mythic Trickster Spells");
                bp.SetDescription(IsekaiContext, "Gain the Spells of an Trickster");
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = false;
                bp.IsClassFeature = true;
                bp.HideInUI = true;
                foreach (var TricksterSpellLevel in SpellTools.SpellList.TricksterSpelllistMythic.SpellsByLevel) {
                    foreach (var spell in TricksterSpellLevel.m_Spells) {
                        bp.AddComponent<AddKnownSpell>(cp => {
                            cp.SpellLevel = TricksterSpellLevel.SpellLevel;
                            cp.m_Spell = spell;
                            cp.m_CharacterClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("051cef8e29064217a6d5c8011b1d9f60").ToReference<BlueprintCharacterClassReference>();
                        });
                    }
                }
            });
            var TricksterSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BlessingOfTheTrickster", bp => {
                bp.SetName(IsekaiContext, "Trickster Mythic Class Feature");
                bp.SetDescription(IsekaiContext, "A feat worthy of a trickster");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.IgnorePrerequisites = false;
                bp.m_AllFeatures = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("4fbc563529717de4d92052048143e0f1").m_AllFeatures;
                bp.m_AllFeatures = bp.m_AllFeatures.AddRangeToArray(BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("5cd96c3460844fc458dc3e1656dafa42").m_AllFeatures);
                bp.m_AllFeatures = bp.m_AllFeatures.AddRangeToArray(BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("446f4a8b32019f5478a8dfeddac74710").m_AllFeatures);
            });
            var AzataSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BlessingOfTheAzata", bp => {
                bp.SetName(IsekaiContext, "Azata Mythic Class Feature");
                bp.SetDescription(IsekaiContext, "Let me show you something fun!");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.IgnorePrerequisites = false;
                bp.m_AllFeatures = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("8a30e92cd04ff5b459ba7cb03584fda0").m_AllFeatures;
            });
            var LichSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BlessingOfTheLich", bp => {
                bp.SetName(IsekaiContext, "Lich Mythic Class Feature");
                bp.SetDescription(IsekaiContext, "What?\nA bit of undeath never hurt anyone...");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.IgnorePrerequisites = false;
                bp.m_AllFeatures = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("1f646b820a37d3d4a8ab116a24ee0022").m_AllFeatures
                .AddToArray<BlueprintFeatureReference>(BlueprintTools.GetBlueprint<BlueprintFeature>("9703d79082dc75e4aaaa4387b9c95229").ToReference<BlueprintFeatureReference>())
                .AddToArray<BlueprintFeatureReference>(BlueprintTools.GetBlueprint<BlueprintFeature>("eea98a8c70c68ff489967c6f9cf1876c").ToReference<BlueprintFeatureReference>())
                .AddToArray<BlueprintFeatureReference>(BlueprintTools.GetBlueprint<BlueprintFeature>("eea98a8c70c68ff489967c6f9cf1876c").ToReference<BlueprintFeatureReference>())
                ;
            });
            var AngelSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BlessingOfTheAngel", bp => {
                bp.SetName(IsekaiContext, "Angel Mythic Class Feature");
                bp.SetDescription(IsekaiContext, "Behold the blessing of the Angel.");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.IgnorePrerequisites = false;
                bp.m_AllFeatures = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("bdbc41e2bad92a640bd58acf74e2af8b").m_AllFeatures
                .AddToArray<BlueprintFeatureReference>(BlueprintTools.GetBlueprint<BlueprintFeature>("bdddaa78f8795024081f2d1eb8b4bd78").ToReference<BlueprintFeatureReference>())
                .AddToArray<BlueprintFeatureReference>(BlueprintTools.GetBlueprint<BlueprintFeature>("dd9648afaaba516488b6aeb8ff86b70a").ToReference<BlueprintFeatureReference>())
                .AddToArray<BlueprintFeatureReference>(BlueprintTools.GetBlueprint<BlueprintFeature>("e4d0a00fb70cd3f4384db0687ef88964").ToReference<BlueprintFeatureReference>())
                .AddToArray<BlueprintFeatureReference>(BlueprintTools.GetBlueprint<BlueprintFeature>("7a6080461eaa278428fe3f12df75c8d0").ToReference<BlueprintFeatureReference>())
                .AddRangeToArray<BlueprintFeatureReference>(BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("e0ce40968bf0007408b11089a10f36cf").m_AllFeatures)
                ;
            });

            var MythicSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "BlessingOfTheMythic", bp => {
                bp.SetName(IsekaiContext, "Mythic Class Feature");
                bp.SetDescription(IsekaiContext, "So I am an angel, is that really a reason not to cast demonic spells? \nOr to deny myself some of those sweet abilities of the trickster?\nSome of you Aeons are far too unflexible.\nSpeaking of Aeons, you got some great spells as well didn't you?\nLet me quickly learn them...");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.IgnorePrerequisites = false;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    MythicAeonSpellsKnown.ToReference<BlueprintFeatureReference>(),
                    MythicAngelSpellsKnown.ToReference<BlueprintFeatureReference>(),
                    MythicAzataSpellsKnown.ToReference<BlueprintFeatureReference>(),
                    MythicDemonSpellsKnown.ToReference<BlueprintFeatureReference>(),
                    MythicLichSpellsKnown.ToReference<BlueprintFeatureReference>(),
                    MythicTricksterSpellsKnown.ToReference<BlueprintFeatureReference>(),
                    TricksterSelection.ToReference<BlueprintFeatureReference>(),
                    AzataSelection.ToReference<BlueprintFeatureReference>(),
                    LichSelection.ToReference<BlueprintFeatureReference>(),
                    AngelSelection.ToReference<BlueprintFeatureReference>(),
                };
            });
            OverpoweredAbilitySelection.AddToSelection(MythicSelection);
            SpecialPower.SpecialPowerSelection.AddToSelection(MythicSelection);
        }
    }
}