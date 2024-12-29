using System.Collections;
using System.Collections.Generic;
using Ami.BroAudio;
using Scellecs.Morpeh.Globals.Events;
using UnityEngine;

public class VictoryUIController : MonoBehaviour
{
    public SoundID victoryMusic;
    public GlobalEvent victoryEvent;

    private void Update()
    {
        if(victoryEvent.IsPublished)
        {
            GetComponent<Canvas>().enabled = true;
            BroAudio.Play(victoryMusic).AsBGM();
        }
    }
}
