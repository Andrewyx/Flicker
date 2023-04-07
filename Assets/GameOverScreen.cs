using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("help please what is going on");
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
