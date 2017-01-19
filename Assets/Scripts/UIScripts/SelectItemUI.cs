using UnityEngine;
using System.Collections;

public class SelectItemUI : MonoBehaviour {
    int currentActionState;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () { 
        if (Input.GetButtonDown("Select"))
        {
            anim.SetInteger("State", currentActionState);
            anim.ResetTrigger("Cancel");
            anim.SetTrigger("Select");

        }
        else if (Input.GetButtonDown("Cancel"))
        {
            anim.SetInteger("State", currentActionState);
            anim.ResetTrigger("Select");
            anim.SetTrigger("Cancel");
        }
	}
}
