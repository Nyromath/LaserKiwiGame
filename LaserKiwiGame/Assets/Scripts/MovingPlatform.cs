using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //editable stats for platform
    [SerializeField] private float speed;
    //[SerializeField] private float movementDistance;

    //variables to determine platform movement
    private bool movingLeft;
    [SerializeField] private float leftEdge;
    [SerializeField] private float rightEdge;

    private void Awake()
    {
        //setting boundaries for where the trap can move
        //leftEdge = transform.position.x - movementDistance;
        //rightEdge = transform.position.x + movementDistance;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
