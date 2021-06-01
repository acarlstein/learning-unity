using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerData playerData;

    [SerializeField]
    private TextMesh textMesh;

    internal int leftClick = 0, rightClick = 1;

    private void Awake()
    {
        playerData = PlayerPersistence.GetData();
    }

    private void OnDestroy()
    {
        PlayerPersistence.SaveData(playerData);
    }

    private void Update()
    {
        Debug.Log("Health:" + playerData.health);
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            ModifyHealth(-1);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            ModifyHealth(1);
        }
        else if (Input.GetKey(KeyCode.R))
        {
            playerData = PlayerPersistence.GetNewPlayerData();
        }
        DisplayHealth();
    }

    private void ModifyHealth(int amount)
    {
        playerData.health += amount;
    }

    private void DisplayHealth()
    {
        if (textMesh)
        {
            textMesh.text = "Health: " + playerData.health;
        }
    }
}
