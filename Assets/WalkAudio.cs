using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            audioSource.PlayOneShot(clip);   
        }
    }
}
