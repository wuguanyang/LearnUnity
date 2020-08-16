using System;

namespace DataStructureAndAlgorithm {

}
public class SortingHelper {
    private SortingHelper () { }

    /// <summary>
    /// 判断数组是否从小到大排序
    /// </summary>
    /// <param name="arr"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool IsSorted<T> (T[] arr) where T : IComparable {
        for (int i = 1; i < arr.Length; i++) {
            if (arr[i - 1].CompareTo (arr[i]) > 0) {
                return false;
            }
        }
        return true;
    }
}