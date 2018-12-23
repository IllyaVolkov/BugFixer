using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        text.text = "Score: " + ScoreManager.score;
        HighscoreManager.Set(ScoreManager.score);
        ErrorManager.errorsCount = 0;
        ScoreManager.score = 0;
    }
}
