using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace EnjoyMoment.Test.EventCenter {
    using EnjoyMoment;
    public class CubeTest : MonoBehaviour {
        private void Start() {
            EventCenter.AddListener(EventType.CubeSwitch, Switch);
        }

        private void OnDestroy() {
            EventCenter.RemoveListener(EventType.CubeSwitch,Switch);
        }
        public void Switch() {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}




