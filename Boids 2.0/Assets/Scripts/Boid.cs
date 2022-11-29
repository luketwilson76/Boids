using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {
    BoidSettings boidSettings;
    // State of boid
    [HideInInspector] public Vector3 position;
    [HideInInspector] public Vector3 forward;
    Vector3 velocity;
    // Update boids:
    Vector3 acceleration;
    [HideInInspector] public Vector3 avgFlockDir;
    [HideInInspector] public Vector3 avgAvoidanceHeading;
    [HideInInspector] public Vector3 centreOfFlockmates;
    [HideInInspector] public int numPerceivedFlockmates;
    // Cached information
    Material boidMaterial;
    Transform boidTransform;
    Transform target;

    void Awake () {
        boidMaterial = transform.GetComponentInChildren<MeshRenderer> ().material;
        boidTransform = transform;
    }

    public void InitializeBoid (BoidSettings settings, Transform target) {
        this.target = target;
        this.boidSettings = settings;
        position = boidTransform.position;
        forward = boidTransform.forward;
        float startSpeed = (settings.minSpeed + settings.maxSpeed) / 2;
        velocity = transform.forward * startSpeed;
    }

    public void SetColor (Color col) {
        if (boidMaterial != null) {
            boidMaterial.color = col;
        }
    }

    public void UpdateBoids () {
        Vector3 acceleration = Vector3.zero;

        if (target != null) {
            Vector3 offsetToTarget = (target.position - position);
            acceleration = SteerToward (offsetToTarget) * boidSettings.targetWeight;
        }
        if (numPerceivedFlockmates != 0) {
            centreOfFlockmates /= numPerceivedFlockmates;
            //new position that adjusts to centre of mass
            Vector3 offsetToFlockmatesCentre = (centreOfFlockmates - position);
            //calculates how far apart, how aligned, and how close boids are
            var alignment = SteerToward (avgFlockDir) * boidSettings.alignWeight;
            var cohesion = SteerToward (offsetToFlockmatesCentre) * boidSettings.cohesionWeight;
            var seperation = SteerToward (avgAvoidanceHeading) * boidSettings.seperateWeight;
            acceleration += alignment;
            acceleration += cohesion;
            acceleration += seperation;
        }
        if (HeadingForCollision ()) {
            Vector3 avoidCollisionDir = DetectionRays ();
            Vector3 avoidCollision = SteerToward (avoidCollisionDir) * boidSettings.avoidCollisionWeight;
            acceleration += avoidCollision;
        }
        velocity += acceleration * Time.deltaTime;
        float speed = velocity.magnitude;
        Vector3 dir = velocity / speed;
        speed = Mathf.Clamp (speed, boidSettings.minSpeed, boidSettings.maxSpeed);
        velocity = dir * speed;
        boidTransform.position += velocity * Time.deltaTime;
        boidTransform.forward = dir;
        position = boidTransform.position;
        forward = dir;
    }
    Vector3 SteerToward(Vector3 vector)
    {
        Vector3 v = vector.normalized * boidSettings.maxSpeed - velocity;
        return Vector3.ClampMagnitude(v, boidSettings.maxSteerForce);
    }
    bool HeadingForCollision () {
        RaycastHit hit;
        if (Physics.SphereCast (position, boidSettings.boundsRadius, forward, out hit, boidSettings.collisionAvoidDst, boidSettings.obstacleMask)) {
            return true;
        } else { }
        return false;
    }
    Vector3 DetectionRays () {
        /*create raycasts until one where there's no collison is created
         use that raycast to */
        Vector3[] rayDirections = BoidHelper.directions;
        for (int i = 0; i < rayDirections.Length; i++) {
            Vector3 dir = boidTransform.TransformDirection (rayDirections[i]);
            Ray ray = new Ray (position, dir);
            if (!Physics.SphereCast (ray, boidSettings.boundsRadius, boidSettings.collisionAvoidDst, boidSettings.obstacleMask)) {
                return dir;
            }
        }
        return forward;
    }
}