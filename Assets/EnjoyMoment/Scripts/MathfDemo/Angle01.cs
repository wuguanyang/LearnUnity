using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Vector3.Angle的结果只能是0-180
先要判断dir2在dir1的正面还是背面？
先要判断dir2在dir1的左边还是右边？
先要判断dir1到dir2是顺时针还是逆时针？
 
 
 */
namespace EnjoyMoment.MathfDemo {
    public class Angle01 : MonoBehaviour {



        Vector3 dir1 = Vector3.up;
        Vector3 dir2 = new Vector3(1, -1, 0);
        void Start() {
            float angle = Vector3.Angle(dir1, dir2);
            if (dir2.normalized.y<0) {
                angle = -angle;
            }
            Debug.Log(angle);
        }


        void Update() {
            Debug.DrawRay(Vector3.zero, dir1, Color.red);
            Debug.DrawRay(Vector3.zero, dir2, Color.green);
        }
    }

}

