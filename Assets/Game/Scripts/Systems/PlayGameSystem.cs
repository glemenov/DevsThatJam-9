using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Globals.Events;
using UnityEngine.SceneManagement;
using Ami.BroAudio;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlayGameSystem))]
public sealed class PlayGameSystem : UpdateSystem
{
    public SoundID gameplayMusic;
    private Filter filter;
    public GlobalEvent startEvent;
    public GlobalEvent roundStartEvent;

    public override void OnAwake()
    {
        this.filter = this.World.Filter.With<PlayGameComponent>().Build();
    }

    public override void OnUpdate(float deltaTime)
    {
        if (startEvent.IsPublished) {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive).completed += ev => {
                roundStartEvent.Publish();
                BroAudio.Play(gameplayMusic).AsBGM();
                };
        }
    }
}