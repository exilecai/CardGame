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
        Debug.Log("游戏开始");
    }

    public void OnExit()
    {
        Debug.Log("退出gamestartState");
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
        Debug.Log("进入PlayerDrawState");
        manager.drawCardButton.onClick.AddListener(manager.DrawCard);//为DrawCardBtn添加抽牌事件
        manager.drawCardButton.onClick.AddListener(drawCardButtonOnClick);//为DrawCardBtn添加标记符转换函数,当按钮被点击，isDrawCardButtonClicked=true
        isDrawCardButtonClicked = false;
    }

    public void OnExit()
    {
        Debug.Log("退出PlayerDrawState");
    }

    public void OnUpdate()
    {
        if (isDrawCardButtonClicked == true)
        {
            manager.drawCardButton.onClick.RemoveAllListeners();//移除所有绑定事件、防止在其他状态下触发抽牌
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
        Debug.Log("进入PlayerActionState");
        isPlayerEndTurnButtonClicked = false;
        manager.playerEndTurnButton.onClick.AddListener(EndTurnButtonOnClick);


    }

    public void OnExit()
    {
        Debug.Log("退出PlayerActionState");
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
