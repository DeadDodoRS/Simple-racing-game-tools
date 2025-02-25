﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FPSCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textField;
    private float updateInterval = 0.5F;
    private float accum = 0; // FPS accumulated over the interval
    private int frames = 0; // Frames drawn over the interval
    private float timeleft; // Left time for current interval

    void Start()
    { 
        timeleft = updateInterval;
    }

    void Update()
    {
        fpsCounter();
    }
    
    private void fpsCounter()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        // Interval ended - update GUI text and start new interval
        if (timeleft <= 0.0)
        {
            // display two fractional digits (f2 format)
            float fps = accum / frames;
            string format = System.String.Format("{0:F1}", fps);
            textField.text = format;

            if (fps < 30)
            {
                textField.color = Color.yellow;
            }
            else
            {
                if (fps < 10)
                    textField.color = Color.red;
                else
                    textField.color = Color.green;
            }

            //	DebugConsole.Log(format,level);
            timeleft = updateInterval;
            accum = 0.0F;
            frames = 0;
        }
    }
}