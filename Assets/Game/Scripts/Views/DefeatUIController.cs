using System.Collections;
using System.Collections.Generic;
using Scellecs.Morpeh.Globals.Events;
using UnityEngine;

public class DefeatUIController : MonoBehaviour
{
    public GlobalEvent defeatEvent;

    private void Update()
    {
        if(defeatEvent.IsPublished)
        {
            GetComponent<Canvas>().enabled = true;
        }
    }
}
