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

        //checking hub gates if level is complete
        switch (levelNumber)
        {
            case 1:
                if (StaticData.level1Complete)
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                    GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + levelNumber);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inputPrompt.SetActive(true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inputPrompt.SetActive(false);
            playerInRange = false;
        }
    }
}
