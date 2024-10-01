using UnityEngine;
using UnityEngine.UI;  
using System.Collections;
using System.Collections.Generic;

public class SkullGate1 : MonoBehaviour, IInteractable {

    public Canvas skull1_1;
    public Canvas skull1_2;
    public GameObject DungeonGate;
    public Canvas Prompt;
    private float currentTime;
    
    public void Interact() {
        if(skull1_1.enabled && skull1_2.enabled)
        {
            Destroy(DungeonGate);
            Debug.Log("Gate is activated");
        }
        if(skull1_1.enabled == false || skull1_2.enabled == false){
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