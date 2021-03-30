/*****************************************************************************
// File Name :         GameManager.cs
// Author :            Kyle Grenier
// Creation Date :     #CREATIONDATE#
//
// Brief Description : ADD BRIEF DESCRIPTION OF THE FILE HERE
*****************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.OnTryQuitGame += ReturnToMenu;
    }

    private void OnDisable()
    {
        EventManager.OnTryQuitGame -= ReturnToMenu;
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void ReturnToMenu()
    {
        LoadScene("TitleScene");
    }
}
