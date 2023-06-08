using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private PetrRates[] petrRates;
    [SerializeField] private Petr petrWon;
    [SerializeField] DataPersistenceManager dataPersistenceManager;
    [SerializeField] GameObject petrDisplay;
    public GameObject PlayerCurrency;

    // [SerializeField] private Transform parentCanvas, spawnPoint;
    // [SerializeField] private GameObject characterCardPrefab;
    // GameObject characterCard; // to save the instantiated version of the prefab
    // CardBehaviour card; //HOW our card is displayed and affected on the canvas. This takes in the CardBehaviour Script which is found on the characterCardPrefab

    public void Gacha(){
        Currency c = PlayerCurrency.GetComponent<Currency>();
        if (2000 < c.currency)
        {
            c.AddCurrency(-2000);

            Debug.Log("Pushed button");
            // if(characterCard == null){
            //     characterCard = Instantiate(characterCardPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
            //     characterCard.transform.SetParent(parentCanvas);
            //     // characterCard.transform.localScale = new Vector3(1, 1, 1); //don't know what this does yet
            //     card = characterCard.GetComponent<CardBehaviour>();

            // }
            Image imageToDisplay = petrDisplay.GetComponent<Image>();
            int rnd = UnityEngine.Random.Range(1,101); //we had to specify that it was the Unity Engine Random function because System also has a Random function
            for(int i = 0; i < petrRates.Length; i++){
                if( rnd <= petrRates[i].rate ){
                    Debug.Log("Congrats! You got " + petrRates[i].rarity);
                    // card.card = Reward(gachaRates[i].rarity);
                    petrWon = Reward(petrRates[i].rarity);
                    Debug.Log("Congratz! It's a " + petrWon.title);
                    imageToDisplay.sprite = petrWon.petrImage;
                    dataPersistenceManager.SaveGame();
                    petrWon = null;
                    return;
                }
            }

        }
    }

    private Petr Reward(string rarity) {
        PetrRates petrRate = Array.Find(petrRates, petrStats => petrStats.rarity == rarity);
        Petr[] rewardPool = petrRate.rewardPool;

        int rnd = UnityEngine.Random.Range(0, rewardPool.Length);
        return rewardPool[rnd];
    }

    public void LoadData(GameData gameData){
        return;
    }

    public void SaveData(GameData gameData){
        if(gameData != null){
            // Debug.Log("gameData is NULL");
            Dictionary<int, int> petrDictionary = gameData.petrDictionary;
            if(petrDictionary.ContainsKey(petrWon.id)){
                petrDictionary[petrWon.id] += 1;
            }else{
                petrDictionary.Add(petrWon.id, 1);
            }
        }
    }
}
