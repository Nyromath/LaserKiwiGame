using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDetector : MonoBehaviour
{
    private SpriteRenderer sr;
    private bool activated;
    [SerializeField] private int variant;
    [SerializeField] private List<Sprite> detectorSprites;
    [SerializeField] private List<GameObject> targets;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = detectorSprites[0];
        activated = false;
    }

    public void Activate()
    {
        Debug.Log("Activated!");

        switch (variant)
        {
            case 0: //Case 0 for Deactivating an Object
                TargetEnabled(false);
                On();
                break;
            case 1: //Case 1 for Enabling an Object
                TargetEnabled(true);
                On();
                break;
            case 2: //Case 2 for toggling platform movement
                if (activated)
                {
                    TargetMovingPlatformToggle(false);
                    Off();
                }
                else
                {
                    TargetMovingPlatformToggle(true);
                    On();
                }
                break;
            default:
                break;
        }
    }

    private void On()
    {
        activated = true;
        sr.sprite = detectorSprites[1];
    }

    private void Off()
    {
        activated = false;
        sr.sprite = detectorSprites[0];
    }

    private void TargetEnabled(bool state)
    {
        foreach (GameObject target in targets)
        {
            target.SetActive(state);
        }
    }

    private void TargetMovingPlatformToggle(bool state)
    {
        targets[0].GetComponent<MovingPlatform>().setActive(state);
    }
}
