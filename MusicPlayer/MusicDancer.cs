using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicDancer : MonoBehaviour
{
    public List<Transform> cubes;
    public float[] spectrum; 
    public const int num_bins = 32;
    public float height_scale = 10;
    public float height_max = (float)5;
    
    public float delta_time = (float)0.1; // 更新时间间隔
    public float remain_timer; // 64 <= spectrum <= 8192

    private void Start()
    {
        // initialize cubes
        for(int i =0; i<num_bins; i++)
            cubes.Add(transform.GetChild(i));
        // initialize remain_timer
        remain_timer = delta_time;
        
        // debug
        Thread.Sleep(500);
    }

    void Update()
    {
        if (remain_timer > 0)
        {
            remain_timer -= Time.deltaTime;
            return;
        }
        
        spectrum = new float[256];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        for (int i = 0; i < num_bins; i++)
        {
            float height = height_scale * spectrum[i]; // Max height: 2.245934 Min height: 0.02674123
            // debug: analyze height dist
            if (height > height_max)
                height = height_max;
            try
            {
                cubes[i].transform.localScale =
                    new Vector3(cubes[i].localScale.x, height, cubes[i].localScale.z);
            }
            catch (Exception e)
            {
                Debug.Log("Exception: {e.Message}");
            }
        }

        remain_timer = delta_time;
    }
}