using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int numTP = 3;
    public int numWalls = 0;
    public int numSentries = 0;

    [SerializeField]
    private TextMeshProUGUI tpText;
    [SerializeField]
    private TextMeshProUGUI wallText;

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

    public void RemoveTP(int amt)
    {
        numTP -= amt;
        UpdateUI();
    }

    private void UpdateUI()
    {
        tpText.text = numTP.ToString();
        wallText.text = numWalls.ToString();
    }
}

public enum InventoryPickups
{
    TP,
    Walls,
    SentryBot // maybe
}