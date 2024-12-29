using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh.Globals.Events;
using Scellecs.Morpeh;
using System.Collections.Generic;
using TMPro;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(RoundStartSystem))]
public sealed class RoundStartSystem : UpdateSystem
{
    public GlobalEvent roundStartEvent;
    public RoundsConfig roundsConfig;
    private Filter ui;
    private Filter filter;
    private Filter presents;
    public override void OnAwake()
    {
        this.filter = this.World.Filter.With<CurrentRoundComponent>().Build();
        this.ui = this.World.Filter.With<GameUIComponent>().Build();
        presents = this.World.Filter.With<PresentComponent>().Build();
    }

    public override void OnUpdate(float deltaTime)
    {
        if (roundStartEvent.IsPublished)
        {
            foreach (var entity in this.filter)
            {
                ref var currentRound = ref entity.GetComponent<CurrentRoundComponent>();

                foreach (var uiEntity in this.ui)
                {
                    ref var uiComponent = ref uiEntity.GetComponent<GameUIComponent>();

                    uiComponent.uIController.roundCounter.SetText($"{currentRound.value + 1}/{roundsConfig.rounds.Count}");

                    List<TMP_Text> buttonsLeft = new List<TMP_Text>(uiComponent.uIController.selectionTexts);
                    var correctAnswer = buttonsLeft.GetRandom();
                    var randomPresent = roundsConfig.rounds[currentRound.value].possiblePresents.GetRandom();

                    correctAnswer.SetText(randomPresent.presentName);
                    buttonsLeft.Remove(correctAnswer);

                    foreach (var present in presents)
                    {
                        ref var presentComponent = ref present.GetComponent<PresentComponent>();
                        presentComponent.presentView.HidePresent();

                        if (presentComponent.presentData.presentName == randomPresent.presentName)
                        {
                            present.AddComponent<CurrentPresentComponent>();
                            presentComponent.presentView.wrapped.SetActive(true);
                        }
                    }

                    foreach (var option in randomPresent.guessingOptions)
                    {
                        var selectedButton = buttonsLeft.GetRandom();
                        selectedButton.SetText(option);
                        buttonsLeft.Remove(selectedButton);
                    }
                }
            }
        }
    }
}