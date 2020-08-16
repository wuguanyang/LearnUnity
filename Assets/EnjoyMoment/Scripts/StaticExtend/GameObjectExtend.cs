
using UnityEngine;

namespace EnjoyMoment {
    
    public static class GameObjectExtend {
        public static bool GameObjectIsNull(this GameObject gameObject) {
            return System.Object.ReferenceEquals(gameObject, null);
            //为什么编辑器最后简化成gameObject is null
        }
    }
}

