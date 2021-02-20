using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public SpriteRenderer gate;
    public SpriteRenderer wall;

    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = wall.bounds.size.x / gate.bounds.size.y;

        if(screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = gate.bounds.size.y / 2;
        } else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = gate.bounds.size.y / 2 * differenceInSize;
        }
    }
}
