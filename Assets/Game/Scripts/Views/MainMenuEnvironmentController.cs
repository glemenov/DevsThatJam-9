using System.Collections;
using System.Collections.Generic;
using Scellecs.Morpeh.Globals.Events;
using UnityEngine;

public class MainMenuEnvironmentController : MonoBehaviour
{
    public GlobalEvent gameStart;
    public GlobalEvent exitToMainMenu;
    public Camera mainCamera;
    public GameObject visuals;
    public GameObject lights;

    private void Update()
    {
        if(gameStart.IsPublished) 
        {
            mainCamera.enabled = false;
            visuals.SetActive(false);
            lights.SetActive(false);
        }
        if(exitToMainMenu.IsPublished) 
        {
            mainCamera.enabled = true;
            visuals.SetActive(true);
            lights.SetActive(true);
        }
    }
}
