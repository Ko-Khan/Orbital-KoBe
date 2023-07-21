using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public string level;
    public static bool continueOn;

    public void Start() {
        
        if (continueOn) {
            LoadPlayerInfo();            
        } else {
            this.level = SceneManager.GetActiveScene().name;
            SavePlayerInfo();
        }
        
    }
   
    public void SavePlayerInfo() {
        SaveSystem.SavePlayerInfo(this);
    }

    public void LoadPlayerInfo() {
        PlayerInfo info = SaveSystem.LoadPlayerInfo();

        this.level = info.level;
        Vector3 position;
        position.x = info.position[0];
        position.y = info.position[1];
        position.z = info.position[2];
        this.transform.position = position;
    }

    
}