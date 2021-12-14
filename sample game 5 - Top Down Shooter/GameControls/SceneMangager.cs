using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMangager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Turtorial");
    }
    public void exit()
    {
        Application.Quit();
    }

}
