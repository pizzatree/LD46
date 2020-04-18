using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScenarioManager : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI  title,
                    text,
                    buttonText1,
                    buttonText2;

    [SerializeField]
    private Scenario[] ScenarioList;

    private void OnEnable()
    {
        var thisScenario = ScenarioList[Random.Range(0, ScenarioList.Length)];

        title.text = thisScenario.Title;
        text.text = thisScenario.ScenarioText;
        buttonText1.text = thisScenario.Choice1;
        buttonText2.text = thisScenario.Choice2;
    }
}

[CreateAssetMenu(fileName = "New Scenario")]
public class Scenario : ScriptableObject
{
    public string Title = "Scene Title";
    [TextArea]
    public string ScenarioText = "Lorem ipsum dorem, what are you gonna do?";

    public string Choice1 = "Wingardium leviosa";
    public float C1SuccessWeight = 70f;
    public string C1SuccessText = "Rooonnn staaahhhppp";
    public string C1FailureText = "Oh no.";
    public int C1RewardID = 0;

    public string Choice2 = "Achio BUM";
    public float Choice2SuccessWeight = 30f;
    public string C2SuccessText = "Rooonnn staaahhhppp";
    public string C2FailureText = "Oh no.";
    public int C2RewardID = 0;
}
