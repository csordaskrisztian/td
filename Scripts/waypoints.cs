using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoints : MonoBehaviour
{
    public List<GameObject> route1;
    public List<GameObject> route2;
    public List<GameObject> route3;
    public static List<GameObject> routestatic1;
    public static List<GameObject> routestatic2;
    public static List<GameObject> routestatic3;
    private void Awake()
    {
        routestatic1 = route1;
        routestatic2 = route2;
        routestatic3 = route3;


    }
}
