/*
CreateBy:     wgy
CreateTime:   2020/08/03 21:51:48
Description:  
*/
using System;
using System.Collections.Generic;

using System.Xml.Serialization;

[Serializable]
public class XmlPerson {

    [XmlAttribute("Id")]
    public int Id { get; set; }

    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlElement("List")]
    public List<int> intList { set; get; }

    public XmlPerson() { }

    public override string ToString() {
        return $"{Id},{Name}";
    }
}
