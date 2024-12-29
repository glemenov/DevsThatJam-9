using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh.Globals.Events;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ApplicationQuitSystem))]
public sealed class ApplicationQuitSystem : UpdateSystem {
    public GlobalEvent quitEvent;
    public override void OnAwake() {
    }

    public override void OnUpdate(float deltaTime) {
        if(quitEvent.IsPublished)
        {
            Application.Quit();
        }
    }
}