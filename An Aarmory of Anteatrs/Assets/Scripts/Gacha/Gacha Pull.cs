using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaPull : MonoBehaviour
{
    //get Instance of Joshua's Currency Container Class

    public void PullGacha(){
        if(hasEnoughCurrency()){
            //do the animation
            //Do Henry's complex genius math stuff to pull a Random number
            //Display the image associated with the random number and go back to Gacha screen
            //update Player's stats accordingly( handle duplicates, achievements with new petrs )
            //(Bonus) Maybe add a summary screen of all petrs obtained. Can be useful if we add a 10 pull button
            //(Bonus) The summary screen can have a CLOSE button and a CURRENCY AGAIN! button
        } else{
            // Display/Change text to say "Oops, you don't have enough currency, you need to walk a bit more"
            //Text should be red
            //OR
            //We make the Gacha Button unclickable and greyed out if they don't have enought to begin with.
        }
    }

    public void CloseSummaryPanel(){
        //closes summary panel, go back to gacha screen.
        //get rid of overlay
        //return to normal controls
    }

    public void OpenSummaryPanel(){
        //Bring up Summary Panel
        //Create a dimmed out Overlay around it
        //Make the summmary panel the only interactable-object on screen until they hit close
    }

    public bool hasEnoughCurrency(){
        return false;
    }
}
