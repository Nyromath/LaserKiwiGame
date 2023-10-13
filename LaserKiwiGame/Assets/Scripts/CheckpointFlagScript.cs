using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointFlagScript : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private GameObject flag;
    [SerializeField] private List<Sprite> flagSprites;

    //start and end positions for flag raising animation
    private Vector3 endPosition = new Vector3(0.11f, 0.072f, 0);
    private Vector3 startPosition = new Vector3(0.11f, -0.103f, 0);
    private float duration = 0.5f;
    private float timePassed;
    private bool activated = false;

    void Start()
    {
        //sets the flag in start position; default flag sprite, flag hidden
        sr = flag.GetComponent<SpriteRenderer>();
        sr.enabled = false;
        sr.sprite = flagSprites[0];
    }

    private void Update()
    {
        if (activated)
        {
            timePassed += Time.deltaTime;
            float progress = timePassed / duration;
            flag.transform.localPosition = Vector3.Lerp(startPosition, endPosition, progress);
        }
    }

    public void ChangeFlag(int num)
    {
        //changes the flag sprite when called
        sr.sprite = flagSprites[num];
    }

    public void Activate()
    {
        //flag sprite appears when activated
        sr.enabled = true;
        activated = true;
    }
}
