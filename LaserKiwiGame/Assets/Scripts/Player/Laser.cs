using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private BoxCollider2D boxCollider;
    private float direction;
    private float lifetime;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) Deactivate(); //deactivates when laser collides with something

        //moves laser
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        //deactivates laser if it goes too long without hitting something; allows for fewer laser objects to be used and helps memory/performance
        lifetime += Time.deltaTime;
        if(lifetime > 0.5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks for collision
        hit = true;
        boxCollider.enabled = false;

        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().TakeDamage(1);
        }
    }

    public void Direction(float _direction)
    {
        //determines direction based on character alignment; called from PlayerAttack script
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
