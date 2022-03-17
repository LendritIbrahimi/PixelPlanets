using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreateMoons : MonoBehaviour
{

    public class Moon
    {
        public GameObject gameobject;
        public Vector3 rotation;
        public float speed;
    }

    public GameObject moonPrefab;
    public List<Moon> moons;
    public int maxNumberOfMoons = 1;
    public Vector2 sizeRange;
    public Vector2 distanceRange;
    public Vector2 speedRange;


    private int isPositive(Vector2 v){
        v.Normalize();
        if((v.x / Mathf.Abs(v.x)) == (v.y / Mathf.Abs(v.y))){
            return -1;
        }

        return 1;
    }
    private Vector3 getRandomPos(float scale)
    {
        int randomSwitch = Random.Range(0, 2) * 2 - 1;
        float x = (Random.Range(distanceRange.x, distanceRange.y) + scale) * randomSwitch;

        randomSwitch = Random.Range(0, 2) * 2 - 1;
        float y = (Random.Range(distanceRange.x, distanceRange.y) + scale) * randomSwitch;

        return new Vector3(x, y, 0);
    }

    void Start()
    {
        maxNumberOfMoons = Random.Range(0,maxNumberOfMoons);
        moons = new List<Moon>();
        for (int i = 0; i < maxNumberOfMoons; i++)
        {
            Moon addMoon = new Moon();
            addMoon.gameobject = Instantiate(moonPrefab, moonPrefab.transform.position, transform.rotation);

            moons.Add(addMoon);
        }
        RandomizeMoons();
    }

    void RandomizeMoons(){
        foreach(Moon randomMoon in moons){
            randomMoon.speed = Random.Range(speedRange.x, speedRange.y);

            float scale = Random.Range(sizeRange.x, sizeRange.y);
            Vector3 position = getRandomPos(scale);
            randomMoon.gameobject.transform.position = position;
            randomMoon.gameobject.transform.localScale = Vector3.one * scale;

            int inv = Random.Range(0, 2) * 2 - 1;
            randomMoon.rotation = new Vector3(isPositive(position), 1) * inv;

            randomMoon.gameobject.GetComponent<RandomizePlanet>().RandomizeColor();
        }
    }
    void Update()
    {
        foreach (Moon moon in moons)
            moon.gameobject.transform.RotateAround(Vector3.zero,
             moon.rotation, moon.speed * Time.deltaTime);
    }
}
