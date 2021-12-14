using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    public float Speed = 1.0f;
    public Color StartColor;
    public Color EndColor;
    public bool repeat = false;

    float StartTime;

    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!repeat)
        {
            float t = (Time.time - StartTime) * Speed;
            GetComponent<Renderer>().material.color = Color.Lerp(StartColor, EndColor, t);
        }
        else
        {
            float t = (Mathf.Sin(Time.time - StartTime) * Speed);
            GetComponent<Renderer>().material.color = Color.Lerp(StartColor, EndColor, t);
        }
       
    }
}
