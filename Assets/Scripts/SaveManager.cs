using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }

    public int currentBike;
    public int money;
    public bool[] bikesUnlocked = new bool[2] { true, false };

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            currentBike = data.currentBike;
            money = data.money;
            bikesUnlocked = data.bikesUnlocked;

            if (data.bikesUnlocked == null)
                bikesUnlocked = new bool[2] { true, false };

            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData_Storage data = new PlayerData_Storage();

        data.currentBike = currentBike;
        data.money = money;
        data.bikesUnlocked = bikesUnlocked;

        bf.Serialize(file, data);
        file.Close();
    }
}

[Serializable]

class PlayerData_Storage
{
    public int currentBike;
    public int money;
    public bool[] bikesUnlocked;
}
