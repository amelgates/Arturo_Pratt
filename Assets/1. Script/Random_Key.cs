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
    public GameObject videoPlayer;
    public VideoClip[] videoList;
    private int videoIndex;
    public double time;
    public double currentTime;
    public bool videoPlaying;

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
    void Start()
    {
        keyList[0] = (int)KeyCode.LeftArrow;
        keyList[1] = (int)KeyCode.RightArrow;
        keyList[2] = (int)KeyCode.UpArrow;
        keyList[3] = (int)KeyCode.DownArrow;
    }

    private void Update()
    {
        if (videoPlaying)
        {
            currentTime = videoPlayer.GetComponent<VideoPlayer>().time;
            if(currentTime >= time)
            {
                waitingForKey = 1;
                videoPlaying = false;
            }
        }
        else
        {
            if (waitingForKey == 1)
            {
                randomValue = Random.Range(0, 4);
                QuickTimeEventCase(randomValue);
                CountingDown = 1;
                waitingForKey = 2;
            }
            if (randomValue == 0)
            {
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown("left"))
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
                    if (Input.GetKeyDown("right"))
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
                    if (Input.GetKeyDown("up"))
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
                    if (Input.GetKeyDown("down"))
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

    IEnumerator KeyPressed()
    {
        randomValue = 4;
        if (correctKey == 1)
        {
            CountingDown = 2;
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
        }
    }

    void QuickTimeEventCase(int e)
    {
        panel.SetActive(true);
        switch (keyList[e])
        {
            case 274:
                panel.GetComponent<Image>().sprite = spriteList[3];
                break;
            case 276:
                panel.GetComponent<Image>().sprite = spriteList[0];
                break;
            case 275:
                panel.GetComponent<Image>().sprite = spriteList[1];
                break;
            case 273:
                panel.GetComponent<Image>().sprite = spriteList[2];
                break;
        }
    }
}
