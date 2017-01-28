using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    MovementMechanics mMechanics;
    JumpMechanics jMechanics;
    FireWeaponMechanics fMechanics;
    Animator anim;
    BufferInputs bufferInputs = new BufferInputs();
    MeleeMechanics meleeMechanics;

	// Use this for initialization
	void Start () {
        mMechanics = GetComponent<MovementMechanics>();
        jMechanics = GetComponent<JumpMechanics>();
        fMechanics = GetComponentInChildren<FireWeaponMechanics>();
        anim = GetComponent<Animator>();
        meleeMechanics = GetComponent<MeleeMechanics>();
        bufferInputs.addInput("Fire");
        bufferInputs.addInput("Melee");
	}
	
	// Update is called once per frame
	void Update () {
        float hInput = Input.GetAxisRaw("Horizontal");
        //float vInput = Input.GetAxisRaw("Vertical");
        bool jumpButton = Input.GetButtonDown("Jump");
        bufferInputs.update(Time.deltaTime);

        if (mMechanics)
        {
            mMechanics.setHorizontalInput(hInput);
        }
        if (jMechanics)
        {
            jMechanics.jump(jumpButton);
        }
        if (fMechanics)
        {
            if (bufferInputs.getInputActive("Fire")) anim.SetTrigger("Projectile");
            else anim.ResetTrigger("Projectile");
        }
        if (meleeMechanics)
        {
            if (bufferInputs.getInputActive("Melee")) anim.SetTrigger("Melee");
            else anim.ResetTrigger("Melee");
        }
        
	}
}
