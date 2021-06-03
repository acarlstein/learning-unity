using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePropeller : MonoBehaviour
{

    public float rotationSpeed = 360.0f;

    // Update is called once per frame
    void Update()
    {
        var child = transform.GetChild(0);
        child.transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
    }
}
