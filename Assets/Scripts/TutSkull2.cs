using UnityEngine;
using UnityEngine.UI;  
using System.Collections;
using System.Collections.Generic;

public class TutSkull2: MonoBehaviour, IInteractable {

    public float cooldownTimer = 1.5f;
    private float currentTime;
    public Canvas Prompt;
    public Canvas tutSkull2;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;


    public void Interact() {
        Debug.Log("Skull is activated");
        Prompt.enabled = true;
        currentTime = cooldownTimer;
        spriteRenderer.sprite = newSprite;
        tutSkull2.enabled = true;
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