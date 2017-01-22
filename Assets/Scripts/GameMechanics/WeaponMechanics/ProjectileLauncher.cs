using UnityEngine;
using System.Collections;

public class ProjectileLauncher : MonoBehaviour {
    public ProjectileMechanics projectilePrefab;//The base projectile of the weapon
    public int maxProjectilesAvailable = 10;//The number of bullets in a game scene to reduce memory overflow
    public Transform launchPosition;//Please remember to add a launch position to this other wise it will just use the weapons default location
    public bool fireActive = true;
    int currentProjectilLaunch = 0;
    ProjectileMechanics[] allProjectiles;

	// Use this for initialization
	void Start () {
        allProjectiles = new ProjectileMechanics[maxProjectilesAvailable];
        for (int i = 0; i < allProjectiles.Length; i++)
        {
            ProjectileMechanics pm = Instantiate<ProjectileMechanics>(projectilePrefab);
            pm.gameObject.SetActive(false);
            //pm.transform.parent = this.transform;
            allProjectiles[i] = pm;
        }
        if (launchPosition == null) launchPosition = this.transform;
	}

    public void fireWeapon(bool fireInput)
    {
        if (fireInput && fireActive)
        {
            ProjectileMechanics pm = allProjectiles[currentProjectilLaunch];
            currentProjectilLaunch = (currentProjectilLaunch + 1) % allProjectiles.Length;
            pm.gameObject.SetActive(true);
            pm.transform.position = launchPosition.position;
            pm.launchProjectile(Vector2.right);

        }
    }

    void OnDestroy()
    {
        foreach (ProjectileMechanics pm in allProjectiles)
        {
            Destroy(pm);
        }
    }
	
	
}
