using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;   

public class ShowPrompt : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas Prompt;

    void onTriggerEnter(Collider TheThingEnteringTheTrigger)
    {
        if(TheThingEnteringTheTrigger.tag == "Player")
        {
            Debug.Log("Player is near the note");
            Prompt.enabled = false;
        }
    }
}
