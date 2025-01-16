using UnityEditor.DeviceSimulation;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour
{
    private bool isCameraAvailable;
    
    /// <summary>
    /// Back camera texture
    /// </summary>
    private WebCamTexture backCamera;
    
    
    /// <summary>
    /// Default texture to display when the camera is not available
    /// </summary> 
    private Texture defaultBackground;
    
    public RawImage background;
    public AspectRatioFitter aspectRatioFitter;
    

    void Start()
    {
        defaultBackground = background.texture;
        WebCamDevice[] webCamDevices = WebCamTexture.devices;
        
        if(webCamDevices.Length == 0)
        {
            Debug.Log("No camera detected");
            isCameraAvailable = false;
            return;
        }
        
        for (int i = 0; i < webCamDevices.Length; i++)
        {
            if (!webCamDevices[i].isFrontFacing)
            {
                backCamera = new WebCamTexture(webCamDevices[i].name, Screen.width, Screen.height);
            }
        }
        
        if (backCamera == null)
        {
            Debug.Log("No back camera detected");
            isCameraAvailable = false;
            return;
        }
        
        backCamera.Play();
        background.texture = backCamera;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCameraAvailable)
        {
            return;
        }
        
    }
}
