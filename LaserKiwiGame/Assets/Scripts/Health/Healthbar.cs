using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currentHealthbar;

    private void Start()
    {
        totalHealthbar.fillAmount = playerHealth.currentHealth / 3;
    }

    private void Update()
    {
        currentHealthbar.fillAmount = playerHealth.currentHealth / 3; //Red health icons image layer unfills as player takes damage, showing black unfilled health icons beneath to represent damage
    }
}
