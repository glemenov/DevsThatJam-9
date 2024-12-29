using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh.Globals.Events;
using Scellecs.Morpeh.Providers;
using Scellecs.Morpeh.Collections;
using Scellecs.Morpeh;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlayerInputSystem))]
public sealed class PlayerInputSystem : UpdateSystem
{
    RaycastHit hit;
    float rayLength = 500f;
    Ray ray;
    public GlobalEvent exitToMainMenu;

    public override void OnAwake()
    {
    }

    public override void OnUpdate(float deltaTime)
    {
        if (Input.GetKeyDown(KeyCode.Escape)) exitToMainMenu.Publish();

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // debug Ray
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (EntityProvider.map.TryGetValue(hit.collider.gameObject.GetInstanceID(), out var item))
                {
                    if (item.entity.Has<InteractableComponent>())
                        item.entity.GetComponent<InteractableComponent>().triggerEvent.Publish();
                }
            }
        }
    }
}