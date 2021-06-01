using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{

    [SerializeField]
    private TextMesh textMesh;

    public string text { get; set; }

    // Update is called once per frame
    void FixedUpdate()
    {
        textMesh.text = text;
    }
}
