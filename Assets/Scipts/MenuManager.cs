using UnityEngine;

public class MenuManager : MonoBehaviour
{   
    public Scenefader scenefader;
    public void NewGame()
    {
        scenefader.FadeTo("selectLevel");
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();

    }
}
