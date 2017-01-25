using UnityEngine;
using System.Collections;

public class FireWeaponMechanics : MonoBehaviour {
    FlipSprite spriteDirection;
    ProjectileLauncher pLauncher;

    void Start()
    {
        pLauncher = GetComponentInChildren<ProjectileLauncher>();
        spriteDirection = GetComponent<FlipSprite>();
    }

    public void fireWeapon()
    {
        if (pLauncher)
        {
            Vector2 direction = Vector2.right;
            if (!spriteDirection.getIsRight()) direction = Vector2.left;
            pLauncher.fireWeapon(true, direction);
        }
    }

    public void setProjectileLauncher(ProjectileLauncher pLauncher)
    {
        this.pLauncher = pLauncher;
    }
}
