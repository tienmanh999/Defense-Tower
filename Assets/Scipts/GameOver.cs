using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{ 
    
    public Scenefader scenefader;
    
    public void Retry()
    {
        scenefader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        scenefader.FadeTo("mainMenu");
    }
   
}
