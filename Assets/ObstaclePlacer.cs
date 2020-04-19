using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePlacer : MonoBehaviour
{
    Inventory inventory;

    [SerializeField]
    private GameObject sentry,
                       wall;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
            PlaceObject();
    }

    private void GetPlacementProperties(out Vector2 location, out Quaternion rotation)
    {
        location = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var angle = Mathf.Atan2(location.y - transform.position.y, location.x - transform.position.x) * Mathf.Rad2Deg;
        rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    private void PlaceObject()
    {
        Vector2 placement;
        Quaternion rotation;
        GetPlacementProperties(out placement, out rotation);
        Debug.Log("#s" + inventory.numSentries + " #w" + inventory.numWalls);
        if (inventory.numSentries > 0)
        {
            Debug.Log("here");
            Instantiate(sentry, placement, rotation);
            inventory.RemoveSentry();
        }
        else if (inventory.numWalls > 0)
        {
            Debug.Log("!!here");
            Instantiate(wall, placement, rotation);
            inventory.RemoveWall();
        }
    }
}
