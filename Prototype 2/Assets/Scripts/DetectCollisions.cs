using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);

        //Destroy(other.gameObject);
        other.gameObject.SetActive(false);
    }
}
