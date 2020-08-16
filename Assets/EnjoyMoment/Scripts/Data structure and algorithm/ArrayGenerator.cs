using System;

namespace DataStructureAndAlgorithm {
    public class ArrayGenerator {
        private ArrayGenerator () { }

        public static int[] GenerateOrderedArray (int n) {
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++) {
                arr[i] = i;
            }
            return arr;
        }
        public static int[] GenerateRandomArray (int n, int bound) {
            int[] arr = new int[n];
            Random rand = new Random ();
            for (int i = 0; i < arr.Length; i++) {
                arr[i] = rand.Next (bound);
            }
            return arr;
        }
    }
}