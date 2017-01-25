using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    /// <summary>
    /// Player stats contains the scales for different stats in of the player.
    /// Base stats have permanent changes, curr stats are for temporary changes.
    /// </summary>
    public float baseHp = 1;
    public float currHp = 1;


    public float baseStr = 1;
    public float currStr = 1;


    public float baseSpd = 1;
    public float currSpd = 1;
}
