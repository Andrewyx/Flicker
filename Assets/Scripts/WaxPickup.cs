using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaxPickup : MonoBehaviour
{
    // Start is called before the first frame update
    public float WaxAmount = 5f;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Hit Something");
        if(other.tag == "Player"){
            Debug.Log("Hit Wax");
            PlayerController.instance.addWax(WaxAmount);
            Destroy(gameObject);
        }    
    }

}
