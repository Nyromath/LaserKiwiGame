using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; } //allows other scripts to get the currentHealth value, but can only be set by this script

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth); //limits health to between 0 and the set max health value

        if(currentHealth > 0)
        {
            
        }
        else
        {
            GetComponent<PlayerMovement>().enabled = false; //player movement deactivates and gets Game Over if health is at or below 0
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(-1);
        }
    }
}
