using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public bool gameEnded = false;
    [HideInInspector] public bool gameWon = false;
    [HideInInspector] public bool timesUp = false;
    [HideInInspector] public bool isDead = false;
    public void EndGame(){
        if(!gameEnded && gameWon){
            gameEnded = true;
            Debug.Log("Congrats! You Win");

        }
        else if (!gameEnded && timesUp){
            gameEnded = true;
            Debug.Log("Oh the misery, your time is up and life forfeit");
            SceneManager.LoadScene("LoseScreen");
            //Invoke("Restart", 2f); //this restarts play
        }
        else if (!gameEnded && isDead){
            gameEnded = true;
            Debug.Log("Your soul is damned for all of eternity");
            SceneManager.LoadScene("LoseScreen");
            //Invoke("Restart", 2f); //this restarts play
        }        
    }
    private void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
