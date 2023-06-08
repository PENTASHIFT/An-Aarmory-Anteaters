using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class CardSO : ScriptableObject
{
    public Sprite characterImg;
    public string characterName;
}
