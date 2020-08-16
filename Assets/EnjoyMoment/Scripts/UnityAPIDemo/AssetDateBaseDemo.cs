/*
CreateBy:     wgy
CreateTime:   2020/08/05 18:35:21
Description:  AssetDateBase常用API
*/

using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
public class AssetDateBaseDemo : MonoBehaviour
{
    
    void Start()
    {
        AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameDate/Prefab/first/first.prefab");
        
        string[] allStr = AssetDatabase.FindAssets("t:Prefab");
    }
}
#endif
