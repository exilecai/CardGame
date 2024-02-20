using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance
    {
        get; private set;
    }
    // 在Awake方法中初始化实例，并保持在场景切换时不被销毁
    private void Awake()
    {
        // 如果已经有实例，就销毁自身并返回
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // 否则，将自身设为实例，并保持在场景切换时不被销毁
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    
    public List<GameObject> LoadDeck(Dictionary<int, int> playerDeck)//加载卡组函数
    {
        List<GameObject> cardList = new List<GameObject>();

        // 遍历字典
        foreach (KeyValuePair<int, int> keyValuePair in playerDeck)
        {
            int cardId = keyValuePair.Key;
            int cardCount = keyValuePair.Value;

            // 按照卡牌数量创建卡牌实例并添加到列表中
            for (int i = 0; i < cardCount; i++)
            {        
                cardList.Add(Resources.Load<GameObject>("Prefabs/Cards/" + cardId));
            }
        }

        return cardList;
    }
}
