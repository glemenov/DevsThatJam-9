using System.Collections;
using System.Collections.Generic;
using Scellecs.Morpeh.Globals.Events;
using UnityEngine;

public class MainMenuUIController : MonoBehaviour
{
    public GlobalEvent exitEvent;

    private void Update()
    {
        if(exitEvent.IsPublished)
        {
            GetComponent<Canvas>().enabled = true;
        }
    }
}
