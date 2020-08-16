/*
CreateBy:     wgy
CreateTime:   2020/08/11 23:18:48
Description:  
*/

using UnityEngine;

public class BaseState : MonoBehaviour
{

    //进入状态的时候

    public virtual void EnterState() {

    }
    //停留在这个状态
    public virtual void StayState() {

    }
    //离开这个状态
    public virtual void ExitState() {

    }

}
