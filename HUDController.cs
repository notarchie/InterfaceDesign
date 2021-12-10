using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{

    public TextMeshProUGUI timeText;
    float startTime;
    public TextMeshProUGUI countText;
    private int count;
    public Image health;
    public Image collected;
    public GameObject player;

    void Start()
    {
        startTime = Time.time;
        collected.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString("00");
        string seconds = (t % 60).ToString("00");
        timeText.text = minutes + ":" + seconds;

        health.fillAmount -= +0.02f * Time.deltaTime;

        if(collected >= 1)
        {
            collected.gameObject.SetActive(true);
        }


        if(health.fillAmount == 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
    }

    public void incrementCount()
    {
        count++;
        countText.text = count.ToString();
    }

    public void ReduceHealth()
    {
        health.fillAmount -= 0.1f;
    }

    public void BallSize(float sliderval)
    {
        player.transform.localScale = new Vector3(sliderval, sliderval, sliderval);
    }
}
