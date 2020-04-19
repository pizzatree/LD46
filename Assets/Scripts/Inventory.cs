using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    private int numTP = 3;
    private int numWalls = 0;
    private int numSentries = 0;

    [SerializeField]
    private TextMeshProUGUI tpText;

    public void Add(InventoryPickups pickup)
    {
        switch (pickup)
        {
            case InventoryPickups.TP:
                ++numTP;
                break;
            case InventoryPickups.Walls:
                numWalls += 3;
                break;
            case InventoryPickups.SentryBot:
                ++numSentries;
                break;
            default:
                break;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        tpText.text = numTP.ToString();
    }
}

public enum InventoryPickups
{
    TP,
    Walls,
    SentryBot // maybe
}