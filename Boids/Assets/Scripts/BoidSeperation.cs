using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
//space between boids
[RequireComponent(typeof(Boid))]
public class BoidSeperation : MonoBehaviour
{
    private Boid boid;
    public float radius;
    public float repulsionForce;

    // Start is called before the first frame update
    void Start()
    {
        boid = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        var boids = FindObjectsOfType<Boid>();
        var average = Vector3.zero;
        var found = 0;

        //finds avg dist between boids and corrects spacing
        foreach (var boid in boids.Where(b => b != boid))
        {
            var diff = boid.transform.position - this.transform.position;
            if (diff.magnitude < radius)
            {
                average += diff;
                found += 1;
            }
        }
        //find avg if more than one boid in flock
        if (found > 0)
        {
            average = average / found;
            boid.velocity -= Vector3.Lerp(Vector3.zero, average, average.magnitude / radius) * repulsionForce;
        }
    }
}

