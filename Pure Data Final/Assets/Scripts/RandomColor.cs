using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public List<Color> colorList = new List<Color>();
    void Start()
    {
        Renderer[] rends = GetComponentsInChildren<Renderer>();
        int randomNumber = Random.Range(0, colorList.Count);
        Color randomColor = colorList[randomNumber];
        for(int i = 0; i < rends.Length; i++)
        {
            rends[i].material.color = randomColor;
        }
    }
}
