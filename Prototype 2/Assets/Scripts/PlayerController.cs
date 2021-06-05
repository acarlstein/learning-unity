using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;
    public GameObject projectilePrefab;


    // Update is called once per frame
    void Update()
    {
        ForceBoundries();
        MoveHorizontally();
        PerformShooting();
    }
   
    private void ForceBoundries()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        } else if (transform.position.x > xRange)
        {
           transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

    private void MoveHorizontally()
    {
        horizontalInput = InputController.GetHorizontal();
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }

    private void PerformShooting()
    {
        if (InputController.DoShoot())
        {
            // Spawn a projectile at the player's location with prefab's rotation
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
