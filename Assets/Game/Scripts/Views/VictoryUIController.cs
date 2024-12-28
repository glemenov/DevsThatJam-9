using System.Collections;
using System.Collections.Generic;
using Scellecs.Morpeh.Globals.Events;
using UnityEngine;

public class VictoryUIController : MonoBehaviour
{
    public GlobalEvent victoryEvent;

    private void Update()
    {
        if(victoryEvent.IsPublished)
        {
            GetComponent<Canvas>().enabled = true;
        }
    }
}
