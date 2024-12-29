using Ami.BroAudio;
using UnityEngine;

[CreateAssetMenu(fileName = "SFXConfig", menuName = "Configs/SFXConfig", order = 0)]
public class SFXConfig : ScriptableObject
{
    public SoundID correctGuess;
    public SoundID wrongGuess;
    public SoundID openingPresent;
    public SoundID nextGift;
}