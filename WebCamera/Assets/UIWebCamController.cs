using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWebCamController : MonoBehaviour
{
    public int width = 1920;
    public int height = 1080;
    //    int width = 1080;
    //    int height = 1920;
    int fps = 60;
    WebCamTexture webcamTexture;
    public float Alpha = 0.5f;
    RawImage rawimage;


    void Start()
    {
        //  WebCamDevice[] devices = WebCamTexture.devices;
        //  
        //  webcamTexture = new WebCamTexture(devices[devices.Length - 1].name, this.width, this.height, this.fps);
        //  GetComponent<Renderer>().material.mainTexture = webcamTexture;
        //  webcamTexture.Play();


        rawimage = this.GetComponents<RawImage>()[0];

        WebCamDevice[] devices = WebCamTexture.devices;
        // display all cameras
        for (var i = 0; i < devices.Length; i++)
        {
            Debug.Log(i.ToString() + ": " + devices[i].name);
        }
        WebCamTexture webcamTexture = new WebCamTexture(devices[devices.Length - 1].name, this.width, this.height, this.fps);

        rawimage.texture = webcamTexture;
        rawimage.material.mainTexture = webcamTexture;
        rawimage.color = new Color(rawimage.color.r, rawimage.color.g, rawimage.color.b, Alpha);

        webcamTexture.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //            if (webcamTexture != null)
            //            {

            rawimage.color = new Color(rawimage.color.r, rawimage.color.g, rawimage.color.b, 0f);
            Debug.Log("Pause");
            rawimage.color = new Color(rawimage.color.r, rawimage.color.g, rawimage.color.b, Alpha);
            Alpha = Alpha - 0.01f;
            if (Alpha < 0.0f)
            {
                Alpha = 0.0f;
            }
            //                webcamTexture.Pause();
        }
        //        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Play");
            Alpha = Alpha + 0.01f;
            if (Alpha > 1.0f)
            {
                Alpha = 1.0f;
            }
            rawimage.color = new Color(rawimage.color.r, rawimage.color.g, rawimage.color.b, Alpha);
            //                webcamTexture.Play();
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