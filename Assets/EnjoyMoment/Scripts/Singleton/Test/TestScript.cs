using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EnjoyMoment.Test.Singleton {

    public class TestScript : MonoBehaviour {

        void Start() {
            Debug.Log(MonoSingletonTest.Instance.name); 
            Debug.Log(SingletonTest.Instance.name);
        }
    }
}










