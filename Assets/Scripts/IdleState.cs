using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class GameStartState : IState
{
    private BattleManager manager;
    
    public GameStartState(BattleManager manager)
    {
        this.manager = manager;
    }
    public void OnEnter()
    {
        Debug.Log("��Ϸ��ʼ");
    }

    public void OnExit()
    {
        Debug.Log("�˳�gamestartState");
    }

    public void OnUpdate()
    {
        manager.TransitionState(GameState.PlayerDraw);
    }
}

public class PlayerDrawState : IState
{
    private BattleManager manager;
    private bool isDrawCardButtonClicked;

    public PlayerDrawState(BattleManager manager)
    {
        this.manager = manager;
    }
    public void OnEnter()
    {
        Debug.Log("����PlayerDrawState");
        manager.drawCardButton.onClick.AddListener(manager.DrawCard);//ΪDrawCardBtn��ӳ����¼�
        manager.drawCardButton.onClick.AddListener(drawCardButtonOnClick);//ΪDrawCardBtn��ӱ�Ƿ�ת������,����ť�������isDrawCardButtonClicked=true
        isDrawCardButtonClicked = false;
    }

    public void OnExit()
    {
        Debug.Log("�˳�PlayerDrawState");
    }

    public void OnUpdate()
    {
        if (isDrawCardButtonClicked == true)
        {
            manager.drawCardButton.onClick.RemoveAllListeners();//�Ƴ����а��¼�����ֹ������״̬�´�������
            manager.TransitionState(GameState.PlayerAction);
        }
    }

    public void drawCardButtonOnClick()
    {
        isDrawCardButtonClicked = true;
    }



}

public class PlayerActionState : IState
{
    private BattleManager manager;

    private bool isPlayerEndTurnButtonClicked;
    
    public PlayerActionState(BattleManager manager)
    {
        this.manager = manager;
    }
    public void OnEnter()
    {
        Debug.Log("����PlayerActionState");
        isPlayerEndTurnButtonClicked = false;
        manager.playerEndTurnButton.onClick.AddListener(EndTurnButtonOnClick);


    }

    public void OnExit()
    {
        Debug.Log("�˳�PlayerActionState");
    }

    public void OnUpdate()
    {
        if(isPlayerEndTurnButtonClicked == true)
        {
            manager.playerEndTurnButton.onClick.RemoveAllListeners();
            manager.TransitionState(GameState.EnemyDraw);
        }
    }

    public void EndTurnButtonOnClick()
    {
        isPlayerEndTurnButtonClicked=true;
    }
}

public class EnemyDrawState : IState
{
    private BattleManager manager;

    public EnemyDrawState(BattleManager manager)
    {
        this.manager = manager;
    }

    public void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}

public class EnemyActionState : IState
{
    private BattleManager manager;

    public EnemyActionState(BattleManager manager)
    {
        this.manager = manager;
    }

    public void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}

public class GameEndState : IState
{
    private BattleManager manager;

    public GameEndState(BattleManager manager)
    {
        this.manager = manager;
    }

    public void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}
