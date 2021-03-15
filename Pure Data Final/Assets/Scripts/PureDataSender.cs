﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PureDataSender : MonoBehaviour
{
    Dictionary<string, ServerLog> servers = new Dictionary<string, ServerLog>();

    // Start is called before the first frame update
    void Start()
    {
        OSCHandler.Instance.Init();
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/ready", "CONNECTION TO UNITY SUCCESSFUL!");
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/distance/enable", 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        OSCHandler.Instance.UpdateLogs();
        Dictionary<string, ServerLog> servers = new Dictionary<string, ServerLog>();
        servers = OSCHandler.Instance.Servers;
        foreach(KeyValuePair<string, ServerLog> item in servers)
        {
            if(item.Value.log.Count > 0)
            {
                int lastPacketIndex = item.Value.packets.Count - 1;
                
                Debug.Log(item.Value.packets[lastPacketIndex].Address.ToString());

                Debug.Log(item.Value.packets[lastPacketIndex].Data[0].ToString());
            }
        }
    }
}
