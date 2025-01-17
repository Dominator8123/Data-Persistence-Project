using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public InputField InputField;

    private MainUIHandler mainUIHandler;

    private void Start()
    {
    }

    public void StartNew()
    {
        mainUIHandler.setName(GameManager.Instance.playerName);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        GameManager.Instance.SaveHighScore();

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void OnNameEntered()
    {
        GameManager.Instance.playerName = InputField.text;
    }
}
