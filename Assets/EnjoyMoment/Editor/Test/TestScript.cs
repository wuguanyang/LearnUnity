using UnityEngine;
using UnityEditor;
public class TestScript {
    [MenuItem("EnjoyMoment/编辑时测试代码",priority =1001)]
    static void TestFunctest() {
        Debug.Log("Testing Editor");
        Debug.Log(Mathf.Cos(90*Mathf.Deg2Rad)); 
        Debug.Log(Mathf.Cos(60*Mathf.Deg2Rad)); 
        Debug.Log(Mathf.Cos(45*Mathf.Deg2Rad));  
        Debug.Log(Mathf.Cos(30*Mathf.Deg2Rad));   
    }
    [MenuItem("EnjoyMoment/运行时测试代码", priority = 1002)]
    static void TestFunctestRuntime() {
        Debug.Log("Testing Runtime");
        UnityEditor.EditorApplication.isPlaying = true;

    }

    [RuntimeInitializeOnLoadMethod]
    static void Example() {
        //Debug.Log(NewBehaviourScript.Instance.gameObject.name);
    }

}
        
 
      
    