using System.Collections;
using System.Collections.Generic;
using Scellecs.Morpeh.Globals.Events;
using UnityEngine;

public class MainMenuEnvironmentController : MonoBehaviour
{
    public GlobalEvent gameStart;
    public GlobalEvent exitToMainMenu;

    private void Update()
    {
        if(gameStart.IsPublished) gameObject.SetActive(false);
        if(exitToMainMenu.IsPublished) gameObject.SetActive(true);
    }
}
