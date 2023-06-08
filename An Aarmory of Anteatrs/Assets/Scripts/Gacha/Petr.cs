using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Petr", menuName = "Scriptable Petr")]
public class Petr : ScriptableObject
{

    //maybe add id 
    [Header("Only UI")]
    public Sprite petrImage;
    public Rarity rarity;
    public string title;

    public string subtitle;

    public int id;

}

public enum Rarity {
    Common,
    Uncommon,
    Rare,
    UltraRare,
    Legend
}
