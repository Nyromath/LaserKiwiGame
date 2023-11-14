using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData : MonoBehaviour
{
    //defining static variables for passing values between scenes
    public static int flagSprite;
    public static bool level1Complete;
    public static bool level2Complete;

    public static void SetFlagSprite(int flag)
    {
        flagSprite = flag;
    }
}
