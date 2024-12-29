using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig", order = 0)]
public class GameConfig : ScriptableObject
{
    public int mistakesAllowed;
}