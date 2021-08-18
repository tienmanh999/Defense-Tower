using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject UI;
    public Scenefader scenefader;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }
    public void Toggle()
    {
        if (Gamemanager.GameisOver)
            return;
        UI.SetActive(!UI.activeSelf);
        if (UI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void Retry()
    {
        Toggle();
        scenefader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        Toggle();
        scenefader.FadeTo("mainMenu");
    }
}
