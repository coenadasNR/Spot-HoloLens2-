using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Sensor;
using UnityEngine.UI;
using System.Text;
using System;
using UnityEngine.EventSystems;


public class VideoSubscriber : MonoBehaviour
{
    ROSConnection ros;
    public string topicName;

    public RawImage display;

    Texture2D texRos;
    Material TextureMaterial;

    bool isDone = false;

    public float publishMessageFrequency = 1.0f;
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        
        ROSConnection.GetOrCreateInstance().Subscribe<ImageMsg>(topicName, AddMessage);
        TextureMaterial = new Material(Shader.Find("Unlit/ImageMsg"));
        
    }




    public void AddMessage(ImageMsg img)
    {

        timeElapsed += Time.deltaTime;

        Debug.Log(timeElapsed);

        Debug.Log(topicName);
        texRos = new Texture2D((int)img.width, (int)img.height, TextureFormat.R8, false); // , TextureFormat.RGB24
        TextureMaterial.SetFloat("_gray", img.GetNumChannels() == 1 ? 1.0f : 0.0f);

        texRos.LoadRawTextureData(img.data);

        texRos.Apply();
        display.texture = texRos;
 

        //if (timeElapsed > publishMessageFrequency)
        //{
            

        //    timeElapsed = 0;

        //}
        //else
        //{

        //    //Debug.Log("Not subscribing to topic");
        //}




    }




}

