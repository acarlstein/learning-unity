using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypeDefinitions { Health, Wealth, Mana, Weapon, Armor, Buff, Empty };
public enum ItemArmorSubType {None, Head, Chest, Hands, Legs, Boots};

[CreateAssetMenu (fileName="New Item", menuName="Spawnable Item/New Pick-up", order=1)]
public class ItemPickUp_SO : ScriptableObject
{
    public ItemTypeDefinitions itemType = ItemTypeDefinitions.Health;
    public ItemArmorSubType itemArmorSubType = ItemArmorSubType.None;
    public int itemAmount = 0;
}
