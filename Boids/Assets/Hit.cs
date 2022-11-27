using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
    }

    

    
}
