using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

//读取卡牌信息SO，并实际挂载到Panel上的脚本
public class CardCreator : MonoBehaviour

{
    public Image cardPicture;
    public TextMeshProUGUI cardName;

    public TextMeshProUGUI cardAttack;
    public TextMeshProUGUI cardHealth;
    public TextMeshProUGUI cardCost;

    public CardScriptableObject cardScriptableObject;
    private void Start()
    {
        CardReadSO();
    }

    public void CardReadSO()
    {
        this.cardPicture.sprite = cardScriptableObject.cardPicture;
        this.cardName.text = cardScriptableObject.cardName;
        this.cardAttack.text=cardScriptableObject.cardAttack.ToString();
        this.cardHealth.text=cardScriptableObject.cardHealth.ToString();
        this.cardCost.text=cardScriptableObject.cardCost.ToString();    


    }
}
