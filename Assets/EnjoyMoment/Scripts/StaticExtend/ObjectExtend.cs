/*
CreateBy:     wgy
CreateTime:   2020/08/03 14:40:32
Description:  object对象的扩展方法
*/

using System.Diagnostics;
using System.Text;

public static class ObjectExtend
{
    ///// <summary>
    ///// 判断一个对像是否为null，比==null更快
    ///// </summary>
    ///// <param name="gameobject"></param>
    ///// <returns></returns>
    //public static bool IsNull(this object gameobject) {
    //    return ReferenceEquals(gameobject, null);// 编辑器提示简化为is null
    //}



    /// <summary>
    /// 打印日志:需要在unity编辑器添加宏定义EnableLog
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="message"></param>
    //[Conditional("EnableLog")] //发布的时候可以添加条件限制
    public static void Log(this object obj,object message) {
        UnityEngine.Debug.Log(message);
    }

    [Conditional("Debug")]
    public static void Debug(this object gameObject, params object[] message) {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < message.Length; i++) {
            sb.Append(message[i].ToString());
            if (i < message.Length - 1) {
                sb.Append(",");
            }
        }
        UnityEngine.Debug.Log(sb);
    }
}
