using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Highscore
{
    public static int GetHighscore()
    {
        return PlayerPrefs.GetInt("highscore", 0);
    }

    public static bool SetNewHighscore(int score)
    {
        int currentHighscore = GetHighscore();
        if (currentHighscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
            return true;
        }

        return false;
    }

}
