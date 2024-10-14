using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Vector3 ScreenToWorld(Camera camera, Vector2 screenPosition)
    {
        return camera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 10f)); //Jos ei toimi vaihda 10f toiseen arvoon niin saattaa
        // toimia !!
    }
}
