using UnityEngine;

public class Utilities
{
    public static T Choice<T>(T[] apps)
    {
        int idx = Random.Range(0, apps.Length);
        return apps[idx];
    }
}
