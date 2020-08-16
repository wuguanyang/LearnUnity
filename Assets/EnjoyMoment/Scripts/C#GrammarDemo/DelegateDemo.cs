using System;
using UnityEngine;

/*
 关于c#语法的应用
       delegate（c#1.0），Action（void）,Func（return）(c#自定义的委托)
       匿名函数（c#2.0），
       Lambda  （c#3.0）
        
    实际都是Delegate类型
 */






namespace EnjoyMoment.GrammerDemo {
    public class DelegateDemo : MonoBehaviour {

        //委托的使用:需要//定义委托//声明委托
        //匿名方法和lambda不用定义和声明，编译会自动创建（Delegate类型）IL代码。
        //因为没有声明，所以无法-=。不过可以用另外的同类委托存储引用,再-=就好
        delegate void TestDelegate();
        TestDelegate test;
        void Foo() { }


        delegate int TestIntDelegate(int x);
        TestIntDelegate testInt;
        int Bar(int x) {
            Debug.Log(x);    
            return x;
        }

        //Action的使用:直接声明
        Action a;
        Action<int> aInt;

        //Func的使用：直接声明,最后一个是返回值
        Func<int, int> fInt;
        Func<int, int> fooInt;

        void Start() {
            test = Foo;
            test();

            //匿名函数的使用
            test += delegate () { Debug.Log("匿名方法"); };
            //lambda表达式
            test += () => { Debug.Log("lambda"); };
            test += () => Debug.Log("lambda");
            //Action
            a += () => Debug.Log("action");
            aInt += (x) => Debug.Log("带参数action");
            test();

            //Func
            fooInt = Bar;
            fInt += fooInt;
            fInt -= fooInt;
            fInt += (x) => { return x; };
            fInt(1);
            //带参数的Delegate
            testInt += Bar;
            testInt += (x) => x;
            testInt(1);
        }

    }
}

