using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    public float turnSpeed = 45.0f;
    public float slideSpeed = 5.0f;
    private float horizontalInput;
    private float verticalInput;
    private float slideInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovingForwardsOrBackwards();
        SlideLeftOrRight();
        TurnLeftOrRight();
    }

    private void MovingForwardsOrBackwards()
    {
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
    }

    private void SlideLeftOrRight()
    {
        slideInput = Input.GetAxis("Q and E");
        transform.Translate(Vector3.right * Time.deltaTime * slideSpeed * slideInput);
    }

    private void TurnLeftOrRight()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
