using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform currentCheckpoint; //position the player will respawn at. SerializeField to use empty PlayerRespawn object as initial spawn point
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    public void Respawn()
    {
        //places the player at the location of their current checkpoint and faces them forward
        transform.position = currentCheckpoint.position;
        transform.localScale = new Vector3(1, 1, 1);

        //player correctly resets, and ensures they can Dash after respawning
        playerHealth.Respawn();
        GetComponent<PlayerMovement>().DashReset();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("Appear");

            playerHealth.TakeDamage(-3); //heals player to full health when activating a checkpoint
        }
    }
}
