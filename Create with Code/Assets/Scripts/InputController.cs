using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public enum KeyboardScheme { WASDQEF, HIJKLUO}
    public KeyboardScheme keyboardScheme = KeyboardScheme.WASDQEF;

    public float GetHorizontal()
    {
        return (keyboardScheme == KeyboardScheme.WASDQEF) 
            ? Input.GetAxis("Horizontal") 
            : Input.GetAxis("Horizontal JL");
    }

    public float GetVertical()
    {
        return (keyboardScheme == KeyboardScheme.WASDQEF)
        ? Input.GetAxis("Vertical")
        : Input.GetAxis("Vertical IK");
    }

    public float GetTopDiagonal()
    {
        return (keyboardScheme == KeyboardScheme.WASDQEF)
        ? Input.GetAxis("Q and E")
        : Input.GetAxis("U and O");
    }

    public bool DoChangeView()
    {
        return (keyboardScheme == KeyboardScheme.WASDQEF)
        ? Input.GetKeyUp(KeyCode.F)
        : Input.GetKeyUp(KeyCode.H);
    }

}
