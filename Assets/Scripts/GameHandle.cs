using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandle : MonoBehaviour
{
    private static GameHandle instance;
    [SerializeField] private Text Highscore;
    private static int score;
    private void Awake()
    {
        instance = this;
        score = 0;
        Highscore.text = "Highscore " + PlayerPrefs.GetInt("highscore",0);
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game starts");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int GetScore()
    {
        return score;
    }

    public static void AddScore()
    {
        score += 1;
    }
}
