using UnityEngine;
using UnityEngine.UI;  
using System.Collections;
using System.Collections.Generic;

public class SkullGate2 : MonoBehaviour, IInteractable {

    public Canvas skull2;
    public GameObject DungeonGate;
    public Canvas Prompt;
    
    private float currentTime;
    
    public void Interact() {
        if(skull2.enabled == true)
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