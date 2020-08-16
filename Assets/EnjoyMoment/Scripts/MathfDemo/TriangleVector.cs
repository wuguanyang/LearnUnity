using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnjoyMoment.MathfDemo {

    public class TriangleVector : MonoBehaviour {

        Vector3 A, B, C, p1, p2, p3;
        Vector3 panelNormal;
        void Start () {
            //切割向量
            A = new Vector3 (0, -1.5f, 0); //切割的起点
            B = new Vector3 (0, 1.5f, 0);
            C = new Vector3 (0, 0, 1);
            //切割面的另外一个向量

            //三角形
            p1 = new Vector3 (-1, 0, 0);
            p2 = new Vector3 (0, 1, 0);
            p3 = new Vector3 (1, 0, 0);

            //切割向量和三角形的关系：三角形在线的左边或者右边，被切割

            //需要一个切割面的法向量
            panelNormal = Vector3.Cross (C - A, B - A);

            var result1 = Vector3.Dot (p1 - A, panelNormal);
            var result2 = Vector3.Dot (p2 - A, panelNormal);
            var result3 = Vector3.Dot (p3 - A, panelNormal);

            if (result1 > 0 && result2 > 0 && result3 > 0) {
                Debug.Log ("法线与切割点到三角形的点全是锐角,三角形在线的左边");
            } else if (result1 < 0 && result2 < 0 && result3 < 0) {
                Debug.Log ("法线与切割点到三角形的点全是钝角三角形在线的右边");
            } else {
                Debug.Log ("三角形被切割");
            }

        }

        private void OnDrawGizmos () {
            Gizmos.DrawSphere (A, 0.2f);
            Gizmos.DrawSphere (B, 0.2f);
            Gizmos.DrawSphere (C, 0.2f);
            Gizmos.DrawLine (A, B);
            Gizmos.DrawLine (A, C);

            Gizmos.DrawLine (p1, p2);
            Gizmos.DrawLine (p2, p3);
            Gizmos.DrawLine (p3, p1);

            Gizmos.DrawRay (A, panelNormal);

        }
    }
}