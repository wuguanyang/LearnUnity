using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataStructureAndAlgorithm {
    /// <summary>
    /// 计算方法运行消耗的时间
    /// </summary>
    public class CostTimer {
        public delegate int DTSearch<T> (T[] data, T target);
        public delegate void DSearch<T> (T[] data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mothed">方法</param>
        /// <param name="data">数组</param>
        /// <param name="target">查找的目标</param>
        /// <param name="count">循环的次数</param>
        /// <typeparam name="T"></typeparam>
        public static void Run<T> (DTSearch<T> mothed, T[] data, T target, int count) where T : IComparable {
            DateTime beforeDT = System.DateTime.Now;
            for (int i = 0; i < count; i++) {
                mothed (data, target);
            }
            DateTime afterDT = System.DateTime.Now;
            TimeSpan ts = afterDT.Subtract (beforeDT);
            Debug.Log ($"{target}DateTime costed for Shuffle function is: {ts.TotalSeconds}s");
            Debug.Log (SortingHelper.IsSorted<T> (data));
        }
        public static void Run<T> (DSearch<T> mothed, T[] data, int count) where T : IComparable {
            DateTime beforeDT = System.DateTime.Now;
            for (int i = 0; i < count; i++) {
                mothed (data);
            }
            DateTime afterDT = System.DateTime.Now;
            TimeSpan ts = afterDT.Subtract (beforeDT);
            Debug.Log ($"DateTime costed for Shuffle function is: {ts.TotalSeconds}s");
            Debug.Log (SortingHelper.IsSorted<T> (data));
        }
    }
}