using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTextScroll : MonoBehaviour
{
    [SerializeField] private List<GameObject> textList;
    [SerializeField] private GameObject inputPrompt;
    private int textPosition;
    private bool playerInRange;

    void Awake()
    {
        //disables text if the player has completed a level
        if(StaticData.level1Complete || StaticData.level2Complete)
        {
            gameObject.SetActive(false);
        }

        //setting base variables, loading first text panel
        textPosition = 0;
        playerInRange = false;
        TextScroll();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange) //reads E input, only if the player is close to the gate
        {
            textPosition += 1; //increments text position

            //checks text position value is in valid range
            if (textPosition >= textList.Count)
            {
                //disables text object and input prompt once text is exhausted
                inputPrompt.SetActive(false);
                gameObject.SetActive(false);
            }
            else
            {
                TextScroll(); //moves to next text panel
            }
        }
    }

    private void TextScroll()
    {
        //deactivates all text objects
        foreach (GameObject text in textList)
        {
            text.SetActive(false);
        }

        //immediately reactivates the current text panel
        textList[textPosition].SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //detects if player is in range
        if (collision.tag == "Player")
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
