using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Scenefader fader;
    public Button[] levelButon;
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < levelButon.Length; i++)
        {
            if(i + 1 > levelReached)
                levelButon[i].interactable = false;
        }    
    }
    public void Select(string loadLevel)
    {
        fader.FadeTo(loadLevel);
    }
}
