/*
CreateBy:     wgy
CreateTime:   2020/08/04 23:14:56
Description:  ab包配置表
*/

using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="ABconfig",menuName ="CreatABconfig",order =0)]
public class ABconfig : ScriptableObject
{
    public List<string> m_AllPrefabPath;
    public List<FileDirABName> m_AllFileDirAB;
    [Serializable]
    public struct FileDirABName {
        public string ABName;
        public string Path;
    }

  
}
