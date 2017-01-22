using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    MovementMechanics mMechanics;
    JumpMechanics jMechanics;
    ProjectileLauncher pMechanics;

	// Use this for initialization
	void Start () {
        mMechanics = GetComponent<MovementMechanics>();
        jMechanics = GetComponent<JumpMechanics>();
        pMechanics = GetComponentInChildren<ProjectileLauncher>();
	}
	
	// Update is called once per frame
	void Update () {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        bool jumpButton = Input.GetButtonDown("Jump");
        bool fireButton = Input.GetButtonDown("Fire");

        if (mMechanics)
        {
            mMechanics.setHorizontalInput(hInput);
        }
        if (jMechanics)
        {
            jMechanics.jump(jumpButton);
        }
        if (pMechanics)
        {
            pMechanics.fireWeapon(fireButton);
        }
	}
}
