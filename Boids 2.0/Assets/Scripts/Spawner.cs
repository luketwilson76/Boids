using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public enum GizmoType { Never, SelectedOnly, Always }

    public Boid boidPrefab;
    public float spawnRadius = 10;
    public int numBoids = 10;
    public Color color;
    public GizmoType spawnRegion;

    void Awake () {
        for (int i = 0; i < numBoids; i++) {
            Vector3 pos = transform.position + Random.insideUnitSphere * spawnRadius;
            Boid boid = Instantiate (boidPrefab);
            boid.transform.position = pos;
            boid.transform.forward = Random.insideUnitSphere;
            boid.SetColor (color);
        }
    }

    void OnDrawGizmosSelected () {
        if (spawnRegion == GizmoType.SelectedOnly) {
            DrawGizmos ();
        }
    }
    private void OnDrawGizmos()
    {
        if (spawnRegion == GizmoType.Always)
        {
            DrawGizmos();
        }
    }

    void DrawGizmos () {
        //draws radius of spawner
        Gizmos.color = new Color (color.r, color.g, color.b, 0.3f);
        Gizmos.DrawSphere (transform.position, spawnRadius);
    }

}