using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuManager : MonoBehaviour
{
    
    public GameObject inputField;
    public GameObject textDisplay;
    public GameObject highscoreDisplay;

    private TextMeshProUGUI welcomeText;
    private TextMeshProUGUI highscoreText;
    // Start is called before the first frame update
    void Start()
    {
        welcomeText = textDisplay.GetComponent<TextMeshProUGUI>();
        highscoreText = highscoreDisplay.GetComponent<TextMeshProUGUI>();
        //name = playerName.gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        highscoreText.text = "Highscore: " + DataManager.Instance.HSPlayerName + ": " + DataManager.Instance.highScore;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        //le dice al compilador que haga una cosa en el editor y otra cuando este compilado, sino no te deja cerrar la aplicacion en el editor. Necesita usar UnityEditor.
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();//cierra el editor
    #else
        Application.Quit();
    #endif
    }

    public void SaveText(string input)
    {
        welcomeText.text = "Welcome, " + input;
        DataManager.Instance.playerName = input;
    }
}
