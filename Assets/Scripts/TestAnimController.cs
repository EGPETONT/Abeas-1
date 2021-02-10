using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimController : MonoBehaviour
{
    [SerializeField] private Animation[] anim;
    [SerializeField] private Vector3 currectPosition;
    [SerializeField] private Transform lastAnimatedObject;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            anim[0].Play();
            lastAnimatedObject = anim[0].transform;

        } else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log(anim[1].transform.position + " " + lastAnimatedObject.position);
            anim[1].transform.root.position += lastAnimatedObject.position;
            anim[1].Play();
        }
        else if(Input.GetKeyDown(KeyCode.D)) {
            anim[2].Play();
        }
    }

    private void SetCurrentPosition(Transform targetPos) { 
        
    }
}
