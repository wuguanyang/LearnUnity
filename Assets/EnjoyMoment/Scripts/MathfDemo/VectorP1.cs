using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnjoyMoment.MathfDemo {
    public class VectorP1 : MonoBehaviour {

        public Transform A;
        public Transform B;
        void Start () {
            var result = Vector3.Dot (B.position - A.position, A.forward);
            if (result > 0) {
                Debug.Log ($"点乘结果{result}大于0,锐角,B在A的前方");
            } else {
                Debug.Log ($"点乘结果{result}小于0,钝角,B在A的后方");
            }
        }

    }
}