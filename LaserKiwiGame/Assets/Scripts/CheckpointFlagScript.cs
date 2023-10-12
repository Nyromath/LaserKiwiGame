using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointFlagScript : MonoBehaviour
{
    [SerializeField] private int flagSpriteNum = 0;
    private SpriteRenderer sr;
    [SerializeField] private GameObject flag;
    [SerializeField] private List<Sprite> flagSprites;

    // Start is called before the first frame update
    void Start()
    {
        sr = flag.GetComponent<SpriteRenderer>();
        sr.enabled = false;
        sr.sprite = flagSprites[flagSpriteNum];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            flagSpriteNum += 1;
            if(flagSpriteNum >= 13)
            {
                flagSpriteNum = 0;
            }

            ChangeFlag(flagSpriteNum);
        }
    }

    private void ChangeFlag(int num)
    {
        sr.sprite = flagSprites[num];
    }

    public void Activate()
    {
        sr.enabled = true;
    }
}
