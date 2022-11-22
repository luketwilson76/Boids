using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoidSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float radius;
    public int number;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<number; i++)
        {
            Instantiate(prefab, this.transform.position + Random.insideUnitSphere * radius, Random.rotation);
        }
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.transform.position, radius);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
