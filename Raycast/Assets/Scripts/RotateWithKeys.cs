using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithKeys : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 30.0f;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }
    }
}
