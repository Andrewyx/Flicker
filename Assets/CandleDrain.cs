using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleDrain : MonoBehaviour
{
    WaxBar waxBar;
    
    public GameObject WaxBar;

    public float totalPlaytime = 30f;
    public float reductionFactor = 0.9f;
    public float downTimeLeft, upTimeLeft;

    void Awake()
    {
        waxBar = WaxBar.GetComponent<WaxBar>();
    }

    void Start()
    {
        downTimeLeft = totalPlaytime;
        waxBar.SetMaxHealth(totalPlaytime);
        waxBar.SetHealth(downTimeLeft);
    }

    // Update is called once per frame
    void Update()
    {
        if(upTimeLeft > totalPlaytime){
            waxBar.SetMaxHealth(upTimeLeft);

            totalPlaytime = upTimeLeft;
        }
        else if (downTimeLeft > totalPlaytime){
            waxBar.SetMaxHealth(downTimeLeft);
            waxBar.SetHealth(downTimeLeft);
            totalPlaytime = downTimeLeft;
        }


        if(upTimeLeft < 0 || downTimeLeft < 0){
            FindObjectOfType<GameManager>().timesUp = true;
            FindObjectOfType<GameManager>().EndGame();            
        }
        else if(transform.position.y == 0.5f){
            downTimeLeft -= Time.deltaTime;
            upTimeLeft += Time.deltaTime * reductionFactor;
            waxBar.SetHealth(downTimeLeft);
            waxBar.SetColor(Color.cyan);
        }
        else if (transform.position.y == 3.5f){
            upTimeLeft -= Time.deltaTime;
            downTimeLeft += Time.deltaTime * reductionFactor;
            waxBar.SetHealth(upTimeLeft);
            waxBar.SetColor(Color.red);
        }

    }
}
