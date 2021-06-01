using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{

    [Header("Debug Section")]

    [SerializeField]
    private bool doDebugRay = false;

    [SerializeField]
    private Color debugRayTintColor = Color.red;

    [Range(0.0f, float.PositiveInfinity)]
    [SerializeField]
    private float debugRayDistance = 20.0f;

    [Header("Settings")]

    [SerializeField]
    private Camera camera;

    [SerializeField]
    private Color singleRayColor = Color.blue;

    [Range(0.0f, float.PositiveInfinity)]
    [SerializeField]
    private float rayRange = 20.0f;

    public Camera Camera { get => camera; set => camera = value; }

    private void OnValidate()
    {
        if (null == Camera)
        {
            Camera = Camera.main;
        }
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        drawRay(ray.origin, ray.direction);
        RaycastHit raycastHit;
        bool doesHit = Physics.Raycast(ray, out raycastHit, rayRange);
        if (doesHit)
        {
            raycastHit.collider.GetComponent<Renderer>().material.color = singleRayColor;
        }

    }
    private void drawRay(Vector3 origin, Vector3 direction)
    {
        if (doDebugRay)
        {
            Debug.DrawRay(origin, direction * debugRayDistance, debugRayTintColor);
        }
    }
}
