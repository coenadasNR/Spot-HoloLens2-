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


public class FrontRightCameraScript : MonoBehaviour
{
    ROSConnection ros;
    public string topicName;

    public GameObject VideoPreviewPlane = null;


    Texture2D texRos;
    private Material VideoMediaMaterial = null;
    Material TextureMaterial;

    bool isDone = false;

    public float publishMessageFrequency = 1.0f;
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {

        ROSConnection.GetOrCreateInstance().Subscribe<ImageMsg>(topicName, AddMessage);
        VideoMediaMaterial = VideoPreviewPlane.GetComponent<MeshRenderer>().material;



    }




    public void AddMessage(ImageMsg img)
    {

        timeElapsed += Time.deltaTime;

        Debug.Log(timeElapsed);

        Debug.Log(topicName);

        texRos = new Texture2D((int)img.width, (int)img.height, TextureFormat.R8, false);
        VideoMediaMaterial.mainTexture = texRos;


        texRos.LoadRawTextureData(img.data);

        texRos.Apply();




    }


}
