/*
FileName:           Copyright.cs
Created:            wgy
CreateTime:         
Description: 
*/

using System.IO;
using System.Text;
using UnityEditor;


public class Copyright : UnityEditor.AssetModificationProcessor {
    private const string AuthorName = "wgy";

    private const string DateFormat = "yyyy/MM/dd HH:mm:ss";
    private static void OnWillCreateAsset(string path) {
        path = path.Replace(".meta", "");
        if (path.EndsWith(".cs")) {
            string allText = File.ReadAllText(path);
            allText = allText.Replace("#AuthorName#", AuthorName);
            allText = allText.Replace("#CreateTime#", System.DateTime.Now.ToString(DateFormat));
            File.WriteAllText(path, allText,Encoding.UTF8);
            AssetDatabase.Refresh();
        }
    }
}
