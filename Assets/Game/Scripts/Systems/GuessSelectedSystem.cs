using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh.Globals.Events;
using UnityEngine.UI;
using TMPro;
using Scellecs.Morpeh;
using Unity.VisualScripting;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(GuessSelectedSystem))]
public sealed class GuessSelectedSystem : UpdateSystem
{
    public GlobalEvent defeatEvent;
    public GlobalEventInt buttonSelected;
    private Filter ui;
    private Filter gameData;
    private Filter presents;
    public override void OnAwake()
    {
        presents = this.World.Filter.With<CurrentPresentComponent>().With<PresentComponent>().Build();
        ui = this.World.Filter.With<GameUIComponent>().Build();
        gameData = this.World.Filter.With<GameDataComponent>().Build();
    }

    public override void OnUpdate(float deltaTime)
    {
        if (buttonSelected.IsPublished)
        {
            var result = (int)buttonSelected.BatchedChanges.Peek();
            foreach (var uiEntity in ui)
            {
                ref var uiComponent = ref uiEntity.GetComponent<GameUIComponent>();
                var choice = uiComponent.uIController.selectionTexts[result].text;

                foreach (var present in presents)
                {
                    ref var presentComponent = ref present.GetComponent<PresentComponent>();
                    if (presentComponent.presentData.presentName.Equals(choice))
                    {
                        //* correct
                        uiComponent.uIController.correctText.SetActive(true);
                        uiComponent.uIController.mistakeText.SetActive(false);
                        uiComponent.uIController.description.gameObject.SetActive(true);
                        uiComponent.uIController.description.SetText($"This is {presentComponent.presentData.presentName}");
                        uiComponent.uIController.nextPresentButton.gameObject.SetActive(true);

                    }
                    else
                    {
                        //* mistake
                        uiComponent.uIController.correctText.SetActive(false);
                        uiComponent.uIController.mistakeText.SetActive(true);
                        uiComponent.uIController.description.gameObject.SetActive(true);
                        uiComponent.uIController.description.SetText($"This is {presentComponent.presentData.presentName}");
                        uiComponent.uIController.nextPresentButton.gameObject.SetActive(true);

                        ref var gameDataComponent = ref gameData.FirstOrDefault().GetComponent<GameDataComponent>();
                        gameDataComponent.currentMistakes++;
                        if(gameDataComponent.currentMistakes > gameDataComponent.gameConfig.mistakesAllowed)
                        {
                            defeatEvent.Publish();
                            return;
                        }
                    }

                    present.RemoveComponent<CurrentPresentComponent>();
                    break;
                }
            }
        }
    }
}