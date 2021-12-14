using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurtorialButtons : MonoBehaviour
{
    public GameObject[] slides;
    public int SlideNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        SlideNumber = 0;
        slides[SlideNumber].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextSlide()
    {
        if (SlideNumber == 3)
        {
            SlideNumber = 3;
            slides[SlideNumber].SetActive(true);

        }
        else if (SlideNumber<3) 
        {
            slides[SlideNumber].SetActive(false);
            slides[SlideNumber + 1].SetActive(true);
            SlideNumber++;
        }
        
    }
    public void PrevSlide()
    {
        if (SlideNumber == 0)
        {
            SlideNumber = 0;
            slides[SlideNumber].SetActive(true);

        }
        else if (SlideNumber >0)
        {
            slides[SlideNumber].SetActive(false);
            slides[SlideNumber - 1].SetActive(true);
            SlideNumber--;
        }

    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
