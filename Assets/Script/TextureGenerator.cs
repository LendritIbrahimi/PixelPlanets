using UnityEngine;
using System.Collections;

public class TextureGenerator
{

    public static Texture2D TextureFromColourMap(Color[] colourMap, int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);
        
        Color fillColor = Color.clear;
         Color[] fillPixels = new Color[width * height];
 
         for (int i = 0; i < fillPixels.Length; i++)
         {
             fillPixels[i] = fillColor;
         }
 
         texture.SetPixels(fillPixels);
         texture.Apply();
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;

        texture.SetPixels(colourMap);
        texture.Apply();
        return texture;
    }

}
