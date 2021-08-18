using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static bool GameisOver;
    public GameObject GameOverUI;
    public GameObject completedLevelUI;

    void Start()
    {
        GameisOver = false;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (GameisOver)
            return;
        if(PlayerStart.Lives <= 0)
        {
            Endgame();
        }
    }
    void Endgame()
    {
        GameisOver = true;
        GameOverUI.SetActive(true);
    }
    public void Winlevel()
    {
        GameisOver = true;
        completedLevelUI.SetActive(true);
    }
}
