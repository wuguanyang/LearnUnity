using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Time.timeScale = 0;
不影响update 
 */

namespace EnjoyMoment.CommonDemo {

    public class TimePauseTest : MonoBehaviour {
        
        
        void Start() {
            GetComponent<Button>().onClick.AddListener(() => {
                if (Time.timeScale != 0) {
                    Time.timeScale = 0;
                }
                else {
                    Time.timeScale = 1;
                }
                Debug.Log(Time.timeScale);
            });
        }


    }
}



