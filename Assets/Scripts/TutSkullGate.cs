using UnityEngine;
using UnityEngine.UI;  
using System.Collections;
using System.Collections.Generic;

public class TutSkullGate : MonoBehaviour, IInteractable {

    public Canvas TutSkull1;
    public Canvas TutSkull2;
    public GameObject DungeonGate;
    
    public void Interact() {
        if(TutSkull1.enabled && TutSkull2.enabled)
        {
            Destroy(DungeonGate);
            Debug.Log("Gate is activated");
        }
    }

}