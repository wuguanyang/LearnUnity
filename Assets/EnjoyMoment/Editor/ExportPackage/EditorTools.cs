
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

namespace EnjoyMoment {
    public class EditorTools
    {
        [MenuItem("EnjoyMoment/导出EnjoyMomentPackage")]
        public static void ExportPackage()
        {
            //要打包的文件路径
            string assetPathName = "Assets/EnjoyMoment";
            //打包完成的文件命名
            string fileName = "EnjoyMoment" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm") + ".unitypackage";


            //导出unitypackage
            AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);

            var url = Path.Combine(Application.dataPath, "../");
            //打开文件夹
            Application.OpenURL("file://" + url);

            Debug.Log("导出EnjoyMomentPackage");
        }
        //TODO 重启当前项目应该怎么写？
        //[MenuItem("EnjoyMoment/ReopenProject")]
        //static void ReopenProject() {  
        //    EditorApplication.Exit(0);
        //    EditorApplication.OpenProject(Application.dataPath, "Assets", string.Empty);
        //}
    }
}

