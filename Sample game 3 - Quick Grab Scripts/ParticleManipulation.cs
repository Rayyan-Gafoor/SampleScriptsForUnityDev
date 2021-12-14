using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManipulation : MonoBehaviour
{
    public ParticleSystem part;
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem part = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ParticleManip());
    }

    IEnumerator ParticleManip()
    {
        
       
           
            var no = part.noise;
            var em = part.emission;
            var lv = part.limitVelocityOverLifetime;
            var vel = part.velocityOverLifetime;
            yield return new WaitForSeconds(2);
            Debug.Log("Phase 1");
            no.strength = 5f;
            
            yield return new WaitForSeconds(5);
            Debug.Log("Phase 2");
            lv.dampen = 0.5f;
            AnimationCurve curve = new AnimationCurve();
            curve.AddKey(0.0f, 1.0f);
            curve.AddKey(1.0f, 0.0f);
            lv.limit = new ParticleSystem.MinMaxCurve(0, curve);
            Debug.Log("Phase 3");
            AnimationCurve curve1 = new AnimationCurve();
            curve1.AddKey(0.0f, 5.0f);
            curve1.AddKey(1.0f, 0.0f);
            vel.x = Time.time;
            vel.y = 5 * Time.time;
            vel.z = 2 * Time.time;
            vel.orbitalX = Time.time;
            vel.orbitalY = 0.5f *Time.time;
            vel.orbitalZ = 0.01f * Time.time;
            yield return new WaitForSeconds(2);
            
            
            
            
            Debug.Log("end of Sytem");
        



    }
}
