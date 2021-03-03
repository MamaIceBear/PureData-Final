using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, Vector3.down, GetComponent<BoxCollider>().size.y / 2 + 0.4f))
        {
            Quaternion rot = transform.rotation;
            rot.z = Mathf.Round(rot.z / 90) * 90;
            transform.rotation = rot;
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector2.up * 55000)
            }
        }
        else
        {
            transform.Rotate(Vector3.back * 5f);
        }
    }
}
