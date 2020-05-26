using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public string playGameLevel;


    public void PlayGame()
    {
        Application.LoadLevel(playGameLevel);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}



