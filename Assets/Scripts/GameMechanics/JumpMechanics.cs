using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class JumpMechanics : MonoBehaviour {
    public float jumpForce = 50;
    public bool jumpDisabled = false;

    bool canDoubleJump;

    InAirCheck inAir;
    CustomGravity customGravity;
    Rigidbody2D rigid;
    Animator anim;

    void Start()
    {
        inAir = GetComponentInChildren<InAirCheck>();
        customGravity = GetComponent<CustomGravity>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("VerticalSpeed", rigid.velocity.y);
        anim.SetBool("inAir", inAir.getInAir());
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
            //hasJumped = true;
        }
    }
}
