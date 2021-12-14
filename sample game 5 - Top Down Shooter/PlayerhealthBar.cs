using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerhealthBar : MonoBehaviour
{
    [SerializeField]
    private Image HealthImage;
    [SerializeField]
    private Text healthNumber;
    [SerializeField]
    private Text WaveCounter;

    private float UpdateSpeed = 0.5f;

    private float HealthBarPer;
    private float healthNum;

    private float WaveNumber;
    

    private void Awake()
    {
        
        HealthBarPer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().HealthPercentage;
        WaveNumber = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveSpawner>().nextWave;
        //GetComponentInParent<EnemyHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealthBarPer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().HealthPercentage;
        WaveNumber = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveSpawner>().nextWave+1;
        HandleHealthChange(HealthBarPer);
        healthNum= HealthBarPer * 69;
        healthNumber.text = healthNum + "/69";
        WaveCounter.text = "Wave: " + WaveNumber;
    }
    void HandleHealthChange(float Percent)
    {
        //Percent = HealthBarPer;
        StartCoroutine(BarToPer(Percent));
    }
    private IEnumerator BarToPer(float PCT)
    {
        float preChangePct = HealthImage.fillAmount;
        float Elapsed = 0f;
        while (Elapsed < UpdateSpeed)
        {
            Elapsed += Time.deltaTime;
            HealthImage.fillAmount = Mathf.Lerp(preChangePct, PCT, Elapsed / UpdateSpeed);
            yield return null;

        }
        HealthImage.fillAmount = PCT;
        //HealthImage.fillAmount = Mathf.Lerp(preChangePct, PCT, Elapsed / UpdateSpeed);
    }

}
