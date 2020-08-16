
using UnityEngine;
using UnityEditor;


namespace EnjoyMoment.Auto {


    public class TextureSetting : AssetPostprocessor {

        static bool autoImportSetting = false;



        void OnPreprocessTexture() {
            if (!autoImportSetting) {
                return;
            }
            Debug.Log("设置texture");
            TextureImporter textureImporter = assetImporter as TextureImporter;
            if (textureImporter.assetPath.Contains("UI")) {

                //安卓平台ui/sprite导入设置
                textureImporter.textureType = TextureImporterType.Sprite;
                textureImporter.mipmapEnabled = false;
                TextureImporterPlatformSettings uiAndroidSettings = new TextureImporterPlatformSettings {
                    name = "Android",
                    overridden = true,
                    textureCompression = TextureImporterCompression.Uncompressed,
                };
                textureImporter.SetPlatformTextureSettings(uiAndroidSettings);
            }
            else if (textureImporter.assetPath.Contains("Texture")) {
                textureImporter.textureType = TextureImporterType.Default;
                textureImporter.mipmapEnabled = true;
                //安卓平台纹理导入设置
                TextureImporterPlatformSettings textureAndroidSettings = new TextureImporterPlatformSettings {
                    name = "Android",
                    overridden = true,
                    textureCompression = TextureImporterCompression.Uncompressed,
                };
                textureImporter.SetPlatformTextureSettings(textureAndroidSettings);
            }
            else if (textureImporter.assetPath.Contains("Sprite")) {
                textureImporter.textureType = TextureImporterType.Sprite;
                textureImporter.mipmapEnabled = false;
                textureImporter.filterMode = FilterMode.Point;
                TextureImporterPlatformSettings uiAndroidSettings = new TextureImporterPlatformSettings {
                    name = "Android",
                    overridden = true,
                    textureCompression = TextureImporterCompression.Uncompressed,
                };
                textureImporter.SetPlatformTextureSettings(uiAndroidSettings);
            }
        }
        void OnPostprocessSprites(Texture2D texture, Sprite[] sprites) {
            if (!autoImportSetting) {
                return;
            }
            Debug.Log("Sprites: " + sprites.Length);
        }
        void OnPostprocessTexture(Texture2D texture) {
            if (!autoImportSetting) {
                return;
            }
            Debug.Log("Texture2D: (" + texture.width + "x" + texture.height + ")");
            TextureImporter textureImporter = assetImporter as TextureImporter;
            textureImporter.maxTextureSize = texture.width;
        }
        [MenuItem("EnjoyMoment/Auto/TextureImportSetting")]
        static void ClickButton() {
            autoImportSetting = !autoImportSetting;
            if (autoImportSetting) {
                Debug.Log("开启了自动处理texture导入设置");
            }
            else {
                Debug.Log("关闭了自动处理texture导入设置");
            }
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, "123");
        }

    }


}
