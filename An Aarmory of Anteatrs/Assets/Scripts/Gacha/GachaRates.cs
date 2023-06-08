using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //makes it visible in the inspector
public class GachaRates
{
    public string rarity;

    [Range(1,100)]
    public int rate;
    public CardSO[] rewardPool;
}
