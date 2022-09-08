using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Random_Key : MonoBehaviour
{
    private int randomValue;
    private int[] keyList = new int [4];
    public Sprite[] spriteList;
    public GameObject panel;
    public int correctKey;
    public int waitingForKey;
    public int CountingDown;
    public VideoPlayer videoPlayer;
    public VideoClip[] videoList;
    private int videoIndex;
    public double time;
    public double currentTime;
    public bool videoPlaying;
    public bool isDone;
    public float timer = 3;
    public GameObject gameOverPanel;
    public bool isDoned
    {
        get
        {
            return isDone;
        }
    }

    private void Awake()
    {
        videoIndex = 0;
        waitingForKey = 0;
        CountingDown = 0;
        randomValue = 5;
        videoPlayer.GetComponent<VideoPlayer>().clip = videoList[videoIndex];
        time = videoPlayer.GetComponent<VideoPlayer>().clip.length;
        videoPlaying = true;
    }

    private void OnEnable()
    {
        videoPlayer.loopPointReached += loopPointReached;
        videoPlayer.prepareCompleted += prepareCompleted;
    }

    void prepareCompleted(VideoPlayer v)
    {
        isDone = false;
    }
    void loopPointReached(VideoPlayer v)
    {
        isDone = true;
        Debug.Log("termino el video");
        waitingForKey = 1;

        videoIndex += 1;
        if (videoIndex >= 6)
        {
            Application.Quit();
        }
    }
    void Start()
    {
        keyList[0] = (int)KeyCode.LeftArrow;
        keyList[1] = (int)KeyCode.RightArrow;
        keyList[2] = (int)KeyCode.UpArrow;
        keyList[3] = (int)KeyCode.DownArrow;
    }

    private void Update()
    {
        Debug.Log(isDone);
        Debug.Log(waitingForKey);
        if (!isDone)
        {
            return;
        }
        else
        {
            if (waitingForKey == 1)
            {
                randomValue = Random.Range(0, 4);
                panel.SetActive(true);
                switch (keyList[randomValue])
                {
                    case 274:
                        panel.SetActive(true);
                        panel.GetComponent<Image>().sprite = spriteList[3];
                        break;
                    case 276:
                        panel.SetActive(true);
                        panel.GetComponent<Image>().sprite = spriteList[0];
                        break;
                    case 275:
                        panel.SetActive(true);
                        panel.GetComponent<Image>().sprite = spriteList[1];
                        break;
                    case 273:
                        panel.SetActive(true);
                        panel.GetComponent<Image>().sprite = spriteList[2];
                        break;
                }
                CountingDown = 1;
                waitingForKey = 2;
            }
            if (randomValue == 0)
            {

                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        correctKey = 1;
                    }
                    else
                    {
                        correctKey = 2;
                    }
                    StartCoroutine(KeyPressed());
                }
            }
            if (randomValue == 1)
            {

                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        correctKey = 1;
                    }
                    else
                    {
                        correctKey = 2;
                    }
                    StartCoroutine(KeyPressed());
                }
            }
            if (randomValue == 2)
            {

                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        correctKey = 1;
                    }
                    else
                    {
                        correctKey = 2;
                    }
                    StartCoroutine(KeyPressed());
                }
            }
            if (randomValue == 3)
            {
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        correctKey = 1;
                    }
                    else
                    {
                        correctKey = 2;
                    }
                    StartCoroutine(KeyPressed());
                }
            }
        }
    }

    IEnumerator TimerCoroutine()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            
            if(timer<= 0)
            {
                gameOverPanel.SetActive(true);
            }
        }
        if (correctKey == 1)
        {
            timer = 3f;
        }
        yield return null;
    }

    IEnumerator KeyPressed()
    {
        randomValue = 4;
        if (correctKey == 1)
        {
            CountingDown = 2;
            correctKey = 0;
            videoPlayer.GetComponent<VideoPlayer>().clip = videoList[videoIndex];
            videoPlayer.Prepare();
        }
        else
        {
            gameOverPanel.SetActive(true);
            isDone = false;
        }
        panel.SetActive(false);
        yield return null;
    }

}
