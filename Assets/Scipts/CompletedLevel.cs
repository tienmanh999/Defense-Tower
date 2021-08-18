using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletedLevel : MonoBehaviour
{
    public string nextLevel = "Level02";
    public int levelToUnclock = 2;
    public Scenefader fader;

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnclock);
        fader.FadeTo(nextLevel);
    }
    public void Menu()
    {
        fader.FadeTo("mainMenu");
    }

}
