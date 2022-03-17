using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseSprite : MonoBehaviour
{
    public int Size;
    public int Speed;
    // The origin of the sampled area in the plane.
    public int xOrg;
    public int yOrg;

    // The number of cycles of the basic noise pattern that are repeated
    // over the width and height of the texture.
    public float scale = 1.0F;

    private Texture2D noiseTex;
    private Color[] pix;
    private SpriteRenderer rend;

    public void RandomizePlanet()
    {
        rend = GetComponent<SpriteRenderer>();

        // Set up the texture and a Color array to hold pixels during processing.
        noiseTex = new Texture2D(Size * 2, Size * 2);
        noiseTex.filterMode = FilterMode.Point;
        
        pix = new Color[noiseTex.width * noiseTex.height];

        CalcNoise();
        rend.sprite = Sprite.Create(noiseTex, new Rect(0, 0, noiseTex.width, noiseTex.height), new Vector2(0.5f, 0.5f));
    }

    void OnValidate(){
        RandomizePlanet();
    }
    void CalcNoise()
    {
        // For each pixel in the texture...
        float y = 0.0F;

        while (y < noiseTex.height)
        {
            float x = 0.0F;
            while (x < noiseTex.width)
            {
                int root = (int)(Mathf.Pow((Size - x),2) + Mathf.Pow((Size - y),2));
                if(Mathf.Sqrt(root) < Size){
                float xCoord = xOrg/4f + x / noiseTex.width * scale;
                float yCoord = yOrg/4f + y / noiseTex.height * scale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                pix[(int)y * noiseTex.width + (int)x] = new Color(sample, sample, sample);
                }
                else pix[(int)y * noiseTex.width + (int)x] = Color.clear;
                
                x++;
            }
            y++;
        }
        // Copy the pixel data to the texture and load it into the GPU.
        noiseTex.SetPixels(pix);
        noiseTex.Apply();
    }

}
