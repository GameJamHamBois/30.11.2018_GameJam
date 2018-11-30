using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    private void Start()
    {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        Camera.main.orthographicSize = 1920 / currentAspect / 200;
    }

    public void OnExit()
    {
        Application.Quit();

    }

    public void OnStartGame()
    {
        SceneManager.LoadScene("Character Controller Prototyping");
    }

    public void OnCreditScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}
