/*Please do support www.bitshiftprogrammer.com by joining the facebook page : fb.com/BitshiftProgrammer
Legal Stuff:
This code is free to use no restrictions but attribution would be appreciated.
Any damage caused either partly or completly due to usage of this stuff is not my responsibility*/
using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(Camera))]
public class PixelateImageEffect : MonoBehaviour
{
    public Material material;
    public int pixelDensity = 64;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Vector2 aspectRatioData;
        if (Screen.height > Screen.width)
            aspectRatioData = new Vector2((float)Screen.width / Screen.height, 1);
        else
            aspectRatioData = new Vector2(1, (float)Screen.height / Screen.width);
        material.SetVector("_AspectRatioMultiplier", aspectRatioData);
        material.SetInt("_PixelDensity", pixelDensity);
        Graphics.Blit(source, destination, material);
    }
}