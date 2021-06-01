using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPersistence
{
    internal static PlayerData GetData()
    {
        if (!PlayerPrefs.HasKey("health"))
        {
            return GetNewPlayerData();
        }
        return LoadFromPlayerPrefs();
    }
    private static PlayerData LoadFromPlayerPrefs()
    {
        return new PlayerData()
        {
            health = PlayerPrefs.GetInt("health"),
            mana = PlayerPrefs.GetInt("mana"),
            speed = PlayerPrefs.GetInt("speed"),
            attack = PlayerPrefs.GetInt("attack"),
            defense = PlayerPrefs.GetInt("defense")
        };
    }
    internal static PlayerData GetNewPlayerData()
    {
        return new PlayerData()
        {
            health = 100,
            mana = 100,
            speed = 30,
            attack = 5,
            defense = 5
        };
    }

    internal static void SaveData(PlayerData playerData)
    {
        PlayerPrefs.SetInt("health", playerData.health);
        PlayerPrefs.SetInt("mana", playerData.mana);
        PlayerPrefs.SetInt("speed", playerData.speed);
        PlayerPrefs.SetInt("attack", playerData.attack);
        PlayerPrefs.SetInt("defense", playerData.defense);
    }

    

    
}
