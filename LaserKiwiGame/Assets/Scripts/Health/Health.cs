using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; } //allows other scripts to get the currentHealth value, but can only be set by this script
    
    //values for invulnerability script
    [SerializeField] private float invDuration;
    [SerializeField] private int invFlashes;
    private SpriteRenderer sprite;

    private void Awake()
    {
        currentHealth = startingHealth;
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //entity dies if falling below y:-1
        if(GetComponent<Transform>().position.y < -1)
        {
            TakeDamage(3);
        }
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth); //limits health to between 0 and the set max health value

        if(currentHealth > 0)
        {
            if (_damage > 0) //only performs invulnerability if player actually takes damage, not when healed
            {
                StartCoroutine(Invulnerability());
            }
        }
        else
        {
            /*
            //checks if player
            if (GetComponent<PlayerMovement>() != null)
            {
                GetComponent<PlayerMovement>().enabled = false; //player movement deactivates and gets Game Over if health is at or below 0
            }

            //checks if enemy
            if (GetComponentInParent<EnemyPatrol>() != null)
            {
                GetComponentInParent<EnemyPatrol>().enabled = false; //enemy patrol script deactivates when enemy hits 0 HP
            }

            if (GetComponent<MeleeEnemy>() != null)
            {
                GetComponent<MeleeEnemy>().enabled = false; //enemy script deactivates when enemy hits 0 HP
            }
            */
            Deactivate();
        }
    }

    //for testing purposes
    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(-1);
        }
    }*/

    private IEnumerator Invulnerability()
    {
        LayerCollision(true);

        //i-frame flashes
        for(int i = 0; i < invFlashes; i++)
        {
            sprite.color = new Color(0, 0, 0, 0.5f);
            yield return new WaitForSeconds(invDuration / invFlashes / 2);
            sprite.color = Color.white;
            yield return new WaitForSeconds(invDuration / invFlashes / 2);
        }

        LayerCollision(false);
    }

    private void LayerCollision(bool state)
    {
        //if game object is player, disable/enable player-to-enemy collision during i-frames
        if(GetComponent<PlayerMovement>() != null)
        {
            Physics2D.IgnoreLayerCollision(7, 8, state);
        }

        //if game object is enemy, disable/enable enemy-to-laser collision during i-frames
        if(GetComponentInParent<EnemyPatrol>() != null)
        {
            Physics2D.IgnoreLayerCollision(8, 9, state);
        }
    }

    public void Respawn()
    {
        gameObject.SetActive(true);
        TakeDamage(startingHealth * -1);
        StartCoroutine(Invulnerability());
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);

        //if deactivated game object is player, get and execute respawn script
        if(GetComponent<PlayerMovement>() != null)
        {
            GetComponent<PlayerRespawn>().Respawn();
        }
    }
}
