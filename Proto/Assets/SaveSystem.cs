using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayerInfo(Player player) {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/PlayerInfo";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerInfo info = new PlayerInfo(player);

        formatter.Serialize(stream, info);
        stream.Close();
    }

    public static PlayerInfo LoadPlayerInfo() {
        string path = Application.persistentDataPath + "/PlayerInfo";

        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerInfo info = formatter.Deserialize(stream) as PlayerInfo;
            stream.Close();

            return info;
        } else {
            Debug.LogError("Save file not found in" + path);
            return null;
        }        
    }
}
