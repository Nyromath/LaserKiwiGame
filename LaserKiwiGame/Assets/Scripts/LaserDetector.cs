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

    private void Awake()
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
            case 0: //Variant 0 for Deactivating an Object
                TargetEnabled(false);
                On();
                break;
            case 1: //Variant 1 for Enabling an Object
                TargetEnabled(true);
                On();
                break;
            case 2: //Variant 2 for toggling platform movement
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
            case 3: //Variant 3 for platform return switch
                TargetMovingPlatformReturn();
                break;
            case 4: //Variant 4 for mirror rotating puzzle
                TargetMirrorRotate();
                break;
            case 5: //Variant 5 for setting player spawn and deactivating platform
                SpawnSet();
                On();
                break;
            default:
                break;
        }
    }

    private void On()
    {
        activated = true;
        sr.sprite = detectorSprites[1]; //sets to Green "On" sprite
    }

    private void Off()
    {
        activated = false;
        sr.sprite = detectorSprites[0]; //sets to Red "Off" sprite
    }

    private void TargetEnabled(bool state)
    {
        //runs through each target in list and sets them as active/inactive
        foreach (GameObject target in targets)
        {
            target.SetActive(state);
        }
    }

    private void TargetMovingPlatformToggle(bool state)
    {
        targets[0].GetComponent<MovingPlatform>().setActive(state);
        targets[1].SetActive(true); //show return switch
    }

    private void TargetMovingPlatformReturn()
    {
        //resets platform and detector active state
        targets[0].GetComponent<MovingPlatform>().setActive(false);
        targets[0].GetComponentInChildren<LaserDetector>().Off();

        targets[0].transform.position = new Vector3(targets[0].GetComponent<MovingPlatform>().GetLeftEdge(), targets[0].transform.position.y, 0); //reset platform position
        targets[1].SetActive(false); //hide return switch
    }

    private void TargetMirrorRotate()
    {
        //runs through each mirror target and rotates them
        foreach(GameObject mirror in targets)
        {
            mirror.GetComponent<Mirror>().clockwise = !mirror.GetComponent<Mirror>().clockwise; //inverts clockwise tag
            mirror.transform.Rotate(0, 0, 90);
        }
    }

    private void SpawnSet()
    {
        targets[0].SetActive(false); //deactivates platform
        targets[1].GetComponent<PlayerRespawn>().SetRespawnPoint(targets[2].transform); //sets player spawn point to the position of the respawn target
    }
}
