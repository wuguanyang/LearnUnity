using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnjoyMoment.Test.Dispatcher {
    
    public class ClassA : MonoBehaviour {

        private void Start() {
            TestDispatcher.Instance.AddEventListener(TestEventID.Switch, Switch);
        }
        public void Switch(string obj) {
            gameObject.SetActive(!gameObject.activeSelf);
        }
        private void OnDestroy() {
            TestDispatcher.Instance.RemoveEventListener(TestEventID.Switch, Switch);
        }

    }

}

