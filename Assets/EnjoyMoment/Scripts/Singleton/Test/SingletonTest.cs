using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnjoyMoment.Test.Singleton {
    public class SingletonTest : Singleton<SingletonTest> {
        public string name = "SingletonTest";
    }
}
