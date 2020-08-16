using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace EnjoyMoment {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <typeparam name="P">委托参数</typeparam>
    /// <typeparam name="X">事件ID或者枚举</typeparam>
    public class EventBase<T,P,X> where T : new() where P:class {

        static T instance;
        public static T Instance {
            get {
                if (instance == null) {
                    instance = new T();
                }
                return instance;
            }
        }

        //todo：为什么使用list，不使用委托的操作符：以为list移除更加方便？
        //存储事件ID 还有方法（委托）
        public Dictionary<X, List<Action<P>>> dic = new Dictionary<X, List<Action<P>>>();


        //添加事件
        public void AddEventListener(X key,Action<P> handle) {
            if (dic.ContainsKey(key)) {
                dic[key].Add(handle);
            }
            else {
                List<Action<P>> actions = new List<Action<P>>();
                actions.Add(handle);
                dic[key] = actions;
            }
        }

        //移除事件
        public void RemoveEventListener(X key, Action<P> handle) {
            if (dic.ContainsKey(key)) {
                List<Action<P>> actions = dic[key];
                actions.Remove(handle);
                if (actions.Count==0) {
                    dic.Remove(key);
                }
            }
        }


        //派发事件的接口-不带参数
        public void Dispatch(X key ,P p) {
            if (dic.ContainsKey(key)) {
                List<Action<P>> actions = dic[key];
                if (actions!=null&&actions.Count>0) {
                    foreach (var item in actions) {
                        if (item!=null) {
                            item(p);
                        }
                    }
                }
            }
        }
        
        //派发事件的接口-带参数
        public void Dispatch(X key) {
            Dispatch(key, null);
        }
    }

}


