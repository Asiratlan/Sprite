using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int keys = 0;
    public List<PlayerEquipment.Weapon> weapons;
    private int _currentWeapon = 0;

    public PlayerEquipment.Weapon nextWeapon()
    {
        if (weapons.Count <= 1)
            return weapons[_currentWeapon];
        if (++_currentWeapon == weapons.Count)
            _currentWeapon = 0;
        return weapons[_currentWeapon];
    }

    public PlayerEquipment.Weapon previousWeapon()
    {
        if (weapons.Count <= 1)
            return weapons[_currentWeapon];
        if (--_currentWeapon == -1)
            _currentWeapon = weapons.Count - 1;
        return weapons[_currentWeapon];
    }
}

