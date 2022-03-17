using System.Collections;
using UnityEngine;
public class Stars : MonoBehaviour
{
    public int maxStars = 1000;
    public int universeSize = 10;
    public float minSize, maxSize;

    private ParticleSystem.Particle[] points;
    private new ParticleSystem particleSystem;

    private void Create()
    {

        points = new ParticleSystem.Particle[maxStars];

        for (int i = 0; i < maxStars; i++)
        {
            points[i].position = Random.insideUnitSphere * universeSize;
            points[i].position = new Vector3(points[i].position.x, points[i].position.y, transform.position.z);
            points[i].startSize = Random.Range(minSize, maxSize);
            if (Random.Range(0.0f, 1.0f) > 0.7f)
            {
                points[i].startColor = new Color(Random.Range(0.00f, 1.0f), Random.Range(0.00f, 1.0f), Random.Range(0.00f, 1.0f), Random.Range(0.5f, 1.0f));
            }
            else
            {
                points[i].startColor = new Color(1, 1, 1, 1);
            }
        }

        particleSystem = gameObject.GetComponent<ParticleSystem>();

        particleSystem.SetParticles(points, points.Length);

    }

    void Start()
    {
        Create();
    }
}