
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

//游戏流程
//开始游戏：加载数据、卡组洗牌、抽卡

public enum GameState
{
    GameStart,PlayerDraw,PlayerAction,EnemyDraw,EnemyAction,GameEnd
}
public class BattleManager : MonoBehaviour
{
    [Header("状态机部分")]
    private IState currentState;

    private Dictionary<GameState, IState> states = new Dictionary<GameState, IState>();

    
    public static BattleManager Instance
    {
        get; private set;
    }

    [Header("Button部分")]
    public Button drawCardButton;

    public Button playerEndTurnButton;


    [Header("玩家与敌人数据")]
    public PlayerData playerData;
    public PlayerData enemyData;


    [Header("抽牌相关")]
    public Transform cardCanvus;//画布位置，所有card需要挂在Canvus下
    public Transform playerHand;//手牌区域
    public int playerMaxCardNum;//手牌上限
    public int playerCurrentCardNum;//玩家当前手牌数量
    [Header("牌堆")]
    public List<GameObject> playerCardDeck = new List<GameObject>();//牌堆
    public List<GameObject> playerCardInHand = new List<GameObject>();//玩家手牌
    public List<GameObject> playerDiscardDeck = new List<GameObject>();//玩家弃牌堆


    private void Awake()
    {
        //单例模式
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // 否则，将自身设为实例，并保持在场景切换时不被销毁
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


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


    //抽牌函数

    public void DrawCard(int drawHowManyCard)
    {
        StartCoroutine(DrawCardCoroutine(drawHowManyCard));
    }

    private IEnumerator DrawCardCoroutine(int drawHowManyCard)
    {
        for (int i = 0; i < drawHowManyCard; i++)
        {
            if (playerCurrentCardNum < playerMaxCardNum)//没有超过手牌上限
            {
                if (playerCardDeck.Count > 0)//当卡组中还有牌
                {
                    GameObject card = Instantiate(playerCardDeck[0], new Vector3(-1161, -243, 0), Quaternion.identity, cardCanvus);//复制卡组第一张牌
                    card.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1090, 250);

                    playerCardDeck.RemoveAt(0);// 从牌堆中删去第一张
                    playerCardInHand.Add(card);//加入手牌组
                    playerCurrentCardNum++;//手牌计数+1
                    Debug.Log("抽一张牌");

                    Sequence drawAnimation = DOTween.Sequence();
                    // 使用 yield return 等待动画完成
                    yield return drawAnimation.Append(card.transform.DOMove(new Vector3(106, 544, 0), 1f)).WaitForCompletion();

                    
                }
                else
                {
                    Debug.Log("没有牌了");
                }
            }
            else
            {
                Debug.Log("抽到手牌上限了");
                break;
            }
        }
    }

    //洗牌算法
    public void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int r = Random.Range(i, list.Count);
            T temp = list[i];
            list[i] = list[r];
            list[r] = temp;
        }
    }

    public void Test()
    {

    }
}
