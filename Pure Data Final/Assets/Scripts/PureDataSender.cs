using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PureDataSender : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OSCHandler.Instance.Init();
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/ready", "CONNECTION TO UNITY SUCCESSFUL!");
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/distance/enable", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
