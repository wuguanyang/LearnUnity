/*
CreateBy:     wgy
CreateTime:   2020/08/03 16:37:22
Description:  
*/

using UnityEngine;
using UnityEditor;
using System;
using System.Diagnostics;
using System.IO;

public class ResourceTest : MonoBehaviour
{
    
    void Start()
    {
        //AssetBundle方式
        //AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/first");
        //GameObject obj = Instantiate(ab.LoadAsset<GameObject>("first"));

#if UNITY_EDITOR
        //AssetDatabase方式
        //Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/EnjoyMoment/Prefab/first.prefab"));
#endif


        this.Log("打印");

        var assetBundle=AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "dir"));
        Instantiate(assetBundle.LoadAsset<GameObject>("first"));



        
    }
}
