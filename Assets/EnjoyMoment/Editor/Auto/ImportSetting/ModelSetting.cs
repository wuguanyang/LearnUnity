
using UnityEngine;
using UnityEditor;

namespace EnjoyMoment.Auto {
    public class ModelSetting : AssetPostprocessor {
        static bool autoImportSetting = false;
        void OnPreprocessModel() {

        }

        void OnPostprocessModel(GameObject gameObject) {

        }
        [MenuItem("EnjoyMoment/Auto/ModelImportSetting")]
        static void ClickButton() {
            autoImportSetting = !autoImportSetting;
            if (autoImportSetting) {
                Debug.Log("开启了自动处理Model导入设置");
            }
            else {
                Debug.Log("关闭了自动处理Model导入设置");
            }
        }
    }

}


