using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] lasers;
    private float cooldownTimer = Mathf.Infinity;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        //checks for input and if attack cooldown has expired, then attacks
        if (Input.GetKey(KeyCode.L) && cooldownTimer > attackCooldown)
        {
            Attack();
        }

        //increments cooldown timer
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        //resets cooldown timer; player can't fire another laser until cooldown expires
        cooldownTimer = 0;

        //activates laser object from pre-made array
        lasers[FindLaser()].transform.position = firePoint.position;
        lasers[FindLaser()].GetComponent<Laser>().Direction(Mathf.Sign(transform.localScale.x));
    }

    private int FindLaser()
    {
        //searches laser array for laser object not currently active
        for(int i = 0; i < lasers.Length; i++)
        {
            if (!lasers[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
