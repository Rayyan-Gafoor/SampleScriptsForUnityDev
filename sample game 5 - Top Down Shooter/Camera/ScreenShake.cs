using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public IEnumerator ShakeScreen(float Length, float Strength)
    {
        Vector3 orignalPostion = transform.position;
        float timePassed = 0f;

        while (timePassed < Length)
        {
            float x = Random.Range(-1f,1f) * Strength;
            float y = Random.Range(-1f,1f) * Strength;

            transform.position = new Vector3(x, y, orignalPostion.z);
            timePassed++;
            Debug.Log(timePassed);
            //timePassed += Time.deltaTime;
            //yield return new WaitForSeconds(2);
            yield return null;
        }
        transform.position = orignalPostion;
        //yield return null;
        //yield return new WaitForSeconds(2);
    }
}
