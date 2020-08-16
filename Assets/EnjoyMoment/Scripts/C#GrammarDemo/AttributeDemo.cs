/*
CreateBy:     wgy
CreateTime:   2020/08/03 14:57:45
Description:  测试自定义特性
*/


using System;
using UnityEngine;

public class AttributeDemo : MonoBehaviour
{
    
    void Start()
    {
        //通过反射拿到自定义特性的信息
        System.Reflection.MemberInfo info = typeof(TestClass);
        object[] attributes = info.GetCustomAttributes(true);
        for (int i = 0; i < attributes.Length; i++) {
            Debug.Log(attributes[i]);
        }

        Type type = typeof(TestClass);
        // 遍历 Rectangle 类的特性
        foreach (object item in type.GetCustomAttributes(false)) {
            HelpAttribute help = (HelpAttribute)item;
            if (null != help) {
                Debug.Log(help.Desciption);//直接访问特性的属性就好
            }
        }

    }

}
