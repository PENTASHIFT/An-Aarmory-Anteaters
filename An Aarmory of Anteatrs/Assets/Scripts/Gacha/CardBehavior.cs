using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardBehaviour : MonoBehaviour
{
    public CardSO card;
    [SerializeField] private Image cardImg;
    [SerializeField] private TextMeshProUGUI cardName;

    // Start is called before the first frame update
    void RefreshCard()
    {
        if(card != null){

            cardImg.sprite = card.characterImg;
            cardName.text = card.characterName;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        RefreshCard();
    }
}
