using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject howToPlay;
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
}
