using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//��Ϸ����
//��ʼ��Ϸ���������ݡ�����ϴ�ơ��鿨
//
public enum GameState
{
    GameStart,PlayerDraw,PlayerAction,EnemyDraw,EnemyAction,GameEnd
}
public class BattleManager : MonoBehaviour
{
    [Header("״̬������")]
    private IState currentState;

    private Dictionary<GameState, IState> states = new Dictionary<GameState, IState>();

    [Header("Button����")]
    public Button drawCardButton;

    public Button playerEndTurnButton;


    private void Start()
    {

        //��ʼ���ֵ䣬��һ��״̬��Ҫ������ע��һ��,���ֵ��ֵ��ʵ����һ��״̬
        states.Add(GameState.GameStart, new GameStartState(this));
        states.Add(GameState.PlayerDraw, new PlayerDrawState(this));
        states.Add(GameState.PlayerAction, new PlayerActionState(this));
        states.Add(GameState.EnemyDraw, new EnemyDrawState(this));
        states.Add(GameState.EnemyAction, new EnemyActionState(this));
        states.Add(GameState.GameEnd, new GameEndState(this));
        //���ó�ʼ״̬
        TransitionState(GameState.GameStart);
    }

    private void Update()
    {
        //��Update�е�����Ӧ״̬��OnUpdate()
        currentState.OnUpdate();
    }

    public void TransitionState(GameState type)//״̬�л�
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = states[type];//ͨ���ֵ�ļ���ö�٣����ҵ�ֵ��״̬�ࣩ
        currentState.OnEnter();

    }

    public void DrawCard()
    {
        Debug.Log("��������");
        
    }


}
