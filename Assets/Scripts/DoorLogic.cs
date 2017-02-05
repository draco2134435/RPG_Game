using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]

public class DoorLogic : MonoBehaviour {
    public DoorLogic destinationDoor;
    public Transform playerSpawnPoint;
    Animator anim;
    public bool isLocked = false;
    public bool canOpen = false;
    GameObject player;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (canOpen && Input.GetButtonDown("Action"))
        {
            transportPlayer();
        }
    }


    public void transportPlayer()
    {
        player.transform.position = destinationDoor.playerSpawnPoint.position;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            canOpen = true;
            player = collider.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            canOpen = false;
        }
    }
}
