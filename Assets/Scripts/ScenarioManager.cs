using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScenarioManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI title,
                    text,
                    buttonText1,
                    buttonText2,
                    successText,
                    successDetails;

    [SerializeField]
    private Scenario[] ScenarioList;

    [SerializeField]
    private GameObject firstScreen,
                       secondScreen;

    private Scenario activeScenario;
    private Inventory inventory => FindObjectOfType<Inventory>();

    [SerializeField]
    private GameObject baseWallsHolder, // if scenario calls for repairs
                       baseWallsPrefab;

    private void OnEnable()
    {
        firstScreen.SetActive(true);
        secondScreen.SetActive(false);

        activeScenario = ScenarioList[Random.Range(0, ScenarioList.Length)];

        title.text = activeScenario.Title;
        text.text = activeScenario.ScenarioText;
        buttonText1.text = activeScenario.Choice1;
        buttonText2.text = activeScenario.Choice2;
    }

    private void RewardHandler(int rewardID, bool success)
    {
        inventory.RemoveTP(1);

        switch (rewardID)
        {
            case -1:
                if (success)
                {
                    RepairBaseWalls();
                    inventory.Add(InventoryPickups.SentryBot);
                }
                else
                    GameOver.Instance.HandleGameOver();
                break;
            case 1:
                if (success)
                    inventory.Add(InventoryPickups.Walls);
                break;

            default:
                break;
        }
    }

    private void RepairBaseWalls()
    {
        var newWalls = Instantiate(baseWallsPrefab, baseWallsHolder.transform.position, Quaternion.identity);
        Destroy(baseWallsHolder);
        baseWallsHolder = newWalls;
    }

    bool success = false;
    int rewardID = 0;
    private void DoChoice(int choiceNum)
    {
        firstScreen.SetActive(false);
        secondScreen.SetActive(true);

        var roll = Random.Range(0f, 100f);

        Debug.Log("roll: " + roll);

        if (choiceNum == 1)
        {
            rewardID = activeScenario.RewardID;
            if (roll <= activeScenario.C1SuccessWeight)
            {
                success = true;
                successDetails.text = activeScenario.C1SuccessText;
            }

            else
            {
                success = false;
                successDetails.text = activeScenario.C1FailureText;
            }
        }

        else if (choiceNum == 2)
        {
            rewardID = -1 * activeScenario.RewardID;
            if (roll <= activeScenario.C2SuccessWeight)
            {
                success = true;
                successDetails.text = activeScenario.C2SuccessText;
            }

            else
            {
                success = false;
                successDetails.text = activeScenario.C2FailureText;
            }
        }

        successText.text = (success) ? "Success" : "Failure";
    }

    public void Choice1() => DoChoice(1);
    public void Choice2() => DoChoice(2);
    public void Exit()
    {
        GameStateManager.Instance.ResumeShooty();
        RewardHandler(rewardID, success);
    }
}