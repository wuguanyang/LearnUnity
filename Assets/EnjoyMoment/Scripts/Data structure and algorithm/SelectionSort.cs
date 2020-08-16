using System;
using UnityEngine;

namespace DataStructureAndAlgorithm {
    /// <summary>
    /// 选择排序：数组（0，i，n）被划分为 有序的（0-i）-无序的（i-n）
    /// 每次内循环都选择最小/大的交换位置
    /// 如果忘记了思路，通常可以先写内循环的找到当前区间的最小下标，再完成外循环的次数。完成排序
    /// 复杂度：数据的大小n，两个循环n^2
    /// </summary>
    public class SelectionSort : MonoBehaviour {

        void Start () {
            //生成无序int的数组，大小100，范围100000
            int[] arr = ArrayGenerator.GenerateRandomArray (100, 100000);

            //Sort<int>(arr);
            CostTimer.Run<int> (Sort, arr, 1);

        }
        //选择排序
        void Sort<T> (T[] data) where T : IComparable {
            for (int i = 0; i < data.Length; i++) {
                int minIndex = i;
                for (int j = i; j < data.Length; j++) {
                    if (data[j].CompareTo (data[minIndex]) < 0) {
                        minIndex = j;
                    }
                }
                T temp = data[i];
                data[i] = data[minIndex];
                data[minIndex] = temp;
            }
        }
        void SortInserve<T> (T[] data) where T : IComparable {
            //先排后面的
            for (int i = data.Length - 1; i >= 0; i--) {
                int maxIndex = i;
                for (int j = i; j >= 0; j--) {
                    if (data[j].CompareTo (data[maxIndex]) > 0) {
                        maxIndex = j;
                    }
                }
                T temp = data[i];
                data[i] = data[maxIndex];
                data[maxIndex] = temp;
            }
        }

    }
}