using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds: MonoBehaviour
{
    private readonly float topBound = 40.0f;
    private readonly float lowerBound = -10.0f;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBound
            || transform.position.z < lowerBound)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }        
    }
}
