using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    public float turnSpeed = 45.0f;
    public float slideSpeed = 5.0f;
    public InputController inputController;

    private float horizontalInput;
    private float verticalInput;
    private float slideInput;


    // Update is called once per frame
    void Update()
    {
        MovingForwardsOrBackwards();
        SlideLeftOrRight();
        TurnLeftOrRight();
    }

    private void MovingForwardsOrBackwards()
    {
        verticalInput = inputController.GetVertical();
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
    }

    private void SlideLeftOrRight()
    {
        slideInput = inputController.GetTopDiagonal();
        transform.Translate(Vector3.right * Time.deltaTime * slideSpeed * slideInput);
    }

    private void TurnLeftOrRight()
    {
        horizontalInput = inputController.GetHorizontal();
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
