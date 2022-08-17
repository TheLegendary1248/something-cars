using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Handles all Settings
/// </summary>
public static class Settings
{
    public static Dictionary<string, object> settings = new Dictionary<string,object>();
    [RuntimeInitializeOnLoadMethod]
    static void Init()
    {
        
    }
}
