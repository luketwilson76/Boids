using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoidSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float size = 10;
    public int number;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<number; i++)
        {
            Instantiate(prefab, new Vector3 (Random.Range(-size,size), Random.Range(-size, size), Random.Range(-size, size)), Random.rotation);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(size *2,size *2,size *2));
    }
}
