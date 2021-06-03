using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 0.5f;
    public float rotationSpeed = 100.0f;
    public bool doInvertYAxis = false;
    
    private float verticalInput;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed);

        // get the user's vertical input
        // tilt the plane up/down based on up/down arrow keys
        verticalInput = Input.GetAxis("Up Down Arrows");
        int invertVerticalInput = (doInvertYAxis) ? -1 : 1;
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput * invertVerticalInput);
    }
}
