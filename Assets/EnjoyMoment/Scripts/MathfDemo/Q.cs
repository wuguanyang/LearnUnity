using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 使用四元素旋转向量
/// </summary>
namespace EnjoyMoment.MathfDemo {
    public class Q : MonoBehaviour {

        private void OnDrawGizmos () {
            var vector3 = new Vector3 (1, 0, 0);
            var result = Quaternion.AngleAxis (90, Vector3.up) * vector3; //四元素要写在左边，unity是矩阵左乘
            Gizmos.DrawRay (Vector3.zero, Vector3.up);
            Gizmos.DrawRay (Vector3.zero, Vector3.right);
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay (Vector3.zero, vector3);
            Gizmos.DrawRay (Vector3.zero, result);

        }
    }
}