using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizePlanet : MonoBehaviour
{
    public float red;
    public float green;
    public float blue;
    public float height;
    public Vector2 speed;
    private MapGenerator map;
    private List<Color> colors = new List<Color>();
    private List<float> heights = new List<float>();

    private void Start()
    {
        Initialize();
    }
    private void Initialize()
    {
        colors.Clear();
        heights.Clear();
        map = this.GetComponent<MapGenerator>();

        if (map != null)
        {
            for (int i = 0; i < map.regions.Length; i++)
            {
                colors.Add(map.regions[i].colour);
                heights.Add(map.regions[i].height);
            }
            RandomizeColor();
        }
    }
    public void Randomize()
    {
        GetComponent<RotatePlanet>().rotateSpeed = Random.Range(speed.x, speed.y);
        RandomizeScale();
        RandomizeColor();
    }
    public void RandomizeSize()
    {
        transform.localScale = Vector3.one * Random.Range(1.5f, 5f);
    }


    private void RandomizeScale()
    {
        float s = Random.Range(3f, 15f);
        map.noiseScale = s;
    }
    public void RandomizeColor()
    {


        if (map == null)
        {
            Initialize();
        }

        for (int i = 0; i < map.regions.Length; i++)
        {
            float randomRed = Random.Range(-red, red) / 100;
            float randomGreen = Random.Range(-green, green) / 100;
            float randomBlue = Random.Range(-blue, blue) / 100;

            float r, g, b;

            r = colors[i].r;
            g = colors[i].g;
            b = colors[i].b;

            r += randomRed;
            g += randomGreen;
            b += randomBlue;

            map.regions[i].height = heights[i] + Random.Range(-height, height) / 100;
            map.regions[i].colour = new Color(r, g, b);
        }
        map.CreatePlanet();
    }
}
