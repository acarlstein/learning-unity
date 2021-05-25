using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Character/Stats", fileName="NewStats", order=1)]
public class CharacterStats_SO : ScriptableObject
{
   
    #region Fields
    public bool setManually = false;
    public bool saveDataOnClose = false;

    public ItemPickUp weapon { get; private set; }
    public ItemPickUp headArmor { get; private set; }
    public ItemPickUp chestArmor { get; private set; }
    public ItemPickUp handsArmor { get; private set; }
    public ItemPickUp legsArmor { get; private set; }
    public ItemPickUp footArmor { get; private set; }
    public ItemPickUp misc1 { get; private set; }
    public ItemPickUp misc2 { get; private set; }

    public int maxHealth = 0;
    public int currentHealth = 0;

    public int maxMana = 0;
    public int currentMana = 0;

    public int maxWealth = 0;
    public int currentWealth = 0;

    public int baseDamage = 0;
    public int currentDamage = 0;

    public float baseResistance = 0.0f;
    public float currentResistance = 0.0f;

    public float currentEncumbrance = 0.0f;

    public int charExperience = 0;
    public int charLevel = 0;

    public CharLevelUps[] charLevelUps;
    #endregion

    [System.Serializable]
    public class CharLevelUps
    {
        public int maxHealth;
        public int maxMana;
        public int maxWealth;
        public float baseResistance;
        public float maxEncumbreance;
    }

    #region Increase Stats

    public void ApplyHealth(int healthAmount)
    {
        currentHealth = increaseOrDefaultToMax(currentHealth, maxHealth);
    }

    private int increaseOrDefaultToMax(int amount, int max)
    {
        int temp = amount + max;
        return (temp > max) ? max : temp;
    }

    public void ApplyMana(int manaAmount)
    {
        currentMana = increaseOrDefaultToMax(currentMana, maxMana);
    }
    public void GiveWealth(int wealthAmount)
    {
        currentWealth = increaseOrDefaultToMax(currentWealth, maxWealth);
    }

    public void EquipWeapon(ItemPickUp weaponPickUp,
                            CharacterInventory characterInventory)
    {
        weapon = weaponPickUp;
        currentDamage = baseDamage + weapon.itemDefinition.itemAmount;

    }

    public void EquipArmor(ItemPickUp armorPickUp,
                            CharacterInventory characterInventory)
    {
        switch (armorPickUp.itemDefinition.itemArmorSubType)
        {
            case ItemArmorSubType.Head:
                headArmor = armorPickUp;
                break;
            case ItemArmorSubType.Chest:
                chestArmor = armorPickUp;
                break;
            case ItemArmorSubType.Hands:
                handsArmor = armorPickUp;
                break;
            case ItemArmorSubType.Legs:
                legsArmor = armorPickUp;
                break;
            case ItemArmorSubType.Boots:
                footArmor = armorPickUp;
                break;
            default:
                return;
        }
        currentResistance += armorPickUp.itemDefinition.itemAmount;
    }

    #endregion

    #region Reduce Stats
    public void TakeDamage(int amount)
    {
        currentHealth = DecreaseOrDefaultToZero(currentHealth, amount);
        if (currentHealth == 0) { Death(); }
    }
    public int DecreaseOrDefaultToZero(int current, int amount)
    {
        current -= amount;
        return (current <= 0) ? 0 : current;
    }
    
    public void TakeMana(int amount)
    {
        currentMana = DecreaseOrDefaultToZero(currentMana, amount);
    }
    #endregion

    #region Level Up and Death
    private void Death()
    {
        // Tell Game Manager to change to Death State to trigger respawn
        // Perform death visualization of player
    }
    #endregion

   
}
