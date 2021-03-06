﻿using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scenario")]
public class Scenario : ScriptableObject
{
    public string Title = "Scene Title";
    [TextArea]
    public string ScenarioText = "Lorem ipsum dorem, what are you gonna do?";

    public string Choice1 = "Wingardium leviosa";
    public float C1SuccessWeight = 70f;
    [TextArea]
    public string C1SuccessText = "Rooonnn staaahhhppp";
    [TextArea]
    public string C1FailureText = "Oh no.";
    public string[] C1SuccessRewards;
    public string[] C1FailureRewards;

    public string Choice2 = "Achio BUM";
    public float C2SuccessWeight = 30f;
    [TextArea]
    public string C2SuccessText = "Rooonnn staaahhhppp";
    [TextArea]
    public string C2FailureText = "Oh no.";
    public string[] C2SuccessRewards;
    public string[] C2FailureRewards;
}