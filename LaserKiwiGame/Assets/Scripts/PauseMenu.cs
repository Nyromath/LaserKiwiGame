using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseMenuUI;
    public GameObject flagMenuUI;
    public GameObject flagManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        flagMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Quit()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void FlagOptionsOpen()
    {
        pauseMenuUI.SetActive(false);
        flagMenuUI.SetActive(true);
    }

    public void FlagOptionsClose()
    {
        pauseMenuUI.SetActive(true);
        flagMenuUI.SetActive(false);
    }

    public void FlagSelect(int flag)
    {
        flagManager.GetComponent<FlagManagerScript>().ChangeFlags(flag);
        FlagOptionsClose();
    }
}
