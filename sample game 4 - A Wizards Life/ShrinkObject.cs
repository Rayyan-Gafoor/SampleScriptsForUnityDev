using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkObject : MonoBehaviour
{

    Vector3 minScale;
    public Vector3 MeltScale;
    public float speed = 2f;
    public float Duration = 5f;
    public bool Melting = false;

    private void Update()
    {
        if (Melting == true)
        {
            Melt();
        }
    }


    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f)
        {
            i = i + Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }

    void Melt()
    {
        minScale = transform.localScale;
       
        
            StartCoroutine(RepeatLerp(minScale, MeltScale, Duration));

    }
}
