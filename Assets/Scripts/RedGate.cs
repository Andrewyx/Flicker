using UnityEngine;
using UnityEngine.UI;  
using System.Collections;
using System.Collections.Generic;

public class RedGate : MonoBehaviour, IInteractable {

    public Canvas RedKey;
    public GameObject DungeonGate;
    
    public void Interact() {
        if(RedKey.enabled)
        {
            Destroy(DungeonGate);
        }
    }

}