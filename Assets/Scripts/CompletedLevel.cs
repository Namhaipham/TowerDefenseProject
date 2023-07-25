using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedLevel : MonoBehaviour
{
    public SceneFader sceneFader;
    public string sceneMainMenu = "MainMenu";
    public string nextLevel;
    public int levelToUnlock;

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(sceneMainMenu);
    }
}
