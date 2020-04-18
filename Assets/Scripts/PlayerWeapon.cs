using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] 
    private GameObject weaponObject;

    private iWeapon weapon => weaponObject.GetComponent<iWeapon>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            weapon?.Fire();
    }
}
