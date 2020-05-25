using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public GameManager gameManager;
    public void StartPressed()
    {
        gameManager.PlayGame();
    }

    public void ExitPressed()
    {
        gameManager.Quit();
    }
}
