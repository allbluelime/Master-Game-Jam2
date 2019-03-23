using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
