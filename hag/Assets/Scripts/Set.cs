using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Set : MonoBehaviour
{
    AudioSource audioSoure;

    private void Start()
    {
        audioSoure = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (ControllerManager.GetInstance().loss == false && ControllerManager.GetInstance().Win == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (ControllerManager.GetInstance().GameIsPaused == false)
                    On();
                else
                    off();
            }

            if (ControllerManager.GetInstance().GameIsPaused == false)
            {

                Time.timeScale = 1f;
            }
            else
            {

                Time.timeScale = 0f;
            }
        }
    }

    public void On()
    {
        audioSoure.Play();
        ControllerManager.GetInstance().GameIsPaused = true;
    }

    public void off()
    {
        audioSoure.Play();
        ControllerManager.GetInstance().GameIsPaused = false;
    }
    public void Game()
    {
        Application.Quit();
    }

    public void main()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
