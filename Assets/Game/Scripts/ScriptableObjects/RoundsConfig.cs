using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoundsConfig", menuName = "Configs/RoundsConfig", order = 0)]
public class RoundsConfig : ScriptableObject
{
    public List<Round> rounds = new List<Round>();
}