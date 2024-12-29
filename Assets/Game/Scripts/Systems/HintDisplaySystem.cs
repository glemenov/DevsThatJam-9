using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Globals.Events;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(HintDisplaySystem))]
public sealed class HintDisplaySystem : UpdateSystem
{
    public GlobalEvent hintShow;
    private Filter presents;
    private Filter ui;

    public override void OnAwake()
    {
        presents = this.World.Filter.With<CurrentPresentComponent>().With<PresentComponent>().Build();
        ui = this.World.Filter.With<GameUIComponent>().Build();
    }

    public override void OnUpdate(float deltaTime)
    {
        if (hintShow.IsPublished)
        {
            ref var uiComponent = ref ui.FirstOrDefault().GetComponent<GameUIComponent>();
            ref var presentComponent = ref presents.FirstOrDefault().GetComponent<PresentComponent>();

            if (!uiComponent.uIController.hintText.gameObject.activeSelf)
            {
                uiComponent.uIController.hintText.gameObject.SetActive(true);
                uiComponent.uIController.hintText.SetText(presentComponent.presentData.hint);
            }
            else
            {
                uiComponent.uIController.hintText.gameObject.SetActive(false);
            }
        }
    }
}