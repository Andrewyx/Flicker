using UnityEngine;
using UnityEngine.UI;  
using System.Collections;
using System.Collections.Generic;

public class ShowPuzzle : MonoBehaviour, IInteractable {

    public Canvas PuzzleCanvas;

    public Text UserInputText;
    public string SecretCode = "1984";

    public void Interact() {
        Debug.Log("Player is near the puzzle");
        PuzzleCanvas.enabled = true;
        if(Input.GetKey(KeyCode.Escape))
        {
            ExitButton();
        }       
    }

    public void ExitButton()
    {
        PuzzleCanvas.enabled = false;
    }
}
