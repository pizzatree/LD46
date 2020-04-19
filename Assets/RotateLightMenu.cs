using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLightMenu : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0.05f * Time.deltaTime, 0, 0);
    }
}
