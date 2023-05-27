using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int currency;
    public Dictionary<string, int> amountOfPetrs;

    public GameData(){
        this.currency = 0;
        this.amountOfPetrs = new Dictionary<string, int>();
    }
}
