using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private Vector3 rotateVector;

    private void Update()
    {
        transform.Rotate(rotateVector * Time.deltaTime);
    }
}
