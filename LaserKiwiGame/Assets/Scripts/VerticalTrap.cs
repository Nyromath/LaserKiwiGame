using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalTrap : MonoBehaviour
{
    //editable stats for trap behaviour
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float movementDistance;

    //variables to determine trap movement
    private bool movingDown;
    [SerializeField] private float downEdge;
    [SerializeField] private float upEdge;

    private void Awake()
    {
        //setting boundaries for where the trap can move
        //downEdge = transform.position.y - movementDistance;
        //upEdge = transform.position.y + movementDistance;
    }

    private void Update()
    {
        //trap movement; checks which direction trap is moving, and if it's reached its movement boundaries
        if (movingDown)
        {
            if (transform.position.y > downEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingDown = false;
            }
        }
        else
        {
            if (transform.position.y < upEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingDown = true;
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
