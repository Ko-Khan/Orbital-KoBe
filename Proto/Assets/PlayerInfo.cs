using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInfo 
{
    public string level;
    public float[] position;

    public PlayerInfo(Player player) {
        this.level = player.level;
        this.position = new float[3];

        this.position[0] = player.transform.position.x;
        this.position[1] = player.transform.position.y;
        this.position[2] = player.transform.position.z;
    }
}
