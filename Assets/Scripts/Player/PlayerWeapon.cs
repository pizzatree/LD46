using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private iWeapon weapon;

    public void SwapWeapon(iWeapon newWeapon)
    {
        weapon?.Drop();
        weapon = newWeapon;
        weapon.Equip();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
            weapon?.Fire();
    }
}
