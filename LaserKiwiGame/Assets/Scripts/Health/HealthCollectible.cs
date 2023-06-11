using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue; //How much health the item pickup restores (will usually be one)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks for collision with player
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(healthValue * -1); //restores health to player (by dealing negative damage to them)
            gameObject.SetActive(false); //item pickup deactivates
        }
    }
}
