/*
CreateBy:     wgy
CreateTime:   2020/08/11 23:17:18
Description:  
*/

using UnityEngine;

public class Game : MonoBehaviour
{
    BaseState curState;
    StartState startState;
    GamingState gamingState;
    GameoverState gameoverState;

    void Start()
    {
        

        startState = GetComponent<StartState>();
        gamingState = GetComponent<GamingState>();
        gameoverState = GetComponent<GameoverState>();

        //设置 开始游戏状态 为当前状态
        SetCurrentState(startState);
    }

    void SetCurrentState(BaseState state) {
        curState = state;
        curState.EnterState();
    }
}
