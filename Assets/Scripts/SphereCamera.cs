using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCamera : MonoBehaviour
{
    [SerializeField] private Vector3 sphereCenter;
    [SerializeField] private Transform player;
    [SerializeField] private float cameraSpeed = 10f;

    private void Update()
    {
        transform.LookAt(player.position);
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.z, transform.eulerAngles.z);
        transform.position = Vector3.Lerp(transform.position, player.position + player.up * 80f, Time.deltaTime * cameraSpeed);
    }
}
