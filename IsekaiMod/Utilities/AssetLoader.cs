using IsekaiMod.Config;
using System.IO;
using UnityEngine;

namespace IsekaiMod.Utilities
{
    class AssetLoader
    {
        public static Sprite LoadInternal(string folder, string file)
        {
            return Image2Sprite.Create($"{ModSettings.ModEntry.Path}Assets{Path.DirectorySeparatorChar}{folder}{Path.DirectorySeparatorChar}{file}");
        }
        public static class Image2Sprite
        {
            public static string icons_folder = "";
            public static Sprite Create(string filePath)
            {
                var bytes = File.ReadAllBytes(icons_folder + filePath);
                var texture = new Texture2D(64, 64, TextureFormat.RGBA32, false);
                _ = texture.LoadImage(bytes);
                var sprite = Sprite.Create(texture, new Rect(0, 0, 64, 64), new Vector2(0, 0));
                return sprite;
            }
        }
    }
}