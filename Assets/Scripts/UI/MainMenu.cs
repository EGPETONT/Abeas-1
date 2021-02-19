using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private LeanButton startGameBtn;
    [SerializeField] private LeanButton closeGameBtn;
    [SerializeField] private LeanButton settingsGameBtn;

    private void Start()
    {
        startGameBtn.OnClick.AddListener(StartGame);
        closeGameBtn.OnClick.AddListener(EndGame);
    }

    private void StartGame() {
        SceneManager.LoadScene(1);
    }

    private void EndGame() {
        Application.Quit();
    }

}
