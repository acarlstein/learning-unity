using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private readonly float leftLimit = -30;
    private readonly float bottomLimit = -5;

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        // Destroy balls if y position less than bottom limit
        if (transform.position.x < leftLimit
            || transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }

    }
}
