using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Vector3 cameraDir;
    private SpriteRenderer theSR;

    private void Start() {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //cameraDir = Camera.main.transform.forward;
        //cameraDir.y = 0;
        //transform.rotation = Quaternion.LookRotation(cameraDir);

        transform.LookAt(PlayerController.instance.transform.position);
    }
}
