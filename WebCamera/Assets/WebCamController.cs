using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCamController : MonoBehaviour
{
    int width = 1920;
    int height = 1080;
    int fps = 30;
    WebCamTexture webcamTexture;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        webcamTexture = new WebCamTexture(devices[0].name, this.width, this.height, this.fps);
        GetComponent<Renderer>().material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (webcamTexture != null)
            {
                Debug.Log("Pause");
                webcamTexture.Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (webcamTexture != null)
            {
                Debug.Log("Play");
                webcamTexture.Play();
//                SaveToPNGFile(webcamTexture.GetPixels(), Application.dataPath + "/../SavedScreen.png");
            }
        }
    }

    void SaveToPNGFile(Color[] texData, string filename)
    {
        Texture2D takenPhoto = new Texture2D(width, height, TextureFormat.ARGB32, false);

        takenPhoto.SetPixels(texData);
        takenPhoto.Apply();

        byte[] png = takenPhoto.EncodeToPNG();
        Destroy(takenPhoto);

        // For testing purposes, also write to a file in the project folder
 //       File.WriteAllBytes(filename, png);
    }

}