using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePE : MonoBehaviour
{
    // gameManager managerScript;

    public float up_y, down_y, side1, side2;
    public float speed = 0.02f;

    private Vector3 up, down, first, sec;


    // Start is called before the first frame update
    void Start()
    {
        first = new Vector3(transform.position.x, transform.position.y, side1);
        sec = new Vector3(transform.position.x, transform.position.y, side2);
        up = new Vector3(transform.position.x, up_y, transform.position.z);
        down = new Vector3(transform.position.x, down_y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(first, sec, Mathf.PingPong(Time.time * speed, 1f));
        transform.position = Vector3.Lerp(up, down, Mathf.PingPong(Time.time * speed, 1f));
    }
}
