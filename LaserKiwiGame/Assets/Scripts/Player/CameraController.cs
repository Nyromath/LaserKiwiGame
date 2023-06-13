using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float aboveDistance;
    private float lookAhead;
    private void Update()
    {
        //positions camera to give player more view in the direction they're moving
        transform.position = new Vector3(player.position.x + lookAhead, Mathf.Clamp(player.position.y, -0.1f, 1000) + aboveDistance, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (player.localScale.x * aheadDistance), Time.deltaTime * speed);
    }
}
