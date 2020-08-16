using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 两帧之间的差
 */

namespace EnjoyMoment.CommonDemo {
    public class FrameTime : MonoBehaviour {
       
        float preFrame=0f;//上一帧 游戏运行的时间
        void Update() {
            if (preFrame == 0f) {
                preFrame = Time.realtimeSinceStartup;
            }
            else {
                var delta = Time.realtimeSinceStartup - preFrame;
                Debug.Log($"{delta}****{Time.deltaTime}");
                preFrame = Time.realtimeSinceStartup;
            } 
        }
    }
}

