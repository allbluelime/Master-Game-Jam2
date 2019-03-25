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
    [SerializeField]
    private GameObject StoryScreen;

    public void RemoveHowToPlay()
    {

        StartCoroutine(RemoveUI(howToPlay));
        Cursor.visible = false;
    }
    public void ShowDeadScreen()
    {
        
        Cursor.visible = true;
        DeathScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void BackToMainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }
    public void RemoveStory()
    {

        StartCoroutine(RemoveUI(StoryScreen));
        howToPlay.SetActive(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void ShowWinScreen()
    {
        Cursor.visible = true;
        Time.timeScale = 0f;
        WinScreen.SetActive(true);
    }

    IEnumerator RemoveUI(GameObject UIScene)
    {
        yield return new WaitForSeconds(0.1f);

        UIScene.SetActive(false);
    }
}
