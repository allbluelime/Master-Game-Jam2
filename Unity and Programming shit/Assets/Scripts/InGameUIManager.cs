using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InGameUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject howToPlay;
    [SerializeField]
    private GameObject DeathScreen;
    [SerializeField]
    private GameObject WinScreen;
    private void Awake()
    {
        Time.timeScale = 0.0f;
    }
    public void RemoveHowToPlay()
    {

        howToPlay.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1.0f;
    }
    public void ShowDeadScreen()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        DeathScreen.SetActive(true);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ShowWinScreen()
    {
        Cursor.visible = true;
        Time.timeScale = 0f;
        WinScreen.SetActive(true);
    }
}
