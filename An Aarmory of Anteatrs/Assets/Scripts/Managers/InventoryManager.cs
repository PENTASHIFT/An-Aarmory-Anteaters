using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour, IDataPersistence
{
    //IMPORTANT when you come back
    //Make slots a prefab
    public GameObject[] inventorySlots;
    // public GameObject inventoryItemPrefab;
    public Dictionary<int, int> petrsDictionary;
    public Petr[] everyPetr;
    
    void Start()
    {
        displayInventory();
    }

    //gacha manager will be calling AddPetr() whenever the player Gachas and gets another petr.
    public bool AddPetr(Petr petr){
        //checks if there is any empty inventory space to add new petr
        //if there is not, this function does nothing but return false
        //separate functionality? Do we want to run code and spawn every time we open the inventory? or do we always want
        //objects to be present but hidden?
        //We will go with UI code ran On-Demand, so we are separating
        petrsDictionary[petr.id] += 1;
        for(int i = 0; i < inventorySlots.Length; i++){
            GameObject slot = inventorySlots[i];
            // GameObject item = slot.GetComponentInChildren<GameObject>();
            Image item = slot.GetComponent<Image>();
            if(item.sprite == null){
                SpawnNewPetr(petr, slot);
                return true;
            }
        }
        return false;

    }

    public void displayInventory(){
        Petr petr;
        foreach(KeyValuePair<int, int> kvp in petrsDictionary){
            petr = getPetrById(kvp.Key);
            for(int i = 0; i < kvp.Value; i++){
                for(int j = 0; j < inventorySlots.Length; j++){
                    GameObject slot = inventorySlots[j];
                    Image item = slot.GetComponent<Image>();
                    if(item.sprite == null) {
                        SpawnNewPetr(petr, slot);
                        break;
                    }
                }
            }
        }
    }

    public Petr getPetrById(int id){
        for(int i = 0; i < everyPetr.Length; i++){
            Petr currentPetr = everyPetr[i];
            if(currentPetr != null && currentPetr.id == id ){
                return currentPetr;
            }
        }
        return null;
    }

    //updating Inventory when we delete or reload an already loaded inventory is gonna be tricky
    //maybe preserve a bool that tells whether you have already cached the inventory,
    //and you only update the inventory when a change happens, like you add a new petr or trade 2 in.
    // public bool DeletePetr() - affects amountCounter

    private void SpawnNewPetr(Petr petr, GameObject slot){
        // GameObject obj = Instantiate(inventoryItemPrefab, slot.transform);
        // Image item = obj.GetComponent<Image>();
        // item.SetPetr(petr);
        Image item = slot.GetComponent<Image>();
        item.enabled = true;
        item.sprite = petr.petrImage;
    }

    public void DeletePetrInSlot(GameObject slotToDelete){
        GameObject slot = slotToDelete;
        Image petrInSlot = slot.GetComponent<Image>();
        if(petrInSlot != null){
            Destroy(petrInSlot); 
        }
    }

    public void LoadData(GameData gameData){
        this.petrsDictionary = gameData.petrDictionary;
    }

    public void SaveData(GameData gameData){
        gameData.petrDictionary = this.petrsDictionary;
    }
}
