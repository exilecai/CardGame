using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//游戏流程
//开始游戏：加载数据、卡组洗牌、抽卡
//
public enum GameState
{
    GameStart,PlayerDraw,PlayerAction,EnemyDraw,EnemyAction,GameEnd
}
public class BattleManager : MonoBehaviour
{
    [Header("状态机部分")]
    private IState currentState;

    private Dictionary<GameState, IState> states = new Dictionary<GameState, IState>();

    [Header("Button部分")]
    public Button drawCardButton;

    public Button playerEndTurnButton;


    private void Start()
    {

        //初始化字典，有一个状态就要在这里注册一个,在字典的值中实例化一个状态
        states.Add(GameState.GameStart, new GameStartState(this));
        states.Add(GameState.PlayerDraw, new PlayerDrawState(this));
        states.Add(GameState.PlayerAction, new PlayerActionState(this));
        states.Add(GameState.EnemyDraw, new EnemyDrawState(this));
        states.Add(GameState.EnemyAction, new EnemyActionState(this));
        states.Add(GameState.GameEnd, new GameEndState(this));
        //设置初始状态
        TransitionState(GameState.GameStart);
    }

    private void Update()
    {
        //在Update中调用相应状态的OnUpdate()
        currentState.OnUpdate();
    }

    public void TransitionState(GameState type)//状态切换
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = states[type];//通过字典的键（枚举）来找到值（状态类）
        currentState.OnEnter();

    }

    public void DrawCard()
    {
        Debug.Log("抽两张牌");
        
    }


}
