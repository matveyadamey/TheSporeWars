using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer1 : MonoBehaviour
{
    public static void DeleteObject(GameObject obj, Point p)
    {
        obj.SetActive(false);
        MapObject.DeleteObject(p);
    }
}
