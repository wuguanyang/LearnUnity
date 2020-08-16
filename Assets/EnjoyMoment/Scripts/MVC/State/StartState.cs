/*
CreateBy:     wgy
CreateTime:   2020/08/11 23:19:19
Description:  
*/

using UnityEngine;

public class StartState : BaseState {

    public override void EnterState() {
        //进入这个状态的时候，显示首页

        View.Instance.ShowStartPanel();

    }
}
