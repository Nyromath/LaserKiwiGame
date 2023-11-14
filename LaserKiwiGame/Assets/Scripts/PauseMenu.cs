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

    void Update()
    {
        //detects Escape input for opening/closing pause menu
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
        //closes all menu overlays
        pauseMenuUI.SetActive(false);
        flagMenuUI.SetActive(false);

        //resumes time
        Time.timeScale = 1f;

        paused = false;
    }

    private void Pause()
    {
        //opens pause menu overlay
        pauseMenuUI.SetActive(true);

        //pauses time
        Time.timeScale = 0f;

        paused = true;
    }

    public void Quit()
    {
        //returns player to main menu scene when "Quit" button is clicked
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void FlagOptionsOpen()
    {
        //closes pause menu overlay
        pauseMenuUI.SetActive(false);
        //opens flag menu overlay
        flagMenuUI.SetActive(true);
    }

    public void FlagOptionsClose()
    {
        //re-opens pause menu overlay
        pauseMenuUI.SetActive(true);
        //closes flag menu overlay
        flagMenuUI.SetActive(false);
    }

    public void FlagSelect(int flag) //when flag option clicked in flag menu, runs this function with the number of the selected flag
    {
        //sets static flag variable; for passing selected flag option between scenes (not working, unsure why)
        StaticData.SetFlagSprite(flag);
        //sets all flags in level to the selected flag sprite
        flagManager.GetComponent<FlagManagerScript>().ChangeFlags(flag);
        FlagOptionsClose();
    }
}
