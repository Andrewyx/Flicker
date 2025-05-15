using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SkullInteractable : MonoBehaviour, IInteractable {

    public float cooldownTimer = 1.5f;
    private float currentTime;
    public Canvas Prompt;
    public Canvas tutSkull;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    public void Interact() {
        Debug.Log("Skull is activated");
        Prompt.enabled = true;
        currentTime = cooldownTimer;
        spriteRenderer.sprite = newSprite;
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