using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class WebCamVariable : ScriptableObject
{
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
    public WebCamTexture Value;

    public float AspectRatio => (float)Value.width / (float)Value.height;
    
    public void SetValue(WebCamTexture value)
    {
        Value = value;
    }

    public void SetValue(WebCamVariable value)
    {
        Value = value.Value;
    }

    public void ApplyRawImage(RawImage rawImage)
    {
        rawImage.texture = Value;
    }
}