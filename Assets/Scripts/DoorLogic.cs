using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour {
    public DoorLogic destinationDoor;
    public bool isLocked = false;


    void OnColliderEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

        }
    }
}
