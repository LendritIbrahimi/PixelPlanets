using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelatedCircleSprite : MonoBehaviour
{

    public int CircleRadius;
    public float radiusIndex = 1;
    public Color CircleColor;

    public void Start()
    {
        CreateSprite();
    }

    public void CreateSprite()
    {
        this.GetComponent<SpriteMask>().sprite = createCircle();
    }


    private void DrawCircle(Texture2D tex, Color color, int radius)
    {
        float rSquared = radius * radius;
        for (int y = 0; y < radius * 2; y++)
            for (int x = 0; x < radius * 2; x++)
            {
                int root = (int)(Mathf.Pow((radius - x), 2) + Mathf.Pow((radius - y), 2));
                if (Mathf.Sqrt(root) < radius / radiusIndex)
                    tex.SetPixel(x, y, color);
                else
                    tex.SetPixel(x, y, Color.clear);
            }
    }

    void OnValidate()
    {
        CircleRadius = Mathf.Max(CircleRadius, 4);
        // CircleRadius = Mathf.Min(CircleRadius, 30);
        radiusIndex = Mathf.Max(radiusIndex, 0.7f);

        CreateSprite();
    }
    private Sprite createCircle()
    {

        Texture2D CircleTexture = new Texture2D(CircleRadius * 2, CircleRadius * 2, TextureFormat.ARGB32, false);
        DrawCircle(CircleTexture, CircleColor, CircleRadius);
        CircleTexture.filterMode = FilterMode.Point;
        CircleTexture.wrapMode = TextureWrapMode.Clamp;
        CircleTexture.Apply();

        return Sprite.Create(CircleTexture, new Rect(0, 0, CircleTexture.width, CircleTexture.height), new Vector2(0.5f, 0.5f), 10f);
    }

}
