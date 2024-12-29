using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(InteractableHoverSystem))]
public sealed class InteractableHoverSystem : UpdateSystem
{
    public Filter interactables;
    public override void OnAwake()
    {
        interactables = this.World.Filter.With<InteractableComponent>().Build();
    }

    public override void OnUpdate(float deltaTime)
    {
        foreach (var interactable in interactables)
        {
            var interactableComponent = interactable.GetComponent<InteractableComponent>();
            var hoverText = interactableComponent.hoverText;

            if (interactable.Has<InteractableHoveredComponent>())
            {
                var displayText = interactableComponent.displayText;
                hoverText.SetText(displayText);
                hoverText.gameObject.SetActive(true);
                if(interactableComponent.light != null) interactableComponent.light.enabled = true;
                // interactable.GetComponent<InteractableComponent>().hoverText.transform.LookAt(Camera.main.transform);
            }
            else
            {
                hoverText.gameObject.SetActive(false);
                if(interactableComponent.light != null) interactableComponent.light.enabled = false;
            }
        }
    }
}