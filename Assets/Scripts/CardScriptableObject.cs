using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//存储卡牌信息
[CreateAssetMenu(fileName ="NewCard",menuName ="Card/NewCard")]
public class CardScriptableObject : ScriptableObject
{
    public int id;
    public Sprite cardPicture;
    public string cardName;
    public int cardAttack;
    public int cardHealth;
    public int cardCost;
}
