using UnityEngine;

public class PhonePictureTaker : MonoBehaviour
{
    /// <summary>
    /// Back camera texture
    /// </summary>
    public WebCamVariable backCamera;
    
    public void TakePicture()
    {
        if (backCamera.Value == null)
        {
            Debug.Log("No camera detected");
            return;
        }
        
        Texture2D picture = new Texture2D(backCamera.Value.width, backCamera.Value.height);
        picture.SetPixels(backCamera.Value.GetPixels());
        picture.Apply();
        
        byte[] bytes = picture.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.persistentDataPath + "/picture.png", bytes);
    }
}
