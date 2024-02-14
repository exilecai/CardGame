using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//¥Ê¥¢ø®≈∆–≈œ¢
[CreateAssetMenu(fileName ="NewCard",menuName ="Card/NewCard")]
public class CardScriptableObject : ScriptableObject
{
    
    public Sprite cardPicture;
    public string cardName;
    public int cardAttack;
    public int cardHealth;
    public int cardCost;
}
