using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Random_Key : MonoBehaviour
{
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
    public GameObject creditsPanel;
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
            creditsPanel.SetActive(true);
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
        if (!isDone)
        {
            return;
        }
        else
        {
            if (waitingForKey == 1)
            {
                StartCoroutine(CountDown());
                switch (videoIndex)
                {
                    case 1:
                        panel.SetActive(true);
                        panel.GetComponent<Image>().sprite = spriteList[2];
                        break;
                    case 2:
                        panel.SetActive(true);
                        panel.GetComponent<Image>().sprite = spriteList[2];
                        break;
                    case 3:
                        panel.SetActive(true);
                        panel.GetComponent<Image>().sprite = spriteList[0];
                        break;
                    case 4:
                        panel.SetActive(true);
                        panel.GetComponent<Image>().sprite = spriteList[1];
                        break;
                    case 5:
                        panel.SetActive(true);
                        panel.GetComponent<Image>().sprite = spriteList[3];
                        break;
                    case 6:
                        break;
                }
                CountingDown = 1;
                waitingForKey = 2;
            }
            if (videoIndex == 3)
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
            if (videoIndex == 4)
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
            if (videoIndex == 1 || videoIndex == 2)
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
            if (videoIndex==5)
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

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(3);
        if (CountingDown == 1)
        {
            waitingForKey = 0;
            CountingDown = 2;
            gameOverPanel.SetActive(true);
            isDone = false;
            panel.SetActive(false);
        }
        else
        {
            yield return null;
        }
    }

    IEnumerator KeyPressed()
    {
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
