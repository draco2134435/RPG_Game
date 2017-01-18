using UnityEngine;
using System.Collections;

public class OptionUINode : MonoBehaviour {
    public OptionUINode NORTH;
    public OptionUINode SOUTH;
    public OptionUINode EAST;
    public OptionUINode WEST;

    public bool hasNode(int direction)
    {
        switch (direction)
        {
            case OptionUIManager.NORTH:
                return NORTH != null;
            case OptionUIManager.SOUTH:
                return SOUTH != null;
            case OptionUIManager.EAST:
                return EAST != null;
            case OptionUIManager.WEST:
                return WEST != null;
            default:
                return false;
        }
    }
}
