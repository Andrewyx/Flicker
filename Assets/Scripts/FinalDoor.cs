using UnityEngine;
using UnityEngine.UI;  
using System.Collections;
using System.Collections.Generic;

public class FinalDoor : MonoBehaviour, IInteractable {

    public Canvas DarkKey;
    public Canvas LightKey;
    public GameObject finalDoor;
    
    public void Interact() {
        if(DarkKey.enabled && LightKey.enabled)
        {
            FindObjectOfType<GameManager>().gameWon = true;
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}