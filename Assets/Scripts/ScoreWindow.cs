using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    // Start is called before the first frame update
    private Text score; 
    private void Awake()
    {
        score = transform.Find("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score " + GameHandle.GetScore().ToString();
    }
}
