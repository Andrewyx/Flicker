using UnityEngine;
using UnityEngine.UI;  
using System.Collections;
using System.Collections.Generic;

public class NumberGenerator : MonoBehaviour, IInteractable {

    public float cooldownTimer = 1.5f;
    private float currentTime;
    public Canvas Prompt;

    public void Interact() {
        Debug.Log("Player is near the note");
        Prompt.enabled = true;
        currentTime = cooldownTimer;
    }

    private void Start(){
        currentTime = cooldownTimer;

    }

    private void FixedUpdate(){
        if(Prompt.enabled){
            currentTime-=Time.deltaTime;
            if(currentTime<=0f){
                Prompt.enabled = false;
            }
        }

    }

}