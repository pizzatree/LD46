using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private PickupType pickupType;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // add to inventory
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