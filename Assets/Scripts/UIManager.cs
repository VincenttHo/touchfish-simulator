using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject gameOverUI;
    public static UIManager instance;

    void Start()
    {
        instance = this;
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
