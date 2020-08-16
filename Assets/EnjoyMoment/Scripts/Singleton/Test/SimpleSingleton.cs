
using UnityEngine;
namespace EnjoyMoment.Test.Singleton {
    public class SimpleSingleton : MonoBehaviour {
        public static SimpleSingleton Instance;

        private void Awake() {
            Instance = this;
        }
    }
}

