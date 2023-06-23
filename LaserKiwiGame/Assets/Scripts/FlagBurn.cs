using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagBurn : MonoBehaviour
{
    [SerializeField] private EndText endingText;
    private SpriteRenderer sprite;
    private bool burning;
    private float alpha;

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
            sprite.color = new Color(1, 0, 0, alpha);
            alpha = Mathf.Lerp(alpha, 0, Time.deltaTime * 1);
        }
    }

    public void BurnUp()
    {
        //causes end text to appear and burning animation to start
        burning = true;
        endingText.Appear();
    }
}
