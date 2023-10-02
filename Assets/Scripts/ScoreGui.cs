using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreGui : MonoBehaviour
{
    public TextMeshProUGUI highscore;
    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        // set screen text with values from game manager
        if (highscore != null)
        {
            highscore.text = $"HighScore: {GameManager.instance.highscore} by {GameManager.instance.highscoreName}";
        }

        if (score != null)
        {
            score.text = $"{GameManager.instance.playerName}'s Score: {GameManager.instance.score}";
        }
    }

    public void OnPlayAgain()
    {
        SceneManager.LoadScene("GameScene");
    }
}
