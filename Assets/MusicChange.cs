using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour
{
    public AudioSource RSong;
    public AudioSource BSong;
    Vector3 targetGridPos;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.instance.transform.position.y >= 2.5f)
        {
            RSong.Play();
            //BSong.Stop();
            Debug.Log("Songplaying");
        }
        else
        {
            BSong.Play();
            //RSong.Stop();
            Debug.Log("SongStop");
        }
    }
}
