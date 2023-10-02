using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Singleton part
    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            instance.ReadHighScore();
        }            
    }

    // GameManager part

    public int score { get; private set; } = 0;
    public int lives { get; private set; } = 3;
    public int highscore { get; private set; } = 0;
    public string playerName { get; private set; }
    public string highscoreName { get; private set; }


    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public void AddScore()
    {
        score++;
    }

    public void KillPlayer()
    {
        lives--;
    }

    public void NewGame()
    {
        score = 0;
        lives = 3;
    }

    private void ReadHighScore()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreName = PlayerPrefs.GetString("highscorename", "");
    }

    public void UpdateHighScore()
    {
        if (score > highscore)
        {
            highscoreName = playerName;
            highscore = score;
            PlayerPrefs.SetString("highscorename", highscoreName);
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }
}
