using System.Collections;
using System.Collections.Generic;
using Ami.BroAudio;
using Scellecs.Morpeh.Globals.Events;
using UnityEngine;

public class DefeatUIController : MonoBehaviour
{
    public SoundID defeatMusic;
    public GlobalEvent defeatEvent;

    private void Update()
    {
        if(defeatEvent.IsPublished)
        {
            GetComponent<Canvas>().enabled = true;
            BroAudio.Play(defeatMusic).AsBGM();
        }
    }
}
