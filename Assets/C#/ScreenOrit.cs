using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrit : MonoBehaviour
{
    public bool AutoOrient;

    // Start is called before the first frame update
    void Start()
    {
        if (AutoOrient) Screen.orientation = ScreenOrientation.AutoRotation;

        else Screen.orientation = ScreenOrientation.Portrait;
    }
}
