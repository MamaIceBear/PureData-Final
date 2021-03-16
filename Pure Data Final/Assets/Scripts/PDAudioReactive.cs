using System.Collections;
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
    public Color beatColor;
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
                if (item.Value.packets[0].Address == "/melodyFreq"){
                    Debug.Log(item.Value.packets[0].Address);
                    Debug.Log(item.Value.packets[0].Data[0].ToString());
                    frequency = float.Parse(item.Value.packets[0].Data[0].ToString());
                }
            }
        }

        if (minFreq <= frequency && frequency < maxFreq){
            m_img.color = Color.Lerp(m_img.color, beatColor, TimeToRest * Time.deltaTime);
        }
        else{
            m_img.color = Color.Lerp(m_img.color, restColor, TimeToRest * Time.deltaTime);
        }
    }
}
