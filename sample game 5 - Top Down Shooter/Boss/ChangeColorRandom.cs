using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorRandom : MonoBehaviour
{
    public float ChangeTime = 0.1f;
    public float lerpTime = 0.1f;

    private float Elapse = 0;
    private Renderer Sprite;
    private void Awake()
    {
        Sprite = GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color Ori = Sprite.material.color;
        Elapse += Time.deltaTime;
        if (Sprite !=null && Elapse>= ChangeTime)
        {
            Color newColor = new Color(
                Random.value,
                Random.value,
                Random.value
                );
           // Sprite.material.color = newColor;

            Sprite.material.color = Color.Lerp(Ori, newColor, lerpTime);
            Sprite.material.color = newColor;
            Elapse = 0f;
        }
    }
}
