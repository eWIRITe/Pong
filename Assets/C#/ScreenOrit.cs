using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrit : MonoBehaviour
{
    public List<Transform> PortretPos = new List<Transform>();

    public List<Transform> LandScapePos = new List<Transform>();

    public List<GameObject> ChangeOrientationObjects = new List<GameObject>();

    public bool AutoOrient;

    public enum Orientations { Portriet, LandScape }

    public Orientations Orientation = Orientations.Portriet;

    private Orientations NewOrientation;

    // Start is called before the first frame update
    void Start()
    {
        if (AutoOrient) Screen.orientation = ScreenOrientation.AutoRotation;

        else Screen.orientation = ScreenOrientation.Portrait;
    }

    void Update()
    {

        switch (Input.deviceOrientation) {

            case DeviceOrientation.Portrait:
                NewOrientation = Orientations.Portriet;
                break;

            case DeviceOrientation.LandscapeLeft:
                NewOrientation = Orientations.LandScape;
                break;

            case DeviceOrientation.LandscapeRight:
                NewOrientation = Orientations.LandScape;
                break;


            default:
                NewOrientation = Orientation;
                break;
        }

        if(NewOrientation != Orientation)
        {
            ChangeOrientation();
        }
    }

    void ChangeOrientation()
    {
        if(NewOrientation == Orientations.Portriet)
        {
            for(int i = 0; i < ChangeOrientationObjects.Count; i++)
            {
                ChangeOrientationObjects[i].transform.position = PortretPos[i].position;
                ChangeOrientationObjects[i].transform.rotation = PortretPos[i].rotation;
            }
        }
        else
        {
            for (int i = 0; i < ChangeOrientationObjects.Count; i++)
            {
                ChangeOrientationObjects[i].transform.position = LandScapePos[i].position;
                ChangeOrientationObjects[i].transform.rotation = LandScapePos[i].rotation;
            }
        }
    }
}
