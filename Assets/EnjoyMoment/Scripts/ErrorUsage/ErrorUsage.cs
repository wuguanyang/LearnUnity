using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/*
    常见错误集锦
 */

namespace EnjoyMoment.ErrorUsage {
    
    public class ErrorUsage : MonoBehaviour {

        
        void Start() {
            TraverseListRemoveItem();
            
        }

        #region 常见错误：遍历列表的同时进行移除
        public List<int> list = new List<int>() {
            0,1,2,3,4,5,6,7,8,9
        };

        void TraverseListRemoveItem() {
            for (int i = 0; i < list.Count; i++) {
                list.Remove(list[i]);
                //list的长度改变了，需要回退下标到正确的位置
                Debug.Log(list.Count);
                i--;
            }
        }
        #endregion


    }
}

