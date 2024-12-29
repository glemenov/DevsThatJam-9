using System.Collections;
using System.Collections.Generic;
using Ami.BroAudio;
using Scellecs.Morpeh.Globals.Events;
using UnityEngine;

public class MainMenuEnvironmentController : MonoBehaviour
{
    public SoundID mainMenuMusic;
    public GlobalEvent gameStart;
    public GlobalEvent exitToMainMenu;
    public Camera mainCamera;
    public GameObject visuals;
    public GameObject lights;

    private void Start()
    {
        BroAudio.Play(mainMenuMusic).AsBGM();
    }
    private void Update()
    {
        if (gameStart.IsPublished)
        {
            mainCamera.enabled = false;
            visuals.SetActive(false);
            lights.SetActive(false);
            BroAudio.Pause(mainMenuMusic, 1f);
        }
        if (exitToMainMenu.IsPublished)
        {
            mainCamera.enabled = true;
            visuals.SetActive(true);
            lights.SetActive(true);
            BroAudio.Stop(BroAudioType.Music);
            BroAudio.Stop(BroAudioType.Ambience);
            BroAudio.Stop(BroAudioType.SFX);

            BroAudio.UnPause(mainMenuMusic);
        }
    }
}
