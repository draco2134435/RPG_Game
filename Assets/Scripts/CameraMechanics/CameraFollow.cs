using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public float xOffset = 0;
    public float yOffset = 0;
    public float movementSpeed = 50;
    Transform targetObject;


    void Start()
    {
        targetObject = transform.parent;
        transform.parent = null;
        xOffset = transform.position.x - targetObject.position.x;
        yOffset = transform.position.y - targetObject.position.y;
    }

    void Update()
    {
        Vector3 goalPosition = new Vector3(targetObject.position.x + xOffset, targetObject.position.y + yOffset, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, goalPosition, Time.deltaTime * movementSpeed);
    }
}
