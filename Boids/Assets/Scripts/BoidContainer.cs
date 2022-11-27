using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Boid))]
public class BoidContainer : MonoBehaviour
{
    private Boid boid;
    public float size;
    public float boundaryForce;

    // Start is called before the first frame update
    void Start()
    {
        boid = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boid.transform.position.magnitude > size)
        {
            boid.velocity += this.transform.position.normalized * (size - boid.transform.position.magnitude) * boundaryForce * Time.deltaTime;
        }
    }
}
