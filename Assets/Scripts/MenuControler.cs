using UnityEngine;
using System.Collections;

public class MenuControler : MonoBehaviour {
    void Start()
    {
        Time.timeScale = 0;
        Time.timeScale = 1;
    }

    
    public void LoadaAsteroidLevel()
    {
        Application.LoadLevel(1);
    }
    public void LoadaMoonLevel()
    {
        Application.LoadLevel(2);
    }
    public void LoadaCredits()
    {
        Application.LoadLevel(3);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
