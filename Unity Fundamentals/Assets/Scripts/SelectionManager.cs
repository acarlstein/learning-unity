using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{

    //Making it public so we can edit it with the editor
    [SerializeField]
    public bool useLayerMask;
    [SerializeField]
    public LayerMask layerMask;

    //TODO Make it an array of strings for later edition
    [SerializeField]
    private string selectableTag = "Selectable";

    [SerializeField]
    private Material highlightMaterial;

    [SerializeField]
    private Material defaultMaterial;

    private Transform currentSelection;

    // Update is called once per frame
    void Update()
    {
        if (currentSelection != null)
        {
            var selectionRenderer = currentSelection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            currentSelection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        var raycast = (useLayerMask)
            ? Physics.Raycast(ray, out hit, 50.0f, layerMask.value)
            : Physics.Raycast(ray, out hit);
        if (raycast)
        {
            var selection = hit.transform;
            debug("Tag: " + selection.tag.ToString());

            //if (selection.CompareTag(selectableTag))
            //{
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }

                currentSelection = selection;
            //}
        }
    }

    string log = "";
    void debug(string str)
    {
        if (str != log)
        {
            log = str; ;
            Debug.Log(log);
        }
    }
}
