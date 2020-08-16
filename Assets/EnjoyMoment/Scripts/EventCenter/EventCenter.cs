using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
/*
    缺点就是一个事件类型只能对应一种callback
    比如事件A只能对应无参数callback的链式叠加
 */
namespace EnjoyMoment {
   
    public class EventCenter {
        //为什么使用delegate(基类)，不直接使用Callback,因为需要支持不同的CallBcak<T，T1>的参数
        static Dictionary<EventType, Delegate> eventDict = new Dictionary<EventType, Delegate>();

        #region 添加监听
        public static void AddListenerSub(EventType eventType, Delegate callBack) {
            if (!eventDict.ContainsKey(eventType)) {
                eventDict.Add(eventType, null);
            }
            Delegate d = eventDict[eventType];
            if (d != null && d.GetType() != callBack.GetType()) {
                throw new Exception($"尝试为事件{eventType}添加不同类型的委托，当前事件的委托是{d.GetType()}，要添加的委托类型是{callBack.GetType()}");
            }
        }
        public static void AddListener(EventType eventType, CallBack callBack) {

            AddListenerSub(eventType, callBack);
            eventDict[eventType] = (CallBack)eventDict[eventType] + callBack;
        }
        public static void AddListener<T>(EventType eventType, CallBack<T> callBack) {
            AddListenerSub(eventType, callBack);
            eventDict[eventType] = (CallBack<T>)eventDict[eventType] + callBack;
        }
        #endregion


        #region 移除监听
        public static void RemoveListenerSub(EventType eventType, Delegate callBack) {
            //错误处理
            if (eventDict.ContainsKey(eventType)) {
                Delegate d = eventDict[eventType];
                if (d == null) {
                    throw new Exception($"移除监听错误：事件{eventType}没有对应的委托");
                }
                else if (d.GetType() != callBack.GetType()) {
                    throw new Exception($"移除监听错误：尝试为事件{eventType}移除不同类型的委托，当前委托类型为{d.GetType()}，要移除的委托类型为{callBack.GetType()}");
                }
            }
            else {
                throw new Exception($"移除监听错误：没有事件{eventType}");
            }
        }
        public static void Remove(EventType eventType) {
            if (eventDict[eventType] == null) {
                eventDict.Remove(eventType);
            }
        }
        public static void RemoveListener(EventType eventType, CallBack callBack) {
            RemoveListenerSub(eventType, callBack);
            //移除监听
            eventDict[eventType] = (CallBack)eventDict[eventType] - callBack;
            Remove(eventType);
        }
        public static void RemoveListener<T>(EventType eventType, CallBack<T> callBack) {
            RemoveListenerSub(eventType, callBack);
            //移除监听
            eventDict[eventType] = (CallBack<T>)eventDict[eventType] - callBack;
            Remove(eventType);
        }
        #endregion


        #region 广播事件
        public static void Broadcast(EventType eventType) {
            Delegate d;
            if (eventDict.TryGetValue(eventType, out d)) {
                CallBack callBack = d as CallBack;
                if (callBack != null) {
                    callBack();
                }
                else {
                    throw new Exception($"广播事件错误：事件{eventType}对应的委托具有不同的类型");
                }
            }
        }
        public static void Broadcast<T>(EventType eventType, T arg) {
            Delegate d;
            if (eventDict.TryGetValue(eventType, out d)) {
                CallBack<T> callBack = d as CallBack<T>;
                if (callBack != null) {
                    callBack(arg);
                }
                else {
                    throw new Exception($"广播事件错误：事件{eventType}对应的委托具有不同的类型");
                }
            }
        }
        #endregion
    }
}

//这种是不满足需求的，不好扩展。并且一个枚举应该存放一个类型的东西
//需要使用多个枚举

