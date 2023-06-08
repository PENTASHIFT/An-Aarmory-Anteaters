using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventory;
    //down below is an array is filled out with all possible petrs that can possibly be attained
    public Petr[] petrsToAdd;

    public void AddPetrToInventory(int index, int amount){
        Petr petrToAdd = petrsToAdd[index];
        bool res = inventory.AddPetr(petrToAdd);
        if(res){
            Debug.Log("Petr added to inventory");
        }else{
            Debug.Log("Petr NOT ADDED to inventory");
        }

    }
}
