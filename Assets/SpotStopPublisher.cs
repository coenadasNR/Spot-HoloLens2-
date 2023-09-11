using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosState = RosMessageTypes.Std.BoolMsg;
using RosMessageTypes.WebotsSpot;
using JetBrains.Annotations;
using System;

public class SpotStopPublisher : MonoBehaviour
{
    // Start is called before the first frame update
    ROSConnection ros;

    public string topicName = "/start_turn"; // give topic name

    bool isDone = false;



    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<RosState>(topicName, latch:true);
        
        


    }

    public void OnEnable()
    {
        Debug.Log("isDone is now false");
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
            Debug.Log("Stop Message Published");
            ros.Publish(topicName, sendMessage);


            isDone = true;
        }





    }
}
