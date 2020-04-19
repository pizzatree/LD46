using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerWeapon : MonoBehaviour
{
    private iWeapon weapon;
    [SerializeField]
    private TextMeshProUGUI ammoUI;

    public void UpdateAmmoUI(int newAmt)
    {
        ammoUI.text = newAmt.ToString();
    }

    public void PickupAmmo()
    {
        weapon.ReplenishAmmo();
    }

    public void SwapWeapon(iWeapon newWeapon)
    {
        weapon?.Drop();
        weapon = newWeapon;
        weapon?.Equip();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
            weapon?.Fire();
    }
}
