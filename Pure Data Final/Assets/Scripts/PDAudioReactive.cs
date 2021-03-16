﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PDAudioReactive : MonoBehaviour
{
    Dictionary<string, ServerLog> servers = new Dictionary<string, ServerLog>();

    public float minFreq;
    public float maxFreq;

    public bool mel;
    
    public float frequency;
    public GameObject sprite;

    public Color restColor = new Color (0f, 0f, 0f, 0f);
    public float TimeToRest = 5f;
    
    private Image m_img;

    private void Start() {
        m_img = GetComponent<Image>();
        sprite = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        OSCHandler.Instance.UpdateLogs();
        Dictionary<string, ServerLog> servers = new Dictionary<string, ServerLog>();
        servers = OSCHandler.Instance.Servers;
        foreach(KeyValuePair<string, ServerLog> item in servers)
        {
            if(item.Value.log.Count > 0)
            {
                Debug.Log(item.Value.packets[0].Address);
                Debug.Log(item.Value.packets[0].Data[0].ToString());
                if (item.Value.packets[0].Address == "/melodyFreq"){
                    frequency = float.Parse(item.Value.packets[0].Data[0].ToString());
                }
            }
        }

        if (minFreq <= frequency && frequency < maxFreq){
            m_img.color = Color.Lerp(m_img.color, freqToColor(), TimeToRest * Time.deltaTime);
        }
        else{
            m_img.color = Color.Lerp(m_img.color, restColor, TimeToRest * Time.deltaTime);
        }
    }

    private Color freqToColor(){
        if (frequency < 33f){return new Color (148f, 0f, 211f, 255f);}
        else if (frequency < 66f){return new Color (75f, 0f, 130f, 255f);}
        else if (frequency < 131f){return new Color (0f, 0f, 255f, 255f);}
        else if (frequency < 262f){return new Color (0f, 255f, 0f, 255f);}
        else if (frequency < 523f){return new Color (255f, 255f, 0f, 255f);}
        else if (frequency < 1047f){return new Color (255f, 127f, 0f, 255f);}
        else if (frequency < 2093f){return new Color (255f, 0f, 0f, 255f);}
        else {return new Color (255f, 255f, 255f, 255f);}
    }
}
