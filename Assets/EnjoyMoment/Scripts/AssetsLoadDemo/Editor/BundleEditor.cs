/*
CreateBy:     wgy
CreateTime:   2020/08/03 15:50:43
Description:  AssetBundle打包：配合配置表使用


*/

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
//BuildAssetBundleOptions.ChunkBasedCompression 常规的压缩
//EditorUserBuildSettings.activeBuildTarget 当前的平台
public class BundleEditor 
{
    public static string ABCONFIGPATH = "Assets/Editor/ABconfig.asset";
    //key是ab包名，value是路径，所有文件夹ab包 dict
    public static Dictionary<string, string> m_AllFileDir = new Dictionary<string, string>();
    //过滤的list
    public static List<string> m_AllFileAB = new List<string>();
    //单个prefab的ab包名，以及依赖list
    public static Dictionary<string, List<string>> m_AllPrefabDir = new Dictionary<string, List<string>>();
    [MenuItem("Tools/打包配置表")]
    public static void Build() {
        m_AllFileDir.Clear();
        ABconfig abConfig = AssetDatabase.LoadAssetAtPath<ABconfig>(ABCONFIGPATH);
        foreach (var item in abConfig.m_AllFileDirAB) {

            if (m_AllFileDir.ContainsKey(item.ABName)) {
                Debug.LogError("请检查配置表,AB包配置名字重复");
            }
            else {
                m_AllFileDir.Add(item.ABName, item.Path);
                m_AllFileAB.Add(item.Path);
            }
        }
        //返回guid数组
        string[] allStr = AssetDatabase.FindAssets("t:Prefab", abConfig.m_AllPrefabPath.ToArray());
        for (int i = 0; i < allStr.Length; i++) {
            string path = AssetDatabase.GUIDToAssetPath(allStr[i]);
            EditorUtility.DisplayProgressBar("查找Prefab", "Prefab:" + path, i * 1.0f / allStr.Length);
            if (!ContainFileAB(path)) {
                GameObject obj = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                string[] allDepend = AssetDatabase.GetDependencies(path);
                List<string> allDependPath = new List<string>();
                for (int j = 0; j < allDepend.Length; j++) {
                    Debug.Log(allDepend[j]);
                    if (!ContainFileAB(allDepend[j])&&!allDepend[j].EndsWith(".cs")) {
                        m_AllFileAB.Add(allDepend[j]);
                        allDependPath.Add(allDepend[j]);
                    }
                }
                if (m_AllPrefabDir.ContainsKey(obj.name)) {
                    Debug.LogError("存在相同名字的Prefab！名字：" + obj.name);
                }
                else {
                    m_AllPrefabDir.Add(obj.name, allDependPath);
                }
            }
        }
        EditorUtility.ClearProgressBar();
       

        AssetDatabase.Refresh();
        MessageBox.Show("打包完成");
    }

    static bool ContainFileAB(string path) {
        for (int i = 0; i < m_AllFileAB.Count; i++) {
            if (path==m_AllFileAB[i]||path.Contains(m_AllFileAB[i])) {
                return true;
            }
        }
        return false;
    }




    [MenuItem("Tools/常规打包")]
    public static void UnityBuild() {
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.ChunkBasedCompression, EditorUserBuildSettings.activeBuildTarget);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        
        MessageBox.Show("打包");
    }

}
