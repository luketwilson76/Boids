using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour {

    const int threadGroupSize = 1024;

    public BoidSettings settings;
    public ComputeShader compute;
    Boid[] boids;

    void Start () {
        boids = FindObjectsOfType<Boid> ();
        foreach (Boid b in boids) {
            b.InitializeBoid (settings, null);
        }
    }

    void Update () {
        if (boids != null) {
            //gather list of boids
            int numBoids = boids.Length;
            var boidData = new BoidData[numBoids];

            for (int i = 0; i < boids.Length; i++) {
                boidData[i].position = boids[i].position;
                boidData[i].direction = boids[i].forward;
            }
            //buffer textures based on light refraction
            var boidBuffer = new ComputeBuffer (numBoids, BoidData.Size);
            boidBuffer.SetData (boidData);
            compute.SetBuffer (0, "boids", boidBuffer);

            //sets the radius in which a boid can detect obstacles or other boids
            compute.SetInt ("numBoids", boids.Length);
            compute.SetFloat ("viewRadius", settings.perceptionRadius);
            compute.SetFloat ("avoidRadius", settings.avoidanceRadius);
            // collecting multiple threads into a single object and manipulating those threads all at once
            int threadGroups = Mathf.CeilToInt (numBoids / (float) threadGroupSize);
            compute.Dispatch (0, threadGroups, 1, 1);

            boidBuffer.GetData (boidData);
            //assign data to each boid to calculate other variables
            for (int i = 0; i < boids.Length; i++) {
                boids[i].avgFlockDir = boidData[i].flockHeading;
                boids[i].centreOfFlockmates = boidData[i].flockCentre;
                boids[i].avgAvoidanceHeading = boidData[i].avoidanceHeading;
                boids[i].numPerceivedFlockmates = boidData[i].numFlockmates;

                boids[i].UpdateBoids ();
            }
            boidBuffer.Release ();
        }
    }

    //struct for each boid object
    public struct BoidData {
        public Vector3 position;
        public Vector3 direction;
        public Vector3 flockHeading;
        public Vector3 flockCentre;
        public Vector3 avoidanceHeading;
        public int numFlockmates;
        public static int Size {
            get {
                return sizeof (float) * 3 * 5 + sizeof (int);
            }
        }
    }
}