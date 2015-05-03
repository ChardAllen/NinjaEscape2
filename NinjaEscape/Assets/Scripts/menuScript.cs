using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class menuScript : MonoBehaviour 
{
    [HideInInspector]
    public static int level = 1;

    public void Awake()
    {


    }
    

	public void StartGame()
    {
        Application.LoadLevel("Level1");        
    }

    public void Settings()
    {
        Application.LoadLevel("Options");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        Application.LoadLevel(level);
    }

    public void MainMenu()
    {
        Application.LoadLevel("Menu");
    }


}
