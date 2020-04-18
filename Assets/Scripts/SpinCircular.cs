using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCircular : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}
