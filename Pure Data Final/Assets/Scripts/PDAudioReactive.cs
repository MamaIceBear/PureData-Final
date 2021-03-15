﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PDAudioReactive : MonoBehaviour
{
    public float minScale = 25f;
    public float maxScale = 100f;

    public float scaleFactor = 1f;
    public float frequency;
    public float gain;
    public GameObject sprite;

    public Color restColor = new Color (255f, 255f, 255f, 0f);
    public Color beatColor;
    private Color defColor;
    public float TimeToRest = 5f;
    
    private Image m_img;

    private void Start() {
        m_img = GetComponent<Image>();
        sprite = gameObject;
        defColor = beatColor;
    }

    // Update is called once per frame
    void Update()
    {
        gain *= scaleFactor;
        gain = Mathf.Clamp(gain, minScale, maxScale);
        sprite.transform.localScale = new Vector3 (gain, gain, gain);

        if (gain == minScale){
            beatColor = restColor;
        }
        else{
            beatColor = freqToColor();
        }

        m_img.color = Color.Lerp(m_img.color, beatColor, TimeToRest * Time.deltaTime);
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