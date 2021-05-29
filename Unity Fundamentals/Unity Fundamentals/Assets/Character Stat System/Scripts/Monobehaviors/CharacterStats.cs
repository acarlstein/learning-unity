using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public CharacterInventory characterInventory;
    public CharacterStats_SO characterDefinition;
    public GameObject characterWeaponSlot;

    #region Constructors
    public CharacterStats()
    {
        characterInventory = CharacterInventory.instance;
    }
    #endregion

    #region Initializations
    private void Start()
    {
        if (!characterDefinition.setManually)
        {
            characterDefinition.maxHealth = 100;
            characterDefinition.currentHealth = 50;

            characterDefinition.maxMana = 25;
            characterDefinition.currentMana = 10;

            characterDefinition.maxWealth = 500;
            characterDefinition.currentWealth = 0;

            characterDefinition.baseResistance = 0;
            characterDefinition.currentResistance = 0;

            characterDefinition.maxEncumbrance = 50.0f;
            characterDefinition.currentEncumbrance = 0.0f;

            characterDefinition.experience = 0;
            characterDefinition.level = 1;

        }
    }
    #endregion

    #region Increase Stats
    public void ApplyHealth(int healthAmount)
    {
        characterDefinition.ApplyHealth(healthAmount);
    }

    public void ApplyMana(int manaAmount)
    {
        characterDefinition.ApplyMana(manaAmount);
    }

    public void GiveWealth(int wealthAmount)
    {
        characterDefinition.GiveWealth(wealthAmount);
    }
    #endregion

    #region Reduce Stats
    public void TakeDamage(int amount)
    {
        characterDefinition.TakeDamage(amount);
    }

    public void TakeMana(int amount)
    {
        characterDefinition.TakeMana(amount);
    }
    #endregion

    #region Change Weapon and Armor
    public void ChangeWeapon(ItemPickUp weaponPickUp)
    {
        bool isSameWeapon = characterDefinition.UnEquipWeapon(weaponPickUp, characterInventory, characterWeaponSlot);
        if (!isSameWeapon)
        {
            characterDefinition.EquipWeapon(weaponPickUp, characterInventory, characterWeaponSlot);
        }
    }

    public void ChangeArmor(ItemPickUp armorPickUp)
    {
        bool isSameArmor = characterDefinition.UnEquipArmor(armorPickUp, characterInventory);
        if (!isSameArmor)
        {
            characterDefinition.EquipArmor(armorPickUp, characterInventory);
        }
    }
    #endregion

    #region Status Report
    public int GetHealth()
    {
        return characterDefinition.currentHealth;
    }

    public ItemPickUp GetCurrentWeapon()
    {
        return characterDefinition.weapon;
    }
    #endregion

    #region Updates

    private const int MOUSE_MIDDLE_CLICK = 2;
    private void Update()
    {
        //if (Input.GetMouseButtonDown(MOUSE_MIDDLE_CLICK))
        //{
        //    characterDefinition.saveCharacterData();
        //}
    }
    #endregion
}
