using UnityEngine;
using System.Collections;

public class OptionUIManager : MonoBehaviour {
    public const int NORTH = 0;
    public const int SOUTH = 1;
    public const int EAST = 2;
    public const int WEST = 3;

    public OptionUINode primaryOptionUINode;
    public float joystickThreshold = .2f;

    OptionUINode currentOptionUINode;
    float hInput;
    float vInput;
    bool canShift;

    void Start()
    {
        if (currentOptionUINode == null)
        {
            currentOptionUINode = primaryOptionUINode;
        }
    }

    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        setCurrentOptionsNode();
    }

    void setCurrentOptionsNode()
    {
        if (Mathf.Abs(hInput) < joystickThreshold && Mathf.Abs(vInput) < joystickThreshold)
        {
            canShift = true;
            return;
        }

        if (!canShift) return;

        if (Mathf.Abs(hInput) > joystickThreshold){
            if (hInput < 0 && currentOptionUINode.hasNode(WEST))
            {
                currentOptionUINode = currentOptionUINode.WEST;
                canShift = false;
            }
            else if (currentOptionUINode.hasNode(EAST))
            {
                currentOptionUINode = currentOptionUINode.EAST;
                canShift = false;
            }
        }
        else if (Mathf.Abs(vInput) > joystickThreshold)
        {
            if (vInput > 0 && currentOptionUINode.hasNode(NORTH))
            {
                currentOptionUINode = currentOptionUINode.NORTH;
                canShift = false;
            } 
            else if(currentOptionUINode.hasNode(SOUTH))
            {
                currentOptionUINode = currentOptionUINode.SOUTH;
                canShift = false;
            }

        }
    }

    public OptionUINode getCurrentUINode()
    {
        return currentOptionUINode;
    }

    public void setInitialOptionsUINode(OptionUINode oNode)
    {
        this.currentOptionUINode = oNode;
    }

    
}
