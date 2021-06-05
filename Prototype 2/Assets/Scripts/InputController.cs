using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController
{
    public static float GetHorizontal()
    {
        return Input.GetAxis("Horizontal");
    }

    public static bool DoShoot()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
