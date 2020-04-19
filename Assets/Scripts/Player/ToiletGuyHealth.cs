using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToiletGuyHealth : Health
{
    protected override void Die()
    {
        GameOver.Instance.HandleGameOver();
    }
}
