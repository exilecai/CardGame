using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData :MonoBehaviour
{
    public Dictionary<int ,int> playerDeck=new Dictionary<int ,int>();//键为卡牌id，值为卡组数量

    private void Awake()
    {
        //test部分
        playerDeck.Add(1, 4);
        playerDeck.Add(2, 7);

    }

   
}
