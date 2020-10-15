using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RtoRestart : MonoBehaviour
{
    public bool canRestart;
    
    void Start() {
        canRestart = true;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && canRestart == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
