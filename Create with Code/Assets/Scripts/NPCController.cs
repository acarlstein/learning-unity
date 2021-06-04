using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    public float speed = 5.0f;
    public float turnSpeed = 10.0f;
    private float horizontalInput;

    // Update is called once per frame
    void FixedUpdate()
    {
        MovingForwardsOrBackwards();
        TurnLeftOrRight();
    }

    private void MovingForwardsOrBackwards()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void TurnLeftOrRight()
    {
        horizontalInput = Random.Range(-1.0f, 1.0f);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
