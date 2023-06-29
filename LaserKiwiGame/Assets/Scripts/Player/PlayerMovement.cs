using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float dashDistance;
    private Rigidbody2D body;
    private bool grounded;
    private bool hasDashed = true;
    private bool isDashing = false;
    private float gravity;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        gravity = body.gravityScale;
    }

    private void Update()
    {
        //MOVEMENT
        float horizontalInput = Input.GetAxis("Horizontal");
        if (!isDashing)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);


            //flipping character sprite based on movement direction
            if (horizontalInput > 0.01f)
            {
                transform.localScale = Vector3.one;
            }
            else if (horizontalInput < -0.01f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            //jumping; only allows jumping if the player is on the ground
            if (Input.GetKey(KeyCode.W) && grounded)
            {
                Jump();
            }
        }

        //dashing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash(transform.localScale.x));
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed * 3.5f);
        hasDashed = false;
    }

    IEnumerator Dash(float direction)
    {
        //only allows the player to dash if they haven't already during this jump, and if they're in the air
        if (!hasDashed && !grounded)
        {
            //setting variables to affect other movement behaviour while dashing
            isDashing = true;
            hasDashed = true;

            //freezes player's Y movement and applies a set force in the dashing direction
            body.velocity = new Vector2(body.velocity.x, 0f);
            body.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
            body.gravityScale = 0;

            //waits for dash to conclude then returns player movement to its regular state
            yield return new WaitForSeconds(0.3f);
            isDashing = false;
            body.gravityScale = gravity;
        }
    }

    public void DashReset()
    {
        //called during respawn. if dash isn't reset, the player could respawn in the air with no gravity or control over the character
        body.gravityScale = gravity;
        isDashing = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the player is on the ground, mark them as "grounded"
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
