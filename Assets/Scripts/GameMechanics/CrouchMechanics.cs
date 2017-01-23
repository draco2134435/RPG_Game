using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchMechanics : MonoBehaviour {
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float vInput = Input.GetAxisRaw("Vertical");

        anim.SetBool("isCrouching", vInput < -.5f);
	}
}
