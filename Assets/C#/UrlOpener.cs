using System.Collections;
using System.Collections.Generic;
using Unity.RemoteConfig;
using UnityEngine;

public class UrlOpener : MonoBehaviour
{
    public string URL;
    public struct userAttributes { }
    public struct appAttributes { }

    void Start()
    {
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());

        URL = ConfigManager.appConfig.GetString("httpAdres");

        Application.OpenURL(URL);

        infra.OpenURL(URL);
    }
}
