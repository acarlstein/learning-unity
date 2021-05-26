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
    public float maxEncumbrance = 0.0f;

    public int experience = 0;
    public int level = 0;

    public CharLevelUps[] characterLevelUps;
    #endregion

    [System.Serializable]
    public class CharLevelUps
    {
        public int maxHealth;
        public int maxMana;
        public int maxWealth;
        public int baseDamage;
        public float baseResistance;
        public float maxEncumbrance;
    }

    #region Increase Stats

    public void ApplyHealth(int healthAmount)
    {
        currentHealth = increaseOrDefaultToMax(currentHealth, maxHealth);
    }

    private int increaseOrDefaultToMax(int amount, int max)
    {
        int newAmount = amount + max;
        return (newAmount > max) ? max : newAmount;
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
                            CharacterInventory characterInventory,
                            GameObject gameObject)
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

    public bool UnEquipWeapon(ItemPickUp weaponPickUp, 
                              CharacterInventory characterInventory, 
                              GameObject weaponSlot)
    {
        bool isSameWeapon = false;
        if (weapon != null)
        {
            if (weapon == weaponPickUp)
            {
                isSameWeapon = true;
            }
           
            DestroyObject(weaponSlot.transform.GetChild(0).gameObject);
            weapon = null;
            currentDamage = baseDamage;
        }
        return isSameWeapon;
    }

    public void DestroyObject(GameObject gameObject)
    {

    }

    /* TODO: Try if something like below is possible. In this way, we can eliminate the switch statement:
      var propName = armorPickUp.itemDefinition.itemArmorSubType.ToString().toLowerCase().concat("Armor");
      if (this[propName] != null){
        if (this[propName] == armorPickUp){
            isSameArmor = true;
        }
        currentResistance -= armorPickUp.itemDefinition.itemAmount;
        headArmor = null;
      }
      Note: Reflection is normally slow so find out if there is a way to do it without it.
    */
    public bool UnEquipArmor(ItemPickUp armorPickUp,
                            CharacterInventory characterInventory)
    {
        bool isSameArmor = false;
        switch (armorPickUp.itemDefinition.itemArmorSubType)
        {
            case ItemArmorSubType.Head:
                isSameArmor = unEquipArmorIfApplicable(headArmor, armorPickUp);
                break;
            case ItemArmorSubType.Chest:
                isSameArmor = unEquipArmorIfApplicable(chestArmor, armorPickUp);
                break;
            case ItemArmorSubType.Hands:
                isSameArmor = unEquipArmorIfApplicable(handsArmor, armorPickUp);
                break;
            case ItemArmorSubType.Legs:
                isSameArmor = unEquipArmorIfApplicable(legsArmor, armorPickUp);
                break;
            case ItemArmorSubType.Boots:
                isSameArmor = unEquipArmorIfApplicable(footArmor, armorPickUp);
                break;
            default:
                break;
        }

        return isSameArmor;
    }

    // TODO: Verify if this works
    private bool unEquipArmorIfApplicable(ItemPickUp currentArmor, ItemPickUp newArmor)
    {
        bool isSameArmor = false;
        if (currentArmor != null)
        {
            if (currentArmor == newArmor)
            {
                isSameArmor = true;
            }
            currentResistance -= newArmor.itemDefinition.itemAmount;
            currentArmor = null;
        }
        return isSameArmor;
    }

    #endregion

    #region Level Up and Death
    private void LevelUp()
    {
        level++;
        // TODO Show level up
        maxHealth = characterLevelUps[level - 1].maxHealth;
        maxMana = characterLevelUps[level - 1].maxMana;
        maxWealth = characterLevelUps[level - 1].maxWealth;
        baseDamage = characterLevelUps[level - 1].baseDamage;
        baseResistance = characterLevelUps[level - 1].baseResistance;
        maxEncumbrance = characterLevelUps[level - 1].maxEncumbrance;
    }

    private void Death()
    {
        // TODO: Tell Game Manager to change to Death State to trigger respawn
        // Perform death visualization of player
    }

    #endregion

   
}
