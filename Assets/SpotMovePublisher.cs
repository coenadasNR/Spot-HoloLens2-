using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosState = RosMessageTypes.Std.BoolMsg;
using RosMessageTypes.WebotsSpot;
using System;

public class SpotMovePublisher : MonoBehaviour
{
    // Start is called before the first frame update
    ROSConnection ros;

    public string topicName = "/start_path"; // give topic name

    bool isDone = false;

    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<RosState>(topicName, latch:true);
        Debug.Log("isDone is now false");
        isDone = false;
    }

    public void OnEnable()
    {
        isDone = false;

    }


    // Update is called once per frame
    void Update()
    {

        if (!isDone)
        {
            // put your code that runs once here
            RosState sendMessage = new RosState(true);

            // Finally send the message to server_endpoint.py running in ROS
            Debug.Log("Start Message Published");
            ros.Publish(topicName, sendMessage);


            isDone = true;
        }


    }
}
