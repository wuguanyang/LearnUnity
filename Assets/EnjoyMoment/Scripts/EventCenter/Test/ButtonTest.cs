using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 点击按钮显示隐藏cube
 */

namespace EnjoyMoment.Test.EventCenter {

    using EnjoyMoment;

    public class ButtonTest : MonoBehaviour {

        private void Start() {
            GetComponent<Button>().onClick.AddListener(() => {
                EventCenter.Broadcast(EventType.CubeSwitch);
            });
        }
    }

}

