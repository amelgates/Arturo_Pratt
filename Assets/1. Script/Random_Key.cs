using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Random_Key : MonoBehaviour
{
    private int randomValue;
    private int[] keyList = new int [4];
    public Sprite[] spriteList;
    public GameObject panel;
    void Start()
    {
        keyList[0] = (int)KeyCode.LeftArrow;
        keyList[1] = (int)KeyCode.RightArrow;
        keyList[2] = (int)KeyCode.UpArrow;
        keyList[3] = (int)KeyCode.DownArrow;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomKeyGenerator();
        }
    }
    void RandomKeyGenerator() 
    {
        randomValue = Random.Range(0, 4);
        QuickTimeEventCase(randomValue);
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
