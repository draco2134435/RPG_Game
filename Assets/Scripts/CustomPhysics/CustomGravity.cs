using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]

public class CustomGravity : MonoBehaviour {
    public const float GRAVITY = 9.8f;
    public float gravityScale = 1.0f;
    public float maxFallSpeed = 10;
    public bool gravityActive = true;
    public InAirCheck inAir;

    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.gravityScale = 0;
        if (inAir == null)
        {
            inAir = GetComponentInChildren<InAirCheck>();
        }
    }

    void Update()
    {
        if (!gravityActive) return;
        if (inAir != null && !inAir.getInAir())
        {
            //if (rigid.velocity.y <= 0)
            transform.position = new Vector3(transform.position.x, inAir.getYPosition(), transform.position.z);

            return;
        }
    }

    void FixedUpdate()
    {
        if (!gravityActive) return;
        if (inAir != null && !inAir.getInAir() && rigid.velocity.y <= 0)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY | rigid.constraints;
        }
        else
        {
            rigid.constraints = ~RigidbodyConstraints2D.FreezePositionY & rigid.constraints;
        }
        rigid.velocity = Vector2.MoveTowards(rigid.velocity, new Vector2(rigid.velocity.x, -maxFallSpeed), Time.fixedDeltaTime * gravityScale * GRAVITY);
    }

}
