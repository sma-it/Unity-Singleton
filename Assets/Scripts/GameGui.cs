using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGui : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI nameText;

    public void Start()
    {
        // reset game
        GameManager.instance.NewGame();

        // set all text when the scene starts
        nameText.text = $"Name: {GameManager.instance.playerName}";
        scoreText.text = $"Score: {GameManager.instance.score}";
        lifeText.text = $"Lives: {GameManager.instance.lives}";
    }

    public void OnPointClick()
    {
        // add a point
        GameManager.instance.AddScore();
        
        // update screen text
        scoreText.text = $"Score: {GameManager.instance.score}";
    }

    public void OnKillClick()
    {
        // substract one life
        GameManager.instance.KillPlayer();

        if (GameManager.instance.lives == 0)
        {
            // there might be a new highscore, check it
            GameManager.instance.UpdateHighScore();

            // go to the score scene
            SceneManager.LoadScene("ScoreScene");
        } else
        {
            // update screen text
            lifeText.text = $"Lives: {GameManager.instance.lives}";
        }
    }
}
