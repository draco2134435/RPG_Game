using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    bool pauseActive = false;

    Transform[] allChildren;

	void Start()
    {
        allChildren = GetComponentsInChildren<Transform>();
        setChildrenActive();
    }

    void Update()
    {
        bool pauseButton = Input.GetButtonDown("Pause");

        if (pauseButton)
        {
            pauseActive = !pauseActive;
            setChildrenActive();
            
        }
    }

    void setChildrenActive()
    {
        foreach (Transform t in allChildren)
        { 

            if (t != this.transform)
            {
                t.gameObject.SetActive(pauseActive);
            }

        }
    }
}
