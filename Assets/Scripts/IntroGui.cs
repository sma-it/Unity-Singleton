using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroGui : MonoBehaviour
{
    public GameObject nameField;

    public void OnStartGame()
    {
        // get the name from the input field
        string name = nameField.GetComponent<TMP_InputField>().text.Trim();

        // save it in the game manager
        GameManager.instance.SetPlayerName(name.Trim());

        // load the next scene
        SceneManager.LoadScene("GameScene");
    }
}
