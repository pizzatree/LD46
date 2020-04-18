using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletGuyHealth : Health
{
    protected override void Die()
    {
        Debug.Log("Game over");
    }
}
