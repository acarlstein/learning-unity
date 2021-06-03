using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Moving the vehicle forward
        //MovingVehicleForwardWithXYZ();
        //MovingVehicleForwardWithVector();
        MovingVehicleForwardAt(speed);
    }

    private void MovingVehicleForwardWithXYZ()
    {
        transform.Translate(0, 0, 1);
    }

    private void MovingVehicleForwardWithVector()
    {
        transform.Translate(Vector3.forward);
    }

    private void MovingVehicleForwardAt(float amount)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * amount);
    }
}
