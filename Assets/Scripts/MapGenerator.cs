using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour
{

    public int circleRadius;
    public int boxWidth;

    public float noiseScale;

    public int octaves;
    [Range(0, 1)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public bool randomSeed;
    public bool randomSize;

    public TerrainType[] regions;

    private float[,] noiseMap;
    private Color[] colourMap;



    public void Start()
    {
        CreatePlanet();
    }

    public void CreatePlanet()
    {


        if (randomSeed)
        {
            seed = Random.Range(0, 1000);
        }
        if (randomSize)
        {
            noiseScale += Random.Range(-10, 15);
        }
        GenerateMap();
        DrawText();
    }
    public void GenerateMap()
    {
        noiseMap = Noise.GenerateNoiseMap(boxWidth, circleRadius * 2, seed, noiseScale, octaves, persistance, lacunarity, offset);

        colourMap = new Color[boxWidth * circleRadius * 2];
        for (int y = 0; y < circleRadius * 2; y++)
        {
            for (int x = 0; x < boxWidth; x++)
            {

                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++)
                {
                    if (currentHeight <= regions[i].height)
                    {
                        colourMap[y * boxWidth + x] = regions[i].colour;
                        break;
                    }
                }
            }
        }

    }
    public void DrawText()
    {
        Texture2D texture = TextureGenerator.TextureFromColourMap(colourMap, boxWidth, circleRadius * 2);
      //  this.GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 10f);
        gameObject.GetComponent<MeshRenderer>().sharedMaterial.mainTexture = texture;
    }

    void OnValidate()
    {
        if (circleRadius < 2)
        {
            circleRadius = 2;
        }
        if (lacunarity < 1)
        {
            lacunarity = 1;
        }
        if (octaves < 0)
        {
            octaves = 0;
        }
CreatePlanet();
    }


}

[System.Serializable]
public struct TerrainType
{
    public string name;
    public float height;
    public Color colour;
}