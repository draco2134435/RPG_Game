using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMechanics : MonoBehaviour {
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        attack(Input.GetButtonDown("Melee"));
    }

    public void attack(bool attackInput)
    {
        if (attackInput)
        {
            anim.SetTrigger("Melee");
        }
    }
}
