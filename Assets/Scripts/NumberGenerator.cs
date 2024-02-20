using UnityEngine;
using UnityEngine.UI;  
using System.Collections;
using System.Collections.Generic;

public class NumberGenerator : MonoBehaviour, IInteractable {

    public float cooldownTimer = 1.5f;
    private float currentTime;
    public Canvas Prompt;
    public Canvas tutSkull1;
    public Canvas tutSkull2;
    public int skullCount = 0;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    public void Interact() {
        Debug.Log("Skull is activated");
        Prompt.enabled = true;
        currentTime = cooldownTimer;
        spriteRenderer.sprite = newSprite;
        skullCount = skullCount + 1;
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