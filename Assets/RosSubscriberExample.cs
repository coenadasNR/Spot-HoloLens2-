using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosColor = RosMessageTypes.Std.BoolMsg;

public class RosSubscriberExample : MonoBehaviour
{
    public GameObject cube;

    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<RosColor>("color", ColorChange);
    }

    void ColorChange(RosColor colorMessage)


    {
        if (colorMessage.data == true)
        {
            cube.GetComponent<Renderer>().material.color = new Color32((byte)200, (byte)190, (byte)170, (byte)1);

        }

        else
        
        {
            cube.GetComponent<Renderer>().material.color = new Color32((byte)80, (byte)70, (byte)2, (byte)1);

        }
        
    }
}
