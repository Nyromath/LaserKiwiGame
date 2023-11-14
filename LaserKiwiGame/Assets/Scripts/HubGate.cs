using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubGate : MonoBehaviour
{
    [SerializeField] private GameObject inputPrompt;
    private bool playerInRange;
    [SerializeField] private int levelNumber;

    private void Awake()
    {
        playerInRange = false;

        //checking hub gates if level is complete; disables them if their associated level is complete
        switch (levelNumber)
        {
            case 1:
                if (StaticData.level1Complete)
                {
                    GetComponent<BoxCollider2D>().enabled = false; //disables box collider so playerInRange variable can never be "true"
                    GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f); //sets colour to grey to give the disabled appearance
                }
                break;
            case 2:
                if (StaticData.level2Complete)
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                    GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
                }
                break;
            default:
                break;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange) //reads E input, only if the player is close to the gate
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + levelNumber); //loads scene based on inputted value
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //detects if player is in range
        if(collision.tag == "Player")
        {
            inputPrompt.SetActive(true); //"E" key input prompt appears on UI
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //detects when player leaves range
        if (collision.tag == "Player")
        {
            inputPrompt.SetActive(false); //"E" key input prompt removed from UI
            playerInRange = false;
        }
    }
}
