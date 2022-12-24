using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] private GameObject MenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ReturnGame();
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        MenuUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReturnGame()
    {
        isPaused = false;
        MenuUI.SetActive(false);
        Time.timeScale = 1;
    }
}
