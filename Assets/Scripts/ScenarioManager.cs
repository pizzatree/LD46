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

    private void RewardHandler()
    {
        inventory.RemoveTP(1);

        if (rewardingActions == null)
            return;

        foreach (var action in rewardingActions)
            Invoke(action, 0);
    }

    private void FillHealth() => Debug.Log("add health refilling");
    private void AddSentry() => inventory.Add(InventoryPickups.SentryBot);
    private void DoGameOver() => GameOver.Instance.HandleGameOver();
    private void AddWalls() => inventory.Add(InventoryPickups.Walls);

    private void RepairBaseWalls()
    {
        var newWalls = Instantiate(baseWallsPrefab, baseWallsHolder.transform.position, Quaternion.identity);
        Destroy(baseWallsHolder);
        baseWallsHolder = newWalls;
    }

    bool success = false;
    string[] rewardingActions = null;
    private void DoChoice(int choiceNum)
    {
        firstScreen.SetActive(false);
        secondScreen.SetActive(true);

        var roll = Random.Range(0f, 100f);

        Debug.Log("roll: " + roll);

        if (choiceNum == 1)
        {
            if (roll <= activeScenario.C1SuccessWeight)
            {
                success = true;
                successDetails.text = activeScenario.C1SuccessText;
                rewardingActions = activeScenario.C1SuccessRewards;
            }

            else
            {
                success = false;
                successDetails.text = activeScenario.C1FailureText;
                rewardingActions = activeScenario.C1FailureRewards;
            }
        }

        else if (choiceNum == 2)
        {
            if (roll <= activeScenario.C2SuccessWeight)
            {
                success = true;
                successDetails.text = activeScenario.C2SuccessText;
                rewardingActions = activeScenario.C2SuccessRewards;
            }

            else
            {
                success = false;
                successDetails.text = activeScenario.C2FailureText;
                rewardingActions = activeScenario.C2FailureRewards;
            }
        }

        successText.text = (success) ? "Success" : "Failure";
    }

    public void Choice1() => DoChoice(1);
    public void Choice2() => DoChoice(2);
    public void Exit()
    {
        GameStateManager.Instance.ResumeShooty();
        RewardHandler();
    }
}