using UnityEngine;
using System.Collections;

public class InAirCheck : MonoBehaviour {
    public Transform[] originPoints;
    public float maxDistance = 0.02f;
    public string[] ignoreLayers = new string[0];

    Collider2D collisionObject;
    int layerMask = -1;

    void Start()
    {
        if (ignoreLayers == null) return;

        foreach (string layerName in ignoreLayers)
        {
            int removeLayer = 1 << LayerMask.NameToLayer(layerName);
            layerMask -= removeLayer;
        }
    }

    void Update()
    {
        RaycastHit2D hit;
        collisionObject = null;
        foreach(Transform t in originPoints)
        {
            hit = Physics2D.Raycast(t.position, Vector2.down, maxDistance, layerMask);
           
            if (hit)
            {
                if (collisionObject == null) collisionObject = hit.collider;
                else if (collisionObject.bounds.max.y < hit.collider.bounds.max.y)
                {
                    collisionObject = hit.collider;
                }
            }
        }
    }

    public bool getInAir()
    {
        return collisionObject == null;
    }

    public float getYPosition()
    {
        if (collisionObject == null) return 0;
        
        return collisionObject.bounds.max.y;
    }
}
