using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class ProjectileMechanics : MonoBehaviour
{
    public float speed = 25;
    public Vector2 direction = Vector2.right;
    public bool usesGravity = false;
    Rigidbody2D rigid;

    void Start()
    {
        if (rigid == null) rigid = GetComponent<Rigidbody2D>();
        if (!usesGravity) rigid.gravityScale = 0;

    }

    public virtual void launchProjectile(Vector2 direction)
    {
        if (!rigid) rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = direction * speed;
    }

}