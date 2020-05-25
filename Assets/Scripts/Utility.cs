using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{

    public static float GetScreenWidth()
    {
        return Camera.main.aspect * Camera.main.orthographicSize;
    }

    public static float GetScreenHeight()
    {
        return Camera.main.orthographicSize;
    }

    public static Vector2 GetScreenSize()
    {
        return new Vector2(GetScreenWidth(), GetScreenHeight());
    }
}
