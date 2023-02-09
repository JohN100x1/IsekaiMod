using IsekaiMod.Config;
using TabletopTweaks.Core.ModLogic;
using static UnityModManagerNet.UnityModManager;

namespace IsekaiMod.ModLogic {

    internal class ModContextTTTBase : ModContextBase {
        public AddedContent AddedContent;

        public ModContextTTTBase(ModEntry ModEntry) : base(ModEntry) {
#if DEBUG
            Debug = true;
#endif
            LoadAllSettings();
        }

        public override void LoadAllSettings() {
            LoadSettings("AddedContent.json", "IsekaiMod.Config", ref AddedContent);
            LoadBlueprints("IsekaiMod.Config", this);
            LoadLocalization("IsekaiMod.Localization");
        }

        public override void AfterBlueprintCachePatches() {
            base.AfterBlueprintCachePatches();
            if (Debug) {
                Blueprints.RemoveUnused();
                SaveSettings(BlueprintsFile, Blueprints);
                ModLocalizationPack.RemoveUnused();
                SaveLocalization(ModLocalizationPack);
            }
        }

        public override void SaveAllSettings() {
            base.SaveAllSettings();
            SaveSettings("AddedContent.json", AddedContent);
        }
    }
}