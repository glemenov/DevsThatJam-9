using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Present", menuName = "Present", order = 0)]
public class Present : ScriptableObject
{
    public string presentName;
    public string hint;
    public List<string> guessingOptions = new List<string>();
}