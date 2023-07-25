using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded;
    
    public GameObject gameOverUI;

    public SceneFader sceneFader;

    public GameObject completedLevelUI;
    void Start()
    {
        gameEnded = false;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (gameEnded)
            return;

        if(PlayerStates.Health <= 0)
        {
            PlayerStates.Health = 0;
            EndGame();
        }       
    }

    void EndGame()
    {
        gameEnded = true;

        gameOverUI.SetActive(true);
        Debug.Log("Game Over");
        
    }

    public void WinLevel()
    {
        gameEnded = true;

        completedLevelUI.SetActive(true);
        
    }
}
