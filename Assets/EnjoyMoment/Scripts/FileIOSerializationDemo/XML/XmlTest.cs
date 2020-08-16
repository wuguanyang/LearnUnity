/*
CreateBy:     wgy
CreateTime:   2020/08/03 20:49:35
Description:  xml序列化
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

public class XmlTest : MonoBehaviour
{
    string filePath;
    void Start()
    {
        filePath= Application.dataPath + "/EnjoyMoment/Scripts/FileIOSerializationDemo/XML/test.xml";
        //SerializeObject();
        //DeSerialize();
        //CreateXMLInMomery();

    }

    void SerializeObject() {
        XmlPerson person = new XmlPerson {
            Id = 1,
            Name = "小黑",
            intList = new List<int> { 0, 1, 2 }
        };

        FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);

        StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);


        XmlSerializer xsr = new XmlSerializer(person.GetType());
        xsr.Serialize(sw, person);

        sw.Close();
        fs.Close();

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }

    void DeSerialize() {
        FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        XmlSerializer xsr = new XmlSerializer(typeof(XmlPerson));
        XmlPerson xp=xsr.Deserialize(fs) as XmlPerson;
        this.Log(xp);
        fs.Close();


    }

    void CreateXMLInMomery() {
        //创建xmldocument
        XmlDocument xd = new XmlDocument();
        XmlDeclaration xmlDeclaration = xd.CreateXmlDeclaration("1.0", "UTF-8", null);
        xd.AppendChild(xmlDeclaration);

        //在节点中写入数据
        XmlElement root = xd.CreateElement("XMLRoot");
        XmlElement groud = xd.CreateElement("Group");
        groud.SetAttribute("username", "小黑");
        groud.SetAttribute("password", "123456");
        xd.AppendChild(root);
        root.AppendChild(groud);

        //读取节点并输出xml字符串
        using (StringWriter sw = new StringWriter ()) {
            using (XmlTextWriter xtw = new XmlTextWriter(sw)) {
                xd.WriteTo(xtw);
                xtw.Flush();
                this.Log(sw.ToString());
            }
        }

    }

}


