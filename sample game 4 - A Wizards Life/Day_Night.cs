using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_Night : MonoBehaviour
{
    Renderer rend;
    public float TIME;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        
        float scaleX = Time.time/TIME;
        rend.material.mainTextureScale = new Vector2(scaleX, 1);
    }
}
