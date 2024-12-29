using System.Collections;
using System.Collections.Generic;
using Scellecs.Morpeh.Globals.Events;
using UnityEngine;

public class MainMenuEnvironmentController : MonoBehaviour
{
    public GlobalEvent gameStart;
    public GlobalEvent exitToMainMenu;
    public Camera mainCamera;

    private void Update()
    {
        if(gameStart.IsPublished) 
        {
            mainCamera.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        if(exitToMainMenu.IsPublished) 
        {
            mainCamera.gameObject.SetActive(true);
            gameObject.SetActive(true);
        }
    }
}
