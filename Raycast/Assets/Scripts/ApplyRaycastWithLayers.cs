using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyRaycastWithLayers : ApplyRaycast
{
    [SerializeField]
    private LayerMask layer;

    protected override void RayCastMultiple()
    {
        base.RayCastMultiple();
    }

    protected override void RayCastSimple()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        drawRay(origin, direction);

        Ray ray = new Ray(origin, direction);
        RaycastHit raycastHit;
        bool doesHit = Physics.Raycast(ray, out raycastHit, rayRange, layer);
        if (doesHit)
        {
            raycastHit.collider.GetComponent<Renderer>().material.color = singleRayColor;
        }
    }
}
