using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour
{
    public static int highScore = 0;
    Text text;


    void Awake()
    {
        text = GetComponent<Text>();
    }

    void Start()
    {
        int width = 1600;
        int height = 2560;
        bool isFullScreen = false;
        int desiredFPS = 60;

        Screen.SetResolution(width, height, isFullScreen, desiredFPS);
    }


    void Update()
    {
        text.text = "Highscore: " + highScore;
    }


    public static void Set(int score)
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }
}
