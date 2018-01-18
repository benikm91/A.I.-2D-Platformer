using UnityEngine;
using System.Collections;

public static class Vector2Extension
{
    public static Vector2 ClampX(this Vector2 val, float minX, float maxX) 
    {
        return new Vector2(val.x.Clamp(minX, maxX), val.y);
    }

    public static Vector2 ClampY(this Vector2 val, float minY, float maxY)
    {
        return new Vector2(val.x, val.y.Clamp(minY, maxY));
    }

    public static Vector2 Clamp(this Vector2 val, float minX, float maxX, float minY, float maxY)
    {
        return new Vector2(val.x.Clamp(minX, maxX), val.y.Clamp(minY, maxY));
    }

}
