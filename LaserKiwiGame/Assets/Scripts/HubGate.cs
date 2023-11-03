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
