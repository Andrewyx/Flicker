using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleDrain : MonoBehaviour
{
    WaxBar waxBar;
    
    public GameObject WaxBar;

    public float totalPlaytime = 30f;
    public float reductionFactor = 0.9f;
    [SerializeField] private float downTimeLeft, upTimeLeft;

    void Awake()
    {
        waxBar = WaxBar.GetComponent<WaxBar>();
    }

    void Start()
    {
        downTimeLeft = totalPlaytime;
        waxBar.SetMaxHealth(totalPlaytime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(upTimeLeft < 0 || downTimeLeft < 0){
            FindObjectOfType<GameManager>().timesUp = true;
            FindObjectOfType<GameManager>().EndGame();            
        }
        else if(transform.position.y == 0.5f){
            downTimeLeft -= Time.deltaTime;
            upTimeLeft += Time.deltaTime * reductionFactor;
        }
        else if (transform.position.y == 3.5f){
            upTimeLeft -= Time.deltaTime;
            downTimeLeft += Time.deltaTime * reductionFactor;
        }

        waxBar.SetHealth(downTimeLeft);
    }
}
