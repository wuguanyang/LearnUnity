/*
    EventCenter
    不同参数个数的委托 
    这边也可以使用c#封装好的action，不过action最大支持4个参数
 */

namespace EnjoyMoment {
    public delegate void CallBack();
    public delegate void CallBack<T>(T arg);
    public delegate void CallBack<T1, T2>(T1 arg1, T2 arg2);
    public delegate void CallBack<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);
    //todo 没有完成2,3个参数的监听的移除监听和广播
}


