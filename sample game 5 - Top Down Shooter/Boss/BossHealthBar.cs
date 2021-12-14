using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField]
    private Image HealthImage;

    private float UpdateSpeed = 0.5f;

    private float HealthBarPer;

    private void Awake()
    {
        HealthBarPer = GetComponentInParent<BossHealth>().HealthPercentage;

        //GetComponentInParent<EnemyHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealthBarPer = GetComponentInParent<BossHealth>().HealthPercentage;
        HandleHealthChange(HealthBarPer);
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
