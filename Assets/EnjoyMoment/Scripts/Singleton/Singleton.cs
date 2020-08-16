using System;
using System.Reflection;

namespace EnjoyMoment {
    /// <summary>
    /// 普通单例脚本模板
    /// </summary>
    /// <typeparam name="T">约束T：带有无参构造函数，可以n使用ew（）</typeparam>
    public class Singleton<T> where T : new() {

        static T instance;
        public static T Instance {
            get {
                if (instance == null) {
                    instance = new T();//因为约束了new（）,所以可以new构造,default 因为只能是class，所以就不用default了
                }
                return instance;
            }            
        }
    }
}
////还有一种反射的写法就是不需要约束new，但是反射太麻烦了，要获取构这个类型的造函数数组，根据条件，获得参数0的构造
//if (instance == null) {
//    var ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
//    var ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
//    if (ctor == null) {
//        throw new Exception("Non-public ctor() not found!");
//    }
//    instance = ctor.Invoke(null) as T;
//}
