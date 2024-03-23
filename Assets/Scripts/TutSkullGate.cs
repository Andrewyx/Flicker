using UnityEngine;
using UnityEngine.UI;  
using System.Collections;
using System.Collections.Generic;

public class TutSkullGate : MonoBehaviour, IInteractable {

    public Canvas TutSkull1;
    public Canvas TutSkull2;
    public GameObject DungeonGate;
    public Canvas Prompt;
    private float currentTime;
    
    public void Interact() {
        if(TutSkull1.enabled)
        {
            Destroy(DungeonGate);
            Debug.Log("Gate is activated");
        }
        if(TutSkull1.enabled == false){
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