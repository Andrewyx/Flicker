using UnityEngine;
using UnityEngine.UI;  
using System.Collections;
using System.Collections.Generic;

public class Skull2 : MonoBehaviour, IInteractable {

    public float cooldownTimer = 1.5f;
    private float currentTime;
    public Canvas Prompt;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    public Canvas skull2;

    public int skull2Count;


    public void Interact() {
        Debug.Log("Skull is activated");
        Prompt.enabled = true;
        currentTime = cooldownTimer;
        spriteRenderer.sprite = newSprite;
        skull2Count++;
    }

    private void Start(){
        currentTime = cooldownTimer;
    }

    private void FixedUpdate(){
        if(Prompt.enabled){
            currentTime -=Time.deltaTime;
            if(currentTime<=0f){
                Prompt.enabled = false;
            }
        }
        if(skull2Count >= 6){
            skull2.enabled = true;
        }
    }

}