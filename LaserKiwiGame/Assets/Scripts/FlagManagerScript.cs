using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManagerScript : MonoBehaviour
{
    [SerializeField] List<CheckpointFlagScript> checkpoints;
    private int flagSpriteNum;

    private void Start()
    {
        //retrieves static flagsprite value, passes it into ChangeFlags script
        flagSpriteNum = StaticData.flagSprite;
        ChangeFlags(flagSpriteNum);
    }

    public void ChangeFlags(int flag)
    {
        //calls function to change flag sprites in each checkpoint flag in the level
        foreach(CheckpointFlagScript i in checkpoints)
        {
            i.ChangeFlag(flag);
        }
    }
}
