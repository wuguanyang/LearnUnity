using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnjoyMoment.MathfDemo {

    public class RotateDir : MonoBehaviour {

        Vector3 dir1 = Vector3.zero;// 向量Vector.Up顺时针旋转30度
        Vector3 dir2 = Vector3.zero;// 向量Vector.Up顺时针旋转60度
        Vector3 dir3 = Vector3.zero;// 向量Vector.Up顺时针旋转120度
        Vector3 dir4 = Vector3.zero;// 向量Vector.Up顺时针旋转240度
        Vector3 dir5 = Vector3.zero;// 向量Vector.Up逆时针针旋转30度
        void Start () {
            //拆分向量，向量*长度
            dir1 = Vector3.up * Mathf.Cos (30 * Mathf.Deg2Rad) + Vector3.right * Mathf.Sin (30 * Mathf.Deg2Rad);
            dir2 = Vector3.up * Mathf.Cos (60 * Mathf.Deg2Rad) + Vector3.right * Mathf.Sin (60 * Mathf.Deg2Rad);
            dir3 = Vector3.up * Mathf.Cos (120 * Mathf.Deg2Rad) + Vector3.right * Mathf.Sin (120 * Mathf.Deg2Rad);
            dir4 = Vector3.up * Mathf.Cos (240 * Mathf.Deg2Rad) + Vector3.right * Mathf.Sin (240 * Mathf.Deg2Rad);
            dir5 = Vector3.up * Mathf.Cos (-30 * Mathf.Deg2Rad) + Vector3.right * Mathf.Sin (-30 * Mathf.Deg2Rad);
            Debug.Log ($"{dir1},{dir2},{dir3}");
        }
        private void OnDrawGizmos () {
            if (dir1 == Vector3.zero) {
                return;
            }
            Gizmos.DrawRay (Vector3.zero, Vector3.up);
            Gizmos.DrawRay (Vector3.zero, Vector3.right);
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay (Vector3.zero, dir1);
            Gizmos.DrawRay (Vector3.zero, dir2);
            Gizmos.DrawRay (Vector3.zero, dir3);
            Gizmos.DrawRay (Vector3.zero, dir4);
            Gizmos.DrawRay (Vector3.zero, dir5);
        }
    }
}