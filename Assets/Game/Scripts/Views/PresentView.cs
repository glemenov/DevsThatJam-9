using System.Collections;
using System.Collections.Generic;
using Ami.BroAudio;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Globals.Events;
using UnityEngine;

public class PresentView : MonoBehaviour
{
    public SFXConfig sFXConfig;
    public GlobalEventString unwrapEvent;
    public GameObject wrapped;
    public GameObject unwrapped;

    private void Update()
    {
        if (unwrapEvent.IsPublished)
        {
            BroAudio.Play(sFXConfig.openingPresent);

            var check = unwrapEvent.BatchedChanges.Peek();
            if (check != GetComponent<PresentProvider>().Entity.GetComponent<PresentComponent>().presentData.presentName) return;

            unwrapped.SetActive(true);
            wrapped.SetActive(false);
        }
    }

    public void HidePresent()
    {
        unwrapped.SetActive(false);
        wrapped.SetActive(false);
    }
}
