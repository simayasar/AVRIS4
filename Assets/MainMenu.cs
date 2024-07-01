using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    private GameObject canvas;
   public void StartApp()
    {
        canvas = GameObject.Find("Canvas");
        canvas.SetActive(false);

    }

    public void QuitApp()
    {
        Application.Quit();
    }






}
