using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh.Globals.Events;
using UnityEngine.SceneManagement;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ExitToMainMenuSystem))]
public sealed class ExitToMainMenuSystem : UpdateSystem {
    public GlobalEvent exitEvent;
    public override void OnAwake() {
    }

    public override void OnUpdate(float deltaTime) {
        if(exitEvent.IsPublished)
        {
            SceneManager.UnloadSceneAsync(1).completed += ev => {};

        }
    }
}