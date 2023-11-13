using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManagerScript : MonoBehaviour
{
    [SerializeField] List<CheckpointFlagScript> checkpoints;
    [SerializeField] private int flagSpriteNum = 0;
    // Start is called before the first frame update

    private void Start()
    {
        ChangeFlags(flagSpriteNum);
    }

    void Update()
    {
        //temporary code to test flag changing
        if (Input.GetKeyDown(KeyCode.N))
        {
            //increments flag sprite number by one, wraps back to 0 at 13
            flagSpriteNum += 1;
            if (flagSpriteNum >= 13)
            {
                flagSpriteNum = 0;
            }

            //calls function to change flag sprites
            ChangeFlags(flagSpriteNum);
        }
    }

    public void ChangeFlags(int num)
    {
        //calls function to change flag sprites in each checkpoint flag in the level
        foreach(CheckpointFlagScript i in checkpoints)
        {
            i.ChangeFlag(num);
        }
    }
}
