using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRoar : MonoBehaviour
{

    public AudioSource audioSource;
    public CaptureColor captureColor;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float vol = captureColor.AverageGreyscale;
        audioSource.volume = PMap(0.0f, 1.0f, 0.2f, 0.5f,  vol);
    }

    public float PMap(float from, float to, float from2, float to2, float value)
    {
        if (value <= from2)
        {
            return from;
        }
        else if (value >= to2)
        {
            return to;
        }
        else
        {
            return (to - from) * ((value - from2) / (to2 - from2)) + from;
        }
    }

}
