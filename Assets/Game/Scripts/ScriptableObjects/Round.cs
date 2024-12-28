using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Round", menuName = "Round", order = 0)]
public class Round : ScriptableObject
{
    public List<Present> possiblePresents = new List<Present>();
}