using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class LoadManager : MonoBehaviour
{
    [SerializeField] private int scene;
    [SerializeField] private GameObject LvlUI;
    [SerializeField] private GameObject MainUI;
    public enum Scene
    {
        GameScene,
    }
    public void Load()
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }

    public static void Reload(){
        
    SceneManager.LoadScene(0);

}

    public void Quit()
    {
        Application.Quit();
    }

    public void ShowLevels()
    {
        LvlUI.SetActive(true);
        MainUI.SetActive(false);
    }

    public void BackToMenu()
    {
        LvlUI.SetActive(false);
        MainUI.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
