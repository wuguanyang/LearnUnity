/*
CreateBy:     wgy
CreateTime:   2020/08/03 16:25:12
Description:  提示消息弹窗
*/

using UnityEditor;


public class MessageBox 
{
    public static void Show(string message) {
        const string title = "MessageBox";
        const string ok = "Finish";
        EditorUtility.DisplayDialog(title,message,ok);
    }
}
