using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public enum KeyboardScheme { WASDQE, IJKLUO}
    public KeyboardScheme keyboardScheme = KeyboardScheme.WASDQE;

    public float GetHorizontal()
    {
        return (keyboardScheme == KeyboardScheme.WASDQE) 
            ? Input.GetAxis("Horizontal") 
            : Input.GetAxis("Horizontal JL");
    }

    public float GetVertical()
    {
        return (keyboardScheme == KeyboardScheme.WASDQE)
        ? Input.GetAxis("Vertical")
        : Input.GetAxis("Vertical IK");
    }

    public float GetTopDiagonal()
    {
        return (keyboardScheme == KeyboardScheme.WASDQE)
        ? Input.GetAxis("Q and E")
        : Input.GetAxis("U and O");
    }
}
