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
        if (burning)
        {
            sprite.color = new Color(1, 0, 0, alpha);
            alpha = Mathf.Lerp(alpha, 0, Time.deltaTime * 1);
        }
    }

    public void BurnUp()
    {
        //sprite.color = Color.red;
        //sprite.color = new Color(1, 0, 0, Mathf.Lerp(1, 0, Time.deltaTime));
        burning = true;
        endingText.Appear();
    }
}
