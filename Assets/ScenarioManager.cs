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

    private void DoChoice(int choiceNum)
    {
        firstScreen.SetActive(false);
        secondScreen.SetActive(true);

        var roll = Random.value * 100f;
        bool success = false;

        Debug.Log("roll: " + roll);

        if (choiceNum == 1)
        {

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
    public void Exit() => GameStateManager.Instance.ResumeShooty();
}

[CreateAssetMenu(fileName = "New Scenario")]
public class Scenario : ScriptableObject
{
    public string Title = "Scene Title";
    [TextArea]
    public string ScenarioText = "Lorem ipsum dorem, what are you gonna do?";
    public int RewardID = 0;

    public string Choice1 = "Wingardium leviosa";
    public float C1SuccessWeight = 70f;
    public string C1SuccessText = "Rooonnn staaahhhppp";
    public string C1FailureText = "Oh no.";

    public string Choice2 = "Achio BUM";
    public float C2SuccessWeight = 30f;
    public string C2SuccessText = "Rooonnn staaahhhppp";
    public string C2FailureText = "Oh no.";
}
