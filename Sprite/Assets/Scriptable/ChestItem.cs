using UnityEngine;
using UnityEditor;
using System;

[CreateAssetMenu(menuName = "Scriptable/ChestItem")]

public class ChestItem : ScriptableObject
{
    public enum Type
    {
        Weapon,
        Key
    }

    public Type type;
    public Sprite sprite;
    public string itemName;
    public PlayerEquipment.Weapon weapon;
}