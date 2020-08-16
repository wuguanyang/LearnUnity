/*
CreateBy:     wgy
CreateTime:   2020/08/04 17:47:43
Description:  ScriptableObject 转 asset文件，可以作为配置文件放置resource
*/

using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

//右键菜单，在选定的目录创建文件

//[CreateAssetMenu(fileName ="PersonData",menuName ="CreatPersonData",order =0)]
public class PersonData : ScriptableObject
{
    public int id;
    public string name;
    public List<string> books;
    
}
