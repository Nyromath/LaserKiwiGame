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
        if (Input.GetKey(KeyCode.L) && cooldownTimer > attackCooldown)
        {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownTimer = 0;

        lasers[FindLaser()].transform.position = firePoint.position;
        lasers[FindLaser()].GetComponent<Laser>().Direction(Mathf.Sign(transform.localScale.x));
    }

    private int FindLaser()
    {
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
