using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObject : MonoBehaviour
{
    public AudioClip sheep;
    public AudioClip Screaming;
    public AudioClip Chicken;
    public AudioSource ObjectSound;
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    public void Shrink()
    {
        
        
        Transform temp = gameObject.transform;
        if (temp< new Vector3(temp*0.2f,temp* 0.2f, temp*0.2f))
        {
            gameObject.transform.localScale = new Vector3(temp.localScale.x / 2f, temp.localScale.y / 2, temp.localScale.z / 2);
        }
        

    }
    public void Enlarge()
    {
        Transform temp = gameObject.transform;
        if (temp < new Vector3(temp*4f, temp*4f,temp* 4f))
        {
            gameObject.transform.localScale = new Vector3(temp.localScale.x * 2f, temp.localScale.y * 2f, temp.localScale.z * 2f);
        }
           

    }
    public void Pixalator()
    {
        //Play Partical Effect;
    }
    public void GoatGun()
    {
        // add in mesh change effect
        Debug.Log("Goat");
        ObjectSound.clip = sheep;
        ObjectSound.Play();
    }
    public void ChickenGun()
    {
        // add in mesh change effect
        Debug.Log("Chicken");
        ObjectSound.clip = Chicken;
        ObjectSound.Play();
    }
    public void ScreamGun()
    {
        Debug.Log("Screaming");
        ObjectSound.clip = Screaming;
        ObjectSound.Play();
    }

}
