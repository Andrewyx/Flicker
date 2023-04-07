using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public bool isPaused; //only used in void update so you cant unpause an unpaused game? or vice versa? idk? are these comments even helpful? they are to me ig

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }   
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // "this stops the in-game clock, stops animations, updates, and stuff like that" https://youtu.be/9dYDBomQpBQ 4:11
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // presumably restarts the in-game clock, or sets its scale to 1 or something. back to normal or something. f stands for float?
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // i didnt know why this was here but like, if you don't have this your time is frozen forever!!!
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // i don't have to do it this way but like, the first tutorial I followed did this so why not. if this causes an issue, reference the main menu by name
    }

    public void QuitGame() //this may cause some conflict.
    {
        Application.Quit();
        Debug.Log("this quits the game but not in the editor. pretend it did. also this might cause conflict cuz I already have a QuitGame already? idk");

    }
}
