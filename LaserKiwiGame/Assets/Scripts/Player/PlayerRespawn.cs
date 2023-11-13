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
            //sets new spawn point and triggers flag raising animation
            SetRespawnPoint(collision.transform);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<CheckpointFlagScript>().Activate();

            //heals player to full health when activating a checkpoint
            playerHealth.TakeDamage(-3);
        }
    }

    public void SetRespawnPoint(Transform spawnPoint)
    {
        currentCheckpoint = spawnPoint;
    }
}
