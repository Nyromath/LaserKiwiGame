using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndText : MonoBehaviour
{
    private void Awake()
    {
        //text is inactive when game starts
        gameObject.SetActive(false);
    }

    public void Appear()
    {
        //text appears once this function is called
        gameObject.SetActive(true);
    }
}
