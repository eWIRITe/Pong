using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeCount : MonoBehaviour
{
    public TMP_Text MainTime;

    public TMP_Text MinTimeEverOnWinCanv;

    public TMP_Text NowTimeOnWinCanv;

    public string SavedName;

    private float Timer;
    private bool first = true;

    private void FixedUpdate()
    {
        Timer += Time.deltaTime;
        MainTime.text = Math.Round(Timer, 1).ToString();
        if (NowTimeOnWinCanv.IsActive())
        {
            if (first)
            {
                SetTimes();
            }
        }
    }

    void SetTimes()
    {
        float MinTime = PlayerPrefs.GetFloat(SavedName);
        if (MinTime == 0 || MinTime >= Timer) MinTime = Timer;
        PlayerPrefs.SetFloat(SavedName, MinTime);

        MinTimeEverOnWinCanv.text = Math.Round(MinTime, 1).ToString();
        NowTimeOnWinCanv.text = Math.Round(Timer, 1).ToString();
        first = false;
    }
}
