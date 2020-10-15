using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCollisionScript : MonoBehaviour
{

    public GameObject winGameObject;

    public string SceneToLoad;

    public GameObject timeGO;

    private TimerScript ts;

    private bool hasWon;

    public GameObject sfx;

    public float timeToChangeScene;
    
    private GameObject PlayerGO;

    private RtoRestart r2r;

    void Start()
    {
        ts = timeGO.GetComponent<TimerScript>();
        winGameObject.SetActive(false);
        hasWon = false;
        PlayerGO = GameObject.FindGameObjectWithTag("Player");
        r2r = PlayerGO.GetComponent<RtoRestart>();
    }

    void Update()
    {
        if(hasWon == true)
        {
            if(timeToChangeScene >= 0)
            {
                timeToChangeScene -= Time.unscaledDeltaTime;
            }
            if(Input.anyKey && timeToChangeScene < 0)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneToLoad);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Win")
        {
            r2r.canRestart = false;
            Instantiate(sfx, this.gameObject.transform.position, Quaternion.identity);
            ts.shouldUpdate = false;
            hasWon = true;
            Time.timeScale = 0;
            winGameObject.SetActive(true);
        }
    }
}
