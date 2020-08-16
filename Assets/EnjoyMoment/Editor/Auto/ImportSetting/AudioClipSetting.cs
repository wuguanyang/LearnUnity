using UnityEngine;
using UnityEditor;


namespace EnjoyMoment.Auto {
    public class AudioClipSetting : AssetPostprocessor {

        static bool autoImportSetting = false;
        void OnPreprocessAudio() {

        }

        void OnPostprocessAudio(AudioClip clip) {

        }

        [MenuItem("EnjoyMoment/Auto/AudioImportSetting")]
        static void ClickButton() {
            autoImportSetting = !autoImportSetting;
            if (autoImportSetting) {
                Debug.Log("开启了自动处理audio导入设置");
            }
            else {
                Debug.Log("关闭了自动处理audio导入设置");
            }
        }
    }
}

