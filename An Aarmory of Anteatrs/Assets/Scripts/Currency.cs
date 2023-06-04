using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour, IDataPersistence
{
    private int currency = 0;
    public TextMeshProUGUI currencyText;

    private void Awake(){
        currencyText = this.GetComponent<TextMeshProUGUI>();
    }

    public void LoadData(GameData gameData){
        this.currency = gameData.currency;
    }

    public void SaveData(GameData gameData){
        gameData.currency = this.currency;
    }

    void Update()
    {
        currencyText.text = "" + currency;
    }

    public void AddCurrency(){
        currency += 10;
    }
}
