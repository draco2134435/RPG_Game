using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class JumpMechanics : MonoBehaviour {
    public float jumpForce = 50;
    public bool jumpDisabled = false;

    bool canDoubleJump;
    bool hasJumped = false;
    InAirCheck inAir;
    CustomGravity customGravity;
    Rigidbody2D rigid;

    void Start()
    {
        inAir = GetComponentInChildren<InAirCheck>();
        customGravity = GetComponent<CustomGravity>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canDoubleJump) return;
        if (inAir != null && !inAir.getInAir())
        {
            canDoubleJump = true;//Not sure if we want a double jump. Take away if we decide not to go with it
        }
    }

    public void jump(bool jumpButton)
    {
        if (inAir == null || jumpDisabled) return;
        if (!inAir.getInAir() && jumpButton)
        {
            customGravity.tempRemoveConstraints();
            rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
            hasJumped = true;
        }
    }
}
