using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveOutOfBounds : MonoBehaviour
{
    private readonly float topBound = 40.0f;
    private readonly float lowerBound = -10.0f;

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeInHierarchy
            && (transform.position.z > topBound
            || transform.position.z < lowerBound))
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }        
    }
}
