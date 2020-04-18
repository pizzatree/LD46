using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : MonoBehaviour, iWeapon
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float inaccuracy = 0.1f,
                  coolDownTime = .2f,
                  shuntForce = 5f;
    [SerializeField]
    private int numBullets = 1;

    public event Action OnFire = delegate { };

    private bool coolingDown = false;

    private Transform firepoint => transform.Find("Firepoint");

    public void Fire()
    {
        if(!coolingDown)
        {
            OnFire();
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        for (int i = 0; i < numBullets; ++i)
        {
            var shotRot = transform.rotation;
            shotRot.z -= Quaternion.Euler(0, 0, UnityEngine.Random.Range(-inaccuracy, inaccuracy)).z;

            Instantiate(bullet, firepoint.position, shotRot);
        }

        coolingDown = true;
        yield return new WaitForSeconds(coolDownTime);
        coolingDown = false;
    }

    WeaponHandling weapHandler => GetComponent<WeaponHandling>();
    public void Drop()
    {
        weapHandler.Deactivate();
        transform.position += (transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).normalized * 3.5f;
    }

    public void Equip()
    {
        weapHandler.Activate();
    }
}
