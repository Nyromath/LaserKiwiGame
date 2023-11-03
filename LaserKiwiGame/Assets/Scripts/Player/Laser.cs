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
    private bool horiz;

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
        if(lifetime > 1) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks for collision
        if (collision.tag == "Mirror")
        {
            if (collision.GetComponent<Mirror>().clockwise == false)
            {
                transform.Rotate(0, 0, 90);
            }
            else
            {
                transform.Rotate(0, 0, -90);
            }
        }
        else
        {
            hit = true;
            boxCollider.enabled = false;

            if (collision.tag == "Enemy")
            {
                collision.GetComponent<Health>().TakeDamage(1);
            }

            if (collision.tag == "EndFlag")
            {
                collision.GetComponent<FlagBurn>().BurnUp();
            }

            if (collision.tag == "Detector")
            {
                collision.GetComponent<LaserDetector>().Activate();
            }
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
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
