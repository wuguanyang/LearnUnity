using System;
using UnityEngine;

/// <summary>
/// 如果数据是有序的，插入排序更好
/// 插入排序：0-i(有序)i-n（无序）
/// 内循环：不断比较交换位置，直到循环结束
/// </summary>
namespace DataStructureAndAlgorithm {
    public class InsertionSort : MonoBehaviour {
        // Start is called before the first frame update
        void Start () {
            int[] arr = ArrayGenerator.GenerateRandomArray (10, 100);
            CostTimer.Run<int> (Sort3, arr, 1);
            foreach (var item in arr) {
                Debug.Log (item);
            }
        }
        void Sort<T> (T[] arr) where T : IComparable {
            for (int i = 1; i < arr.Length; i++) {
                for (int j = i; j > 0; j--) {
                    if (arr[j - 1].CompareTo (arr[j]) > 0) {
                        var temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    } else {
                        break;
                    }
                }
            }
        }

        //优化 交换操作改成平移：记录临时变量
        void Sort2<T> (T[] arr) where T : IComparable {
            for (int i = 1; i < arr.Length; i++) {
                T t = arr[i];
                for (int j = i; j > 0; j--) {
                    if (arr[j - 1].CompareTo (t) > 0) {
                        arr[j] = arr[j - 1];
                    } else {
                        arr[j] = t;
                        break;
                    }
                }
            }
        }

        //0-i无序，i-n有序
        void Sort3<T> (T[] arr) where T : IComparable {
            for (int i = arr.Length - 2; i >= 0; i--) {
                T t = arr[i];
                for (int j = i; j < arr.Length - 1; j++) {
                    if (arr[j + 1].CompareTo (t) < 0) {
                        arr[j] = arr[j + 1];
                    } else {
                        arr[j] = t;
                        break;
                    }
                }
            }
        }

    }
}