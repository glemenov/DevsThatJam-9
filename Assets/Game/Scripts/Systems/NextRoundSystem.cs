using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh.Globals.Events;
using Scellecs.Morpeh;
using Ami.BroAudio;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(NextRoundSystem))]
public sealed class NextRoundSystem : UpdateSystem
{
    public SFXConfig sFXConfig;
    public GlobalEvent nextRoundEvent;
    public GlobalEvent roundStartEvent;
    public GlobalEvent victoryEvent;
    public RoundsConfig roundsConfig;
    private Filter roundEntities;
    private Filter ui;
    public override void OnAwake()
    {
        this.roundEntities = this.World.Filter.With<CurrentRoundComponent>().Build();
        this.ui = this.World.Filter.With<GameUIComponent>().Build();
    }

    public override void OnUpdate(float deltaTime)
    {
        if (nextRoundEvent.IsPublished)
        {
            foreach (var round in roundEntities)
            {
                ref var currentRound = ref round.GetComponent<CurrentRoundComponent>();
                currentRound.value++;

                if(currentRound.value == roundsConfig.rounds.Count)
                {
                    victoryEvent.Publish();
                    return;
                }
            }

            foreach (var uiEntity in this.ui)
            {
                ref var uiComponent = ref uiEntity.GetComponent<GameUIComponent>();
                var uIController = uiComponent.uIController;
                uIController.NextRoundUI();
            }

            roundStartEvent.Publish();
            BroAudio.Play(sFXConfig.nextGift);
        }
    }
}