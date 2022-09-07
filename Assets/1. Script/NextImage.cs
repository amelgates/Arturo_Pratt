using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextImage : MonoBehaviour
{
    public Sprite[] spriteList;
    public GameObject panel;
    private int index;

    private void Awake()
    {
        index = 0;
        panel.GetComponent<Image>().sprite = spriteList[index];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeImage();
        }
    }

    void ChangeImage()
    {
        index = index + 1;
        panel.GetComponent<Image>().sprite = spriteList[index];
    }
}
