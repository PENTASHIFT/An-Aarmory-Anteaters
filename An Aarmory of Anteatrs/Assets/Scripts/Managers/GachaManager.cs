using System;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    [SerializeField] private GachaRates[] gachaRates;
    [SerializeField] private Transform parentCanvas, spawnPoint;
    [SerializeField] private GameObject characterCardPrefab;
    GameObject characterCard; // to save the instantiated version of the prefab
    CardBehaviour card; //HOW our card is displayed and affected on the canvas. This takes in the CardBehaviour Script which is found on the characterCardPrefab

    public void Gacha(){
        Debug.Log("Pushed button");
        if(characterCard == null){
            characterCard = Instantiate(characterCardPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
            characterCard.transform.SetParent(parentCanvas);
            // characterCard.transform.localScale = new Vector3(1, 1, 1); //don't know what this does yet
            card = characterCard.GetComponent<CardBehaviour>();

        }

        int rnd = UnityEngine.Random.Range(1,101); //we had to specify that it was the Unity Engine Random function because System also has a Random function
        for(int i = 0; i < gachaRates.Length; i++){
            if( rnd <= gachaRates[i].rate ){
                Debug.Log("Congrats! You got " + gachaRates[i].rarity);
                card.card = Reward(gachaRates[i].rarity);
                return;
            }
        }
    }

    private CardSO Reward(string rarity) {
        GachaRates gachaRate = Array.Find(gachaRates, rate => rate.rarity == rarity);
        CardSO[] rewardPool = gachaRate.rewardPool;

        int rnd = UnityEngine.Random.Range(0, rewardPool.Length);
        return rewardPool[rnd];
    }


}
