using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    
    public int viewNumber = 1;
    private Vector3[] cameraViews = {
        new Vector3(0, 5, -8), // Behind
        new Vector3(0, 4.2f, 0), // Inside
        new Vector3(-14, 4, 0) // Side        
    };

    //private Vector3 offset;
    private bool isAllowedToRotate = true;
    private bool doRotateBack = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Before viewNumber:" + viewNumber);
            viewNumber = ++viewNumber % cameraViews.Length;
            Debug.Log("After viewNumber:" + viewNumber);
        }
    }

    // Update is called once per frame
    //void Update()
    void LateUpdate()
    {
        if (viewNumber == 2)
        {
            if (isAllowedToRotate)
            {
                Debug.Log("viewNumber:" + viewNumber);
                isAllowedToRotate = false;
                doRotateBack = true;
                transform.Rotate(Vector3.up, 90.0f);
            }
        } else
        {
            if (doRotateBack)
            {
                transform.Rotate(Vector3.up, -90.0f);
                doRotateBack = false;
            }
            isAllowedToRotate = true;
        }
        
        transform.position = player.transform.position + cameraViews[viewNumber];
       
    }
}
