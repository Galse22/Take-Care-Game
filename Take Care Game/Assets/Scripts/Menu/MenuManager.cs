﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame () 
    {
       SceneManager.LoadScene(2);
    }

    public void AboutGame()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void QuitGame ()
    {
       Debug.Log ("QUIT!");
       Application.Quit();
    }
    
}
