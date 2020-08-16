/*
CreateBy:     wgy
CreateTime:   2020/08/03 22:11:02
Description:  
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
public class BinaryTest : MonoBehaviour {
    string filePath;
    void Start() {
        filePath = Application.dataPath + "/EnjoyMoment/Scripts/FileIOSerializationDemo/Binary/test.bytes";

        //Serialize();

        DeSerialize();
    }

    void Serialize() {
        BinaryPerson person = new BinaryPerson {
            Id = 1,
            Name = "小黑",
            intList = new List<int> { 0, 1, 2 }
        };

        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite)) {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, person);
        }
        AssetDatabase.Refresh();

    }

    void DeSerialize() {
        TextAsset ta = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets" + "/EnjoyMoment/Scripts/FileIOSerializationDemo/Binary/test.bytes");
        MemoryStream ms = new MemoryStream(ta.bytes);
        BinaryFormatter bf = new BinaryFormatter();
        BinaryPerson bp = (BinaryPerson)bf.Deserialize(ms);
        ms.Close();
        this.Log(bp);


    }
}
#endif

[Serializable]
public class BinaryPerson {

    
    public int Id { get; set; }

    
    public string Name { get; set; }

    
    public List<int> intList { set; get; }

    public BinaryPerson() { }

    public override string ToString() {
        return $"{Id},{Name}";
    }
}
