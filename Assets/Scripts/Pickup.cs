using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private PickupType pickupType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (pickupType)
            {
                case PickupType.Toiletpaper:
                    break;
                case PickupType.Money:
                    break;
                case PickupType.Ammo:
                    collision.GetComponent<PlayerWeapon>().PickupAmmo();
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}

public enum PickupType
{
    Toiletpaper,
    Money,
    Ammo
}