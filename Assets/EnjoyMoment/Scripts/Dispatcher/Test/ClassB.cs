using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EnjoyMoment.Test.Dispatcher {

    public class ClassB : MonoBehaviour {
        private void Start() {
            GetComponent<Button>().onClick.AddListener(() => {

                TestDispatcher.Instance.Dispatch(TestEventID.Switch);
            });
        }
    }

}

