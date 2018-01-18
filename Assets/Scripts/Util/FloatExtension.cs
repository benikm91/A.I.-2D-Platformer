using UnityEngine;
using System.Collections;

public static class FloatExtension
{
    public static float Clamp(this float val, float min, float max) 
    {
        if (val < min) return min;
        if (val > max) return max;
        return val;
    }

    public static float Overflow(this float val, float min, float max) 
    {
        float diff = (max - min);
        if (val < min) return (val + diff).Overflow(min, max);
        if (val > max) return (val - diff).Overflow(min, max);
        return val;
    }
}
