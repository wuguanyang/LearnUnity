using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EnjoyMoment.MathfDemo {

    public class PointTriangle : MonoBehaviour {

        Vector3 P1 = Vector3.left;
        Vector3 p2 = Vector3.right;
        Vector3 p3 = Vector3.up;
        Vector3 point = new Vector3 (-1f,1f);//(-1f,1f)(-0.5f, 0.3f)

        void Start () {
            var result1 = Vector3.Cross (P1 - point, p3 - P1).normalized;
            var result2 = Vector3.Cross (p3 - point, p2 - p3).normalized;
            var result3 = Vector3.Cross (p2 - point, P1 - p3).normalized;
            Debug.Log ($"{result1},{result2},{result3}");
            if (Vector3.Dot(result1,result2)*Vector3.Dot(result3,result2)<0) {
                Debug.Log ("point在三角形外");
            } else {
                Debug.Log ("point在三角形内");
            }
        }

        private void OnDrawGizmos () {
            Gizmos.DrawSphere (P1, 0.2f);
            Gizmos.DrawSphere (p2, 0.2f);
            Gizmos.DrawSphere (p3, 0.2f);
            Gizmos.DrawSphere (point, 0.2f);
            Gizmos.DrawLine (P1, p3);
            Gizmos.DrawLine (p3, p2);
            Gizmos.DrawLine (p2, P1);
        }
    }
}