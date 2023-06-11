using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    //editable stats for trap behaviour
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float movementDistance;

    //variables to determine trap movement
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {
        //setting boundaries for where the trap can move
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    private void Update()
    {
        //trap movement; checks which direction trap is moving, and if it's reached its movement boundaries
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //damages player if the player touches the trap
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(1);
        }
    }
}
