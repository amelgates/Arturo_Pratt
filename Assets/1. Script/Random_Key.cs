using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Key : MonoBehaviour
{
    public int randomValue;
    private int[] keyList = new int [4];
    void Start()
    {
        keyList[0] = (int)KeyCode.LeftArrow;
        keyList[1] = (int)KeyCode.RightArrow;
        keyList[2] = (int)KeyCode.UpArrow;
        keyList[3] = (int)KeyCode.DownArrow;
    }
    void Update(Event e)
    {
       randomValue = Random.Range(0, 3);
       Debug.Log("valor arreglo:" + keyList[randomValue].ToString());

       // switch ((int)e.keyCode)
       // {
       //     case 274: 
       //     default;
       // }

    }
}
