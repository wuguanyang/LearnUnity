using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataStructureAndAlgorithm {
    public class LinerSearch : MonoBehaviour {
        private void Start () {
            int[] dataSize = { 1000000, 10000000 };
            foreach (var item in dataSize) {
                int[] data = ArrayGenerator.GenerateOrderedArray (item);
                CostTimer.Run<int> (LinerSearch.Search, data, item, 1);
            }

        }

        //public static int Search<T> (T[] data, T target) where T:struct,IComparable
        /// <summary>
        /// 线性查找法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="target"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int Search<T> (T[] data, T target) {
            for (int i = 0; i < data.Length; i++) {
                // if (data[i] == target) {

                // }
                // if (System.NullReferenceException.Equals (data[i], target)) {
                //     return i;
                // }
                // if (data[i].CompareTo (target) == 0) {
                //     return i;
                // }
                if (data[i].Equals (target)) {
                    return i;
                }
            }
            return -1;
        }

        //循环不变量

    }

}