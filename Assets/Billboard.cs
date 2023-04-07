using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Vector3 cameraDir;
    private SpriteRenderer theSR;

    private void Start() {
        theSR = GetComponent<SpriteRenderer>();
        theSR.flipX = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(PlayerController.instance.transform.position);
    }
}
