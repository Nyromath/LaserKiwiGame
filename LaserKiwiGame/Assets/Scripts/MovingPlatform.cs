using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //editable stats for platform
    [SerializeField] private float speed;

    //variables to determine platform movement
    private bool movingLeft;
    [SerializeField] private bool active;
    [SerializeField] private float leftEdge;
    [SerializeField] private float rightEdge;

    private void Update()
    {
        //trap movement; checks which direction trap is moving, and if it's reached its movement boundaries
        if (active)
        {
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
    }

    //using parent/child relationship to make the player move with the platform when the player collides with it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

    public void setActive(bool state) //"active" state used for laser detector controlled platform; platform only moves when "active" is true
    {
        active = state;
    }

    public float GetLeftEdge() //used for laser detector controlled platforms to return them to their start position
    {
        return leftEdge;
    }
}
