/*
CreateBy:     wgy
CreateTime:   2020/08/03 14:40:32
Description:  创建自定义特性demo
*/

using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class HelpAttribute : Attribute {

    protected string description;
    public string Desciption {
        get {
            return this.description;
        }
    }

    public HelpAttribute(string description_in) {
        this.description = description_in;
    }

}

[Help("this is a do-nothing class")]//可以通过反射来拿到这些信息
public class TestClass { }

