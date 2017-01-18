using UnityEngine;
using System.Collections;

public class UIPointer : MonoBehaviour {
    public float speed;
    OptionUIManager uiManager;
    Transform target;

	// Use this for initialization
	void Start () {
        uiManager = this.transform.parent.GetComponent<OptionUIManager>();    
	}
	
	// Update is called once per frame
	void Update () {
        bool noSlerp = false;
        if (uiManager)
        {
            if (target == null) noSlerp = true;
            target = uiManager.getCurrentUINode().transform;
        }
        if (!target) return;

        if (noSlerp) transform.position = target.position;
        else
        {
            transform.position = Vector3.Slerp(transform.position, target.position, Time.deltaTime * speed);
        }

	}
}
