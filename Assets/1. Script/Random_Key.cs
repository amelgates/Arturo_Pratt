using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Key : MonoBehaviour
{
    private int randomValue;
    private int[] keyList = new int [4];
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
        switch (keyList[e])
        {
            case 274:
                Debug.Log("Presiona la flecha abajo");
                break;
            case 276:
                Debug.Log("Presiona la flecha izquierda");
                break;
            case 275:
                Debug.Log("Presiona la flecha derecha");
                break;
            case 273:
                Debug.Log("Presiona la flecha arriba");
                break;
        }
    }
}
