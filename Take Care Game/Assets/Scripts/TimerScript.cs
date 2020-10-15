using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public float TimeLevel;
    public GameObject loseGameObject;

    public Slider slider;

    public GameObject sfx;

    private float maxVALUE;

    private bool haventShakedYet;

    public bool shouldUpdate;

    public float timeToChangeScene;

    private GameObject PlayerGO;

    private RtoRestart r2r;

    void Start() {
        shouldUpdate = true;
        loseGameObject.SetActive(false);
        maxVALUE = TimeLevel;
        haventShakedYet = true;
        slider.maxValue = maxVALUE;
        slider.value = maxVALUE;
        PlayerGO = GameObject.FindGameObjectWithTag("Player");
        r2r = PlayerGO.GetComponent<RtoRestart>();
    }

    void Update()
    {
        if(shouldUpdate == true)
        {
            if(TimeLevel > 0)
        {
            TimeLevel -= Time.deltaTime;
            SetTime(TimeLevel);
        }
        if(TimeLevel <= 0)
        {
            if(haventShakedYet == true)
            {
                r2r.canRestart = false;
                Instantiate(sfx, this.gameObject.transform.position, Quaternion.identity);
                loseGameObject.SetActive(true);
                CinemachineShake.Instance.ShakeCamera(30f, .1f);
                haventShakedYet = false;
                Time.timeScale = 0;
            }

            if(timeToChangeScene >= 0)
            {
                timeToChangeScene -= Time.unscaledDeltaTime;
            }

            if(Input.anyKey && timeToChangeScene < 0)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        }
    }

    public void SetTime(float time)
    {
        slider.value = time;
    }
}
