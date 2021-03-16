using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGainReactive : MonoBehaviour
{
    public AudioSource audioSource;
    public float updateStep = 0.1f;
    public int sampleDataLen = 1024;

    private float currentUpdateTime = 0f;

    public float clipGain;
    private float[] clipSampData;

    public GameObject sprite;
    public float sizeFactor = 1;

    public float minSize = 0;
    public float maxSize = 500;

    private void Awake() {
        clipSampData = new float[sampleDataLen];
    }

    private void Update() {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep){
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampData, audioSource.timeSamples);
            clipGain = 0f;
            foreach (var sample in clipSampData){
                clipGain += Mathf.Abs(sample);
            }
            clipGain /= sampleDataLen;

            clipGain *= sizeFactor;
            clipGain = Mathf.Clamp(clipGain, minSize, maxSize);
            sprite.transform.localScale = new Vector3(clipGain, clipGain, clipGain);

        }
    }

}
