using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFormController : MonoBehaviour
{
    [SerializeField] private GameObject[] forms;

    private int currentState = 0;
    public void NextState() {
        DeactiveAll();
        currentState++;
        if (currentState >= forms.Length) {
            currentState = 0;
        }
        ActivateState(currentState);
    }

    private void ActivateState(int state) {
        forms[state].SetActive(true);
    }

    private void DeactiveAll() {
        foreach (var go in forms) {
            go.SetActive(false);
        }
    }
}
