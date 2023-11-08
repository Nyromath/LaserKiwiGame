using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] lasers;
    [SerializeField] private Transform playerPosition;
    private float cooldownTimer = Mathf.Infinity;

    private Health playerHealth;

    private void Update()
    {
        //increments attack cooldown timer
        cooldownTimer += Time.deltaTime;

        //if the enemy 'sees' the player, and their attack is off cooldown, enemy will attack
        if (PlayerInSight())
        {
            if (cooldownTimer > attackCooldown)
            {
                Attack();
            }
        }

        //turns to face in the direction the player is relative to the ranged enemy
        if (playerPosition.position.x <= transform.position.x)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else
        {
            transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
        }
    }

    private bool PlayerInSight()
    {
        //determines if player is in reach
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0,
            Vector2.left,
            0,
            playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        //draws box ahead of the enemy in editor mode; helps to visualize where the enemy hitbox area is
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void Attack()
    {
        //resets cooldown timer; player can't fire another laser until cooldown expires
        cooldownTimer = 0;

        //activates laser object from pre-made array
        lasers[FindLaser()].transform.position = firePoint.position;
        lasers[FindLaser()].GetComponent<Laser>().Direction(Mathf.Sign(transform.localScale.x * -1));
    }

    private int FindLaser()
    {
        //searches laser array for laser object not currently active
        for (int i = 0; i < lasers.Length; i++)
        {
            if (!lasers[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
