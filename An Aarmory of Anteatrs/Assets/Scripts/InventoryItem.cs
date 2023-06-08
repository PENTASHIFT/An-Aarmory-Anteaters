using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Petr petr;
    public Sprite newImage;
    private Image imageComponent;
    
    // private void InitializePetr(){
    //     if(this.mage.sprite == null){
    //         Debug.LogWarning("Cannot find image for petr!");
    //     }
        
    // }

    private void Awake(){
        imageComponent = GetComponent<Image>();
        newImage = petr.petrImage;
        imageComponent.sprite = newImage;
    }

    public void SetPetr(Petr petr){
        // imageComponent = GetComponent<Image>();
        this.petr = petr;
        imageComponent.sprite = petr.petrImage;
    }
}
