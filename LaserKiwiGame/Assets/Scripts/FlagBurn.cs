using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagBurn : MonoBehaviour
{
    [SerializeField] private GameObject gate;
    [SerializeField] private int level;
    private SpriteRenderer sprite;
    private bool burning;
    private float alpha;
    private float timePassed;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        burning = false;
        alpha = 1;
    }

    private void Update()
    {
        //sprite turns red and gradually fades out every frame once burning condition is met
        if (burning)
        {
            timePassed += Time.deltaTime;
            float progress = timePassed / 1;
            sprite.color = new Color(1, 0, 0, alpha);
            alpha = Mathf.Lerp(1, 0, progress);
        }
    }

    public void BurnUp()
    {
        //causes return gate to appear and burning animation to start
        burning = true;
        gate.SetActive(true);

        //marks level as complete
        switch (level)
        {
            case 1:
                StaticData.level1Complete = true;
                break;
            case 2:
                StaticData.level2Complete = true;
                break;
            default:
                break;
        }
    }
}
