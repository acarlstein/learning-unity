using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;
    public ObjectPooler ammunitionPool;

    private void Start()
    {
 
    }

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
            GameObject bullet = ammunitionPool.GetPooledObject();
            if (bullet == null) throw new System.NullReferenceException("Cannot obtain bullet");
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
    }
}
