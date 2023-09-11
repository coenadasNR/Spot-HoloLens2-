using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.UnityRoboticsDemo;
using RosMessageTypes.WebotsSpot;


/// <summary>
///
/// </summary>
public class RosPublisherExample : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "/Spot/inverse_gait_input";

    // The game object
    //public GameObject cube;
    public string myText;
    // Publish the cube's position and rotation every N seconds
    public float publishMessageFrequency = 0.5f;

    // Used to determine how much time has elapsed since the last message was published
    private float timeElapsed;
    double speed = 1.0;
    double turn = 0.5;
    double x = 0.0;
    double y = 0.0;
    double z = 0.1;
    double roll = 0.0;
    double pitch = 0.0;
    double yaw = 0.0;
    double StepLength = 0.024;
    double StepDirection = 0; // 1: to move forward and 0: to stop
    double LateralFraction = 0.0;
    double YawRate = 0.0;
    double StepVelocity = 0.01;
    double ClearanceHeight = 0.024;
    double PenetrationDepth = 0.003;
    double SwingPeriod = 0.2;
    double YawControl = 0.0;
    double YawControlOn = 0.0;

    void Start()
    {
        // start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<GaitInputMsg>(topicName);

    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        

        if (timeElapsed > publishMessageFrequency)
        {
            //cube.transform.rotation = Random.rotation;

            //x = 1.0;

            GaitInputMsg cubePos = new GaitInputMsg(

                            x,
                            y,
                            z,
                            roll,
                            pitch,
                            yaw,
                            StepLength * StepDirection * speed,
                            LateralFraction,
                            YawRate * turn,
                            StepVelocity,
                            ClearanceHeight,
                            PenetrationDepth,
                            SwingPeriod,
                            YawControl,
                            YawControlOn

            );

            // Finally send the message to server_endpoint.py running in ROS
            ros.Publish(topicName, cubePos);

            timeElapsed = 0;
        }
    }
}