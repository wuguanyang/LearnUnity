
using UnityEngine;


namespace EnjoyMoment {
    /// <summary>
    /// 继承monobehaviour的单例模板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MonoSingleton<T>:MonoBehaviour where T : MonoBehaviour {
        

        static T instance;
        static GameObject instanceGameObject;
        public static T Instance {
            get {
                if (instanceGameObject.GameObjectIsNull()) {
                    instance = GameObject.FindObjectOfType<T>();
                    instanceGameObject = instance.gameObject;
                    DontDestroyOnLoad(instanceGameObject);
                }         
                return instance;
            }
        }
    }
}
/*
    使用方法：在场景新建一个物体，新建一个脚本，继承这个基本即可。
    为什么不在代码新建一个物体呢？
    因为在场景新建的物体更方便调试，单例对象通常都带有一些游戏参数的设置
    不够严谨的地方就是对象的销毁处理，有可能场景切换，有些单例对象不需要存在的。
    但是我写的单例基本都是整个游戏循环都会需要用到的。
 */



