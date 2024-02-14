using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�洢������Ϣ
[CreateAssetMenu(fileName ="NewCard",menuName ="Card/NewCard")]
public class CardScriptableObject : ScriptableObject
{
    
    public Sprite cardPicture;
    public string cardName;
    public int cardAttack;
    public int cardHealth;
    public int cardCost;
}
