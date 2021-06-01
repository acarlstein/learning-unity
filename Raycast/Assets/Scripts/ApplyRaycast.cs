using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyRaycast : MonoBehaviour
{

    [Header("Debug Section")]

    [SerializeField]
    protected bool doDebugRay = false;
    
    [SerializeField]
    private Color debugRayTintColor = Color.red;

    [Range(0.0f, float.PositiveInfinity)]
    [SerializeField]
    protected float debugRayDistance = 10.0f;

    [Space]
    
    [Header("Settings")]

    [SerializeField]
    private bool isMultiple = false;

    [SerializeField]
    protected Color singleRayColor = Color.green;

    [SerializeField]
    private Color multiRayColor = Color.yellow;

    [Range(0.0f, float.PositiveInfinity)]
    [SerializeField]
    protected float rayRange = 10.0f;    

    private void Update()
    {
       if (isMultiple)
        {
            RayCastMultiple();
        }
        else
        {
            RayCastSimple();
        }
    }

    protected virtual void RayCastMultiple()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        drawRay(origin, direction);

        Ray ray = new Ray(origin, direction);

        var multipleRaycastHits = Physics.RaycastAll(ray);
        foreach (var raycastHit in multipleRaycastHits)
        {
            raycastHit.collider.GetComponent<Renderer>().material.color = multiRayColor;
        }
    }

    protected void drawRay(Vector3 origin, Vector3 direction)
    {
        if (doDebugRay)
        {
            Debug.DrawRay(origin, direction * debugRayDistance, debugRayTintColor);
        }
    }

    protected virtual void RayCastSimple()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        drawRay(origin, direction);

        Ray ray = new Ray(origin, direction);
        RaycastHit raycastHit;
        bool doesHit = Physics.Raycast(ray, out raycastHit, rayRange);
        if (doesHit)
        {
            raycastHit.collider.GetComponent<Renderer>().material.color = singleRayColor;
        }
    }
}
