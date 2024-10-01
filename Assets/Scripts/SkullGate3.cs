using UnityEngine;
using UnityEngine.UI;  
using System.Collections;
using System.Collections.Generic;

public class SkullGate3 : MonoBehaviour, IInteractable {

    public Canvas skull3;
    public GameObject DungeonGate;
    public Canvas Prompt;
    
    private float currentTime;
    
    public void Interact() {
        if(skull3.enabled == true)
        {
            Destroy(DungeonGate);
            Debug.Log("Gate is activated");
        }
        else{
            Prompt.enabled = true;
            if(Prompt.enabled){
                currentTime-=Time.deltaTime;
                if(currentTime<=0f){
                    Prompt.enabled = false;
                }
            }
        }
    }

}