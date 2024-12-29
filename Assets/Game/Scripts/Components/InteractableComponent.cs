using Scellecs.Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using TMPro;
using Scellecs.Morpeh.Globals.Events;

[System.Serializable]
[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
public struct InteractableComponent : IComponent {
    public Light light;
    public TMP_Text hoverText;
    public string displayText;
    public GlobalEvent triggerEvent;
}