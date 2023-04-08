using UnityEngine;
using UnityEngine.UI;  
using System.Collections;
using System.Collections.Generic;

public class ShowPuzzle : MonoBehaviour, IInteractable {

    public Canvas PuzzleCanvas;
    public Canvas VictoryCanvas;
    public Canvas RedKey;

    public float cooldownTimer = 1.5f;
    private float currentTime;

    public Text UserInputText;
    public string SecretCode = "1984";
    public bool SecretCodeEntered = false;


    public void Interact() {
        Debug.Log("Player is near the puzzle");
        PuzzleCanvas.enabled = true;
        currentTime = cooldownTimer;     
    }

    public void ExitButton()
    {
        PuzzleCanvas.enabled = false;
        Debug.Log("Player missed it");
    }

    private void Start(){
        currentTime = cooldownTimer;

    }

    private void Update(){
        if(Input.GetKey(KeyCode.Mouse1) && PuzzleCanvas.enabled)
        {
            ExitButton();
        }
        if(UserInputText.text == SecretCode && SecretCodeEntered==false)
        {
            Debug.Log("Correct!");
            SecretCodeEntered = true;
            PuzzleCanvas.enabled = false;
            VictoryCanvas.enabled = true;
            RedKey.enabled = true;
        }
        if(VictoryCanvas.enabled){
            currentTime-=Time.deltaTime;
            if(currentTime<=0f){
                VictoryCanvas.enabled = false;
            }
        }   
    }
}
