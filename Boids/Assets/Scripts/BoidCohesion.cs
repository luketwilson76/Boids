using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

//steer center of mass
[RequireComponent(typeof(Boid))]
public class BoidCohesion : MonoBehaviour
{
    private Boid boid;
    public float radius;

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
        //avg steering degrees in 3D space between flock
        foreach (var boid in boids.Where(b => b != boid))
        {
            var diff = boid.transform.position - this.transform.position;
            if (diff.magnitude < radius)
            {
                average += diff;
                found += 1;
            }
        }
        //find avg allignment if more than one boid in flock
        if (found > 0)
        {
            average = average / found;
            boid.velocity += Vector3.Lerp(Vector3.zero, average, average.magnitude / radius);
        }
    }
}
