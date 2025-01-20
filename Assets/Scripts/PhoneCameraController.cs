using UnityEditor.DeviceSimulation;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCameraController : MonoBehaviour
{
    private bool isCameraAvailable;
    
    /// <summary>
    /// Back camera texture
    /// </summary>
    public WebCamVariable backCamera;
    
    
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
                backCamera.SetValue(new WebCamTexture(webCamDevices[i].name, Screen.width, Screen.height));
            }
        }
        
        if (backCamera == null)
        {
            Debug.Log("No back camera detected");
            isCameraAvailable = false;
            return;
        }
        
        backCamera.Value.Play();
        background.texture = backCamera.Value;
        isCameraAvailable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (backCamera.Value != null)
        {
            return;
        }
        
        // float aspectRatio = backCamera.AspectRatio;
        // aspectRatioFitter.aspectRatio = aspectRatio;
        
        // Flip the camera if it's mirrored
        float scaleY = backCamera.Value.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orientation = -backCamera.Value.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
    }
}
