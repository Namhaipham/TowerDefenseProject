using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] buttons;
    public SceneFader sceneFader;
    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            if( i + 1 < levelReached)
            buttons[i].interactable = false;
        }
    }
    public void Select(string levelName)
    {
      SceneManager.LoadScene(levelName);
    }
}
