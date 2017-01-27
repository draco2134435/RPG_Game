using UnityEngine;
using System.Collections;

public class Hitbox : MonoBehaviour {
    public float hitBoxStrength = 1;
    public float hitStun = 0; //The amount of time in seconds, for an enemy to be 


    protected virtual void onHitboxEntered()
    {

    }

    protected virtual void onHurtboxEntered()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {

    }

    void OnTriggerExit2D(Collider2D collider)
    {

    }
}
