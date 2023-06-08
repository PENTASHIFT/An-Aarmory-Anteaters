using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int currency;
    public Dictionary<int, int> petrDictionary;

    public GameData(){
        this.currency = 0;
        this.petrDictionary = new Dictionary<int, int>();
    }
}
